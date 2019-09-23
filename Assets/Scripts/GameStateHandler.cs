using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Active,
    Paused,
    Won,
    Failed
}

public class GameStateHandler : MonoBehaviour
{
    public Canvas headsUpDisplay;
    public Canvas pauseMenu;
    public Canvas winMenu;
    public Canvas failMenu;

    GameState state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGameState(GameState gm)
    {
        switch(gm)
        {
            case GameState.Active:
                ResumeGame();
                break;
            case GameState.Paused:
                PauseGame();
                break;
            case GameState.Won:
                Win();
                break;
            case GameState.Failed:
                Fail();
                break;
        }
    }

    void ResumeGame()
    {
        state = GameState.Active;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        headsUpDisplay.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
    }

    void PauseGame()
    {
        state = GameState.Paused;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        headsUpDisplay.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
    }

    void Win()
    {
        ResumeGame();
        Cursor.lockState = CursorLockMode.None;
        headsUpDisplay.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        winMenu.gameObject.SetActive(true);
    }

    void Fail()
    {
        ResumeGame();
        Cursor.lockState = CursorLockMode.None;
        headsUpDisplay.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        failMenu.gameObject.SetActive(true);
    }
}
