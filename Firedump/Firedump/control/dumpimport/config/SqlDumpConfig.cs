

using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.CSharp.RuntimeBinder;
using Firedump.models.configuration.jsonconfig.dto;

namespace Firedump.models.configuration.jsonconfig
{
    public sealed class SqlDumpConfig : ConfigurationClass<SqlDumpConfig>
    {
        private const string jsonFilePath = "./config/SqlDumpConfig.json";

        private static SqlDumpConfig mysqlDumpConfigInstance;

        private SqlDumpDto mySqlDumpDto;

        private SqlDumpConfig() {
            this.mySqlDumpDto = new SqlDumpDto();
        }

        public static SqlDumpConfig getInstance()
        {
            if(mysqlDumpConfigInstance == null)
            {
                mysqlDumpConfigInstance = new SqlDumpConfig();
                mysqlDumpConfigInstance.initializeConfig(false);
            }
            return mysqlDumpConfigInstance;
        }

        private SqlDumpConfig initializeConfig(bool skipRecursion = false)
        {
            try
            {
                this.mySqlDumpDto = JsonConvert.DeserializeObject<SqlDumpDto>(File.ReadAllText(jsonFilePath));
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

        public SqlDumpConfig resetToDefaults(bool skipRecursion = false)
        {
            mysqlDumpConfigInstance = new SqlDumpConfig();
            mysqlDumpConfigInstance.saveConfig();
            mysqlDumpConfigInstance.initializeConfig(skipRecursion);
            return mysqlDumpConfigInstance;
        }

        public SqlDumpDto getSettings()
        {
            return this.mySqlDumpDto;
        }

        public void setSettings(SqlDumpDto settings)
        {
            this.mySqlDumpDto = settings;
        }

    }
}