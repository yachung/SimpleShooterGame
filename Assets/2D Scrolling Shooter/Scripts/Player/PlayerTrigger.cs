using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// �÷��̾��� �浹 ó���� ����ϴ� ��ũ��Ʈ.
public class PlayerTrigger : MonoBehaviour
{
    // �� ź���� �±�.
    [SerializeField] private string enemyBulletTag;

    // �÷��̾��� ü��(Health Power).
    [SerializeField] private float hp = 0f;
    [SerializeField] private float originHp = 100f;

    [SerializeField] private Image hpBarImage; 

    // �̺�Ʈ.
    public UnityEvent OnPlayerDamaged;
    public UnityEvent<Vector3> OnPlayerDead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �±� ��.
        if (collision.CompareTag(enemyBulletTag))
        {
            // �� ź���� ����.
            Destroy(collision.gameObject);

            // �÷��̾ ������� �Ծ��ٴ� �̺�Ʈ ����.
            OnPlayerDamaged?.Invoke();

            // ����� ó��.
            hp = hp - collision.GetComponent<BulletDamage>().Damage;
            hp = hp < 0f ? 0f : hp;

            if (hpBarImage != null)
            {
                hpBarImage.fillAmount = hp/100;
            }

            // ���� Ȯ�� �� �̺�Ʈ ����.
            if (hp == 0f)
            {
                // �̺�Ʈ ����.
                OnPlayerDead?.Invoke(transform.position);

                // �÷��̾� ���� ������Ʈ ����.
                Destroy(gameObject);
            }
        }
    }
}