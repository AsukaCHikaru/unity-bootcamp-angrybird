using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockControllerBase : MonoBehaviour {
    [SerializeField]
    private Vector2 force = Vector2.zero;

    private Rigidbody2D rigidbody2D;
    private float mass;

    TextMeshProUGUI text;

    // Start is called before the first frame update
    protected virtual void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        mass = rigidbody2D.mass;
        text = transform.Find("Canvas").Find("force").Find("text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    protected virtual void Update() {
        UpdateForce();
        if (force != Vector2.zero) {
            float normalizedForce = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(force.x), 2) + Mathf.Pow(Mathf.Abs(force.y), 2));
            text.text = normalizedForce.ToString("F2");
        }
    }

    public Vector2 GetAppliedForce() {
        return force;
    }

    void UpdateForce() {
        Vector2 velocity = rigidbody2D.velocity;
        force = velocity * mass;
    }
}
