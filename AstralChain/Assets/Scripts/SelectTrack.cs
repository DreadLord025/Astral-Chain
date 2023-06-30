using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTrack : MonoBehaviour
{
    public AudioSource TrackSource;
    public AudioSource MainSource;

    public AudioClip Track1;
    public AudioClip Track2;
    public AudioClip Track3;
    public AudioClip Track4;
    public AudioClip Track5;

    public static int ButtonCount1 = 0;
    public static int ButtonCount2 = 0;
    public static int ButtonCount3 = 0;
    public static int ButtonCount4 = 0;
    public static int ButtonCount5 = 0;

    public void SelectFirst()
    {
        ButtonCount2 = 0;
        ButtonCount3 = 0;
        ButtonCount4 = 0;
        ButtonCount5 = 0;
        ButtonCount1++;
        MainSource.Stop();
        TrackSource.Stop();
        if (ButtonCount1 == 1) TrackSource.PlayOneShot(Track1);
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void SelectSecond()
    {
        ButtonCount1 = 0;
        ButtonCount3 = 0;
        ButtonCount4 = 0;
        ButtonCount5 = 0;
        ButtonCount2++;
        MainSource.Stop();
        TrackSource.Stop();
        if (ButtonCount2 == 1) TrackSource.PlayOneShot(Track2);
        else SceneManager.LoadScene(2);
    }
    public void SelectThird()
    {
        ButtonCount2 = 0;
        ButtonCount1 = 0;
        ButtonCount4 = 0;
        ButtonCount5 = 0;
        ButtonCount3++;
        MainSource.Stop();
        TrackSource.Stop();
        if (ButtonCount3 == 1) TrackSource.PlayOneShot(Track3);
        else SceneManager.LoadScene(3);
    }
    public void SelectFour()
    {
        ButtonCount2 = 0;
        ButtonCount3 = 0;
        ButtonCount1 = 0;
        ButtonCount5 = 0;
        ButtonCount4++;
        MainSource.Stop();
        TrackSource.Stop();
        if (ButtonCount4 == 1) TrackSource.PlayOneShot(Track4);
        else
        {
            ButtonCount4 = 0;
            TrackSource.Stop();
            TrackSource.PlayOneShot(Track4);
        }
    }
    public void SelectFive()
    {
        ButtonCount2 = 0;
        ButtonCount3 = 0;
        ButtonCount4 = 0;
        ButtonCount1 = 0;
        ButtonCount5++;
        MainSource.Stop();
        TrackSource.Stop();
        if (ButtonCount5 == 1) TrackSource.PlayOneShot(Track5);
        else
        {
            ButtonCount5 = 0;
            TrackSource.Stop();
            TrackSource.PlayOneShot(Track5);
        }
    }
}
