using BurningLab.SceneManagement.Database;

namespace BurningLab.SceneManagement
{
    /// <summary>
    /// Root interface for scenes management configuration providers.
    /// </summary>
    public interface IScenesManagementConfigurationProvider
    {
        /// <summary>
        /// Return active scenes management configuration instance.
        /// </summary>
        /// <returns>Scenes management configuration instance.</returns>
        public IScenesManagementConfiguration GetConfiguration();
    }
}