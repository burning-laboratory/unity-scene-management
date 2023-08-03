using System.Collections.Generic;

namespace BurningLab.SceneManagement.Database
{
    /// <summary>
    /// Root interface for scenes database implementations.
    /// </summary>
    public interface IScenesDatabase
    {
        /// <summary>
        /// Return all included scenes lists.
        /// </summary>
        /// <returns>All included scenes list.</returns>
        public List<ISceneData> GetScenes();
        
        /// <summary>
        /// Return scene data by name.
        /// </summary>
        /// <param name="sceneName">Target scene data name.</param>
        /// <returns>Scene data with requested name.</returns>
        public ISceneData GetSceneDataByName(string sceneName);
        
        /// <summary>
        /// Return true if scene data with requested path exists.
        /// </summary>
        /// <param name="scenePath">Target scene path.</param>
        /// <returns>True if scene data with path exists.</returns>
        public bool SceneDataExists(string scenePath);
    }
}