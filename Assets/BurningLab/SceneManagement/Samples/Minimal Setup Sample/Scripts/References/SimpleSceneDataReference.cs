using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.References;
using BurningLab.SceneManagement.Samples.MinimalSetupSample.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.References
{
    /// <summary>
    /// Reference to simple scene data instance.
    /// </summary>
    [AddTypeMenu("Simple Scene Data Reference")]
    [System.Serializable]
    public class SimpleSceneDataReference : ISceneDataReference
    {
        #region Settings

        [Tooltip("Decoration display name.")]
        [SerializeField] private string _displayName;
        
        [Tooltip("Reference to simple scene target instance.")]
        [SerializeField] private SimpleSceneData _targetSceneData;

        #endregion

        #region Public Methods

        /// <summary>
        /// Return target scene data.
        /// </summary>
        /// <returns>Target scene data.</returns>
        public ISceneData GetSceneData() => _targetSceneData;

        #endregion
    }
}