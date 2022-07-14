using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitDoor : MonoBehaviour
{
    [SerializeField]
    float _levelLoadDelay = 3f;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(_levelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
