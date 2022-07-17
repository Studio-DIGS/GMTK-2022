using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    public GameObject levelCompleted;
    [SerializeField]
    private List<Wire> wires;

    public int wiresCut;

    [SerializeField]
    private string nextScene;

    private string mainMenu = "MainMenu";

    public static event Action<int> StopSlot;


    public void CheckForLevelCompleted()
    {
        foreach (Wire wire in wires)
        {
            if (wire.hasBeenHit != true)
            {
                return;
            }
        }
        levelCompleted.SetActive(true);
        Debug.Log("Level Completed!");
    }

    public void TriggerStopSlot(int id)
    {
        if (StopSlot != null)
        {
            StopSlot(id);
        }
    }

    public void RestartLevel()
    {
        //TODO: Restart Level
        /*
            if (Input.GetKeyDown(R))
            {
                SceneManager.LoadScene(name of this scene);
            }
        */
    }

    public void ToNextLevel()
    {
        Debug.Log("Going To: " + nextScene);
    }

    public void ToMainMenu()
    {
        Debug.Log("Going To: " + mainMenu);
        SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
    }
}
