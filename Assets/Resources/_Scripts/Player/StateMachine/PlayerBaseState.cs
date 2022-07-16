using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager _player);
    public abstract void UpdateState(PlayerStateManager _player);
    public abstract void LateUpdateState(PlayerStateManager _player);
    public void OnTriggerEnterState(PlayerStateManager _player, Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == _player.coinPrefab.tag)
        {
            _player.hasCoin = true;
            _player.GetCoin(other.gameObject);
        }
    }
}
