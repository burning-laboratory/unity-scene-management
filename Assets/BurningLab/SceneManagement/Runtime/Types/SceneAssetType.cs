namespace BurningLab.SceneManagement.Types
{
    /// <summary>
    /// Scene asset type. Local or addressable scene.
    /// </summary>
    public enum SceneAssetType
    {
        /// <summary>
        /// Local scene asset.
        /// </summary>
        LocalAsset = 0,
        
        /// <summary>
        /// Addressable scene asset.
        /// </summary>
        AddressableAsset = 1,
    }
}