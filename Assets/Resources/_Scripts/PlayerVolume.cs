using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVolume : MonoBehaviour
{
    
    public float volumePercent = 1f;

    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Settings");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        LoadPrefs();
    }
    // Update is called once per frame
    private void OnApplicationQuit() 
    {
        SavePrefs();
    }

    void LoadPrefs()
    {
        volumePercent = PlayerPrefs.GetFloat("Volume", 1f);
    }
    void SavePrefs()
    {
        PlayerPrefs.SetFloat("Volume", volumePercent);
        PlayerPrefs.Save();
    }
    public void UpdatePrefs(float _newPercent)
    {
        volumePercent = _newPercent;
        Debug.Log(volumePercent);
    }
}
