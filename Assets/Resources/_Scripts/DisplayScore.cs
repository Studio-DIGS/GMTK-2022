using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    TMP_Text text;
    PlayerStateManager player;
    
    private void Awake() 
    {
        text = GetComponent<TMP_Text>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerStateManager>();
    }
    private void Start()
    {
        text.SetText("$ " + player.score.GetPoints());
    }
}
