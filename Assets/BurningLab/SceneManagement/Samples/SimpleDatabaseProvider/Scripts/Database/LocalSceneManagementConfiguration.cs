using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension
{
    /// <summary>
    /// Local scenes management configuration object implementation.
    /// </summary>
    [CreateAssetMenu(menuName = "Burning-Lab/Scenes Management/Extensions/Local Scenes Database Extension/Local Scenes Management Configuration", fileName = "New Local Scenes Management Configuration", order = 51)]
    public class LocalSceneManagementConfiguration : ScriptableObject, IScenesManagementConfiguration
    {
        #region Settings

        [Header("Settings")]
        [Tooltip("List of always loaded scenes references.")]
        [SerializeReference, SubclassSelector] private List<ISceneDataReference> _alwaysLoadedScenes;

        #endregion

        #region Public Methods

        /// <summary>
        /// Return always loaded scenes. This scenes is never unloading.
        /// </summary>
        public List<ISceneData> GetAlwaysLoadedScenes()
        {
            List<ISceneData> alwaysLoadedScenes = new List<ISceneData>();

            foreach (ISceneDataReference sceneDataReference in _alwaysLoadedScenes)
            {
                ISceneData sceneData = sceneDataReference.GetSceneData();
                alwaysLoadedScenes.Add(sceneData);
            }
            
            return alwaysLoadedScenes;
        }

        #endregion
    }
}