using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//I didn't want to mess with the other UI Manager script so I made a new one for the main menu
public class MenuUIManager : MonoBehaviour
{
    //This canvas will be hidden upon Level Select 
    public GameObject mainCanvas;

    //This is the level select "screen" that replaces main canvas upon Level Select
    public GameObject levelSelectCanvas;

    private void Awake()
    {
        levelSelectCanvas.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        mainCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(3);
    }

    public void BackButton()
    {
        levelSelectCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
