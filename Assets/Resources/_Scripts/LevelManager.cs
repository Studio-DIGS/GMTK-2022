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
    private int value = 1000;
    public FloatSO playerScore;

    [SerializeField]
    private int nextScene = 1;

    [SerializeField] AudioSource gameplayMusic;
    private PlayerVolume playerVolume;

    private string mainMenu = "MainMenu";
    private object elseif;

    public static event Action<int> StopSlot;
    public static event Action BeatLevel;

    private void Awake() 
    {
        playerVolume = GameObject.Find("PlayerSettings").GetComponent<PlayerVolume>();
    }

    private void Start() 
    {
        gameplayMusic.volume = playerVolume.volumePercent;
    }

    public void CheckForLevelCompleted()
    {
        foreach (Wire wire in wires)
        {
            if (wire.hasBeenHit != true)
            {
                return;
            }
        }
        playerScore.Value += value;
        levelCompleted.SetActive(true);
        TriggerBeatLevel();
        Debug.Log("Level Completed!");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            {
            RestartLevel(); 
            } 
    }

    public void TriggerStopSlot(int id)
    {
        if (StopSlot != null)
        {
            StopSlot(id);
        }
    }

    public void TriggerBeatLevel()
    {
        if (BeatLevel != null)
        {
            BeatLevel();
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
        nextScene =SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void ToMainMenu()
    {
        Debug.Log("Going To: " + mainMenu);
        SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
    }
}
