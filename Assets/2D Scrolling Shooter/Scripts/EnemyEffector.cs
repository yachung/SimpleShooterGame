using System.Collections;
using UnityEngine;

public class EnemyEffector : MonoBehaviour
{
    // �ʵ�
    // ������ �����̴� �ִϸ��̼��� ����ϴ� �ð�(����: ��)
    [SerializeField] private float animationDuration = 0.5f;
    // ��������Ʈ ������ ���� ������Ʈ
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    public void PlayDamageEffect()
    {
        StartCoroutine(PlayDamageAnimation());
    }

    private IEnumerator PlayDamageAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(animationDuration);

        spriteRenderer.color = Color.white;
    }
}
