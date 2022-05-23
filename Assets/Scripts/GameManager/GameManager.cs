using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas gameOver_canvas;

    public Canvas victory_canvas;

    public Easy_Movement Easy_Movement;
    public Normal_Movement Normal_Movement;
    public Hard_Movement Hard_Movement;

    bool easyActive, regularActive, hardActive;

    void Start()
    {
        easyActive = true;
    }

    public void GameOver()
    {
        Behaviour bhvr = (Behaviour)gameOver_canvas;
        bhvr.enabled = true;
    }

    public void Quit() // Quit Game
    {
        Application.Quit();

    }

    public void Reset() // Resets Game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Victory()
    {
        Behaviour bhvr = (Behaviour)victory_canvas;
        bhvr.enabled = true;
    }

    public void EasyMovement()
    {
        if(!easyActive)
        {
            Easy_Movement.enabled = true;
            easyActive = true;
        }
        
        if(regularActive)
        {
            Normal_Movement.enabled = false;
            regularActive = false;
        }

        if(hardActive)
        {
            Hard_Movement.enabled = false;
            hardActive = false;
        }
    }
    
    public void RegularMovement()
    {
        if(!regularActive)
        {
            Normal_Movement.enabled = true;
            regularActive = true;
        }
        
        if(easyActive)
        {
            Easy_Movement.enabled = false;
            easyActive = false;
        }

        if(hardActive)
        {
            Hard_Movement.enabled = false;
            hardActive = false;
        }
    }

    public void HardMovement()
    {
        if(!hardActive)
        {
            Hard_Movement.enabled = true;
            hardActive = true;
        }
        
        if(easyActive)
        {
            Easy_Movement.enabled = false;
            easyActive = false;
        }

        if(regularActive)
        {
            Normal_Movement.enabled = false;
            regularActive = false;
        }
    }
}