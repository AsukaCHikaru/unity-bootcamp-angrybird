using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject playerObject;
    PlayerStateManager player;
    Vector3 playerPosition;
    Vector3 positionOffset;
    Vector3 finalCameraPosition;
    Vector3 startCameraPosition;
    public bool isAtStartPosition;

    void Awake() {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<PlayerStateManager>();
        finalCameraPosition = GameObject.Find("FinalCameraPoint").transform.position;
        startCameraPosition = GameObject.Find("StartCameraPoint").transform.position;
    }

    public void SetStartPosition() {
        playerPosition = playerObject.transform.position;
        positionOffset = transform.position - playerPosition;
    }

    // Update is called once per frame
    void Update() {
        if (player.isFlyState()) {
            FollowPlayer();
        }

        if (!isAtStartPosition) {
            isAtStartPosition = Vector3.Distance(transform.position, startCameraPosition) < 0.5f;
        }
    }

    void FollowPlayer() {
        if (transform.position.x >= finalCameraPosition.x) { return; }

        playerPosition = playerObject.transform.position;
        transform.position = new Vector3(playerPosition.x + positionOffset.x, transform.position.y, transform.position.z);
    }

    public void SetCameraStartPosition() {
        Debug.Log("Set camera start position");
        transform.position = finalCameraPosition;
    }

    public void MoveToStartPosition() {
        transform.position = Vector3.Lerp(transform.position, startCameraPosition, Time.deltaTime);
    }
}
