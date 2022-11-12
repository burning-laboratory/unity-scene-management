using TMPro;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.UI
{
    public class UIAppVersionDrawer : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private TMP_Text _textField;

        private void Start()
        {
            string version = Application.version;
            _textField.SetText(version);
        }
    }
}