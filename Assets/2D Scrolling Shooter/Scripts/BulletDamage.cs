using System;
using UnityEngine;

// ź���� ������ ������ ������ ����� ��ũ��Ʈ
public class BulletDamage : MonoBehaviour
{
    // ������
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