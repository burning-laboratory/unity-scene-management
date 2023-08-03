using System.Collections.Generic;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Types;
using TMPro;
using UnityEngine;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.UI
{
    public class UIDatabaseStatsDrawer : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private IScenesDatabase _scenesDatabase;
        [SerializeField] private IScenesManagementConfiguration _configuration;
        [SerializeField] private IScenesGroupDatabase _scenesGroupDatabase;
        
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
            _scenesDatabase = ScenesSwitcher.Instance.ScenesDatabase;
            _configuration = ScenesSwitcher.Instance.Configuration;
            _scenesGroupDatabase = ScenesSwitcher.Instance.ScenesGroupDatabase;
            
            List<ISceneData> alwaysLoadedScenes = _configuration.GetAlwaysLoadedScenes();
            int alwaysLoadedScenesCount = alwaysLoadedScenes.Count;
            _alwaysLoadedScenesCountTextField.SetText(alwaysLoadedScenesCount.ToString());

            List<ISceneData> scenes = _scenesDatabase.GetScenes();
            int scenesCount = scenes.Count;
            _totalScenesCountTextField.SetText(scenesCount.ToString());

            List<IScenesGroup> scenesGroups = _scenesGroupDatabase.GetScenesGroups();
            int scenesGroupsCount = scenesGroups.Count;
            _scenesGroupCountTextField.SetText(scenesGroupsCount.ToString());

            
            int localScenesCount = scenes.FindAll(sd => {
                SceneAssetType sceneAssetType = sd.GetSceneAssetType();
                return sceneAssetType == SceneAssetType.LocalAsset;
            }).Count;
            _localScenesCountTextField.SetText(localScenesCount.ToString());
            
            int addressableScenesCount = scenes.FindAll(sd => {
                SceneAssetType sceneAssetType = sd.GetSceneAssetType();
                return sceneAssetType == SceneAssetType.AddressableAsset;
            }).Count;
            _addressableScenesCountTextField.SetText(addressableScenesCount.ToString());
            
            int activeScenesCount = scenes.FindAll(sd => {
                SceneLoadType sceneLoadType = sd.GetSceneLoadType();
                return sceneLoadType == SceneLoadType.Active;
            }).Count;
            _activeScenesCountTextField.SetText(activeScenesCount.ToString());
            
            int additionalScenesCount = scenes.FindAll(sd => {
                SceneLoadType sceneLoadType = sd.GetSceneLoadType();
                return sceneLoadType == SceneLoadType.Additional;
            }).Count;
            _additionalScenesCountTextField.SetText(additionalScenesCount.ToString());
            
            int autoActivationScenesCount = scenes.FindAll(sd => {
                SceneActivationMode sceneActivationMode = sd.GetActivationMode();
                return sceneActivationMode == SceneActivationMode.Auto;
            }).Count;
            _autoActivationScenesCountTextField.SetText(autoActivationScenesCount.ToString());
            
            int manualActivationScenesCount = scenes.FindAll(sd => {
                SceneActivationMode sceneActivationMode = sd.GetActivationMode();
                return sceneActivationMode == SceneActivationMode.Manual;
            }).Count;
            _manualActivationScenesCountTextField.SetText(manualActivationScenesCount.ToString());
        }
    }
}