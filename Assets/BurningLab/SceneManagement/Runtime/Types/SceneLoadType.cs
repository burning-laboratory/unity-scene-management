namespace BurningLab.SceneManagement.Types
{
    /// <summary>
    /// Scene load type.
    /// </summary>
    [System.Serializable]
    public enum SceneLoadType
    {
        /// <summary>
        /// Load scene as active.
        /// </summary>
        Active = 0,
        
        /// <summary>
        /// Load scene as additional.
        /// </summary>
        Additional = 1,
    }
}