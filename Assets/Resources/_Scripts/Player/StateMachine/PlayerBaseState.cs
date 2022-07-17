using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager _player);
    public abstract void UpdateState(PlayerStateManager _player);
    public abstract void LateUpdateState(PlayerStateManager _player);
    public abstract void ExitState(PlayerStateManager _player);

    public void OnTriggerEnterState(PlayerStateManager _player, Collider other)
    {
        if (other.gameObject.CompareTag(_player.coinPrefab.tag))
        {
            _player.hasCoin = true;
            _player.GetCoin(other.transform.parent.gameObject);
        }
    }
}
