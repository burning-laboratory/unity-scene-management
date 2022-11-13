using System;
using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Types;
using Unity.Plastic.Antlr3.Runtime.Tree;
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

        private void OnScenesChangedEventHandler(SceneData sd)
        {
            foreach (UIActiveSceneItem item in _items)
            {
                Destroy(item);
            }
            
            List<SceneData> loadedScenes = ScenesSwitcher.Instance.LoadedScenes;
            for (int i = loadedScenes.Count - 1; i >= 0; i--)
            {
                SceneData sceneData = loadedScenes[i];

                if (ScenesSwitcher.Instance.Database.AlwaysLoadedScenes.Contains(sceneData))
                {
                    UIActiveSceneItem activeSceneItem = Instantiate(_alwaysLoadedScenePrefab.gameObject, _listContainer).GetComponent<UIActiveSceneItem>();
                    activeSceneItem.Init(sceneData);
                    continue;
                }
                
                switch (sceneData.SceneLoadType)
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