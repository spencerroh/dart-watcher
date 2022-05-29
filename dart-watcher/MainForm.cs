using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace dart_watcher
{
    public partial class MainForm : Form
    {
        const string CONFIG_XML_PATH = @".\configs\config.xml";
        const string KEYWORD_STORAGE_PATH = @".\configs\dart-watcher.conf";

        private readonly Configurations configurations = ConfigurationLoader.Load<Configurations>(CONFIG_XML_PATH);
        private readonly KeywordStorage keywordStorage = new KeywordStorage(KEYWORD_STORAGE_PATH);
        private readonly DartWatcher dartWatcher;

        public MainForm()
        {
            InitializeComponent();
            ToastNotificationManagerCompat.OnActivated += OnToastClicked;

            var keywords = keywordStorage.Load();
            ApplyKeywords(keywords);

            dartWatcher = new DartWatcher(configurations.ApiKey);
            dartWatcher.ReportFound += OnReportFound;
            dartWatcher.SetKeywords(keywords);
            dartWatcher.Run();
        }

        private void OnReportFound(WatchedReport report)
        {
            ShowMessage(report.Name, report.Title, report.Url);
        }

        private void OnToastClicked(ToastNotificationActivatedEventArgsCompat e)
        {
            ToastArguments args = ToastArguments.Parse(e.Argument);

            Process.Start(new ProcessStartInfo(args.Get("url"))
            {
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private void ShowMessage(string name, string title, string url)
        {
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddArgument("url", url)
                .AddText("빠른 공시 알림")
                .AddText(name)
                .AddText(title)
                .AddAppLogoOverride(new Uri("file:///" + Path.GetFullPath("logo.png"), UriKind.Absolute), ToastGenericAppLogoCrop.Circle)
                .Show();
        }

        private void OnKeywordEntered(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                OnKeywordAdded(uiKeyword, null);
        }

        private void OnKeywordAdded(object sender, EventArgs e)
        {
            uiKeywords.Items.Add(uiKeyword.Text);
            uiKeyword.Text = "";

            UpdateKeywords();
        }

        private void OnKeywordRemoved(object sender, EventArgs e)
        {
            if (uiKeywords.SelectedItem != null)
                uiKeywords.Items.Remove(uiKeywords.SelectedItem);

            UpdateKeywords();
        }

        private void UpdateKeywords()
        {
            var keywords = uiKeywords.Items.Cast<string>();

            SaveKeywords(keywords);
            dartWatcher.SetKeywords(keywords);
        }

        private void ApplyKeywords(IEnumerable<string> keywords)
        {
            uiKeywords.Items.Clear();
            uiKeywords.Items.AddRange(keywords.ToArray());
        }

        private void SaveKeywords(IEnumerable<string> keywords)
        {
            keywordStorage.Save(keywords);
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            dartWatcher.Stop();
        }
    }
}
