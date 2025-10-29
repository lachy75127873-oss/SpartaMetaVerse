using System;
using System.Collections;
using System.Collections.Generic;
using _Project.FlappyPlane;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UiManager : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    [SerializeField] public GameObject gameInfoPanel;
    /*[SerializeField] public GameObject RestartText;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI BestScoreText;
    [SerializeField] private TextMeshProUGUI RecurrentScoreText;
    [SerializeField] private TextMeshProUGUI ReBestScoreText;*/
    
    GameManager gameManager;
    
    

    private void Awake()
    {
        gameManager = GameManager.instance;
    }
    
    void OnEnable()  { GameManager.OnStateChanged += UiState; }
    void OnDisable() { GameManager.OnStateChanged -= UiState; }
    

    void UiState(GameState state)
    {
        switch (state)
        {
            case GameState.Ready:
                /*기본판넬
                 0점 표시
                 */
                
                
                break;
            case GameState.Playing:
                /*
                 * 기본판넬 닫고, 점수 올리기
                 */
                break;
            case GameState.GameOver:
                /*시본판넬 열기
                 */
                break;
            default:
                break;
        }
    }
    
    
    
    
    
    
    void Start()
    {
        if (gameInfoPanel == null) Debug.Log("gameInfoPanel is null");
        if (scoreText == null) Debug.Log("scoreText is null");
        //if (RestartText == null) Debug.Log("RestartText is null");
        
    }

    public void setCurrentScore(int score)
    {
        
        //if(currentScoreText)  currentScoreText.text = score.ToString(); 
        //if(RecurrentScoreText)   RecurrentScoreText.text = score.ToString();
    }

    public void setBestScore(int score)
    {
       //if(BestScoreText)  BestScoreText.text = score.ToString();
        //if(ReBestScoreText)  ReBestScoreText.text = score.ToString();
    }

    public void GetReady()
    {
        gameInfoPanel.gameObject.SetActive(true);
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
    
}