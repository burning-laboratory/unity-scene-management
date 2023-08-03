using BurningLab.SceneManagement.Database;

namespace BurningLab.SceneManagement
{
    /// <summary>
    /// Root scenes groups database provider interface.
    /// </summary>
    public interface IScenesGroupDatabaseProvider
    {
        /// <summary>
        /// Return active scenes group database instance.
        /// </summary>
        /// <returns>Scenes group database instance.</returns>
        public IScenesGroupDatabase GetScenesGroupDatabase();
    }
}