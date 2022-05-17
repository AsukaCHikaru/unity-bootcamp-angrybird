using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStateManager : MonoBehaviour
{
    [SerializeField]
    StageBaseState currentState;
    StageIntroState stageIntroState = new StageIntroState();
    StagePlayState stagePlayState = new StagePlayState();
    StageResultState stageResultState = new StageResultState();

    CameraController cameraController;

    private void Start() {
        currentState = stageIntroState;
        stageIntroState.EnterState(this);
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    private void Update() {
        currentState.UpdateState(this);

        if (currentState == stageIntroState && cameraController.isAtStartPosition) {
            currentState = stagePlayState;
            stagePlayState.EnterState(this);
        }
    }
}
