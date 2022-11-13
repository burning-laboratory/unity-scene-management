using BurningLab.SceneManagement.Database;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.AppLoader.Types
{
    [System.Serializable]
    public struct LoadStage
    {
        public string stageName;
        public LoadStageType type;
        public string sceneName;
        public float delay;
        public ScenesGroup scenesGroup;
    }
}