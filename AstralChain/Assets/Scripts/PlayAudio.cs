using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour 
{
    public AudioSource audioSourceMUSIC;
    public AudioClip audioClip;
    public AudioSource ClickAudioSource;
    public AudioClip[] ClickAudio;
    public float fadeDuration = 1f;
    public float delay;
    void Start()
    {
        StartCoroutine(FadeInAudio(audioSourceMUSIC, fadeDuration));
    }
    private IEnumerator FadeInAudio(AudioSource audioSource, float duration = 5f)
    {
        yield return new WaitForSeconds(delay);

        audioSourceMUSIC.volume = 0f;
        audioSourceMUSIC.PlayOneShot(audioClip);
        float elapsedTime = 0f;
        float startVolume = 0f;
        float targetVolume = 1f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = targetVolume;
    }

    public void ClickSoundTap()
    {
        int randomSound = Random.Range(0, ClickAudio.Length);
        AudioClip RandomClip = ClickAudio[randomSound];

        ClickAudioSource.PlayOneShot(RandomClip);
    }
}
