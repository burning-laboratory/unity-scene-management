using BurningLab.SceneManagement.Database;
using TMPro;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.UI
{
    public class UIActiveSceneItem : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private TMP_Text _textField;

        public void Init(SceneData sceneData)
        {
            _textField.SetText(sceneData.SceneAssetName);
        }
    }
}