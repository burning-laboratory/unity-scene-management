using System.Collections.Generic;
using UnityEngine;

namespace BurningLab.SceneManagement.Database
{
    [CreateAssetMenu(fileName = "New Scenes Group", menuName = "Burning-Lab/Scene Management/Scenes Group", order = 51)]
    public class ScenesGroup : ScriptableObject
    {
        #region Settings
        
        [Header("Scenes group settings")]
        [Tooltip("Scenes group name.")]
        [SerializeField] private string _groupName;
        
        [Tooltip("Included scenes in scene group.")]
        [SerializeField] private List<SceneData> _scenes;

        #endregion

        #region Public Properties
        
        /// <summary>
        /// Scenes group name.
        /// </summary>
        public string GroupName => _groupName;
        
        /// <summary>
        /// Included scenes in scene group.
        /// </summary>
        public List<SceneData> Scenes => _scenes;

        #endregion
    }
}