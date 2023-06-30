using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class Pause : MonoBehaviour
{
    private AudioSource[] audioSources;
    private Equalizer[] equalizers;
    private List<Button> tileButtonComponents;

    public GameObject[] TileButtons;

    private PostProcessVolume postProcessVolume;
    private DepthOfField depthOfField;

    public GameObject PauseButton;
    public GameObject ResumeButton;

    private void Start()
    {
        postProcessVolume = Camera.main.GetComponent<PostProcessVolume>();
        depthOfField = postProcessVolume.profile.GetSetting<DepthOfField>();
        
        audioSources = FindObjectsOfType<AudioSource>();
        equalizers = FindObjectsOfType<Equalizer>();

        tileButtonComponents = new List<Button>();
        foreach (GameObject tileButton in TileButtons)
        {
            Button buttonComponent = tileButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                tileButtonComponents.Add(buttonComponent);
            }
        }
    }

    public void ToggleResume()
    {
            Time.timeScale = 1f; // Возобновление времени в игре

            // Возобновление музыки
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.UnPause();
            }

            foreach (Equalizer equalizer in equalizers)
            {
                equalizer.enabled = true;
            }

            // Включение кнопок
            foreach (Button buttonComponent in tileButtonComponents)
            {
                buttonComponent.interactable = true;
            }
            depthOfField.enabled.value = false;
        Button pause = PauseButton.GetComponent<Button>();
        pause.enabled = true;
        ResumeButton.active = false;
    }

    public void TogglePause()
    {
            Time.timeScale = 0f; // Остановка времени в игре

            // Приостановка музыки
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.Pause();
            }

            foreach (Equalizer equalizer in equalizers)
            {
                equalizer.enabled = false;
            }
            // Выключение кнопок
            foreach (Button buttonComponent in tileButtonComponents)
            {
                buttonComponent.interactable = false;
            }
        depthOfField.enabled.value = true;
            Button pause = PauseButton.GetComponent<Button>();
            pause.enabled = false;
            ResumeButton.active = true;
    }
}
