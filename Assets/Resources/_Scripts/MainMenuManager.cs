using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string cutsceneName;
    [SerializeField] AudioSource backgroundMusic;
    private PlayerVolume playerVolume;

    private void Awake() 
    {
        playerVolume = GameObject.Find("PlayerSettings").GetComponent<PlayerVolume>();
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
        foreach (GameObject obj in musicObj)
        {
            Destroy(obj);
        }
    }
    
    private void Start() 
    {
        backgroundMusic.volume = playerVolume.volumePercent;
    }

    public void Cutscene()
    {
        SceneManager.LoadScene(cutsceneName);
    }
    public void ChangeVolume(float _volume)
    {
        backgroundMusic.volume = _volume;
        playerVolume.UpdatePrefs(_volume);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
