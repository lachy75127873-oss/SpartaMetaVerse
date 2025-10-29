using System;
using System.Collections;
using System.Collections.Generic;
using _Project.FlappyPlane;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    Animator animator;
    Rigidbody2D _rigidbody;
    GameManager gameManager;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;
    
    private Vector3 startPosition;
    private Quaternion startRotation;
    private float defaultGravity;
    
    bool isFlap = false;
    
    public bool godMode = false;

    private void Awake()
    {

        gameManager = GameManager.instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        
        if (animator == null )Debug.Log("Not Founded Animator");
        if (_rigidbody == null) Debug.Log("Not Founded Rigidbody");
        
        defaultGravity = _rigidbody.gravityScale;
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    
    void OnEnable()  { GameManager.OnStateChanged += HandleState; }
    void OnDisable() { GameManager.OnStateChanged -= HandleState; }

    void HandleState(GameState s)
    {
        switch (s)
        {
            case GameState.Ready:
                _rigidbody.simulated = false;
                _rigidbody.velocity = Vector2.zero;
                transform.position = startPosition;
                transform.rotation = startRotation;
                isDead = false;
                break;

            case GameState.Playing:
                _rigidbody.simulated = true;
                _rigidbody.gravityScale = defaultGravity;
                _rigidbody.velocity = Vector2.zero; 
                break;

            case GameState.GameOver:
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentGameState != GameState.Playing) return;

        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                   gameManager.SetState(GameState.GameOver);
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                
                isFlap = true;
            }
        }
        
    }

    void FixedUpdate()
    {
        if (gameManager.currentGameState != GameState.Playing) return;

        if (isDead){return;}
        
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y = flapForce;
            isFlap = false;
        }
        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f ), -90, 90);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (godMode) return;
        if(isDead) return;
        
        isDead = true;
        deathCooldown = 1f;
        
        animator.SetInteger("IsDie",1);
        gameManager.GameOver();
    }
}
