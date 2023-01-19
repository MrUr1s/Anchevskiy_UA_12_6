using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInterface : MonoBehaviour
{
    public static GameInterface instance;
    private GameMenuControl _gameMenuControl;

    public GameMenuControl GameMenuControl { get => _gameMenuControl;private set => _gameMenuControl = value; }

    private void Awake()
    {
        if(instance == null)
            instance = this;
           GameMenuControl = GetComponentInChildren<GameMenuControl>();
        GameMenuControl.resetGame += ResetGame;
        GameMenuControl.continueGame += ContinueGame;
        GameMenuControl.exit += Exit;
    }

    private void Exit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPaused = true;
    }

    private void ContinueGame()
    {
        GameMenuControl.transform.localScale = Vector3.zero;
        Time.timeScale = 1f;
    }
    private void ResetGame()
    {
        ContinueGame();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");        
    }
}
