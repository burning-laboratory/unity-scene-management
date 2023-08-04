using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.Database
{
    public class SimpleScenesManagementConfiguration : MonoBehaviour, IScenesManagementConfiguration
    {
        [Header("Settings")] 
        [SerializeReference, SubclassSelector] private List<ISceneDataReference> _alwaysLoadedScenes;

        public List<ISceneData> GetAlwaysLoadedScenes()
        {
            List<ISceneData> alwaysLoadedScenes = new List<ISceneData>();

            for (int i = _alwaysLoadedScenes.Count - 1; i >= 0; i--)
            {
                ISceneDataReference alwaysLoadedSceneReference = _alwaysLoadedScenes[i];
                ISceneData targetAlwaysLoadedScene = alwaysLoadedSceneReference.GetSceneData();
                alwaysLoadedScenes.Add(targetAlwaysLoadedScene);
            }
            
            return alwaysLoadedScenes;
        }
    }
}