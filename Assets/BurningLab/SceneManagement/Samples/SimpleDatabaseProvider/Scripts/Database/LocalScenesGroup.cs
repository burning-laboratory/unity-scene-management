using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension
{
    /// <summary>
    /// Local scenes group data implementation.
    /// </summary>
    [CreateAssetMenu(menuName = "Burning-Lab/Scenes Management/Extensions/Local Scenes Database Extension/Local Scenes Group", fileName = "New Local Scenes Group", order = 51)]
    public class LocalScenesGroup : ScriptableObject, IScenesGroup
    {
        #region Settings
        
        [Tooltip("Scenes group name.")]
        [SerializeField] private string _groupName;
        
        [Tooltip("Included scenes in scene group.")]
        [SerializeReference, SubclassSelector] private List<ISceneDataReference> _sceneDataReferences;

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Scenes group name.
        /// </summary>
        public string GetScenesGroupName() => _groupName;

        /// <summary>
        /// Included scenes in scene group.
        /// </summary>
        public List<ISceneData> GetScenes()
        {
            List<ISceneData> scenes = new List<ISceneData>();

            foreach (ISceneDataReference sceneDataReference in _sceneDataReferences)
            {
                ISceneData sceneData = sceneDataReference.GetSceneData();
                scenes.Add(sceneData);
            }

            return scenes;
        }

        #endregion
    }
}