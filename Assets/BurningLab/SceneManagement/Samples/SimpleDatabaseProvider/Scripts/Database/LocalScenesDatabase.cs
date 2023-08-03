using System;
using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension
{
    /// <summary>
    /// Local scenes database implementation.
    /// </summary>
    [CreateAssetMenu(menuName = "Burning-Lab/Scenes Management/Extensions/Local Scenes Database Extension/Local Scenes Database", fileName = "New Local Scenes Database", order = 51)]
    public class LocalScenesDatabase : ScriptableObject, IScenesDatabase
    {
        #region Settings
        
        [Tooltip("All defined scenes in project.")]
        [SerializeReference, SubclassSelector] private List<ISceneDataReference> _scenes;

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Return scene data by scene name.
        /// </summary>
        /// <param name="sceneDataName">Scene name.</param>
        /// <returns>Scene data from scenes collection or null.</returns>
        /// <exception cref="ArgumentException">No find scene data.</exception>
        public ISceneData GetSceneDataByName(string sceneDataName)
        {
            List<ISceneData> scenesData = GetScenes();
            for (int i = scenesData.Count - 1; i >= 0; i--)
            {
                ISceneData candidateSceneData = scenesData[i];
                string sceneAssetName = candidateSceneData.GetSceneAssetName();
                if (sceneAssetName.Equals(sceneDataName))
                {
                    return candidateSceneData;
                }
            }

            throw new ArgumentException($"Not found scene data with name: {sceneDataName}", nameof(sceneDataName));
        }

        /// <summary>
        /// Check exists scene data for scene asset path.
        /// </summary>
        /// <param name="path">Scene asset path.</param>
        /// <returns>Exists scene data with scene asset path.</returns>
        public bool SceneDataExists(string path)
        {
            List<ISceneData> scenesData = GetScenes();
            ISceneData sceneData = scenesData.Find(sd =>
            {
                string sceneAssetPath = sd.GetSceneAssetPath();
                return sceneAssetPath == path;
            });
            return sceneData != null;
        }
        
        /// <summary>
        /// All defined scenes in project.
        /// </summary>
        public List<ISceneData> GetScenes()
        {
            List<ISceneData> scenesData = new List<ISceneData>();

            foreach (ISceneDataReference sceneDataReference in _scenes)
            {
                ISceneData sceneData = sceneDataReference.GetSceneData();
                scenesData.Add(sceneData);
            }
            
            return scenesData;
        }
        
        #endregion
    }
}