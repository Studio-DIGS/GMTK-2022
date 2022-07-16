using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPhysics : MonoBehaviour
{
    public LayerMask collisionMask;

    public float maxSpeed = 10f;

    
    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxSpeed * Time.deltaTime + 0.1f, collisionMask))
        {
            Debug.Log("Bounce");
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            transform.forward = reflectDir;
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * maxSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bounce");

        Vector3 reflectDir = Vector3.Reflect(transform.up, collision.contacts[0].normal);
        float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(rot, 0, 0);

    }
}
