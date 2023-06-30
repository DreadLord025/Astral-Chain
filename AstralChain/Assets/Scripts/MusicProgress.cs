using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicProgress : MonoBehaviour
{
    public AudioSource audioSource;
    public float yMax = 5f;         // Максимальное поднятие по Y
    public Text progressText;       // Текст с процентом 

    Vector3 startPos;              // Начальная позиция объекта
    float startTime;                // Время начала проигрывания
    float journeyLength;           // Длина звукового клипа
    public PlayableDirector Timeline;

    void Start()
    {
        startPos = transform.position;
        startTime = Time.time;
        journeyLength = audioSource.clip.length;
    }

    void Update()
    {
        // Получаем прошедшее время и процент проигрывания
        float elapsedTime = Time.time - startTime;
        float progress = elapsedTime / journeyLength;

        // Меняем только Y позицию, остальные оставляем как в начале
        Vector3 pos = startPos;
        pos.y = Mathf.Lerp(startPos.y, yMax, progress);
        transform.position = pos;
        // Обновляем текст с процентом проигрывания
        int progressInt = (int)(progress * 100);

        if (progressInt >= 0 && progressInt <= 100)
        {
            progressText.text = progressInt.ToString();
        }
        if (progressInt == 102)
        {
            Timeline.Play();
        }
        if (Timeline.state == PlayState.Playing && Timeline.time >= Timeline.duration)
        {
            SceneManager.LoadScene(0);
        }
    }
}