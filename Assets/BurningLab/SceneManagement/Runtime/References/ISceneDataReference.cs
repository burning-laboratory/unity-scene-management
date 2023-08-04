using BurningLab.SceneManagement.Database;

namespace BurningLab.SceneManagement.References
{
    /// <summary>
    /// Root interfaces for scene data references implementations.
    /// </summary>
    public interface ISceneDataReference
    {
        /// <summary>
        /// Return linked scene data instance.
        /// </summary>
        /// <returns>Linked scene data instance.</returns>
        public ISceneData GetSceneData();
    }
}