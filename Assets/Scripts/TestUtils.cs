using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUtils : MonoBehaviour
{
    PlayerStateManager player;

    private void Awake() {
        player = GameObject.Find("Player").GetComponent<PlayerStateManager>();
    }

    public void ResetPlayerState () {
        GameObject launchPoint = GameObject.Find("LaunchPoint");
        player.transform.position = launchPoint.transform.position;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        player.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
        player.ResetState();

    }
}
