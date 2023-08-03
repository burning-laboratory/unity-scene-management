using BurningLab.SceneManagement.Database;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.AppLoader.Types
{
    [System.Serializable]
    public struct LoadStage
    {
        public string stageName;
        public LoadStageType type;
        public string sceneName;
        public float delay;
        [SerializeReference, SubclassSelector] public IScenesGroupReference scenesGroup;
    }
}