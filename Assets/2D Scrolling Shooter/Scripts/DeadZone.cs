using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // �� ������ ��� �ݶ��̴��� ����.
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ���� ������Ʈ ����.
        Destroy(collision.gameObject);
    }
}