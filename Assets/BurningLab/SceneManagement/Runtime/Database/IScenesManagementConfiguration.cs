using System.Collections.Generic;

namespace BurningLab.SceneManagement.Database
{
    /// <summary>
    /// Root interface for scene management configurations.
    /// </summary>
    public interface IScenesManagementConfiguration
    {
        /// <summary>
        /// Return always loaded scenes list.
        /// </summary>
        /// <returns>Always loaded scenes list.</returns>
        public List<ISceneData> GetAlwaysLoadedScenes();
    }
}