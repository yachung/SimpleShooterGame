using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 싱글톤으로 외부 접근이 가능하도록 하는 프로퍼티
    public static GameManager Instance { get; private set; }

    // 게임이 시작됐는지를 알려주는 프로퍼티
    public bool IsGameStarted { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // 플레이어가 죽었을 때 실행할 리스너 함수
    public void OnPlayerDead()
    {
        IsGameStarted = false;
        ScoreManager.Instance.SaveScore();
        SceneManager.LoadScene(1);
    }

    // Fade 애니메이션이 종료되면 발행되는 이벤트에 등록할 리스터 함수
    public void OnFadeAnimationEnd()
    {
        IsGameStarted = true;
    }
}