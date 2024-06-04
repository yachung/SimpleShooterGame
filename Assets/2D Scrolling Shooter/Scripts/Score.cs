using System.IO;
using TMPro;
using UnityEngine;

// �÷��̾��� ������ �����ϴµ� ����� ������ Ŭ����
// [System.Serializable]�� �ٿ��� �ν����Ϳ��� �ʿ��� �� ������ ����

[System.Serializable]
public class Score
{
    // �÷��̾��� ���� ����
    private int score = 0;

    // �÷��̾��� �ְ� ����(���)
    [SerializeField] private int bestScore = 0;

    //public string jsonString;

    // �ؽ�Ʈ UI ���� ����
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI bestScoreText;

    // ���� �޼ҵ� - �ʱ�ȭ �Լ�
    public void Initialize()
    {
        // �ְ� ���� �ε�
        //bestScore = PlayerPrefs.GetInt("BestScore");

        // ������ȭ
        // 1. ������ �ҷ��� ���ڿ��� �о����
        string jsonString = File.ReadAllText($"{Application.dataPath}/Score.txt");

        // 2. �ҷ��� ���ڿ� ���� ��ü�� ���� (������ȭ)
        bestScore = JsonUtility.FromJson<Score>(jsonString).bestScore;

        // UI ������Ʈ
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

    // ���� ȹ�� �Լ�
    public void Add(int gainScore)
    {
        // ���� ����.
        score += gainScore;

        if (scoreText != null)
            scoreText.text = $"Score: {score}";

        // �ְ� ���� Ȯ�� �Ŀ� �Ѿ����� �ְ� ������ ������Ʈ
        if (score > bestScore)
        {
            bestScore = score;

            // �ְ� ������ ���Ͽ� ���.
            PlayerPrefs.SetInt("BestScore", bestScore);

            // JSON���� ���
            // 1. ������ ��ü�� JSON���ڿ��� ���� (��ȯ)
            var jsonString = JsonUtility.ToJson(this);
            
            // 2. ��ȯ�� JSON ���ڿ��� ���Ϸ� ����
            // 2-1. ���Ϸ� �����Ϸ��� ���(�����Ϸ��� ��ġ)�� ���� �̸�, Ȯ���ڸ� �����ؾ� ��.
            File.WriteAllText($"{Application.dataPath}/Score.txt", jsonString);

            if (bestScoreText != null)
                bestScoreText.text = $"BestScore: {bestScore}";
        }

    }


}
