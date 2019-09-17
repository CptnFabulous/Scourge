using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
   
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    #region levelselect
    public void Level1Select()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2Select()
    {
        SceneManager.LoadScene(2);
    }
    public void Level3Select()
    {
        SceneManager.LoadScene(3);
    }
    #endregion
    public void Quit()
    {
        Application.Quit();
    }
}
