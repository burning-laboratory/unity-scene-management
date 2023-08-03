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
        /// <summary>
        /// Scene asset path.
        /// </summary>
        public string GetSceneAssetPath();

        /// <summary>
        /// Reference to addressable scene asset.
        /// </summary>
        public AssetReference GetSceneAssetReference();

        /// <summary>
        /// Scene loading priority.
        /// </summary>
        public int GetSceneLoadPriority();

        /// <summary>
        /// Scene asset name.
        /// </summary>
        public string GetSceneAssetName();

        /// <summary>
        /// Scene asset type. Local or Addressable asset.
        /// </summary>
        public SceneAssetType GetSceneAssetType();

        /// <summary>
        /// Scene load type. Active or Additional scene.
        /// </summary>
        public SceneLoadType GetSceneLoadType();

        /// <summary>
        /// Scene load mode. Single or Additive.
        /// </summary>
        public LoadSceneMode GetSceneLoadMode();

        /// <summary>
        /// Scene activation mode. Auto or Manual.
        /// </summary>
        public SceneActivationMode GetActivationMode();

        /// <summary>
        /// Policy for scene reloading. Ignore or Allow scene reload.
        /// </summary>
        public SceneReloadPolicy GetSceneReloadPolicy();

        /// <summary>
        /// Cast activation mode enum to bool value.
        /// </summary>
        /// <returns>True for auto activation scenes, false for manual activation scenes.</returns>
        public bool GetActivationModeAsBool();
        
        /// <summary>
        /// Set target scene to scene data instance.
        /// </summary>
        /// <param name="scenePath">Target scene path.</param>
        public void SetScene(string scenePath);
    }
}