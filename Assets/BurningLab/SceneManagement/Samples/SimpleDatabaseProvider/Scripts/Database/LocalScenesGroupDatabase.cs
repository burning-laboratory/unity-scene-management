using System;
using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension
{
    /// <summary>
    /// Local scenes group database implementation.
    /// </summary>
    [CreateAssetMenu(menuName = "Burning-Lab/Scenes Management/Extensions/Local Scenes Database Extension/Local Scenes Group Database", fileName = "New Local Scenes Group", order = 51)]
    public class LocalScenesGroupDatabase : ScriptableObject, IScenesGroupDatabase
    {
        #region Settings
        
        [Header("Settings")]
        [Tooltip("All defined scenes groups in project.")]
        [SerializeReference, SubclassSelector] private List<IScenesGroupReference> _sceneGroups;

        #endregion

        #region Public Methods

        /// <summary>
        /// All defined scenes groups in project.
        /// </summary>
        public List<IScenesGroup> GetScenesGroups()
        {
            List<IScenesGroup> scenesGroups = new List<IScenesGroup>();

            foreach (IScenesGroupReference scenesGroupReference in _sceneGroups)
            {
                IScenesGroup scenesGroup = scenesGroupReference.GetScenesGroup();
                scenesGroups.Add(scenesGroup);
            }
            
            return scenesGroups;
        }
        
        /// <summary>
        /// Return scenes group by scenes group name.
        /// </summary>
        /// <param name="scenesGroupName">Target scenes group name.</param>
        /// <returns>Scenes group from database.</returns>
        /// <exception cref="ArgumentException">No find scenes group.</exception>
        public IScenesGroup GetScenesGroupByName(string scenesGroupName)
        {
            List<IScenesGroup> scenesGroups = GetScenesGroups();
            for (int i = scenesGroups.Count - 1; i >= 0; i--)
            {
                IScenesGroup candidateScenesGroup = scenesGroups[i];
                string candidateScenesGroupName = candidateScenesGroup.GetScenesGroupName();
                if (candidateScenesGroupName == scenesGroupName)
                {
                    return candidateScenesGroup;
                }
            }

            throw new ArgumentException($"Not found scenes group with name: {scenesGroupName}", nameof(scenesGroupName));
        }

        #endregion
    }
}