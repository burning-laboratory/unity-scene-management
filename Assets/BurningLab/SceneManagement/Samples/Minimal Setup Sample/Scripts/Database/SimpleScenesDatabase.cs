using System;
using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.References;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.Database
{
    /// <summary>
    /// Implement IScenesDatabase as mono behaviour object.
    /// </summary>
    public class SimpleScenesDatabase : MonoBehaviour, IScenesDatabase
    {
        #region Settings

        [Header("Settings")] 
        [Tooltip("List of all project scenes data references.")]
        [SerializeReference, SubclassSelector] private List<ISceneDataReference> _scenesData;

        #endregion

        #region Public Methods

        /// <summary>
        /// Return all project scenes list.
        /// </summary>
        /// <returns>All project scenes list.</returns>
        public List<ISceneData> GetScenes()
        {
            List<ISceneData> scenesData = new List<ISceneData>();

            foreach (ISceneDataReference sceneDataReference in _scenesData)
            {
                ISceneData targetSceneData = sceneDataReference.GetSceneData();
                scenesData.Add(targetSceneData);
            }
            
            return scenesData;
        }
        
        /// <summary>
        /// Return scene data with requested name.
        /// </summary>
        /// <param name="sceneName">Requested scene data name.</param>
        /// <returns>Scene data with requested name.</returns>
        /// <exception cref="ArgumentException">If scene data with requested name not found in database.</exception>
        public ISceneData GetSceneDataByName(string sceneName)
        {
            List<ISceneData> scenes = GetScenes();
            foreach (ISceneData candidateSceneData in scenes)
            {
                string candidateSceneName = candidateSceneData.GetSceneAssetName();
                if (sceneName.Equals(candidateSceneName))
                    return candidateSceneData;
            }

            throw new ArgumentException($"Can't find scene with name: {sceneName} in {nameof(SimpleScenesDatabase)}.");
        }
        
        /// <summary>
        /// Return true if scene data with target scene path exists in database.
        /// </summary>
        /// <param name="scenePath">Target scene asset path.</param>
        /// <returns>True if scene data with target scene path exists in database </returns>
        public bool SceneDataExists(string scenePath)
        {
            List<ISceneData> scenes = GetScenes();
            
            foreach (ISceneData candidateSceneData in scenes)
            {
                string candidateScenePath = candidateSceneData.GetSceneAssetPath();
                if (scenePath.Equals(candidateScenePath))
                    return true;
            }

            return false;
        }

        #endregion
    }
}