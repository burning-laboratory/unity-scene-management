﻿namespace BurningLab.SceneManagement.Types
{
    /// <summary>
    /// Scene activation mode.
    /// </summary>
    public enum SceneActivationMode
    {
        /// <summary>
        /// Activate on load.
        /// </summary>
        Auto = 0,
        
        /// <summary>
        /// Manual activate with ScenesLoadOperation.ActivateScenes.
        /// </summary>
        Manual = 1
    }
}