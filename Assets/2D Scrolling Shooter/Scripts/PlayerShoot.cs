using UnityEngine;
using UnityEngine.Events;

// 플레이어의 발사를 제어하는 스크립트
public class PlayerShoot : MonoBehaviour
{
    // 탄약 발사 - 게임 로직
    // 자동으로 발사되도록 기능을 구현
    // 탄약이 발사되는 간격
    [SerializeField] private float shootInterval = 0.2f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;

    // 탄약을 발사할 때 발생시킬 이벤트 (타입: 유니티 이벤트)
    public UnityEvent OnShoot;

    // 초 계산 변수 (누적 시간 계산)
    private float elapsedTime = 0f;

    private void Awake()
    {
        // 자동으로 반복 실행 되도록 예약
        //InvokeRepeating("Shoot", 0f, shootInterval);
    }

    private void Update()
    {
        // 타이머 업데이트
        elapsedTime += Time.deltaTime;
        if (elapsedTime > shootInterval)
        {
            Shoot();
            elapsedTime = 0f;
        }
    }

    // 발사 함수
    private void Shoot()
    {
        // 탄약 발사 이벤트 발행
        OnShoot?.Invoke();

        // 애니메이션 트리거 설정.
        //refAnimator.SetTrigger("Shoot");

        // 탄약 발사.
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("<color=red> bulletPrefab 변수가 설정되지 않았습니다. </color>");
        }
    }
}