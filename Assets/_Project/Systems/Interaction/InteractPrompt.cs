using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


[RequireComponent(typeof(Collider2D))]
public class InteractPrompt : MonoBehaviour
{
    
    [Header("Basic")]
    [SerializeField] private GameObject promptPanel; // 하단 안내 패널(프리팹 인스턴스 or 씬 오브젝트)
    [SerializeField] private KeyCode interactKey = KeyCode.F;
    [SerializeField] private string sceneToLoad = "GameScene";

    private bool _inZone;
    private bool _loading;

    private void Reset()
    {
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void Awake()
    {
        if (promptPanel) promptPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
           if (!other.CompareTag("Player")) return;
           _inZone = true;
           if (promptPanel)
           {
               promptPanel.SetActive(true);
           }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;
        _inZone = false;
        if(promptPanel) promptPanel.SetActive(false);
    }
    

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_loading || !_inZone) return;

        if (Input.GetKeyDown(interactKey))
        {
            Debug.Log("Interact");
            _loading = true;
            SceneManager.LoadScene(sceneToLoad);
        }
        
        
    }
}
