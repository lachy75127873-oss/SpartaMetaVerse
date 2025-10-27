using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("데이터(읽기 전용)")]
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] Animator _animator;
    
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    static readonly int HashIsMove = Animator.StringToHash("IsMove");
    
    float startThresh = 0.01f; // 움직임 시작 판단
    float stopThresh = 0.0005f; // 정지 시점 판단
    
    private Vector2 direction;
    private bool directionChanged;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (MathF.Abs(direction.x) > 0)
        {
            directionChanged = !(direction.x > 0f);
            _spriteRenderer.flipX = directionChanged;
        }
        
    }

    void FixedUpdate()
    {
        
        Vector2 targetVelocity =  direction * _playerStats.moveSpeed;
        _rigidbody2D.velocity = targetVelocity;
        
        //가속, 감속 기능 추가
        
        float speedSq = _rigidbody2D.velocity.sqrMagnitude;
        
        bool playerMove = speedSq > startThresh;
        
        if (!playerMove && _animator.GetBool(HashIsMove) && speedSq > stopThresh)
            playerMove = true;

        if (_animator && _animator.GetBool(HashIsMove) != playerMove)
            _animator.SetBool(HashIsMove, playerMove);
        
    }
    
    
}
