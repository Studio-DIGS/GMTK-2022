using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager _enemy);
    public abstract void UpdateState(EnemyStateManager _enemy);
    public void OnCollsionEnterState(EnemyStateManager _enemy, Collision other)
    {
        if (other.gameObject == GameObject.FindWithTag("Player"))
        {
            //Destroy(other.gameObject);
            Debug.Log("Game Over!");
            return;
        }
        if (other.gameObject == GameObject.FindWithTag("Coin"))
        {
            //Destroy(this);
            Debug.Log("Enemy Defeated!");
        }
    }
}
