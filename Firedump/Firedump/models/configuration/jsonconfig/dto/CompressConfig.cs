using Firedump.models.configuration.jsonconfig.dto;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Firedump.models.configuration.jsonconfig
{
    public class CompressConfig : ConfigurationClass<CompressConfig>
    {
        private readonly string jsonFilePath = "./config/CompressConfig.json";

        private static CompressConfig compressConfigInstance;

        private CompressDto compressDto;
        private CompressConfig() {
            this.compressDto = new CompressDto();
        }
        public static CompressConfig getInstance()
        {
            if (compressConfigInstance == null)
            {
                compressConfigInstance = new CompressConfig();
                compressConfigInstance.initializeConfig(false);
            }
            return compressConfigInstance;
        }

        private CompressConfig initializeConfig(bool skipRecursion = false)
        {
            try
            {
                this.compressDto = JsonConvert.DeserializeObject<CompressDto>(File.ReadAllText(jsonFilePath));
                return this;
            }
            catch (Exception ex)
            {
                if(skipRecursion)
                {
                    throw new Exception("Somthing went wrong initializing config file options.:"+ex.Message);
                }
                return this.resetToDefaults(true);
            }
        }
        public void saveConfig()
        {
            this.compressDto.use32bit = !Environment.Is64BitOperatingSystem;
            FileInfo file = new FileInfo(jsonFilePath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
            File.WriteAllText(file.FullName, JsonConvert.SerializeObject(this.compressDto, Formatting.Indented));
        }

        public CompressConfig resetToDefaults(bool skipRecursion = false)
        {
            compressConfigInstance = new CompressConfig();
            compressConfigInstance.saveConfig();
            compressConfigInstance.initializeConfig(skipRecursion);
            return compressConfigInstance;
        }

        public CompressDto getSettings()
        {
            return this.compressDto;
        }

        public void setSettings(CompressDto  settings)
        {
            this.compressDto = settings;
        }
    }
}
