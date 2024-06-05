using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// 게임 결과 관련 기능을 담당하는 스크립트
public class GameResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    // 컴포넌트가 활성화되면 실행되는 이벤트 함수
    private void OnEnable()
    {
        // 게임 결과 파일 로드
        string jsonString = File.ReadAllText($"{Application.dataPath}/Score.txt");

        // 로드할 파일을 데이터 객체로 역직렬화
        var score = JsonUtility.FromJson<Score>(jsonString);

        // 객체로부터 점수값을 읽어와 텍스트에 표기
        scoreText.text = $"Score : {score.score}";
        bestScoreText.text = $"bestScore : {score.bestScore}";
    }

    // Restart 버튼 함수
    public void OnRestartClicked()
    {
        SceneManager.LoadScene(0);
    }

    // Quit 버튼 함수
    public void OnQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}