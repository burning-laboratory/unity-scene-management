using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension
{
    /// <summary>
    /// Reference to local scenes group data.
    /// </summary>
    [AddTypeMenu("Burning-Lab/Local Scenes Group Reference")]
    [System.Serializable]
    public class LocalScenesGroupReference : IScenesGroupReference
    {
        #region Settings
        
        [SerializeField] private string _displayName;
        
        [Tooltip("Target local scenes group.")] 
        [SerializeField] private LocalScenesGroup _targetScenesGroup;

        #endregion

        #region Public Methods

        /// <summary>
        /// Return target scenes group data instance.
        /// </summary>
        /// <returns>Target scenes group.</returns>
        public IScenesGroup GetScenesGroup() => _targetScenesGroup;

        #endregion
    }
}