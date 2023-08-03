using BurningLab.SceneManagement.Types;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace BurningLab.SceneManagement.Database
{
    /// <summary>
    /// Root interface for scene data assets.
    /// </summary>
    public interface ISceneData
    {
        #region Public Methods

        #region Local Scene Path Methods

        /// <summary>
        /// Set target scene to scene data instance.
        /// </summary>
        /// <param name="scenePath">Target scene path.</param>
        public void SetScene(string scenePath);

        /// <summary>
        /// Scene asset path.
        /// </summary>
        public string GetSceneAssetPath();
        
        /// <summary>
        /// Scene asset name.
        /// </summary>
        public string GetSceneAssetName();
        
        #endregion

        #region Addressable Scene Asset Methods

        /// <summary>
        /// Reference to addressable scene asset.
        /// </summary>
        public AssetReference GetSceneAssetReference();

        /// <summary>
        /// Set target addressable scene.
        /// </summary>
        /// <param name="assetReference">Addressable scene asset reference.</param>
        public void SetScene(AssetReference assetReference);
        
        #endregion

        #region Scene Load Priotity Methods

        /// <summary>
        /// Set scene loading priority.
        /// </summary>
        /// <param name="sceneLoadPriority">Scene load priority.</param>
        public void SetSceneLoadPriority(int sceneLoadPriority);
        
        /// <summary>
        /// Scene loading priority.
        /// </summary>
        public int GetSceneLoadPriority();

        #endregion

        #region Scene Asset Type Methods

        /// <summary>
        /// Set scene asset type.
        /// </summary>
        /// <param name="sceneAssetType">Scene asset type to set.</param>
        public void SetSceneAssetType(SceneAssetType sceneAssetType);
        
        /// <summary>
        /// Scene asset type. Local or Addressable asset.
        /// </summary>
        public SceneAssetType GetSceneAssetType();

        #endregion

        #region Scene Load Type Methods

        /// <summary>
        /// Set scene load type.
        /// </summary>
        /// <param name="sceneLoadType">Scene load type to set.</param>
        public void SetSceneLoadType(SceneLoadType sceneLoadType);
        
        /// <summary>
        /// Scene load type. Active or Additional scene.
        /// </summary>
        public SceneLoadType GetSceneLoadType();

        #endregion

        #region Scene Load Mode Methods

        /// <summary>
        /// Set scene load mode.
        /// </summary>
        /// <param name="sceneLoadMode">Scene load mode to set.</param>
        public void SetSceneLoadMode(LoadSceneMode sceneLoadMode);
        
        /// <summary>
        /// Scene load mode. Single or Additive.
        /// </summary>
        public LoadSceneMode GetSceneLoadMode();

        #endregion

        #region Scene Acitvation Mode Methods

        /// <summary>
        /// Set scene activation mode.
        /// </summary>
        /// <param name="sceneActivationMode">Scene activation mode to set.</param>
        public void SetSceneActivationMode(SceneActivationMode sceneActivationMode);
        
        /// <summary>
        /// Scene activation mode. Auto or Manual.
        /// </summary>
        public SceneActivationMode GetActivationMode();

        /// <summary>
        /// Cast activation mode enum to bool value.
        /// </summary>
        /// <returns>True for auto activation scenes, false for manual activation scenes.</returns>
        public bool GetActivationModeAsBool();
        
        #endregion

        #region Scene Reload Policy Methods

        /// <summary>
        /// Set scene reload policy.
        /// </summary>
        /// <param name="sceneReloadPolicy">Scene reload policy to set.</param>
        public void SetSceneReloadPolicy(SceneReloadPolicy sceneReloadPolicy);
        
        /// <summary>
        /// Policy for scene reloading. Ignore or Allow scene reload.
        /// </summary>
        public SceneReloadPolicy GetSceneReloadPolicy();

        #endregion
        
        #endregion
    }
}