using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPhysics : MonoBehaviour
{
    private Rigidbody rigidBody;

    private void Awake() 
    {
        rigidBody = GetComponent<Rigidbody>();
    }

}
