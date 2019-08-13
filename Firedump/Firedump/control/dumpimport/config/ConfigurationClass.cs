

namespace Firedump.models.configuration.jsonconfig
{
    public interface ConfigurationClass<T>
    {
        void saveConfig();
        T resetToDefaults(bool skip = false);
    }
}
