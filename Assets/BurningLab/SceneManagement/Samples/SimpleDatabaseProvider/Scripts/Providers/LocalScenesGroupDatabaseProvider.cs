using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension
{
    [AddTypeMenu("Burning-Lab/Local Scenes Group Database Provider")]
    [System.Serializable]
    public class LocalScenesGroupDatabaseProvider : IScenesGroupDatabaseProvider
    {
        #region Settings
        
        [Tooltip("Reference to target local scenes group database instance.")]
        [SerializeField] private LocalScenesGroupDatabase _scenesGroupDatabase;

        #endregion

        #region Public Medhods

        /// <summary>
        /// Return local scenes group database instance.
        /// </summary>
        /// <returns>Local scenes group database instance.</returns>
        public IScenesGroupDatabase GetScenesGroupDatabase() => _scenesGroupDatabase;

        #endregion
    }
}