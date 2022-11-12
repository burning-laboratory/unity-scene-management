using System;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Types;
using TMPro;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.UI
{
    public class UIDatabaseStatsDrawer : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private ScenesDatabase _database;

        [Header("Text fields")] 
        [SerializeField] private TMP_Text _alwaysLoadedScenesCountTextField;
        [SerializeField] private TMP_Text _totalScenesCountTextField;
        [SerializeField] private TMP_Text _scenesGroupCountTextField;
        [SerializeField] private TMP_Text _localScenesCountTextField;
        [SerializeField] private TMP_Text _addressableScenesCountTextField;
        [SerializeField] private TMP_Text _activeScenesCountTextField;
        [SerializeField] private TMP_Text _additionalScenesCountTextField;
        [SerializeField] private TMP_Text _autoActivationScenesCountTextField;
        [SerializeField] private TMP_Text _manualActivationScenesCountTextField;

        private void Start()
        {
            int alwaysLoadedScenesCount = _database.AlwaysLoadedScenes.Count;
            _alwaysLoadedScenesCountTextField.SetText(alwaysLoadedScenesCount.ToString());

            int scenesCount = _database.Scenes.Count;
            _totalScenesCountTextField.SetText(scenesCount.ToString());
            
            int scenesGroupsCount = _database.SceneGroups.Count;
            _scenesGroupCountTextField.SetText(scenesGroupsCount.ToString());

            int localScenesCount = _database.Scenes.FindAll(sd => sd.AssetType == SceneAssetType.LocalAsset).Count;
            _localScenesCountTextField.SetText(localScenesCount.ToString());
            
            int addressableScenesCount = _database.Scenes.FindAll(sd => sd.AssetType == SceneAssetType.AddressableAsset).Count;
            _addressableScenesCountTextField.SetText(addressableScenesCount.ToString());

            int activeScenesCount = _database.Scenes.FindAll(sd => sd.SceneLoadType == SceneLoadType.Active).Count;
            _activeScenesCountTextField.SetText(activeScenesCount.ToString());
            
            int additionalScenesCount = _database.Scenes.FindAll(sd => sd.SceneLoadType == SceneLoadType.Additional).Count;
            _additionalScenesCountTextField.SetText(additionalScenesCount.ToString());
            
            int autoActivationScenesCount = _database.Scenes.FindAll(sd => sd.ActivationMode == ActivationMode.Auto).Count;
            _autoActivationScenesCountTextField.SetText(autoActivationScenesCount.ToString());
            
            int manualActivationScenesCount = _database.Scenes.FindAll(sd => sd.ActivationMode == ActivationMode.Manual).Count;
            _manualActivationScenesCountTextField.SetText(manualActivationScenesCount.ToString());
        }
    }
}