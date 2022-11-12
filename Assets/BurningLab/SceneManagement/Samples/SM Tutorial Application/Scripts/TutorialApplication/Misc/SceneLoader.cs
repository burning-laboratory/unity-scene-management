using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BurningLab.SceneManagement.Samples.SM_Tutorial_Application.Scripts.TutorialApplication.Misc
{
    public class SceneLoader : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private string _sceneName;
        [SerializeField] private float _delay;

        private void Start()
        {
            StartCoroutine(LoadSceneWithDelay(_sceneName, _delay));
        }

        private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}