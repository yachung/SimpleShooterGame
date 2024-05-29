using System.Collections;
using UnityEngine;

public class EnemyEffector : MonoBehaviour
{
    // 필드
    // 색상을 깜박이는 애니메이션을 재생하는 시간(단위: 초)
    [SerializeField] private float animationDuration = 0.5f;
    // 스프라이트 렌더러 참조 컴포넌트
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
