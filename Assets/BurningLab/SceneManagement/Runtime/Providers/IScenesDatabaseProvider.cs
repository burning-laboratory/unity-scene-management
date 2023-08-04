using BurningLab.SceneManagement.Database;

namespace BurningLab.SceneManagement.Providers
{
    /// <summary>
    /// Root interface for custom database providers.
    /// </summary>
    public interface IScenesDatabaseProvider
    {
        /// <summary>
        /// Return active scenes database instance.
        /// </summary>
        /// <returns>Scenes database instance.</returns>
        public IScenesDatabase GetScenesDatabase();
    }
}