using BurningLab.SceneManagement;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Types;
using UnityEngine;

public class MainSceneLoader : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ScenesSwitcher _scenesSwitcher;

    [Header("Settings")] 
    [SerializeField] private ScenesGroup _mainScenesGroup;

    private bool _isLoadStarting;
    private ScenesLoadOperation _loadOperation;
    
    private void Start()
    {
        _scenesSwitcher = FindObjectOfType<ScenesSwitcher>();
        _loadOperation = _scenesSwitcher.LoadScenesGroup(_mainScenesGroup);
        _isLoadStarting = true;
    }

    private void Update()
    {
        if (_isLoadStarting)
        {
            if (_loadOperation.IsDone)
            {
                Destroy(gameObject);
            }
        }
    }
}
