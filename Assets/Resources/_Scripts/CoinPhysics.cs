using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPhysics : MonoBehaviour
{
    public Rigidbody _rb;
    public float angularDrag;

    void Start()
    {
        _rb.angularDrag = angularDrag;
    }
}
