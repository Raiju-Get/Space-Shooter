using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    ScoreKeepers scoreKeepers;
    private void Awake()
    {
        scoreKeepers = FindObjectOfType<ScoreKeepers>();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        scoreKeepers.ResetScore(); 

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
