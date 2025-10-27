using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    
    void Start()
    {
        if (restartText == null) Debug.Log("restartText is null");
        if (scoreText == null) Debug.Log("scoreText is null");
        
        restartText.gameObject.SetActive(false);
        
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
    
}