using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicProgress : MonoBehaviour
{
    public AudioSource audioSource;
    public float yMax = 5f;         // ������������ �������� �� Y
    public Text progressText;       // ����� � ��������� 

    Vector3 startPos;              // ��������� ������� �������
    float startTime;                // ����� ������ ������������
    float journeyLength;           // ����� ��������� �����
    public PlayableDirector Timeline;

    void Start()
    {
        startPos = transform.position;
        startTime = Time.time;
        journeyLength = audioSource.clip.length;
    }

    void Update()
    {
        // �������� ��������� ����� � ������� ������������
        float elapsedTime = Time.time - startTime;
        float progress = elapsedTime / journeyLength;

        // ������ ������ Y �������, ��������� ��������� ��� � ������
        Vector3 pos = startPos;
        pos.y = Mathf.Lerp(startPos.y, yMax, progress);
        transform.position = pos;
        // ��������� ����� � ��������� ������������
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