using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyState : PlayerBaseState
{
    CameraController cameraController;

    public override void EnterState(PlayerStateManager player) {
        Debug.Log("Enter FLY state");
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
        cameraController.SetStartPosition();
        player.gameObject.layer = LayerMask.NameToLayer("Fly");
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public override void UpdateState(PlayerStateManager player) {
        // Debug.Log("Update FLY state");
        
    }
}
