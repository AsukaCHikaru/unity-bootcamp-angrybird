using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageIntroState : StageBaseState
{
    CameraController cameraController;
    public override void EnterState(StageStateManager stage) {
        Debug.Log("Enter Stage Intro State");
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
        cameraController.SetCameraStartPosition();
    }

    public override void UpdateState(StageStateManager stage) {
        cameraController.MoveToStartPosition();
    }
}
