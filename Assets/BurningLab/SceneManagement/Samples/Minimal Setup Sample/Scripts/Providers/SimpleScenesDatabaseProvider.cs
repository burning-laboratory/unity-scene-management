using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Providers;
using BurningLab.SceneManagement.Samples.MinimalSetupSample.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.Providers
{
    /// <summary>
    /// Provide reference to target scenes database instance.
    /// </summary>
    [AddTypeMenu("Simple Scenes Database Provider")]
    [System.Serializable]
    public class SimpleScenesDatabaseProvider : IScenesDatabaseProvider
    {
        #region Settings

        [Tooltip("Reference to target simple scenes database instance")]
        [SerializeField] private SimpleScenesDatabase _targetDatabase;

        #endregion

        #region Public Methods

        /// <summary>
        /// Return target scenes database.
        /// </summary>
        /// <returns>Target database instance.</returns>
        public IScenesDatabase GetScenesDatabase() => _targetDatabase;

        #endregion
    }
}