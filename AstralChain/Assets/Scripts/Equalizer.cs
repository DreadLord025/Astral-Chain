using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equalizer : MonoBehaviour
{
    [Space(15)]
    public Color equalizerColor = Color.gray;
    public ObjectEqualizer[] visualizerObjects;
    public AudioSource audioSource;
    private AudioClip audioClip;
    [Space(15), Range(64, 8192)]
    public float minHeight = 35.0f;
    public float maxHeight = 1035.0f;
    public int visualizerSimples = 64;
    public float updateSenstivity = 0.5f;

    void Start()
    {
        visualizerObjects = GetComponentsInChildren<ObjectEqualizer>();

        audioClip = audioSource.clip;
        if (!audioClip) return;
       
    } 
    void Update()
    {
        float[] spectrumData = audioSource.GetSpectrumData(visualizerSimples, 0, FFTWindow.Rectangular);

        for (int i = 0; i < visualizerObjects.Length; i++)
        {
            Vector2 newSize = visualizerObjects[i].GetComponent<RectTransform>().rect.size;
            newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, minHeight + (spectrumData[i] * (maxHeight - minHeight) * 5.0f), updateSenstivity), minHeight, maxHeight);
            visualizerObjects[i].GetComponent<RectTransform>().sizeDelta = newSize;

            visualizerObjects[i].GetComponent<Image>().color = equalizerColor;
        }
    }
}