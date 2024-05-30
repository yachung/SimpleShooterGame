using UnityEngine;

// ź���� �̵���Ű�� ��ũ��Ʈ
public class BulletMove : MonoBehaviour
{
    // ź���� �̵� �ӵ�
    [SerializeField] private float moveSpeed = 10f;

    // Ʈ������ ������Ʈ ���� ����
    private Transform refTransform;

    private void Awake()
    {
        refTransform = transform;
    }

    private void Update()
    {
        refTransform.position += refTransform.up * moveSpeed * Time.deltaTime;
    }

    // ������, �������� �̵� �̷�, ����
}
