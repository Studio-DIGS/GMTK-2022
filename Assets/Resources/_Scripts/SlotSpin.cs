using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSpin : MonoBehaviour
{
    public int icon;
    public int id;
    public float spinSpeed;
    private float maxSpinSpeed = -1000f;
    private float acceleration = 0.2f;
    private bool spinning = true;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.StopSlot += StopSpin;
    }

    // Update is called once per frame
    void Update()
    {
        if (spinning)
        {
            spinSpeed = Mathf.Lerp(spinSpeed, maxSpinSpeed, acceleration * Time.deltaTime);
            transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
        }
    }

    private void StopSpin(int id)
    {
        if (id == this.id)
        {
            spinning = false;
            transform.eulerAngles = new Vector3((-90 - 60*icon), -90, 270);
        }
    }

    private void OnDestroy()
    {
        LevelManager.StopSlot -= StopSpin;
    }
}

