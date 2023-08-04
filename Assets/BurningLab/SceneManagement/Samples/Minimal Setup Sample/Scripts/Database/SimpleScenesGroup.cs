using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.Database
{
    /// <summary>
    /// Implement IScenesGroup interface as MonoBehavior component.
    /// </summary>
    public class SimpleScenesGroup : MonoBehaviour, IScenesGroup
    {
        #region Settings

        [Header("Settings")]
        [SerializeField] private string _scenesGroupName;
        [SerializeReference, SubclassSelector] private List<ISceneDataReference> _sceneReferences;

        #endregion

        #region Public Methods

        /// <summary>
        /// Set scenes group name.
        /// </summary>
        /// <param name="scenesGroupName">Scenes group name to set.</param>
        public void SetScenesGroupName(string scenesGroupName) => _scenesGroupName = scenesGroupName;
        
        /// <summary>
        /// Return scenes group name.
        /// </summary>
        /// <returns>Scenes group name.</returns>
        public string GetScenesGroupName() => _scenesGroupName;
        
        /// <summary>
        /// Set included in group scenes references list.
        /// </summary>
        /// <param name="sceneReferences">List of scenes reference for include to scenes group.</param>
        public void SetScenes(List<ISceneDataReference> sceneReferences) => _sceneReferences = sceneReferences;
        
        /// <summary>
        /// Return included in group scenes list.
        /// </summary>
        /// <returns>Included in group scenes.</returns>
        public List<ISceneData> GetScenes()
        {
            List<ISceneData> scenes = new List<ISceneData>();

            foreach (ISceneDataReference sceneDataReference in _sceneReferences)
            {
                ISceneData targetSceneData = sceneDataReference.GetSceneData();
                scenes.Add(targetSceneData);
            }
            
            return scenes;
        }

        #endregion
    }
}