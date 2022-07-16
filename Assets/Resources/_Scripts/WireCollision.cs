using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCollision : MonoBehaviour
{
    private Material hitWireMaterial;

    private void Awake() 
    {
        hitWireMaterial = (Material) Resources.Load("Materials/TestHitWireMaterial");
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Coin")
        {
            this.GetComponent<MeshRenderer>().material = hitWireMaterial;
        }
    }
}
