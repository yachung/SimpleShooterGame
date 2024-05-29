using System;
using UnityEngine;

// 탄약의 데미지 정보를 관리할 대미지 스크립트
public class BulletDamage : MonoBehaviour
{
    // 데미지
    [SerializeField] private float damage = 10f;

    // Getter
    public float Damage
    {
        get
        {
            return damage;
        }
    }
}