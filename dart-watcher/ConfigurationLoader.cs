using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace dart_watcher
{
    public class ConfigurationAttribute : Attribute
    {
        public ConfigurationAttribute(string config, string valueIfNotExists)
        {
            Config = config;
            ValueIfNotExists = valueIfNotExists;
        }

        public string Config { get; }
        public string ValueIfNotExists { get; }
    }

    public class ConfigurationLoader
    {
        public static T Load<T>(string configurationFilePath)
        {
            var configurations = GetConfigurations(configurationFilePath);
            var configProperties = GetConfigurationProperties<T>();

            return CreateConfigurationObject<T>(configurations, configProperties);
        }

        private static IEnumerable<(PropertyInfo, ConfigurationAttribute)> GetConfigurationProperties<T>()
        {
            return typeof(T).GetProperties().Where(property =>
            {
                return (property.PropertyType == typeof(string)) &&
                       property.CanWrite &&
                       property.CanRead &&
                       (property.GetCustomAttribute<ConfigurationAttribute>() != null);
            }).Select(property => (
                property, 
                property.GetCustomAttribute<ConfigurationAttribute>() 
            ));
        }

        private static IDictionary<string, string> GetConfigurations(string configurationFilePath)
        {
            var document = XDocument.Load(configurationFilePath);

            return document.Root.Elements().ToDictionary(
                elem => elem.Name.ToString(), 
                elem => elem.Value);
        }

        private static T CreateConfigurationObject<T>(
            IDictionary<string, string> configurations, 
            IEnumerable<(PropertyInfo, ConfigurationAttribute)> configurationProperties)
        {
            var configuration = Activator.CreateInstance<T>();
            foreach (var property in configurationProperties)
            {
                string value;
                if (configurations.ContainsKey(property.Item2.Config))
                {
                    configurations.TryGetValue(property.Item2.Config, out value);
                }
                else
                {
                    value = property.Item2.ValueIfNotExists;
                }

                property.Item1.SetValue(configuration, value);
            }

            return configuration;
        }
    }
}
