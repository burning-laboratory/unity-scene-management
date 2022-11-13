using BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.AppLoader.Types;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.UI
{
    public class UIAppLoadProgressDrawer : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private SimpleAppLoader _appLoader;
        [SerializeField] private TMP_Text _stageNameTextField;
        [SerializeField] private Slider _progressSlider;

        private float _completedStagesCount;

        private void Awake()
        {
            _appLoader.OnStartStage += OnStartLoadStageEventHandler;
            _appLoader.OnEndStage += OnEndLoadStageEventHandler;
        }

        private void OnDestroy()
        {
            _appLoader.OnStartStage -= OnStartLoadStageEventHandler;
            _appLoader.OnEndStage -= OnEndLoadStageEventHandler;
        }

        private void OnStartLoadStageEventHandler(LoadStage stage)
        {
            _stageNameTextField.SetText(stage.stageName);
            
            float maxProgress = _appLoader.StagesCount;
            float progress = _completedStagesCount / maxProgress;
            _progressSlider.value = progress;
        }
        
        private void OnEndLoadStageEventHandler(LoadStage stage)
        {
            _completedStagesCount++;
            
            float maxProgress = _appLoader.StagesCount;
            float progress = _completedStagesCount / maxProgress;
            _progressSlider.value = progress;
        }
    }
}