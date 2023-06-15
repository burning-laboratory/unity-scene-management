namespace BurningLab.SceneManagement.Types
{
    /// <summary>
    /// Policy for scene reloading.
    /// </summary>
    [System.Serializable]
    public enum SceneReloadPolicy
    {
        /// <summary>
        /// Ignore scene reloading.
        /// </summary>
        Ignore = 0,
        
        /// <summary>
        /// Allow scene reloading.
        /// </summary>
        ForceReload = 1
    }
}