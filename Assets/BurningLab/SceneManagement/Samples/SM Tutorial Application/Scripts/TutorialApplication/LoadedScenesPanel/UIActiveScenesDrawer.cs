using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Types;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.UI
{
    public class UIActiveScenesDrawer : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Transform _listContainer;
        [SerializeField] private List<UIActiveSceneItem> _items;

        [Header("Prefabs")] 
        [SerializeField] private UIActiveSceneItem _defaultScenePrefab;
        [SerializeField] private UIActiveSceneItem _alwaysLoadedScenePrefab;
        [SerializeField] private UIActiveSceneItem _activeScenePrefab;

        private void OnScenesChangedEventHandler(ISceneData sd)
        {
            foreach (UIActiveSceneItem item in _items)
            {
                Destroy(item);
            }
            
            List<ISceneData> loadedScenes = ScenesSwitcher.Instance.LoadedScenes;
            for (int i = loadedScenes.Count - 1; i >= 0; i--)
            {
                ISceneData sceneData = loadedScenes[i];

                List<ISceneData> alwaysLoadedScene = ScenesSwitcher.Instance.Configuration.GetAlwaysLoadedScenes();
                if (alwaysLoadedScene.Contains(sceneData))
                {
                    UIActiveSceneItem activeSceneItem = Instantiate(_alwaysLoadedScenePrefab.gameObject, _listContainer).GetComponent<UIActiveSceneItem>();
                    activeSceneItem.Init(sceneData);
                    continue;
                }

                SceneLoadType sceneLoadType = sceneData.GetSceneLoadType();
                switch (sceneLoadType)
                {
                    case SceneLoadType.Active:
                        UIActiveSceneItem activeSceneItem = Instantiate(_activeScenePrefab.gameObject, _listContainer).GetComponent<UIActiveSceneItem>();
                        activeSceneItem.Init(sceneData);
                        break;
                    
                    case SceneLoadType.Additional:
                        UIActiveSceneItem additionalSceneData = Instantiate(_defaultScenePrefab.gameObject, _listContainer).GetComponent<UIActiveSceneItem>();
                        additionalSceneData.Init(sceneData);
                        break;
                }
            }
        }
        
        private void Start()
        {
            ScenesSwitcher.Instance.OnSceneLoaded += OnScenesChangedEventHandler;
            ScenesSwitcher.Instance.OnSceneUnloaded += OnScenesChangedEventHandler;
        }

        private void OnDestroy()
        {
            ScenesSwitcher.Instance.OnSceneLoaded -= OnScenesChangedEventHandler;
            ScenesSwitcher.Instance.OnSceneUnloaded -= OnScenesChangedEventHandler;
        }
    }
}