using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockControllerBase : MonoBehaviour {
    ScoreController scoreController;
    public GameObject ScoreTextPrefab;

    [SerializeField]
    private float force = 0f;
    private float contactForce = 0f;
    [SerializeField]
    private float destroyThreshold;
    [SerializeField]
    private int baseScore;

    private Rigidbody2D rigidbody2D;
    private float mass;

    TextMeshProUGUI text;

    // Start is called before the first frame update
    protected virtual void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        mass = rigidbody2D.mass;
        text = transform.Find("Canvas").Find("force").Find("text").GetComponent<TextMeshProUGUI>();
        scoreController = GameObject.Find("StageController").GetComponent<ScoreController>();
    }

    // Update is called once per frame
    protected virtual void Update() {
        UpdateForce();
        CalculateContactForce();
    }

    void UpdateForce() {
        Vector2 velocity = rigidbody2D.velocity;
        Vector2 forceVector = velocity * mass;
        force = Mathf.Sqrt(forceVector.sqrMagnitude);
    }

    void CalculateContactForce () {
        if (contactForce == 0f) {
            return;
        }

        text.text = contactForce.ToString("F2");
        if (contactForce > destroyThreshold) {
            DestroyBlock();
            CalculateScore();
        }
    }

    void DestroyBlock() {
        Destroy(this.gameObject);
    }

    protected virtual void CalculateScore () {
        scoreController.AddScore(baseScore);

        if (ScoreTextPrefab) {
            GameObject floatingScoreText = Instantiate(ScoreTextPrefab, transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            floatingScoreText.transform.Find("text").GetComponent<TextMeshProUGUI>().text = baseScore.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject contactObject = collision.gameObject.tag == "Environment" ? this.gameObject : collision.gameObject;

        Rigidbody2D contactObjectRb2D = contactObject.GetComponent<Rigidbody2D>();
        float contactSpeed = Mathf.Sqrt(rigidbody2D.velocity.sqrMagnitude);
        // Debug.Log($"contact speed,{transform.name},{contactSpeed}");

        if (contactSpeed < 2f) {
            return;
        }

        Vector2 contactObjectForceVector = contactObjectRb2D.velocity * contactObjectRb2D.mass;
        contactForce = Mathf.Sqrt(contactObjectForceVector.sqrMagnitude);
        // Debug.Log($"collision,{transform.name},{collision.gameObject.name},{contactObject.name},{contactForce}");
    }
}
