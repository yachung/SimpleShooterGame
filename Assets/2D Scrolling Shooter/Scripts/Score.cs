using System.IO;
using TMPro;
using UnityEngine;

// 플레이어의 점수를 저장하는데 사용할 데이터 클래스
// [System.Serializable]을 붙여야 인스펙터에서 필요할 때 노출이 가능

[System.Serializable]
public class Score
{
    // 플레이어의 현재 점수
    [SerializeField] public int score { get; private set; } = 0;

    // 플레이어의 최고 점수(기록)
    [SerializeField] public int bestScore = 0;

    //public string jsonString;

    // 텍스트 UI 참조 변수
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI bestScoreText;

    // 공개 메소드 - 초기화 함수
    public void Initialize()
    {
        // 최고 점수 로드
        //bestScore = PlayerPrefs.GetInt("BestScore");

        // 역직렬화
        // 1. 파일을 불러와 문자열로 읽어오기
        string jsonString = File.ReadAllText($"{Application.dataPath}/Score.txt");

        // 2. 불러온 문자열 값을 객체로 복원 (역직렬화)
        bestScore = JsonUtility.FromJson<Score>(jsonString).bestScore;

        // UI 업데이트
        if (scoreText != null)
            scoreText.text = $"Score: {score}";

        if (bestScoreText != null )
            bestScoreText.text = $"BestScore: {bestScore}";
    }

    public void SetTextUI(TextMeshProUGUI scoreText, TextMeshProUGUI bestScoreText)
    {
        this.scoreText = scoreText;
        this.bestScoreText = bestScoreText;
    }

    // 점수 획득 함수
    public void Add(int gainScore)
    {
        // 점수 누적.
        score += gainScore;

        if (scoreText != null)
            scoreText.text = $"Score: {score}";

        // 최고 점수 확인 후에 넘었으면 최고 점수도 업데이트
        if (score > bestScore)
        {
            bestScore = score;

            // 최고 점수를 파일에 기록.
            PlayerPrefs.SetInt("BestScore", bestScore);

            if (bestScoreText != null)
                bestScoreText.text = $"BestScore: {bestScore}";
        }
    }

    // 점수를 파일로 저장하는 함수
    public void Save()
    {
        // JSON으로 기록
        // 1. 저장할 객체를 JSON문자열로 생성 (변환)
        var jsonString = JsonUtility.ToJson(this);

        // 2. 변환한 JSON 문자열을 파일로 저장
        // 2-1. 파일로 저장하려면 경로(저장하려는 위치)와 파일 이름, 확장자를 지정해야 함.
        File.WriteAllText($"{Application.dataPath}/Score.txt", jsonString);
    }
}
