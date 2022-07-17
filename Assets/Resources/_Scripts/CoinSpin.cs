using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public CoinPhysics _physics;
    private Rigidbody _rb;
    public float modifier;
    public float stopSpeed;

    private float spinSpeed;
    private float xEnd;

    void Awake()
    {
        _rb = _physics.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.isKinematic == false)
        {
            spinSpeed = modifier * _rb.velocity.z;
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);

            if (_rb.velocity.magnitude < 1f)
            {
                xEnd += stopSpeed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-90,-90,0), xEnd);
            }
        }
    }
}
