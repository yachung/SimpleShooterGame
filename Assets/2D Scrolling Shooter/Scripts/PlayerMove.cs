using System;
using UnityEngine;

// 마우스 드래그(모바일 - 터치)를 사용해서 플레이어를 이동시키는 스크립트.
public class PlayerMove : MonoBehaviour
{
    // 최소/최대 범위를 지정할 때 사용할 클래스 정의.

    // 우리가 선언한 클래스는 유니티가 모름
    // 이 클래스를 인스펙터에 노출하려면, 명시적으로 아래 태그를 추가해야함
    [Serializable]
    class ClampValue
    {
        [SerializeField] private float min;
        [SerializeField] private float max;

        public float Min { get { return min; } }
        public float Max { get { return max; } }

        // 전달 받은 값을 min과 max사이의 값으로 고정해주는 함수
        public float Clamp(float target)
        {
            return Mathf.Clamp(target, min, max);
        }
    }

    [SerializeField] private float lagSpeed = 5f;

    // x 위치에 사용할 범위 변수
    [SerializeField] private ClampValue clampX;

    // y 위치에 사용할 범위 변수
    [SerializeField] private ClampValue clampY;

    // 카메라를 저장할 참조 변수
    private Camera mainCamera;

    // 플레이어와 드래그 위치의 오프셋 값
    private Vector3 offset;

    // 트랜스폼 참조 변수
    private Transform refTransform;

    private void Awake()
    {
        // 메인 카메라를 변수에 저장.
        mainCamera = Camera.main;

        refTransform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 위치를 3차원 월드 좌표로 변환
            Vector3 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = refTransform.position.z;

            offset = refTransform.position - clickPosition;
        }
        // 마우스 클릭 시 반복
        if (Input.GetMouseButton(0))
        {
            // 마우스 위치를 3차원 월드 좌표로 변환
            Vector3 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = refTransform.position.z;

            // 오프셋을 보정해 이동해야할 최종 위치를 저장
            Vector3 targetPosition = clickPosition + offset;

            //targetPosition.x = Mathf.Clamp(targetPosition.x, clampX.Min, clampX.Max);
            targetPosition.x = clampX.Clamp(targetPosition.x);
            //targetPosition.y = Mathf.Clamp(targetPosition.y, clampY.Min, clampY.Max);
            targetPosition.y = clampX.Clamp(targetPosition.y);

            // 3차원으로 변환을 거친 위치를 플레이어의 위치로 설정.
            refTransform.position = Vector3.Lerp(refTransform.position, targetPosition, Time.deltaTime * lagSpeed);
        }

        // 클릭 해제 시 값 정리
        if (Input.GetMouseButtonUp(0))
        {
            offset = Vector3.zero;
        }
    }
}
