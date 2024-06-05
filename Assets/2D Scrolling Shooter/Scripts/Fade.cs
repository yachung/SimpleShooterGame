using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Fade In/Out을 처리하는 스크립트
// 스크립트 추가시 해당 컴포넌트를 강제(없을시 추가, 해당 컴포넌트 삭제 불가능)
[RequireComponent(typeof(Image))]
public class Fade : MonoBehaviour
{
    // 필드
    // 딜리게이트 - 페이드 애니메이션이 모두 재생되면 발행할 이벤트
    public UnityEvent OnAnimationEnd;

    // 페이드 애니메이션 시간
    [SerializeField] private float animationTime = 2f;

    // 한 프레임에 더하기(또는 빼기)를 할 간격
    private float animationDiffrence = 1f;

    // 알파값 조정에 사용할 값(RGBA)
    private float alpha = 0f;

    private Image image;


    private void Awake()
    {
        // 초기화
        image = GetComponent<Image>();

        // 시작할 때 Alpah값 저장
        alpha = image.color.a;
    }

    // Update에서 처리
    //private void Update()
    //{
    //    if (alpha > 0f)
    //    {
    //        alpha -= (1.0f / animationTime) * Time.deltaTime;

    //        Color color = image.color;
    //        color.a = alpha;

    //        image.color = color;
    //    }
    //}

    private void Start()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    // 코루틴에서 처리
    IEnumerator FadeInCoroutine()
    {
        gameObject.SetActive(true);

        while (alpha > 0f)
        {
            alpha -= animationDiffrence * Time.deltaTime;

            Color color = image.color;
            color.a = alpha;
            image.color = color;

            yield return null;
        }

        gameObject.SetActive(false);

        // 애니메이션 종료 이벤트 발행
        OnAnimationEnd?.Invoke();
    }

    IEnumerator FadeOutCoroutine(Action OnComplete = null)
    {
        gameObject.SetActive(true);

        while (alpha < 1f)
        {
            alpha += animationDiffrence * Time.deltaTime;

            Color color = image.color;
            color.a = alpha;
            image.color = color;

            yield return null;
        }

        gameObject.SetActive(false);

        OnComplete?.Invoke();
    }
}
