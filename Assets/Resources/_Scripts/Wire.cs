using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    //Wire Vars
    [SerializeField] AudioSource wireCutSFX;
    [SerializeField] GameObject uncutWire;
    [SerializeField] GameObject cutWire;
    private LevelManager levelManager;
    private Material hitWireMaterial;
    public ParticleSystem electricParticles;

    //Wire Properties
    [SerializeField]
    private int value = 1000;
    
    [HideInInspector]
    public bool hasBeenHit = false;

    private void Awake() 
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        hitWireMaterial = (Material) Resources.Load("Materials/TestHitWireMaterial");
        electricParticles.Stop();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Coin" && !hasBeenHit)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerStateManager>().score.AddPoints(value);
            uncutWire.SetActive(false);
            cutWire.SetActive(true);

            hasBeenHit = true;
            wireCutSFX.Play();
            electricParticles.Play();

            levelManager.wiresCut += 1;
            levelManager.TriggerStopSlot(levelManager.wiresCut);
            levelManager.CheckForLevelCompleted();
        }
    }
}
