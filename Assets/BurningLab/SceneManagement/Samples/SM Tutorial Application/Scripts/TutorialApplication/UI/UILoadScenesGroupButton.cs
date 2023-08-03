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
        [SerializeReference, SubclassSelector] private IScenesGroupReference _scenesGroupReference;

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
            IScenesGroup targetScenesGroup = _scenesGroupReference.GetScenesGroup();
            ScenesLoadOperation operation = ScenesSwitcher.Instance.LoadScenesGroup(targetScenesGroup);
            operation.ActivateScenes();
        }
    }
}