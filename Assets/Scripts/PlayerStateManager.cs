using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    PlayerIdleState playerIdleState = new PlayerIdleState();
    PlayerDraggedState playerDraggedState = new PlayerDraggedState();
    PlayerFlyState playerFlyState = new PlayerFlyState();
    PlayerEndState playerEndState = new PlayerEndState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = playerIdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnMouseDown() {
        currentState = playerDraggedState;
        currentState.EnterState(this);
    }

    private void OnMouseUp() {
        if (currentState == playerDraggedState) {
            currentState = playerFlyState;
            currentState.EnterState(this);
        }
    }
}
