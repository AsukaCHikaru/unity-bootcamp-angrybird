using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField]
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

    public bool isFlyState () {
        return currentState == playerFlyState;
    }

    private void OnMouseDown() {
        if (currentState == playerIdleState) {
            currentState = playerDraggedState;
            currentState.EnterState(this);
        }
    }

    private void OnMouseUp() {
        if (currentState == playerDraggedState) {
            currentState = playerFlyState;
            currentState.EnterState(this);
        }
    }

    public void ResetState () {
        currentState = playerIdleState;
        currentState.EnterState(this);
    }
}
