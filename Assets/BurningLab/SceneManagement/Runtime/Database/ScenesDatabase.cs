using System;
using System.Collections.Generic;
using UnityEngine;

namespace BurningLab.SceneManagement.Database
{
    /// <summary>
    /// Scenes database.
    /// </summary>
    [CreateAssetMenu(fileName = "Scenes Database", menuName = "Burning-Lab/Scene Management/Scenes Database", order = 51)]
    public class ScenesDatabase : ScriptableObject
    {
        #region Settings

        [Header("Settings")]
        [Tooltip("Always loaded scenes. This scenes is never unloading.")]
        [SerializeField] private List<SceneData> _alwaysLoadedScenes;
        
        [Tooltip("All defined scenes in project.")]
        [SerializeField] private List<SceneData> _scenes;
        
        [Tooltip("All defined scenes groups in project.")]
        [SerializeField] private List<ScenesGroup> _sceneGroups;

        #endregion

        #region Public Properties
        
        /// <summary>
        /// Always loaded scenes. This scenes is never unloading.
        /// </summary>
        public List<SceneData> AlwaysLoadedScenes => _alwaysLoadedScenes;
        
        /// <summary>
        /// All defined scenes in project.
        /// </summary>
        public List<SceneData> Scenes => _scenes;
        
        /// <summary>
        /// All defined scenes groups in project.
        /// </summary>
        public List<ScenesGroup> SceneGroups => _sceneGroups;

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Return scene data by scene name.
        /// </summary>
        /// <param name="sceneDataName">Scene name.</param>
        /// <returns>Scene data from scenes collection or null.</returns>
        /// <exception cref="ArgumentException">No find scene data.</exception>
        public SceneData GetSceneDataByName(string sceneDataName)
        {
            for (int i = _scenes.Count - 1; i >= 0; i--)
            {
                SceneData candidateSceneData = _scenes[i];
                if (candidateSceneData.SceneAssetName.Equals(sceneDataName))
                {
                    return candidateSceneData;
                }
            }

            throw new ArgumentException($"Not found scene data with name: {sceneDataName}", nameof(sceneDataName));
        }
        
        /// <summary>
        /// Return scenes group by scenes group name.
        /// </summary>
        /// <param name="scenesGroupName">Target scenes group name.</param>
        /// <returns>Scenes group from database.</returns>
        /// <exception cref="ArgumentException">No find scenes group.</exception>
        public ScenesGroup GetScenesGroupByName(string scenesGroupName)
        {
            for (int i = _sceneGroups.Count - 1; i >= 0; i--)
            {
                ScenesGroup candidateScenesGroup = _sceneGroups[i];
                if (candidateScenesGroup.GroupName == scenesGroupName)
                {
                    return candidateScenesGroup;
                }
            }

            throw new ArgumentException($"Not found scenes group with name: {scenesGroupName}", nameof(scenesGroupName));
        }

        #endregion
    }
}