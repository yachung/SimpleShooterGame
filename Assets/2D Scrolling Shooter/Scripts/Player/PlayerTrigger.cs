using UnityEngine;
using UnityEngine.Events;

// 플레이어의 충돌처리를 담당하는 스크립트
public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private string enemyBulletTag;
    [SerializeField] private float hp = 100f;

    public UnityEvent OnPlayerDamaged;
    public UnityEvent<Vector3> OnPlayerDead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyBulletTag))
        {
            Destroy(collision.gameObject);

            OnPlayerDamaged?.Invoke();

            hp = hp - collision.GetComponent<BulletDamage>().Damage;
            hp = hp < 0f ? 0f : hp;

            if (hp == 0f)
            {
                OnPlayerDead?.Invoke(transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}
