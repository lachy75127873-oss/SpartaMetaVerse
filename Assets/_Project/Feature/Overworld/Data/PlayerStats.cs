using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/Player Stats")]

public class PlayerStats : ScriptableObject
{
   [Header("이동 속도(유닛/초)")]
   [Range(0.1f, 15f)]
   public float moveSpeed =5f;
   
   [Header("가속/감속 (선택가능)")]
   [Range(0f, 50f)] public float acceleration = 5f;
   [Range(0f, 50f)] public float deceleration = 5f;
      
}
