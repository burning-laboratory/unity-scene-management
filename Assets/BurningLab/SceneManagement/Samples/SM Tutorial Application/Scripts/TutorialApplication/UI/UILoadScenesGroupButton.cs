using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Types;
using UnityEngine;
using UnityEngine.UI;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.UI
{
    [RequireComponent(typeof(Button))]
    public class UILoadScenesGroupButton : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Button _loadButton;

        [Header("Settings")] 
        [SerializeField] private ScenesGroup _scenesGroup;

        private void Awake()
        {
            _loadButton = GetComponent<Button>();
        }

        private void Start()
        {
            _loadButton.onClick.AddListener(OnLoadButtonClick);
        }

        private void OnDestroy()
        {
            _loadButton.onClick.RemoveListener(OnLoadButtonClick);
        }

        private void OnLoadButtonClick()
        {
            ScenesLoadOperation operation = ScenesSwitcher.Instance.LoadScenesGroup(_scenesGroup);
            operation.ActivateScenes();
        }
    }
}