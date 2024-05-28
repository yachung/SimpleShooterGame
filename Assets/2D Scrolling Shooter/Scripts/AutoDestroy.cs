// ������ �ð��� ������ ���� ������Ʈ�� �ڵ� �������ִ� ��ũ��Ʈ.
using UnityEngine;

// ������ �ð��� ������ ���� ������Ʈ�� �ڵ� �������ִ� ��ũ��Ʈ.
public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime = 3f;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
}