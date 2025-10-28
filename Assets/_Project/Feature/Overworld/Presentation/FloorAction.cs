using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FloorAction : MonoBehaviour
{
    Animator animator;

    void Awake() => animator = GetComponent<Animator>();

    void OnBecameVisible() => animator.speed = 1f;
    void OnBecameInvisible() => animator.speed = 0f;
}