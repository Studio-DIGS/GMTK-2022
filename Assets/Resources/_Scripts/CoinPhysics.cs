using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPhysics : MonoBehaviour
{
    public Rigidbody _rb;
    public float angularDrag = 35f;

    void Start()
    {
        _rb.angularDrag = angularDrag;
    }
}
