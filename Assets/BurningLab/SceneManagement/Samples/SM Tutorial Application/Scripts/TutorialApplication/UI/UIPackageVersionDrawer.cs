using TMPro;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.UI
{
    public class UIPackageVersionDrawer : MonoBehaviour
    {
        [System.Serializable]
        private struct Manifest
        {
            public string version;
        }
        
        [Header("Components")] 
        [SerializeField] private TMP_Text _textField;
        
        [Header("Settings")]
        [SerializeField] private TextAsset _packageManifest;

        private void Start()
        {
            Manifest manifest = JsonUtility.FromJson<Manifest>(_packageManifest.text);
            _textField.SetText(manifest.version);
        }
    }
}