using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeepers scoreKeepers;

    private void Awake()
    {
        scoreKeepers = FindObjectOfType<ScoreKeepers>();
    }
    private void Start()
    {
        healthSlider.maxValue = playHealth.GetHealth();
    }

    private void Update()
    {
        healthSlider.value = playHealth.GetHealth();
        scoreText.text = scoreKeepers.GetScore().ToString("0000000");
    }
}
