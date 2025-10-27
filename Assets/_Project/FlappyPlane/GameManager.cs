using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.FlappyPlane
{
    public class GameManager : MonoBehaviour
    {
        static GameManager _gameManager;
        public static GameManager instance{get{return _gameManager;}}
    
        UiManager uiManager;
        public UiManager UiManager{get{return uiManager;}}
    
        private int currentScore = 0;

        private void Awake()
        {
            _gameManager = this;
            uiManager = FindObjectOfType<UiManager>(); 
        }

        private void Start()
        {
            uiManager.SetScore(0);
        }

        public void GameOver()
        {
            Debug.Log("GameOver");
        }

        public void Restart()
        {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void AddScore(int score)
        {
            currentScore += score;
            Debug.Log("Score"+currentScore);
            uiManager.SetScore(currentScore);
        }
    
    }
}