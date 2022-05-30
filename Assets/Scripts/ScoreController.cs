using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour {
    [SerializeField]
    private int score;
    TextMeshProUGUI Text;

    private void Start() {
        Text = GameObject.Find("Score").transform.Find("text").GetComponent<TextMeshProUGUI>(); 
        score = 0;
    }

    public void AddScore(int value) {
        score += value;
        Text.text = $"SCORE: {score}";
    }

    
}
