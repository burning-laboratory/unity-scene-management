using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension
{
    /// <summary>
    /// Provide reference to local scenes management configuration.
    /// </summary>
    [AddTypeMenu("Burning-Lab/Local Scenes Management Configuration Provider")]
    [System.Serializable]
    public class LocalScenesManagementConfigurationProvider : IScenesManagementConfigurationProvider
    {
        #region Settings

        [Tooltip("Reference to target local scene management configuration instance.")]
        [SerializeField] private LocalSceneManagementConfiguration _sceneManagementConfiguration;

        #endregion

        #region Public Methods

        /// <summary>
        /// Return target local scenes management configuration instance.
        /// </summary>
        /// <returns>Local scenes management configuration instance.</returns>
        public IScenesManagementConfiguration GetConfiguration() => _sceneManagementConfiguration;

        #endregion
    }
}