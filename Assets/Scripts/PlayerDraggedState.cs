using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDraggedState : PlayerBaseState {
    public override void EnterState(PlayerStateManager player) {
        Debug.Log("Enter DRAGGED state");
        player.gameObject.layer = LayerMask.NameToLayer("Dragged");
    }

    public override void UpdateState(PlayerStateManager player) {
        Debug.Log("Update DRAGGED state");

        GameObject launchPoint = GameObject.Find("LaunchPoint");

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 launchPointPosition = launchPoint.transform.position;
        float distance = Vector3.Distance(mousePosition, launchPointPosition);

        float pullMaxLength = launchPoint.GetComponent<CircleCollider2D>().radius;

        if (distance < pullMaxLength) {
            player.transform.position = new Vector3(mousePosition.x, mousePosition.y, 1);
        } else {
            Vector3 maxPosition = Vector3.MoveTowards(launchPointPosition, mousePosition, pullMaxLength);
            player.transform.position = new Vector3(maxPosition.x, maxPosition.y, 1);
        }

    }
}
