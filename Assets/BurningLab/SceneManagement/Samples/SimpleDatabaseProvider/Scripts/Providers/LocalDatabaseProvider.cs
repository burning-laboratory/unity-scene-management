using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement;
using UnityEngine;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension
{
    /// <summary>
    /// Provide local scenes database instance.
    /// </summary>
    [AddTypeMenu("Burning-Lab/Local Scenes Database Provider")]
    [System.Serializable]
    public class LocalDatabaseProvider : IScenesDatabaseProvider
    {
        #region Settings
        
        [Tooltip("Reference to local scenes database instance.")]
        [SerializeField] private LocalScenesDatabase _scenesDatabase;

        #endregion

        #region Public Methods

        /// <summary>
        /// Return active scenes database instance.
        /// </summary>
        /// <returns>Local scenes database instance.</returns>
        public IScenesDatabase GetScenesDatabase()
        {
            return _scenesDatabase;
        }

        #endregion
    }
}