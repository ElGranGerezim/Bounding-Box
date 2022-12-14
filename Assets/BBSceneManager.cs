using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BBSceneManager : MonoBehaviour
{
    public void LoadMainMenu () {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel (int lvlNumber) {
        string levelName = "level" + lvlNumber;
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit () {
        Application.Quit();
    }
}
