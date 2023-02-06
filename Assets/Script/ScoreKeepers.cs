using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeepers : MonoBehaviour
{
    static ScoreKeepers instance;


    private void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    

int score;

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score,0,int.MaxValue);

        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }

}
