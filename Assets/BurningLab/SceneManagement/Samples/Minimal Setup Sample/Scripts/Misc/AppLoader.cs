using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Providers;
using BurningLab.SceneManagement.References;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.Misc
{
    /// <summary>
    /// Scenes Management demo application loader.
    /// </summary>
    public class AppLoader : MonoBehaviour
    {
        #region Settings

        [Header("Settings")]
        [Tooltip("Enable this if you need mark ScenesSwitcher as DontDestroyOnLoad.")]
        [SerializeField] private bool _dontDestroyOnLoadScenesSwitcher;

        [Tooltip("Scenes management configuration provider implementation.")]
        [SerializeReference, SubclassSelector] private IScenesManagementConfigurationProvider _configurationProvider;
        
        [Tooltip("Application main scenes group reference.")]
        [SerializeReference, SubclassSelector] private IScenesGroupReference _mainScenesGroup;

        #endregion

        #region Unity Event Methods

        private void Start()
        {
            ScenesSwitcher scenesSwitcher = ScenesSwitcher.Instance;
            
            if (_dontDestroyOnLoadScenesSwitcher)
            {
                DontDestroyOnLoad(scenesSwitcher.gameObject);
            }

            IScenesManagementConfiguration scenesManagementConfiguration = _configurationProvider.GetConfiguration();
            List<ISceneData> alwaysLoadedScenes = scenesManagementConfiguration.GetAlwaysLoadedScenes();
            foreach (ISceneData alwaysLoadedSceneData in alwaysLoadedScenes)
            {
                scenesSwitcher.LoadScene(alwaysLoadedSceneData);
            }

            IScenesGroup mainScenesGroup = _mainScenesGroup.GetScenesGroup();
            scenesSwitcher.LoadScenesGroup(mainScenesGroup);
        }

        #endregion
    }
}