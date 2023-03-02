using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using BurningLab.SceneManagement.Attributes;
using BurningLab.SceneManagement.Types;

namespace BurningLab.SceneManagement.Database
{
    /// <summary>
    /// Scene load metadata structure.
    /// </summary>
    [CreateAssetMenu(fileName = "New Scene Data", menuName = "Burning-Lab/Scene Management/Scene Data", order = 51)]
    public class SceneData : ScriptableObject
    {
        #region Settings
        
        [Tooltip("Reference to scene asset.")]
        [SerializeField, SceneAssetField] private string _sceneAsset;

        [Tooltip("Reference to addressable scene asset.")]
        [SerializeField] private AssetReference _sceneAssetReference;

        [Tooltip("Scene loading priority.")]
        [SerializeField] private int _loadPriority;
        
        [Tooltip("Scene asset type. Local or Addressable asset.")]
        [SerializeField] private SceneAssetType _assetType;
        
        [Tooltip("Scene type. Active or Additional scene.")]
        [SerializeField] private SceneLoadType _sceneLoadType;
        
        [Tooltip("Load scene mode. Single or additive.")]
        [SerializeField] private LoadSceneMode _loadMode;

        [Tooltip("Scene activation mode. Auto activation or manual activation.")]
        [SerializeField] private ActivationMode _activationMode;
        
        #endregion

        #region Public Properties
        
        /// <summary>
        /// Scene asset path.
        /// </summary>
        public string SceneAssetPath => _sceneAsset;

        /// <summary>
        /// Reference to addressable scene asset.
        /// </summary>
        public AssetReference SceneAssetReference => _sceneAssetReference;

        /// <summary>
        /// Scene loading priority.
        /// </summary>
        public int LoadPriority => _loadPriority;
        
        /// <summary>
        /// Scene asset name.
        /// </summary>
        public string SceneAssetName => Path.GetFileNameWithoutExtension(_sceneAsset);

        /// <summary>
        /// Scene asset type. Local or Addressable asset.
        /// </summary>
        public SceneAssetType AssetType => _assetType;
        
        /// <summary>
        /// Scene load type. Active or Additional scene.
        /// </summary>
        public SceneLoadType SceneLoadType => _sceneLoadType;
        
        /// <summary>
        /// Scene load mode. Single or Additive.
        /// </summary>
        public LoadSceneMode LoadMode => _loadMode;
        
        /// <summary>
        /// Scene activation mode. Auto or Manual.
        /// </summary>
        public ActivationMode ActivationMode => _activationMode;

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Cast activation mode enum to bool value.
        /// </summary>
        /// <returns>True for auto activation scenes, false for manual activation scenes.</returns>
        public bool GetActivationMode()
        {
            switch (_activationMode)
            {
                case ActivationMode.Auto:
                    return true;
                
                case ActivationMode.Manual:
                    return false;
            }

            return false;
        }
        
        public void SetScene(string scenePath) => _sceneAsset = scenePath;

        #endregion
    }
}