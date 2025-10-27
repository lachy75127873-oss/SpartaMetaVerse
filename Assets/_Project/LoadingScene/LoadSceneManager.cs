using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private float loadingTime = 3.0f;
    
    private bool started;
    private string nextScene; 
    private float timer;

    private void Awake()
    {
        nextScene = SceneRouter.NextSceneName;
        if (string.IsNullOrEmpty(nextScene))
        {
            Debug.LogError("[LoadSceneManager] 다음 씬 이름이 비어 있습니다. SceneRouter.NextSceneName을 확인하세요.");
            nextScene = "Overworld";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!started)
        {
            started = true;
            StartCoroutine(loadNextAfterDelay()); 
        }

    }

    private IEnumerator loadNextAfterDelay()
    {
        
        float t = 0;
        while (t < loadingTime)
        {
            t += Time.deltaTime;
            //로딩바 업데이트
            yield return null;
        }
        
        SceneManager.LoadScene(nextScene);
    }

   
}
