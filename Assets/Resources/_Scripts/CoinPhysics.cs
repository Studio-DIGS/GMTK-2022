using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPhysics : MonoBehaviour
{
    public ParticleSystem particles;
    public Rigidbody _rb;
    public float angularDrag = 35f;
    [SerializeField] AudioSource coinBounceSFX;

    void Start()
    {
        _rb.angularDrag = angularDrag;
        // _rb.isKinematic = true;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject != GameObject.FindWithTag("Player"))
        {
            coinBounceSFX.Play();
            particles.Play();
        }
    }
}
