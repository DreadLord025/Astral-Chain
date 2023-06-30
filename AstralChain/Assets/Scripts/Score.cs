using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text TextScore;
    public int scorePoints;
    private const float totalTime = 1f; // ����� ��� ������� ���������� ��������

    private bool CoroutineNow = false; // ����, ����������� �� ������� ���������� ��������

    public void ScoreUpdate()
    {
        if (CoroutineNow)
        {
            return; // ���� ��� ����������� ��������, ������ ������� �� ������
        }

        int currentScore = scorePoints; // ��������� ������� �������� ��������
        int randomScore = Random.Range(200, 501);

        StartCoroutine(UpdateScore(currentScore, currentScore + randomScore)); // ���������� ����������� �������� �������� ��������
    }

    private IEnumerator UpdateScore(int startScore, int targetScore)
    {
        CoroutineNow = true;
        float elapsedTime = 0f; // ��������� �����
        int finalScore = targetScore; // ��������� �������� �������� ��������

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / totalTime; // �������� ���������� �������� (�� 0 �� 1)
            int currentScore = (int)Mathf.Lerp(startScore, finalScore, progress); // ������������� ������� �������

            string scoreText = currentScore.ToString("D8"); // ����������� ���� � �������� ������ �� 8 ����
            TextScore.text = scoreText;

            yield return null;
        }

        // ����������, ��� �������� �������� �������� ����� ������������� finalScore
        scorePoints = finalScore;
        // �������� ���� ����� ���������� ����������
        CoroutineNow = false;
    }
}
