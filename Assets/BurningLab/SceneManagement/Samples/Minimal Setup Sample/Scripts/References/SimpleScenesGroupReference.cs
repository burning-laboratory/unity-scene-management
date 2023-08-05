using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.References;
using BurningLab.SceneManagement.Samples.MinimalSetupSample.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.References
{
    /// <summary>
    /// Reference to simple scenes group instance.
    /// </summary>
    [AddTypeMenu("Simple Scenes Group Reference")]
    [System.Serializable]
    public class SimpleScenesGroupReference : IScenesGroupReference
    {
        #region Settings

        [Tooltip("Decorative name.")]
        [SerializeField] private string _displayName;
        
        [Tooltip("Reference to target scenes group.")]
        [SerializeField] private SimpleScenesGroup _targetScenesGroup;

        #endregion

        #region Public Methods

        /// <summary>
        /// Return target scenes group.
        /// </summary>
        /// <returns>Target scenes group.</returns>
        public IScenesGroup GetScenesGroup() => _targetScenesGroup;

        #endregion
    }
}