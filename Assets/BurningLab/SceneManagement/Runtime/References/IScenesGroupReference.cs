﻿using BurningLab.SceneManagement.Database;

namespace BurningLab.SceneManagement.References
{
    /// <summary>
    /// Root interface for scenes group data reference implementations.
    /// </summary>
    public interface IScenesGroupReference
    {
        /// <summary>
        /// Return linked scenes group instance.
        /// </summary>
        /// <returns>Linked scenes group instance.</returns>
        public IScenesGroup GetScenesGroup();
    }
}