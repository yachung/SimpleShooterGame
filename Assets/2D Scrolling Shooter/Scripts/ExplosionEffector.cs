using UnityEngine;

// 폭발 이펙트를 재생시키는 스크립트 
public class ExplosionEffector : MonoBehaviour
{
    // 폭발 애니메이션을 재생할 프리팹
    [SerializeField] private GameObject m_ExplosionPrefab;

    public void PlayerExplosionEffect(Vector3 targetPosition)
    {
        Instantiate(m_ExplosionPrefab, targetPosition, Quaternion.identity) ;
    }
}
