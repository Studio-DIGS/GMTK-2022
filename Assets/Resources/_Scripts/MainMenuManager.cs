using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string firstLevelName;
    [SerializeField] AudioSource backgroundMusic;
    private PlayerVolume playerVolume;

    private void Awake() 
    {
        playerVolume = GameObject.Find("PlayerSettings").GetComponent<PlayerVolume>();
    }
    
    private void Start() 
    {
        backgroundMusic.volume = playerVolume.volumePercent;
    }

    public void ToFirstLevel()
    {
        SceneManager.LoadScene(firstLevelName);
    }
    public void ChangeVolume(float _volume)
    {
        backgroundMusic.volume = _volume;
        playerVolume.UpdatePrefs(_volume);
    }
}
