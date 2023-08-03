using System;
using System.Collections.Generic;
using UnityEngine;
using BurningLab.SceneManagement.Database;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace BurningLab.SceneManagement.Types
{
    /// <summary>
    /// Scenes loading operation wrapper.
    /// </summary>
    public class ScenesLoadOperation
    {
        #region Internal Types
        
        /// <summary>
        /// Loading scene data structure.
        /// </summary>
        private struct LoadingScene
        {
            /// <summary>
            /// Loading scene data.
            /// </summary>
            public ISceneData SceneData;
            
            /// <summary>
            /// Loading async operation.
            /// </summary>
            public AsyncOperation AsyncOperation;
            
            /// <summary>
            /// Loading async operation handle.
            /// </summary>
            public AsyncOperationHandle<SceneInstance> AsyncOperationHandle;
            
            /// <summary>
            /// Return progress for addressable scene loading.
            /// </summary>
            /// <param name="operationHandle">Addressable scene operation handle.</param>
            /// <returns>Loading progress.</returns>
            private float GetProgress(AsyncOperationHandle operationHandle)
            {
                return operationHandle.PercentComplete;
            }
            
            /// <summary>
            /// Return progress for local scene loading.
            /// </summary>
            /// <param name="operation">Local scene loading operation.</param>
            /// <returns>Loading progress.</returns>
            private float GetProgress(AsyncOperation operation)
            {
                if (Math.Abs(operation.progress - 0.9f) < 0.1f)
                    return 1;

                return operation.progress;
            }
            
            /// <summary>
            /// Return progress for loading scene.
            /// </summary>
            /// <returns>Loading progress.</returns>
            public float GetProgress()
            {
                SceneAssetType sceneAssetType = SceneData.GetSceneAssetType();
                switch (sceneAssetType)
                {
                    case SceneAssetType.LocalAsset:
                        return GetProgress(AsyncOperation);
                    case SceneAssetType.AddressableAsset:
                        return GetProgress(AsyncOperationHandle);
                }

                return 1;
            }
        }

        #endregion

        #region Private Fields

        /// <summary>
        /// Loading scenes collection.
        /// </summary>
        private readonly List<LoadingScene> _loadingScenes = new();

        #endregion

        #region Public Properties

        public float LoadingProgress
        {
            get
            {
                int loadingScenesCount = _loadingScenes.Count;
                float maxProgress = loadingScenesCount;
                float currentProgress = 0;

                foreach (LoadingScene loadingScene in _loadingScenes)
                {
                    currentProgress += loadingScene.GetProgress();
                }

                return currentProgress / maxProgress;
            }
        }

        public bool IsDone
        {
            get
            {
                bool result = true;
                
                foreach (LoadingScene loadingScene in _loadingScenes)
                {
                    SceneAssetType sceneAssetType = loadingScene.SceneData.GetSceneAssetType();
                    switch (sceneAssetType)
                    {
                        case SceneAssetType.LocalAsset:
                            if (loadingScene.AsyncOperation.isDone)
                                result = false;
                            break;
                        
                        case SceneAssetType.AddressableAsset:
                            if (loadingScene.AsyncOperationHandle.IsDone)
                                result = false;
                            break;
                    }
                }

                return result;
            }
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Add loading scene to operation and register loading async operation.
        /// </summary>
        /// <param name="sceneData">Loading scene data.</param>
        /// <param name="loadOperation">Local scene load async operation.</param>
        public void RegisterSceneLoadAsyncOperation(ISceneData sceneData, AsyncOperation loadOperation)
        {
            LoadingScene loadingScene = new LoadingScene
            {
                SceneData = sceneData,
                AsyncOperation = loadOperation
            };
            
            _loadingScenes.Add(loadingScene);
        }
        
        /// <summary>
        /// Add loading scene to operation and register loading async operation handle.
        /// </summary>
        /// <param name="sceneData">Loading scene data.</param>
        /// <param name="loadOperation">Addressable scene load async operation handle.</param>
        public void RegisterSceneLoadAsyncOperationHandle(ISceneData sceneData, AsyncOperationHandle<SceneInstance> loadOperation)
        {
            LoadingScene loadingScene = new LoadingScene
            {
                SceneData = sceneData,
                AsyncOperationHandle = loadOperation
            };
            
            _loadingScenes.Add(loadingScene);
        }
        
        /// <summary>
        /// Activate loading scenes.
        /// </summary>
        public void ActivateScenes()
        {
            foreach (LoadingScene loadingScene in _loadingScenes)
            {
                SceneAssetType sceneAssetType = loadingScene.SceneData.GetSceneAssetType();
                switch (sceneAssetType)
                {
                    case SceneAssetType.LocalAsset:
                        loadingScene.AsyncOperation.allowSceneActivation = true;
                        break;
                    
                    case SceneAssetType.AddressableAsset:
                        SceneInstance sceneInstance = loadingScene.AsyncOperationHandle.Result;
                        sceneInstance.ActivateAsync();
                        break;
                }
            }
        }

        #endregion
    }
}