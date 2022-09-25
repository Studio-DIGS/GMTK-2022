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
    private string victoryScreen = "WinScreen";
    private object elseif;

    public static event Action<int> StopSlot;
    public static event Action BeatLevel;

    private void Awake() 
    {
        playerVolume = GameObject.FindWithTag("Settings").GetComponent<PlayerVolume>();
        gameplayMusic = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    public void ToWinScreen()
    {
        SceneManager.LoadScene(victoryScreen, LoadSceneMode.Single);
    }

    public void toLevelSelect() //Ant
    {
        SceneManager.LoadScene("LevelMenu");
    }

    //---------------------Ant
        public void ToLevel1() //Ant
        {
            SceneManager.LoadScene("pLevel 1");
        }
        
        public void ToLevel2() //Ant
        {
            SceneManager.LoadScene("pLevel 2");
        }

        public void ToLevel3() //Ant
        {
            SceneManager.LoadScene("pLevel 3");
        }

        public void ToLevel4() //Ant
        {
            SceneManager.LoadScene("pLevel 4");
        }

        public void ToLevel5() //Ant
        {
            SceneManager.LoadScene("pLevel 5");
        }

        public void ToLevel6() //Ant
        {
            SceneManager.LoadScene("pLevel 6");
        }

        public void ToLevel7() //Ant
        {
            SceneManager.LoadScene("pLevel 7");
        }

        public void ToLevel8() //Ant
        {
            SceneManager.LoadScene("pLevel 8");
        }

        public void ToLevel9() //Ant
        {
            SceneManager.LoadScene("pLevel 9");
        }

        public void ToLevel10() //Ant
        {
            SceneManager.LoadScene("pLevel 10");
        }
}