using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSpin : MonoBehaviour
{
    public int id;
    public float spinSpeed = -1000f;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.StopSlot += StopSpin;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }

    private void StopSpin(int id)
    {
        if (id == this.id)
        {
            
        }
    }

    private void OnDestroy()
    {
        LevelManager.StopSlot -= StopSpin;
    }
}

