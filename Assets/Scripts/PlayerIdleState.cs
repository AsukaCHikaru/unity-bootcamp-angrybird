using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player) {
        Debug.Log("Enter IDLE state");

        player.gameObject.layer = LayerMask.NameToLayer("Idle");
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public override void UpdateState(PlayerStateManager player) {
        Debug.Log("Update IDLE state");
    }
}
