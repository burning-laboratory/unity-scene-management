using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Providers;
using BurningLab.SceneManagement.Samples.MinimalSetupSample.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.Providers
{
    /// <summary>
    /// Provide reference to target scenes group database instance.
    /// </summary>
    [AddTypeMenu("Simple Scenes Group Database Provider")]
    [System.Serializable]
    public class SimpleScenesGroupDatabaseProvider : IScenesGroupDatabaseProvider
    {
        #region Settings

        [Tooltip("Reference to target scenes group database instance.")]
        [SerializeField] private SimpleScenesGroupsDatabase _targetScenesGroupDatabase;

        #endregion

        #region Public Methods

        /// <summary>
        /// Return target scenes group database instance.
        /// </summary>
        /// <returns>Target scenes group database instance.</returns>
        public IScenesGroupDatabase GetScenesGroupDatabase() => _targetScenesGroupDatabase;

        #endregion
    }
}