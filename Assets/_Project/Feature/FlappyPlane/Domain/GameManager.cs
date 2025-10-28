using System;   
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.FlappyPlane
{

    public enum GameState
    {
        Ready,
        Playing,
        GameOver
    }
    
    public class GameManager : MonoBehaviour
    {
        static GameManager _gameManager;
        public static GameManager instance{get{return _gameManager;}}
    
        UiManager uiManager;
        public UiManager UiManager{get{return uiManager;}}
        
        public static event Action<GameState> OnStateChanged;
        
        public GameState currentGameState = GameState.Ready;
    
        private int currentScore = 0;
        private int bestScore = 0;
        private int playCount = 0;
        
        private const string BEST_KEY = "BestScore";
        private const string COUNT_KEY = "PlayCount";

        private void Awake()
        {
            _gameManager = this;
            uiManager = FindObjectOfType<UiManager>(); 
        }

        private void Start()
        {
            bestScore = PlayerPrefs.GetInt(BEST_KEY, 0);
            playCount = PlayerPrefs.GetInt(COUNT_KEY, 0); 
            
            uiManager?.setBestScore(bestScore);
            uiManager?.setCurrentScore(currentScore);
            
            uiManager.SetScore(0);
            SetState(GameState.Ready);
        }
        
        public void StartGame()
        {
            playCount++;
            PlayerPrefs.SetInt(COUNT_KEY, playCount);
            PlayerPrefs.Save();
            
            SetState(GameState.Playing);
        }
        
        public void GameOver()
        {
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                PlayerPrefs.SetInt(BEST_KEY, bestScore);
                PlayerPrefs.Save();
            }
            
            
            
            SetState(GameState.GameOver);
        }
        

        public void SetState(GameState s)
        {
            currentGameState = s;
            switch (s)
            {
                case GameState.Ready:
                    uiManager.gameInfoPanel.SetActive(true);
                    uiManager.RestartText.gameObject.SetActive(false);
                    break;
                
                case GameState.Playing:
                    uiManager.gameInfoPanel.SetActive(false);
                    break;
                case GameState.GameOver:
                    uiManager.RestartText.gameObject.SetActive(true);
                    break;
                
            }
            OnStateChanged?.Invoke(s);

        }
        
        public void Restart()
        {
            SceneManager.LoadScene("MiniGame_Flapy");
        }

        public void ExitGame()
        {
            SceneRouter.NextSceneName = "Overworld";
            SceneManager.LoadScene("LoadingScene");
        }

        public void AddScore(int score)
        {
            currentScore += score;
            uiManager.SetScore(currentScore);
        }
    
    }
}