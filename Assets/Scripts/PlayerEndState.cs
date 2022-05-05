using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player) {
        Debug.Log("Enter END state");
    }

    public override void UpdateState(PlayerStateManager player) {
        Debug.Log("Update END state");
    }
}
