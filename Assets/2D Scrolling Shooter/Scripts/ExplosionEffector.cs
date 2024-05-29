using UnityEngine;

// ���� ����Ʈ�� �����Ű�� ��ũ��Ʈ 
public class ExplosionEffector : MonoBehaviour
{
    // ���� �ִϸ��̼��� ����� ������
    [SerializeField] private GameObject m_ExplosionPrefab;

    public void PlayerExplosionEffect(Vector3 targetPosition)
    {
        Instantiate(m_ExplosionPrefab, targetPosition, Quaternion.identity) ;
    }
}
