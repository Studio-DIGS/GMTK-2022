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
        Debug.Log("Going To: " + nextScene);
    }

    public void RestartLevel()
    {

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
