

using Firedump.models.configuration.jsonconfig.dto;

namespace Firedump.models.configuration.jsonconfig
{
    public sealed class ConfigurationManager : ConfigurationClass<ConfigurationManager>
    {
        public SqlDumpConfig mysqlDumpConfigInstance { set; get; }
        public CompressConfig compressConfigInstance { set; get; }
        private static ConfigurationManager configurationManagerInstance;
        private ConfigurationManager() { }
        
        /// <returns>Returns a ConfigurationManager instance with all configuration class instances set as fields of this instance</returns>
        public static ConfigurationManager getInstance()
        {
            if (configurationManagerInstance == null)
            {
                configurationManagerInstance = new ConfigurationManager();
                configurationManagerInstance.initializeConfig();
            }
            return configurationManagerInstance;
        }

        /// <summary>
        /// Calls the initiallize methods of every configuration class.
        /// </summary>
        private ConfigurationManager initializeConfig()
        {
            this.mysqlDumpConfigInstance = SqlDumpConfig.getInstance();
            this.compressConfigInstance = CompressConfig.getInstance();
            return configurationManagerInstance;
        }

        /// <summary>
        /// Calls the save methods of every configuration class.
        /// IMPORTANT: initializeConfig must be called at least once before this method is called.
        /// </summary>
        public void saveConfig()
        {
            this.mysqlDumpConfigInstance.saveConfig();
            this.compressConfigInstance.saveConfig();
        }

        public ConfigurationManager resetToDefaults(bool skip = false)
        {
            this.mysqlDumpConfigInstance = SqlDumpConfig.getInstance().resetToDefaults();
            this.compressConfigInstance = CompressConfig.getInstance().resetToDefaults();
            return configurationManagerInstance;
        }

        public SqlDumpDto getMySqlDumpSettings()
        {
            return this.mysqlDumpConfigInstance.getSettings();
        }

        public CompressDto getCompressSettings()
        {
            return this.compressConfigInstance.getSettings();
        }

    }
}
