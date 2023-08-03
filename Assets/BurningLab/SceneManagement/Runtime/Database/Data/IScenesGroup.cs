using System.Collections.Generic;

namespace BurningLab.SceneManagement.Database
{
    /// <summary>
    /// Root interface for scenes group implementations.
    /// </summary>
    public interface IScenesGroup
    {
        /// <summary>
        /// Scenes group name.
        /// </summary>
        public string GetScenesGroupName();

        /// <summary>
        /// Included scenes in scene group.
        /// </summary>
        public List<ISceneData> GetScenes();
    }
}