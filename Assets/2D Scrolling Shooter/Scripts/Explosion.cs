using UnityEngine;

// Explosion �ִϸ��̼� �̺�Ʈ�� ó���� ��ũ��Ʈ.
public class Explosion : MonoBehaviour
{
    // �ִϸ��̼� �̺�Ʈ�� ������ �Լ�.
    void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}