using System.Collections.Generic;
using BurningLab.SceneManagement.References;

namespace BurningLab.SceneManagement.Database
{
    /// <summary>
    /// Root interface for scenes group implementations.
    /// </summary>
    public interface IScenesGroup
    {
        /// <summary>
        /// Set scenes group name.
        /// </summary>
        /// <param name="scenesGroupName">Scenes group name to set.</param>
        public void SetScenesGroupName(string scenesGroupName);
        
        /// <summary>
        /// Scenes group name.
        /// </summary>
        public string GetScenesGroupName();

        /// <summary>
        /// Set scenes group scenes lists.
        /// </summary>
        /// <param name="sceneReferences">List of scenes references to set.</param>
        public void SetScenes(List<ISceneDataReference> sceneReferences);
        
        /// <summary>
        /// Included scenes in scene group.
        /// </summary>
        public List<ISceneData> GetScenes();
    }
}