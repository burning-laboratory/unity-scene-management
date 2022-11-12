using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleAppLoader : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private List<string> _scenesToLoad;
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        foreach (string sceneName in _scenesToLoad)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        
        Destroy(gameObject);
    }
}
