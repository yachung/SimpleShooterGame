using TMPro;
using UnityEngine;

// 점수 관리자 - 컴포넌트로 관리할 스크립트.
// 싱글톤 - 디자인 패턴
// - 실행 환경에서 1개만 존재해야하는 제한 사항이 있음
// - 1개이기 때문에 없어도 안되고, 2개여도 안됨
// - 사용하는 이유: 어디에서나 쉽게 접근이 가능한 구조를 제공하기 위해
public class ScoreManager : MonoBehaviour
{
    // 싱글톤 필드
    private static ScoreManager instance = null;

    [SerializeField] private Score score;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    public static ScoreManager Instance
    {
        get { return instance; }
    }

    // 싱글톤 접근 공개 메소드
    public static ScoreManager Get()
    { return instance; }

    // 객체 생성은 Awake에서 하는게 정석. 과거 버전에선 변수 선언하면서 객체 생성하면 오류.
    private void Awake()
    {
        // 싱글촌 초기화
        // instance가 null인 경우는 생성이 필요한 경우이기 때문에
        // 이 게임 오브젝트를 싱글톤 객체로 설정
        if (instance == null)
        {
            instance = this;
        }
        // instance가 null이 아니라면, 다른 객체가 이미 싱글톤으로 설정돼 있다는 의미이기 때문에
        // 이 객체는 삭제해야함.
        else
        {
            Destroy(gameObject);
        }

        if (score == null)
            score = new Score();

        score.SetTextUI(scoreText, bestScoreText);
        score.Initialize();
    }

    public void SaveScore()
    {
        score.Save();
    }

    public void AddScore(int gainScore)
    {
        score.Add(gainScore);
    }
}