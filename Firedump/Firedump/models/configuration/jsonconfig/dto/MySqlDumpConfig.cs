

using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.CSharp.RuntimeBinder;
using Firedump.models.configuration.jsonconfig.dto;
using Firedump.model.configuration.jsonconfig.dto;

namespace Firedump.models.configuration.jsonconfig
{
    public class MySqlDumpConfig : ConfigurationClass<MySqlDumpConfig>
    {
        private readonly string jsonFilePath = "./config/MySqlDumpConfig.json";

        private static MySqlDumpConfig mysqlDumpConfigInstance;

        private MySqlDumpDto mySqlDumpDto;

        private MySqlDumpConfig() {
            this.mySqlDumpDto = new MySqlDumpDto();
        }

        public static MySqlDumpConfig getInstance()
        {
            if(mysqlDumpConfigInstance == null)
            {
                mysqlDumpConfigInstance = new MySqlDumpConfig();
                mysqlDumpConfigInstance.initializeConfig(false);
            }
            return mysqlDumpConfigInstance;
        }

        private MySqlDumpConfig initializeConfig(bool skipRecursion = false)
        {
            try
            {
                this.mySqlDumpDto = JsonConvert.DeserializeObject<MySqlDumpDto>(File.ReadAllText(jsonFilePath));
                return this;
            }
            catch (Exception ex)
            {
                if(skipRecursion)
                {
                    throw new Exception("Somthing went wrong initializing config file options."+ex.Message);
                }
                return this.resetToDefaults(true);
            }
        }

        public void saveConfig()
        {
            if (string.IsNullOrEmpty(this.mySqlDumpDto.tempSavePath))
            {
                this.mySqlDumpDto.tempSavePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Firedump\\";
            }
            FileInfo file = new FileInfo(jsonFilePath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            File.WriteAllText(file.FullName, JsonConvert.SerializeObject(this.mySqlDumpDto, Formatting.Indented));
        }

        public MySqlDumpConfig resetToDefaults(bool skipRecursion = false)
        {
            mysqlDumpConfigInstance = new MySqlDumpConfig();
            mysqlDumpConfigInstance.saveConfig();
            mysqlDumpConfigInstance.initializeConfig(skipRecursion);
            return mysqlDumpConfigInstance;
        }

        public MySqlDumpDto getSettings()
        {
            return this.mySqlDumpDto;
        }

        public void setSettings(MySqlDumpDto settings)
        {
            this.mySqlDumpDto = settings;
        }

    }
}