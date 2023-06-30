using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text TextScore;
    public int scorePoints;
    private const float totalTime = 1f; // Время для полного обновления счетчика

    private bool CoroutineNow = false; // Флаг, указывающий на текущее выполнение корутины

    public void ScoreUpdate()
    {
        if (CoroutineNow)
        {
            return; // Если уже выполняется корутина, просто выходим из метода
        }

        int currentScore = scorePoints; // Сохраняем текущее значение счетчика
        int randomScore = Random.Range(200, 501);

        StartCoroutine(UpdateScore(currentScore, currentScore + randomScore)); // Используем сохраненное значение текущего счетчика
    }

    private IEnumerator UpdateScore(int startScore, int targetScore)
    {
        CoroutineNow = true;
        float elapsedTime = 0f; // Прошедшее время
        int finalScore = targetScore; // Сохраняем конечное значение счетчика

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / totalTime; // Прогресс обновления счетчика (от 0 до 1)
            int currentScore = (int)Mathf.Lerp(startScore, finalScore, progress); // Интерполируем текущий счетчик

            string scoreText = currentScore.ToString("D8"); // Форматируем счет с ведущими нулями до 8 цифр
            TextScore.text = scoreText;

            yield return null;
        }

        // Убеждаемся, что конечное значение счетчика точно соответствует finalScore
        scorePoints = finalScore;
        // Обнуляем флаг после завершения обновления
        CoroutineNow = false;
    }
}
