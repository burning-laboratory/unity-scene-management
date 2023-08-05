using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.References;
using UnityEngine;
using UnityEngine.UI;

namespace BurningLab.SceneManagement.Samples.MinimalSetupSample.Ui
{
    /// <summary>
    /// Load target scenes group on target button click.
    /// </summary>
    public class UiLoadSimpleScenesGroupButton : MonoBehaviour
    {
        #region Settings

        [Header("Components")] 
        [Tooltip("Reference to target button for clicks handling.")]
        [SerializeField] private Button _targetButton;
        
        [Header("Settings")] 
        [Tooltip("Reference to target scenes group to load.")]
        [SerializeReference, SubclassSelector] private IScenesGroupReference _targetScenesGroupReference;
        

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handle a click on target button.
        /// </summary>
        private void OnTargetButtonClickEventHandler()
        {
            IScenesGroup scenesGroup = _targetScenesGroupReference.GetScenesGroup();
            
            ScenesSwitcher scenesSwitcher = ScenesSwitcher.Instance;
            scenesSwitcher.LoadScenesGroup(scenesGroup);
        }

        #endregion

        #region Unity Event Methods

        private void OnEnable()
        {
            _targetButton.onClick.AddListener(OnTargetButtonClickEventHandler);
        }

        private void OnDisable()
        {
            _targetButton.onClick.RemoveAllListeners();
        }

        #endregion
    }
}