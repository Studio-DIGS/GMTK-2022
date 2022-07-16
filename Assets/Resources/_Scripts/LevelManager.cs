using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<Wire> wires;

    [SerializeField]
    private string nextScene;

    public void CheckForLevelCompleted()
    {
        foreach (Wire wire in wires)
        {
            if (wire.hasBeenHit != true)
            {
                return;
            }
        }
        Debug.Log("Level Completed!");
        Debug.Log("Going To: " + nextScene);
    }
}
