using System.IO;
using UnityEngine.SceneManagement;
using BurningLab.SceneManagement.Attributes;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Types;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.Database
{
    /// <summary>
    /// Scene data instance as mono behaviour component.
    /// </summary>
    [System.Serializable]
    public class SimpleSceneData : MonoBehaviour, ISceneData
    {
        #region Settings

        [Tooltip("Target scene path displayed ad scene field selector.")]
        [SerializeField, SceneAssetField] private string _targetScene;
        
        [Tooltip("Target addressable scene asset reference.")]
        [SerializeField] private AssetReference _sceneAssetReference;
        
        [Tooltip("Target scene asset type. Local or Addressable.")]
        [SerializeField] private SceneAssetType _sceneAssetType;
        
        [Tooltip("Target scene load priority.")]
        [SerializeField] private int _loadPriority;
        
        [Tooltip("Target scene load type. Active or Additional.")]
        [SerializeField] private SceneLoadType _sceneLoadType;
        
        [Tooltip("Target scene load mode. Single or Additive.")]
        [SerializeField] private LoadSceneMode _sceneLoadMode;
        
        [Tooltip("Target scene activation mode. Auto or Manual.")]
        [SerializeField] private SceneActivationMode _sceneActivationMode;
        
        [Tooltip("Target scene reload policy. Ignore or ForceReload.")]
        [SerializeField] private SceneReloadPolicy _sceneReloadPolicy;

        #endregion

        #region Public Methods

        #region Local Scene Path Methods
        
        /// <summary>
        /// Set target scene path.
        /// </summary>
        /// <param name="scenePath">Target scene path.</param>
        public void SetScene(string scenePath) => _targetScene = scenePath;
        
        /// <summary>
        /// Return local scene asset path.
        /// </summary>
        /// <returns>Local scene asset path.</returns>
        public string GetSceneAssetPath() => _targetScene;
        
        /// <summary>
        /// Return local scene asset name.
        /// </summary>
        /// <returns>Local scene asset name.</returns>
        public string GetSceneAssetName() => Path.GetFileNameWithoutExtension(_targetScene);

        #endregion

        #region Addressable Scene Asset Methods

        /// <summary>
        /// Set addressable scene asset reference.
        /// </summary>
        /// <param name="assetReference">Target addressable scene asset reference.</param>
        public void SetScene(AssetReference assetReference) => _sceneAssetReference = assetReference;
        
        /// <summary>
        /// Return target addressable scene asset reference.
        /// </summary>
        /// <returns>Target addressable scene asset reference.</returns>
        public AssetReference GetSceneAssetReference() => _sceneAssetReference;

        #endregion

        #region Scene Load Priotity Methods
        
        /// <summary>
        /// Set target scene load priority.
        /// </summary>
        /// <param name="sceneLoadPriority">Scene load priority.</param>
        public void SetSceneLoadPriority(int sceneLoadPriority) => _loadPriority = sceneLoadPriority;
        
        /// <summary>
        /// Return target scene load priority.
        /// </summary>
        /// <returns>Target scene load priority.</returns>
        public int GetSceneLoadPriority() => _loadPriority;
        
        #endregion

        #region Scene Asset Type Methods
        
        /// <summary>
        /// Set target scene asset type. Local or Addressable scene.
        /// </summary>
        /// <param name="sceneAssetType">Type of target scene asset.</param>
        public void SetSceneAssetType(SceneAssetType sceneAssetType) => _sceneAssetType = sceneAssetType;
        
        /// <summary>
        /// Return target scene asset type.
        /// </summary>
        /// <returns>Target scene asset type.</returns>
        public SceneAssetType GetSceneAssetType() => _sceneAssetType;

        #endregion

        #region Scene Load Type Methods
        
        /// <summary>
        /// Set target scene load type. Active or Additional scenes.
        /// </summary>
        /// <param name="sceneLoadType">Scene load type.</param>
        public void SetSceneLoadType(SceneLoadType sceneLoadType) => _sceneLoadType = sceneLoadType;
        
        /// <summary>
        /// Return target scene load type.
        /// </summary>
        /// <returns>Scene load type.</returns>
        public SceneLoadType GetSceneLoadType() => _sceneLoadType;

        #endregion
        
        #region Scene Load Mode Methods
        
        /// <summary>
        /// Set target scene load mode. Single or Additive.
        /// </summary>
        /// <param name="sceneLoadMode"></param>
        public void SetSceneLoadMode(LoadSceneMode sceneLoadMode) => _sceneLoadMode = sceneLoadMode;
        
        /// <summary>
        /// Return target scene load mode.
        /// </summary>
        /// <returns>Target scene load mode.</returns>
        public LoadSceneMode GetSceneLoadMode() => _sceneLoadMode;

        #endregion

        #region Scene Acitvation Mode Methods
        
        /// <summary>
        /// Set target scene activation mode.
        /// </summary>
        /// <param name="sceneActivationMode">Scene activation mode.</param>
        public void SetSceneActivationMode(SceneActivationMode sceneActivationMode) => _sceneActivationMode = sceneActivationMode;
        
        /// <summary>
        /// Return target scene activation mode.
        /// </summary>
        /// <returns>Target scene activation mode.</returns>
        public SceneActivationMode GetActivationMode() => _sceneActivationMode;
        
        /// <summary>
        /// Return target scene activation mode converted to bool value.
        /// True - Allow auto scene activation after load.
        /// False - Block auto scene activation after load.
        /// </summary>
        /// <returns>Target scene activation mode as bool value.</returns>
        public bool GetActivationModeAsBool()
        {
            switch (_sceneActivationMode)
            {
                case SceneActivationMode.Auto:
                    return true;

                case SceneActivationMode.Manual:
                    return false;
            }

            return false;
        }
        
        #endregion

        #region Scene Reload Policy Methods
        
        /// <summary>
        /// Set target scene reload policy.
        /// </summary>
        /// <param name="sceneReloadPolicy">Scene reload policy to set.</param>
        public void SetSceneReloadPolicy(SceneReloadPolicy sceneReloadPolicy) => _sceneReloadPolicy = sceneReloadPolicy;
        
        /// <summary>
        /// Return target scene reload policy.
        /// </summary>
        /// <returns>Target scene reload policy.</returns>
        public SceneReloadPolicy GetSceneReloadPolicy() => _sceneReloadPolicy;

        #endregion
        
        #endregion
    }
}