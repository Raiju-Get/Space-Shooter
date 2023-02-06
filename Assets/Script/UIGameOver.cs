using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoretext;
    ScoreKeepers scoreKeeper;
    // Start is called before the first frame update
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeepers>();
    }

    private void Start()
    {
        scoretext.text = "You scored:\n" +  scoreKeeper.GetScore().ToString("000000");
    }
}
