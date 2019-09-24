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

    GameState state = GameState.Active;

    // Start is called before the first frame update
    void Start()
    {
        ChangeGameState(state);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (state == GameState.Active)
            {
                ChangeGameState(GameState.Paused);
            }
            else if (state == GameState.Paused)
            {
                ChangeGameState(GameState.Active);
            }
        }
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

    void DisableMenus()
    {
        headsUpDisplay.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        winMenu.gameObject.SetActive(false);
        failMenu.gameObject.SetActive(false);
    }

    void ResumeGame()
    {
        state = GameState.Active;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        DisableMenus();
        headsUpDisplay.gameObject.SetActive(true);
    }

    void PauseGame()
    {
        state = GameState.Paused;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DisableMenus();
        pauseMenu.gameObject.SetActive(true);
    }

    void Win()
    {
        state = GameState.Won;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DisableMenus();
        winMenu.gameObject.SetActive(true);
    }

    void Fail()
    {
        state = GameState.Failed;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DisableMenus();
        failMenu.gameObject.SetActive(true);
    }
}
