using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using BurningLab.SceneManagement.Attributes;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Types;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension
{
    /// <summary>
    /// Scene load metadata structure.
    /// </summary>
    [CreateAssetMenu(menuName = "Burning-Lab/Scenes Management/Extensions/Local Scenes Database Extension/Local Scene Data", fileName = "New Local Scene Data", order = 51)]
    public class LocalSceneData : ScriptableObject, ISceneData
    {
        #region Settings
        
        [Tooltip("Reference to scene asset.")]
        [SerializeField, SceneAssetField] private string _sceneAsset;

        [Tooltip("Reference to addressable scene asset.")]
        [SerializeField] private AssetReference _sceneAssetReference;
        
        [Header("Loading settings")]
        [Tooltip("Scene loading priority.")]
        [SerializeField] private int _loadPriority;
        
        [Tooltip("Scene asset type. Local or Addressable asset.")]
        [SerializeField] private SceneAssetType _assetType;
        
        [Tooltip("Scene type. Active or Additional scene.")]
        [SerializeField] private SceneLoadType _sceneLoadType;
        
        [Tooltip("Load scene mode. Single or additive.")]
        [SerializeField] private LoadSceneMode _loadMode;

        [Tooltip("Scene activation mode. Auto activation or manual activation.")]
        [SerializeField] private SceneActivationMode _activationMode;

        [Header("Other settings")]
        [Tooltip("Policy for scene reloading. Ignore or Allow scene reload.")]
        [SerializeField] private SceneReloadPolicy _sceneReloadPolicy;
        
        #endregion

        #region Public Methods
        
        /// <summary>
        /// Scene asset path.
        /// </summary>
        public string GetSceneAssetPath() => _sceneAsset;

        /// <summary>
        /// Reference to addressable scene asset.
        /// </summary>
        public AssetReference GetSceneAssetReference() => _sceneAssetReference;

        /// <summary>
        /// Scene loading priority.
        /// </summary>
        public int GetSceneLoadPriority() => _loadPriority;
        
        /// <summary>
        /// Scene asset name.
        /// </summary>
        public string GetSceneAssetName() => Path.GetFileNameWithoutExtension(_sceneAsset);

        /// <summary>
        /// Scene asset type. Local or Addressable asset.
        /// </summary>
        public SceneAssetType GetSceneAssetType() => _assetType;
        
        /// <summary>
        /// Scene load type. Active or Additional scene.
        /// </summary>
        public SceneLoadType GetSceneLoadType() => _sceneLoadType;
        
        /// <summary>
        /// Scene load mode. Single or Additive.
        /// </summary>
        public LoadSceneMode GetSceneLoadMode() => _loadMode;
        
        /// <summary>
        /// Scene activation mode. Auto or Manual.
        /// </summary>
        public SceneActivationMode GetActivationMode() => _activationMode;
        
        /// <summary>
        /// Policy for scene reloading. Ignore or Allow scene reload.
        /// </summary>
        public SceneReloadPolicy GetSceneReloadPolicy() => _sceneReloadPolicy;
        
        /// <summary>
        /// Cast activation mode enum to bool value.
        /// </summary>
        /// <returns>True for auto activation scenes, false for manual activation scenes.</returns>
        public bool GetActivationModeAsBool()
        {
            switch (_activationMode)
            {
                case SceneActivationMode.Auto:
                    return true;
                
                case SceneActivationMode.Manual:
                    return false;
            }

            return false;
        }
        
        /// <summary>
        /// Set reference to target scene.
        /// </summary>
        /// <param name="scenePath">Target scene path.</param>
        public void SetScene(string scenePath) => _sceneAsset = scenePath;

        #endregion
    }
}