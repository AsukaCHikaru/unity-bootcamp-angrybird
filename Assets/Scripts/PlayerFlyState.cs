using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player) {
        Debug.Log("Enter FLY state");
        player.gameObject.layer = LayerMask.NameToLayer("Fly");
        player.GetComponent<Rigidbody2D>().gravityScale = 2;
    }

    public override void UpdateState(PlayerStateManager player) {
        Debug.Log("Update FLY state");
    }
}
