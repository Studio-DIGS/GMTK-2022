using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    //Wire Vars
    [SerializeField] AudioSource wireCutSFX;
    private LevelManager levelManager;
    private Material hitWireMaterial;

    //Wire Properties
    [SerializeField]
    private int value = 1000;
    
    [HideInInspector]
    public bool hasBeenHit = false;

    private void Awake() 
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        hitWireMaterial = (Material) Resources.Load("Materials/TestHitWireMaterial");
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Coin" && !hasBeenHit)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerStateManager>().score.AddPoints(value);
            this.GetComponent<MeshRenderer>().material = hitWireMaterial;

            hasBeenHit = true;
            wireCutSFX.Play();

            levelManager.CheckForLevelCompleted();
        }
    }
}
