using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject levelCompleted;
    [SerializeField]
    private List<Wire> wires;

    [SerializeField]
    private string nextScene;

    private string mainMenu = "MainMenu";
    private object elseif;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            {
            RestartLevel(); 
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
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Pressed R");
   
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
