using System.Collections;
using UnityEngine;

// ����� ȿ���� ������ �� ����� ��ũ��Ʈ.
public class DamageEffector : MonoBehaviour
{
    // �ʵ�.
    // ������ �����̴� �ִϸ��̼��� ����ϴ� �ð�(����: ��).
    [SerializeField] private float colorAnimationInterval = 0.1f;

    // ��������Ʈ ������ ���� ������Ʈ.
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // ���� �޼ҵ� - �������̽�.
    public void PlayDamageEffect()
    {
        StartCoroutine(PlayDamageAnimation());
    }

    private IEnumerator PlayDamageAnimation()
    {
        // ��������Ʈ �������� ������ ���������� ����.
        spriteRenderer.color = Color.red;

        // ���.
        yield return new WaitForSeconds(colorAnimationInterval);

        // ��������Ʈ �������� ������ ������� ����.
        spriteRenderer.color = Color.white;
    }
}