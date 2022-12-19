using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Types;
using BurningLab.SceneManagement.Utils;

namespace BurningLab.SceneManagement
{
    /// <summary>
    /// Async scenes switcher.
    /// </summary>
    public class ScenesSwitcher : MonoBehaviour
    {
        #region Settings

        [Header("Settings")] 
        [Tooltip("Scenes database asset reference.")]
        [SerializeField] private ScenesDatabase _database;
        
        [Tooltip("Auto moving main camera game object to active scene.")]
        [SerializeField] private bool _mainCameraHandling;
        
        #endregion

        #region Private Fields

#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
        [Header("Debug fields")]
        [SerializeField]
#endif
        private GameObject _mainCamera;
        
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
        [SerializeField]
#endif
        private List<SceneData> _loadedScenes = new();
        
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
        [SerializeField]
#endif
        private List<SceneData> _scenesToUnload = new();

        #endregion

        #region Public Fields
        
        /// <summary>
        /// Scenes switcher static instance.
        /// </summary>
        public static ScenesSwitcher Instance => _instance;
        
        /// <summary>
        /// Scenes switcher private static instance.
        /// </summary>
        
        private static ScenesSwitcher _instance;
        
        /// <summary>
        /// Loaded scenes list.
        /// </summary>
        public List<SceneData> LoadedScenes => _loadedScenes;

        /// <summary>
        /// Scenes database reference.
        /// </summary>
        public ScenesDatabase Database => _database;
        
        #endregion

        #region Events

        /// <summary>
        /// Scene loaded event.
        /// </summary>
        public event Action<SceneData> OnSceneLoaded;
        
        /// <summary>
        /// Scene unloaded event.
        /// </summary>
        public event Action<SceneData> OnSceneUnloaded; 

        #endregion
        
        #region Unity Event Methods

        private void Awake()
        {
            #region Create static instance.

            if (_instance == null)
            {
                _instance = this;
            }

#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
            UnityConsole.PrintLog("ScenesSwitcher", "Awake", "Create scenes switcher static instance.", gameObject);
#endif

            #endregion

            #region Cache main camera reference.

            if (_mainCameraHandling)
            {
                if (Camera.main != null)
                {
                    _mainCamera = Camera.main.gameObject;
                }
            }

#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
            UnityConsole.PrintLog("ScenesSwitcher", "Awake", "Cache main camera reference.", gameObject);
#endif

            #endregion

            #region Get loaded scenes

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.isLoaded)
                {
                    SceneData loadedSceneData = _database.GetSceneDataByName(scene.name);
                    _loadedScenes.Add(loadedSceneData);
                }
            }
            
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
            UnityConsole.PrintLog("ScenesSwitcher", "Awake", "Add previous loaded scenes.", gameObject);
#endif

            #endregion

            #region Start wathing scenes

            SceneManager.sceneLoaded += OnSceneLoadedEventHandler;
            SceneManager.sceneUnloaded += OnSceneUnloadedEventHandler;
            
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
            UnityConsole.PrintLog("ScenesSwitcher", "Awake", "Start scenes loading/unloading watching.", gameObject);
#endif

            #endregion
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoadedEventHandler;
            SceneManager.sceneUnloaded -= OnSceneUnloadedEventHandler;
            
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
            UnityConsole.PrintLog("ScenesSwitcher", "OnDestroy", "Stop scenes loading/unloading watching.", gameObject);
#endif
        }

        #endregion

        #region Event Handlers
        
        private void OnSceneLoadedEventHandler(Scene scene, LoadSceneMode mode)
        {
            SceneData loadedSceneData = _database.GetSceneDataByName(scene.name);
            _loadedScenes.Add(loadedSceneData);
            
            OnSceneLoaded?.Invoke(loadedSceneData);
            
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
            UnityConsole.PrintLog("ScenesSwitcher", "OnSceneLoadedEventHandler", $"Scene loaded: {loadedSceneData.SceneAssetName}", gameObject);
#endif

            if (loadedSceneData.SceneLoadType == SceneLoadType.Active)
            {
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
                Scene previousActiveScene = SceneManager.GetActiveScene();
#endif
                
                SceneManager.SetActiveScene(scene);
                
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
                Scene currentActiveScene = SceneManager.GetActiveScene();
                UnityConsole.PrintLog("ScenesSwitcher", "OnSceneLoadedEventHandler", $"Active scene changed. From: {previousActiveScene.name}, To: {currentActiveScene.name}", gameObject);
#endif
                
                if (_mainCameraHandling)
                {
                    SceneManager.MoveGameObjectToScene(_mainCamera, scene);
                        
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
                    UnityConsole.PrintLog("ScenesSwitcher", "OnSceneLoadedEventHandler", $"Main camera moved. From: {previousActiveScene.name}, To: {currentActiveScene.name}", gameObject);
#endif
                }
            }
            
            for (int i = _scenesToUnload.Count - 1; i >= 0; i--)
            {
                SceneData sceneData = _scenesToUnload[i];
                
                switch (sceneData.AssetType)
                {
                    case SceneAssetType.LocalAsset:
                        SceneManager.UnloadSceneAsync(sceneData.SceneAssetName);
                        break;
                        
                    case SceneAssetType.AddressableAsset:
                        Addressables.UnloadSceneAsync(sceneData.SceneAssetReference.OperationHandle);
                        break;
                }

                _scenesToUnload.Remove(sceneData);
            }
        }

        private void OnSceneUnloadedEventHandler(Scene scene)
        {
            SceneData unloadedSceneData = _database.GetSceneDataByName(scene.name);
            _loadedScenes.Remove(unloadedSceneData);
            
            OnSceneUnloaded?.Invoke(unloadedSceneData);
            
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
            UnityConsole.PrintLog("ScenesSwitcher", "OnSceneUnloadedEventHandler", $"Scene unloaded: {scene.name} ", gameObject);
#endif
        }

        #endregion

        #region Public Methods

        #region Unload Scene Methods

        /// <summary>
        /// Unload scene.
        /// </summary>
        /// <param name="sceneData">Scene data.</param>
        public void UnloadScene(SceneData sceneData)
        {
            switch (sceneData.AssetType)
            {
                case SceneAssetType.LocalAsset:
                    SceneManager.UnloadSceneAsync(sceneData.SceneAssetName);
                    break;
                
                case SceneAssetType.AddressableAsset:
                    Addressables.UnloadSceneAsync(sceneData.SceneAssetReference.OperationHandle);
                    break;
            }
        }
        
        /// <summary>
        /// Unload scene.
        /// </summary>
        /// <param name="sceneName">Scene asset name.</param>
        public void UnloadScene(string sceneName) => SceneManager.UnloadSceneAsync(sceneName);
        
        /// <summary>
        /// Unload scene.
        /// </summary>
        /// <param name="sceneBuildIndex">Scene build index.</param>
        public void UnloadScene(int sceneBuildIndex) => SceneManager.UnloadSceneAsync(sceneBuildIndex);

        #endregion

        #region Load Scene Methods

        /// <summary>
        /// Load one scene.
        /// </summary>
        /// <param name="sceneData">Single scene data to load.</param>
        /// <returns>Scene load async operations wrapper.</returns>
        public ScenesLoadOperation LoadScene(SceneData sceneData)
        {
            ScenesLoadOperation scenesLoadOperation = new ScenesLoadOperation();

            bool activationMode = sceneData.GetActivationMode();
            int priority = sceneData.LoadPriority;
            
            switch (sceneData.AssetType)
            {
                case SceneAssetType.LocalAsset:
                    AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneData.SceneAssetName, sceneData.LoadMode);
                    loadSceneOperation.allowSceneActivation = activationMode;
                    loadSceneOperation.priority = priority;
                    scenesLoadOperation.RegisterSceneLoadAsyncOperation(sceneData, loadSceneOperation);
                    break;
                
                case SceneAssetType.AddressableAsset:
                    AsyncOperationHandle<SceneInstance> loadSceneOperationHandle = sceneData.SceneAssetReference.LoadSceneAsync(sceneData.LoadMode, activationMode, priority);
                    scenesLoadOperation.RegisterSceneLoadAsyncOperationHandle(sceneData, loadSceneOperationHandle);
                    break;
            }
            
            return scenesLoadOperation;
        }
        
        /// <summary>
        /// Load one scene.
        /// </summary>
        /// <param name="sceneName">Target scene name.</param>
        /// <returns>Scenes load async operation wrapper.</returns>
        public ScenesLoadOperation LoadScene(string sceneName)
        {
            SceneData sceneData = _database.GetSceneDataByName(sceneName);
            ScenesLoadOperation loadOperation = LoadScene(sceneData);
            return loadOperation;
        }

        /// <summary>
        /// Load one scene.
        /// </summary>
        /// <param name="sceneBuildIndex">Target scene build index.</param>
        /// <returns>Scenes load async operation wrapper.</returns>
        public ScenesLoadOperation LoadScene(int sceneBuildIndex)
        {
            Scene targetScene = SceneManager.GetSceneByBuildIndex(sceneBuildIndex);
            string sceneName = targetScene.name;
            SceneData targetSceneData = _database.GetSceneDataByName(sceneName);
            ScenesLoadOperation loadOperation = LoadScene(targetSceneData);
            return loadOperation;
        }

        #endregion

        #region Load Scenes Group Methods

        /// <summary>
        /// Load scenes groups. Scenes not included in loading group or always loaded scenes will be unload.
        /// </summary>
        /// <param name="scenesGroup">Scenes group to load.</param>
        /// <returns>Scene load async operations wrapper.</returns>
        public ScenesLoadOperation LoadScenesGroup(ScenesGroup scenesGroup)
        {
            foreach (SceneData loadedSceneData in _loadedScenes)
            {
                if (_database.AlwaysLoadedScenes.Contains(loadedSceneData))
                    continue;

                _scenesToUnload.Add(loadedSceneData);
            }

            if (_mainCameraHandling)
            {
                bool needChangeActiveScene = _scenesToUnload.Exists(s => s.SceneLoadType == SceneLoadType.Active);
                bool activeSceneInLoadGroupExists = scenesGroup.Scenes.Exists(s => s.SceneLoadType == SceneLoadType.Active);

                if (needChangeActiveScene && activeSceneInLoadGroupExists == false)
                {
                    throw new ArgumentException($"Not found active scene to camera moving in: {scenesGroup.GroupName} scenes group.");
                }
            }

            ScenesLoadOperation scenesLoadOperation = new ScenesLoadOperation();

            foreach (SceneData sceneData in scenesGroup.Scenes)
            {
                bool activationMode = sceneData.GetActivationMode();
                int priority = sceneData.LoadPriority;
            
                switch (sceneData.AssetType)
                {
                    case SceneAssetType.LocalAsset:
                        AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneData.SceneAssetName, sceneData.LoadMode);
                        loadSceneOperation.allowSceneActivation = activationMode;
                        loadSceneOperation.priority = priority;
                        scenesLoadOperation.RegisterSceneLoadAsyncOperation(sceneData, loadSceneOperation);
                        break;
                
                    case SceneAssetType.AddressableAsset:
                        AsyncOperationHandle<SceneInstance> loadSceneOperationHandle = sceneData.SceneAssetReference.LoadSceneAsync(sceneData.LoadMode, activationMode, priority);
                        scenesLoadOperation.RegisterSceneLoadAsyncOperationHandle(sceneData, loadSceneOperationHandle);
                        break;
                }
            }
            
            return scenesLoadOperation;
        }

        #endregion
        
        #endregion
    }
}