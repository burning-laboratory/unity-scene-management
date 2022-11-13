using System;
using System.Collections;
using System.Collections.Generic;
using BurningLab.SceneManagement;
using BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.AppLoader.Types;
using BurningLab.SceneManagement.Types;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleAppLoader : MonoBehaviour
{
    [Header("Settings")] [SerializeField] private float _delay;
    [SerializeField] private List<LoadStage> _stages;

    public int StagesCount => _stages.Count;

    public event Action<LoadStage> OnStartStage;
    public event Action<LoadStage> OnEndStage;

    private ScenesLoadOperation _operation;
    
    private bool LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        return true;
    }
    
    private IEnumerator Start()
    {
        DontDestroyOnLoad(gameObject);

        foreach (LoadStage stage in _stages)
        {
            OnStartStage?.Invoke(stage);
            Debug.Log($"Start stage: {stage.stageName}");        
            Debug.Log(stage.type);
            switch (stage.type)
            {
                case LoadStageType.Delay:
                    yield return new WaitForSeconds(stage.delay);
                    break;
                
                case LoadStageType.LoadScene:
                    yield return LoadScene(stage.sceneName);
                    break;
                
                case LoadStageType.LoadScenesGroup: 
                    _operation = ScenesSwitcher.Instance.LoadScenesGroup(stage.scenesGroup);
                    while (_operation.IsDone == false)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    break;
                
                case LoadStageType.ScenesGroupActivation:
                    _operation.ActivateScenes();
                    break;
                
                case LoadStageType.WaitAnyKeyDown:
                    while (Input.anyKeyDown == false)
                    {
                        if (Input.anyKey)
                        {
                            break;
                        }
                        yield return new WaitForEndOfFrame();
                    }
                    break;
            }
            
            OnEndStage?.Invoke(stage);
        }

        yield return new WaitForSeconds(_delay);
        Destroy(gameObject);
    }
}
