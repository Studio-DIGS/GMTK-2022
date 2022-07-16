using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    private LevelManager levelManager;

    private Material hitWireMaterial;
    public bool hasBeenHit = false;

    private void Awake() 
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        hitWireMaterial = (Material) Resources.Load("Materials/TestHitWireMaterial");
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Coin")
        {
            this.GetComponent<MeshRenderer>().material = hitWireMaterial;
            hasBeenHit = true;
            levelManager.CheckForLevelCompleted();
        }
    }
}
