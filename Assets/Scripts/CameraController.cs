using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject playerObject;
    PlayerStateManager player;
    Vector3 playerPosition;
    Vector3 positionOffset;
    Vector3 finalCameraPoint;

    void Start() {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<PlayerStateManager>();
        finalCameraPoint = GameObject.Find("FinalCameraPoint").transform.position;
    }

    public void SetStartPosition() {
        playerPosition = playerObject.transform.position;
        positionOffset = transform.position - playerPosition;
    }

    // Update is called once per frame
    void Update() {
        if (player.isFlyState()) {
            MoveCamera();
        }
    }

    void MoveCamera() {
        if (transform.position.x >= finalCameraPoint.x) { return; }

        playerPosition = playerObject.transform.position;
        transform.position = new Vector3(playerPosition.x + positionOffset.x, transform.position.y, transform.position.z);
    }
}
