using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;

namespace dart_watcher
{
    public class DartWatcher
    {
        private readonly string apiKey;
        private BackgroundWorker dartWacherWorker;
        private long lastReportId = 0;
        private object lockObj = new object();
        private IEnumerable<string> keywords = Enumerable.Empty<string>();

        public DartWatcher(string apiKey)
        {
            this.apiKey = apiKey;

            dartWacherWorker = new BackgroundWorker();
            dartWacherWorker.WorkerSupportsCancellation = true;
            dartWacherWorker.DoWork += OnDartWatching;
        }

        public void SetKeywords(IEnumerable<string> keywords)
        {
            lock (lockObj)
            {
                this.keywords = keywords;
            }
        }

        public void Run()
        {
            dartWacherWorker.RunWorkerAsync();
        }

        public void Stop()
        {
            dartWacherWorker.CancelAsync();
        }

        private void OnDartWatching(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (dartWacherWorker.CancellationPending)
                    return;

                var root = XDocument.Parse(RequestReports()).Root;
                var latestReports = root.Elements("list").Select(x => new
                {
                    name = x.Element("corp_name").Value,
                    title = x.Element("report_nm").Value,
                    reportId = long.Parse(x.Element("rcept_no").Value),
                    type = x.Element("rm").Value,
                })
                .OrderBy(x => x.reportId)
                .Where(item => item.type == "유" || item.type == "코");

                lock (lockObj)
                {
                    foreach (var report in latestReports)
                    {
                        if (lastReportId >= report.reportId)
                            continue;

                        if (IsWatchingStock(report.title))
                        {
                            ReportFound?.Invoke(new WatchedReport()
                            {
                                Name = report.name,
                                Title = report.title,
                                Url = $"https://dart.fss.or.kr/dsaf001/main.do?rcpNo={report.reportId}"
                            });
                        }

                        lastReportId = report.reportId;
                    }
                }

                Thread.Sleep(15000);
            }
        }

        private string RequestReports()
        {
            HttpRequestMessage message = new HttpRequestMessage(
                HttpMethod.Get,
                new Uri($"https://opendart.fss.or.kr/api/list.xml?crtfc_key={apiKey}&sort_mth=desc&page_no=1&page_count=20"));
            message.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            HttpClient client = new HttpClient();

            var response = client.Send(message);
            using (var reader = new StreamReader(response.Content.ReadAsStream()))
            {
                return reader.ReadToEnd();
            };
        }

        private bool IsWatchingStock(string title)
        {
            return keywords.Where(keyword => title.Contains(keyword)).Any();
        }

        public event Action<WatchedReport> ReportFound;
    }
}
