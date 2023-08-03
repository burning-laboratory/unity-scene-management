using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement;
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
        
        [Header("Providers")]
        [Tooltip("Scenes database provider instance.")]
        [SerializeReference, SubclassSelector] private IScenesDatabaseProvider _scenesDatabaseProvider;
        
        [Tooltip("Scenes groups database provider instance.")]
        [SerializeReference, SubclassSelector] private IScenesGroupDatabaseProvider _scenesGroupDatabaseProvider;
        
        [Tooltip("Scenes management configuration provider instance.")]
        [SerializeReference, SubclassSelector] private IScenesManagementConfigurationProvider _configurationProvider;
        
        [Header("Settings")]
        [Tooltip("Auto moving main camera game object to active scene.")]
        [SerializeField] private bool _mainCameraHandling;
        
        #endregion

        #region Private Fields
        
        /// <summary>
        /// Main camera reference.
        /// </summary>
        private GameObject _mainCamera;
        
        /// <summary>
        /// List of current loaded scenes.
        /// </summary>
        private List<ISceneData> _loadedScenes = new();
        
        /// <summary>
        /// List of scenes marked to unloading.
        /// </summary>
        private List<ISceneData> _scenesToUnload = new();
        
        /// <summary>
        /// Reference to active scenes database.
        /// </summary>
        private IScenesDatabase _scenesDatabase;
        
        /// <summary>
        /// Reference to active scenes group database.
        /// </summary>
        private IScenesGroupDatabase _scenesGroupDatabase;

        /// <summary>
        /// Reference to active scene management system configuration.
        /// </summary>
        private IScenesManagementConfiguration _scenesManagementConfiguration;
        
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
        public List<ISceneData> LoadedScenes => _loadedScenes;

        /// <summary>
        /// Scenes database reference.
        /// </summary>
        public IScenesDatabase ScenesDatabase => _scenesDatabase;

        public IScenesGroupDatabase ScenesGroupDatabase => _scenesGroupDatabase;

        public IScenesManagementConfiguration Configuration => _scenesManagementConfiguration;
        
        #endregion

        #region Events

        /// <summary>
        /// Scene loaded event.
        /// </summary>
        public event Action<ISceneData> OnSceneLoaded;
        
        /// <summary>
        /// Scene unloaded event.
        /// </summary>
        public event Action<ISceneData> OnSceneUnloaded; 

        #endregion
        
        #region Unity Event Methods

        private void Awake()
        {
            #region Get Database

            _scenesDatabase = _scenesDatabaseProvider.GetScenesDatabase();
            _scenesGroupDatabase = _scenesGroupDatabaseProvider.GetScenesGroupDatabase();
            _scenesManagementConfiguration = _configurationProvider.GetConfiguration();
            
            #endregion
            
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
                    ISceneData loadedSceneData = _scenesDatabase.GetSceneDataByName(scene.name);
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
            ISceneData loadedSceneData = _scenesDatabase.GetSceneDataByName(scene.name);
            _loadedScenes.Add(loadedSceneData);
            
            OnSceneLoaded?.Invoke(loadedSceneData);
            
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
            string loadedSceneName = loadedSceneData.GetSceneAssetName();
            UnityConsole.PrintLog("ScenesSwitcher", "OnSceneLoadedEventHandler", $"Scene loaded: {loadedSceneName}", gameObject);
#endif

            SceneLoadType sceneLoadType = loadedSceneData.GetSceneLoadType();
            if (sceneLoadType == SceneLoadType.Active)
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
                ISceneData sceneData = _scenesToUnload[i];

                SceneAssetType sceneAssetType = sceneData.GetSceneAssetType();
                switch (sceneAssetType)
                {
                    case SceneAssetType.LocalAsset:
                        string sceneName = sceneData.GetSceneAssetName();
                        SceneManager.UnloadSceneAsync(sceneName);
                        break;
                        
                    case SceneAssetType.AddressableAsset:
                        AssetReference addressableSceneReference = sceneData.GetSceneAssetReference();
                        Addressables.UnloadSceneAsync(addressableSceneReference.OperationHandle);
                        break;
                }

                _scenesToUnload.Remove(sceneData);
            }
        }

        private void OnSceneUnloadedEventHandler(Scene scene)
        {
            ISceneData unloadedSceneData = _scenesDatabase.GetSceneDataByName(scene.name);
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
        public void UnloadScene(ISceneData sceneData)
        {
            SceneAssetType sceneAssetType = sceneData.GetSceneAssetType();
            switch (sceneAssetType)
            {
                case SceneAssetType.LocalAsset:
                    string sceneName = sceneData.GetSceneAssetName();
                    SceneManager.UnloadSceneAsync(sceneName);
                    break;
                
                case SceneAssetType.AddressableAsset:
                    AssetReference addressableSceneReference = sceneData.GetSceneAssetReference();
                    Addressables.UnloadSceneAsync(addressableSceneReference.OperationHandle);
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
        public ScenesLoadOperation LoadScene(ISceneData sceneData)
        {
            SceneReloadPolicy sceneReloadPolicy = sceneData.GetSceneReloadPolicy();
            if (_loadedScenes.Contains(sceneData) && sceneReloadPolicy == SceneReloadPolicy.Ignore)
                return new ScenesLoadOperation();

            ScenesLoadOperation scenesLoadOperation = new ScenesLoadOperation();

            bool activationMode = sceneData.GetActivationModeAsBool();
            int priority = sceneData.GetSceneLoadPriority();
            LoadSceneMode loadSceneMode = sceneData.GetSceneLoadMode();
            
            SceneAssetType sceneAssetType = sceneData.GetSceneAssetType();
            switch (sceneAssetType)
            {
                case SceneAssetType.LocalAsset:
                    string sceneName = sceneData.GetSceneAssetName();
                    AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
                    loadSceneOperation.allowSceneActivation = activationMode;
                    loadSceneOperation.priority = priority;
                    scenesLoadOperation.RegisterSceneLoadAsyncOperation(sceneData, loadSceneOperation);
                    break;
                
                case SceneAssetType.AddressableAsset:
                    AssetReference addressableSceneReference = sceneData.GetSceneAssetReference();
                    AsyncOperationHandle<SceneInstance> loadSceneOperationHandle = addressableSceneReference.LoadSceneAsync(loadSceneMode, activationMode, priority);
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
            ISceneData sceneData = _scenesDatabase.GetSceneDataByName(sceneName);
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
            ISceneData targetSceneData = _scenesDatabase.GetSceneDataByName(sceneName);
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
        public ScenesLoadOperation LoadScenesGroup(IScenesGroup scenesGroup)
        {
            foreach (ISceneData loadedSceneData in _loadedScenes)
            {
                List<ISceneData> alwaysLoadedScenes = _scenesManagementConfiguration.GetAlwaysLoadedScenes();
                if (alwaysLoadedScenes.Contains(loadedSceneData))
                    continue;

                _scenesToUnload.Add(loadedSceneData);
            }

            List<ISceneData> scenesListInGroup = scenesGroup.GetScenes();
            if (_mainCameraHandling)
            {
                bool needChangeActiveScene = _scenesToUnload.Exists(s => {
                    SceneLoadType sceneLoadType = s.GetSceneLoadType();
                    return sceneLoadType == SceneLoadType.Active;
                });
                bool activeSceneInLoadGroupExists = scenesListInGroup.Exists(s => {
                    SceneLoadType sceneLoadType = s.GetSceneLoadType();
                    return sceneLoadType == SceneLoadType.Active;
                });

                if (needChangeActiveScene && activeSceneInLoadGroupExists == false)
                {
                    string scenesGroupName = scenesGroup.GetScenesGroupName();
                    throw new ArgumentException($"Not found active scene to camera moving in: {scenesGroupName} scenes group.");
                }
            }

            ScenesLoadOperation scenesLoadOperation = new ScenesLoadOperation();
            foreach (ISceneData sceneData in scenesListInGroup)
            {
                SceneReloadPolicy sceneReloadPolicy = sceneData.GetSceneReloadPolicy();
                if (_loadedScenes.Contains(sceneData) && sceneReloadPolicy == SceneReloadPolicy.Ignore)
                    continue;

                bool activationMode = sceneData.GetActivationModeAsBool();
                int priority = sceneData.GetSceneLoadPriority();
                LoadSceneMode loadSceneMode = sceneData.GetSceneLoadMode();
                
                SceneAssetType sceneAssetType = sceneData.GetSceneAssetType();
                switch (sceneAssetType)
                {
                    case SceneAssetType.LocalAsset:
                        string sceneName = sceneData.GetSceneAssetName();
                        AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
                        loadSceneOperation.allowSceneActivation = activationMode;
                        loadSceneOperation.priority = priority;
                        scenesLoadOperation.RegisterSceneLoadAsyncOperation(sceneData, loadSceneOperation);
                        break;
                
                    case SceneAssetType.AddressableAsset:
                        AssetReference addressableSceneReference = sceneData.GetSceneAssetReference();
                        AsyncOperationHandle<SceneInstance> loadSceneOperationHandle = addressableSceneReference.LoadSceneAsync(loadSceneMode, activationMode, priority);
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