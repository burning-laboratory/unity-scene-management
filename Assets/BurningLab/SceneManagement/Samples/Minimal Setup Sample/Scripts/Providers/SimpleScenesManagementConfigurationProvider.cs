using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Providers;
using BurningLab.SceneManagement.Samples.MinimalSetupSample.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.Providers
{
    /// <summary>
    /// Provide reference to simple scenes management configuration instance.
    /// </summary>
    [AddTypeMenu("Simple Scenes Management Configuration Provider")]
    [System.Serializable]
    public class SimpleScenesManagementConfigurationProvider : IScenesManagementConfigurationProvider
    {
        [Tooltip("Target scenes management configuration.")]
        [SerializeField] private SimpleScenesManagementConfiguration _targetConfiguration;

        /// <summary>
        /// Return reference to target scenes management configuration instance.
        /// </summary>
        /// <returns>Target scenes management configuration instance.</returns>
        public IScenesManagementConfiguration GetConfiguration() => _targetConfiguration;
    }
}