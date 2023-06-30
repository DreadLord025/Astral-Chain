using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SelectTrack.ButtonCount1 == 2)
        {
            StartCoroutine(LoadAsyncFirst());
        }
        if (SelectTrack.ButtonCount2 == 2)
        {
            StartCoroutine(LoadAsyncSecond());
        }
        if (SelectTrack.ButtonCount3 == 2)
        {
            StartCoroutine(LoadAsyncThird());
        }
        if (SelectTrack.ButtonCount4 == 2)
        {
            StartCoroutine(LoadAsyncFour());
        }
        if (SelectTrack.ButtonCount5 == 2)
        {
            StartCoroutine(LoadAsyncFive());
        }
    }
    IEnumerator LoadAsyncFirst()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(6);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    IEnumerator LoadAsyncSecond()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(7);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    IEnumerator LoadAsyncThird()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(8);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    IEnumerator LoadAsyncFour()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(9);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    IEnumerator LoadAsyncFive()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(10);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
