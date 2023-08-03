using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension
{
    [AddTypeMenu("Burning-Lab/Local Scene Data Reference")]
    [System.Serializable]
    public class LocalSceneDataReference : ISceneDataReference
    {
        [SerializeField] private string _displayName;
        
        [Tooltip("Target local scene data instance.")]
        [SerializeField] private LocalSceneData _targetSceneData;
        
        /// <summary>
        /// Return target local scene data instance.
        /// </summary>
        /// <returns>Target local scene data.</returns>
        public ISceneData GetSceneData() => _targetSceneData;
    }
}