using System.Configuration;
public static string GetValueByKey(string configFileName, string key)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {
                ExeConfigFilename = GetAssemblyPath() + configFileName
            };
            System.Configuration.Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            if (!configuration.AppSettings.Settings.AllKeys.Contains<string>(key))
            {
                throw new SettingsPropertyNotFoundException("未找到相应的配置信息，请检查配置文件！");
            }
            return configuration.AppSettings.Settings[key].Value.ToString();
        }