using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    TMP_Text text;
    public FloatSO playerScore;
    
    private void Awake() 
    {
        text = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        LevelManager.BeatLevel += DisplayPoints;
        text.SetText("$ " + playerScore.Value);
    }

    private void DisplayPoints()
    {
        text.SetText("$ " + playerScore.Value);
    }
}
