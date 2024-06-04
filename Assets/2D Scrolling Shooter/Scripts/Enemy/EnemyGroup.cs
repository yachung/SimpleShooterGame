using UnityEngine;

// �ڽ� ���� ������Ʈ�� ������ ������ �ϵ��� ó���ϴ� ��ũ��Ʈ.
public class EnemyGroup : MonoBehaviour
{
    private void Awake()
    {
        // ���������� Ȯ��.
        InvokeRepeating("CheckChildState", 0f, 0.5f);
    }

    //private void Update()
    //{
    //    CheckChildState();
    //}

    // �ڽ� ���� ������Ʈ�� �ִ��� ������ Ȯ���ϴ� �Լ�.
    private void CheckChildState()
    {
        // �ڽ��� ������ ���� ������Ʈ ����.
        if (transform.childCount == 0)
        {
            CancelInvoke("CheckChildState");
            Destroy(gameObject);
        }
    }
}