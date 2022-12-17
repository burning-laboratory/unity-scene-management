namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.AppLoader.Types
{
    [System.Serializable]
    public enum LoadStageType
    {
        Delay = 0,
        LoadScene = 1,
        LoadScenesGroup = 2,
        ScenesGroupActivation = 3,
        WaitAnyKeyDown = 4
    }
}