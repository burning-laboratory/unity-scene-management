using System.Collections.Generic;

namespace BurningLab.SceneManagement.Database
{
    /// <summary>
    /// Root interface for scenes groups database.
    /// </summary>
    public interface IScenesGroupDatabase
    {
        /// <summary>
        /// Return all registered scenes group data.
        /// </summary>
        /// <returns></returns>
        public List<IScenesGroup> GetScenesGroups();
        
        /// <summary>
        /// Return scenes group by name.
        /// </summary>
        /// <param name="scenesGroupName">Target scenes group name.</param>
        /// <returns>Scenes group with target name.</returns>
        public IScenesGroup GetScenesGroupByName(string scenesGroupName);
    }
}