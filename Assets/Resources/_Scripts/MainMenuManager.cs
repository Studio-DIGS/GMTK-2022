using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string firstLevelName;

    public void ToFirstLevel()
    {
        SceneManager.LoadScene(firstLevelName);
    }
}
