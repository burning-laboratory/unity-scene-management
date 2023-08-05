using System;
using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.References;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.Database
{
    /// <summary>
    /// Implement IScenesGroupDatabase interface as MonoBehaviour component.
    /// </summary>
    public class SimpleScenesGroupsDatabase : MonoBehaviour, IScenesGroupDatabase
    {
        #region Settings

        [Header("Settings")] 
        [Tooltip("List of all scenes group reference in project.")]
        [SerializeReference, SubclassSelector] private List<IScenesGroupReference> _scenesGroups;

        #endregion
        
        /// <summary>
        /// Return all scenes group from database.
        /// </summary>
        /// <returns>Scenes group list in database.</returns>
        public List<IScenesGroup> GetScenesGroups()
        {
            List<IScenesGroup> scenesGroups = new List<IScenesGroup>();

            foreach (IScenesGroupReference scenesGroupReference in _scenesGroups)
            {
                IScenesGroup targetScenesGroup = scenesGroupReference.GetScenesGroup();
                scenesGroups.Add(targetScenesGroup);
            }

            return scenesGroups;
        }
        
        /// <summary>
        /// Return scenes group with target scenes group name.
        /// </summary>
        /// <param name="scenesGroupName">Target scenes group name.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IScenesGroup GetScenesGroupByName(string scenesGroupName)
        {
            List<IScenesGroup> scenesGroups = GetScenesGroups();

            for (int i = scenesGroups.Count - 1; i >= 0; i--)
            {
                IScenesGroup candidateScenesGroup = scenesGroups[i];
                string candidateScenesGroupName = candidateScenesGroup.GetScenesGroupName();
                if (scenesGroupName.Equals(candidateScenesGroupName))
                    return candidateScenesGroup;
            }
            
            throw new ArgumentException($"Can't find scenes group with name: {scenesGroupName} in {nameof(SimpleScenesGroupsDatabase)}");
        }
    }
}