using System.Configuration;
public static string GetValueByKey(string configFileName, string key)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {
                ExeConfigFilename = GetAssemblyPath() + configFileName
            };
            System.Configuration.Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            if (!configuration.AppSettings.Settings.AllKeys.Contains<string>(key))
            {
                throw new SettingsPropertyNotFoundException("δ�ҵ���Ӧ��������Ϣ�����������ļ���");
            }
            return configuration.AppSettings.Settings[key].Value.ToString();
        }