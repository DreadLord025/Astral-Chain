using UnityEngine;
using System.Collections;

public class RandomBubble : MonoBehaviour
{
    public GameObject objectPrefab;
    public int spawnLimit;
    public float sizeMin;
    public float sizeMax;
    public Color color1;
    public Color color2;
    public float alphaValue;
    public float movementSpeedMin;
    public float movementSpeedMax;
    public float spawnZoneXMin;
    public float spawnZoneXMax;
    public float cleanupDelay = 10f; // Delay before cleaning up the first objects

    private float spawnTimer = 0f;
    private float cleanupTimer = 0f;
    private bool cleanupStarted = false;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 0.5f)
        {
            spawnTimer = 0f;

            if (transform.childCount < spawnLimit)
            {
                SpawnRandomObject();
            }
        }

        if (!cleanupStarted && transform.childCount >= spawnLimit)
        {
            cleanupTimer += Time.deltaTime;
            if (cleanupTimer >= cleanupDelay)
            {
                StartCleanup();
            }
        }

        MoveObjects();
    }

    private void SpawnRandomObject()
    {
        float x = Random.Range(spawnZoneXMin, spawnZoneXMax);
        float y = Random.Range(-spawnLimit, spawnLimit);

        Vector3 spawnPosition = Camera.main.transform.position;
        spawnPosition.x = x;
        spawnPosition.y = -20f + y;
        spawnPosition.z = 20f; // Set Z position to 0

        float size = Random.Range(sizeMin, sizeMax);

        GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, transform);
        spawnedObject.transform.localScale = new Vector2(size, size);

        SpriteRenderer spriteRenderer = spawnedObject.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            Color randomColor = Random.value < 0.5f ? color1 : color2;
            randomColor.a = 0f; // Set initial alpha to 0
            spriteRenderer.color = randomColor;

            StartCoroutine(IncreaseAlphaOverTime(spriteRenderer, alphaValue));
        }
    }

    private void MoveObjects()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            float movementSpeed = Random.Range(movementSpeedMin, movementSpeedMax);
            child.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }
    }

    private IEnumerator IncreaseAlphaOverTime(SpriteRenderer spriteRenderer, float targetAlpha)
    {
        float currentAlpha = spriteRenderer.color.a;
        float elapsedTime = 0f;
        float duration = 1f; // Duration for alpha increase

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, t);

            Color newColor = spriteRenderer.color;
            newColor.a = newAlpha;
            spriteRenderer.color = newColor;

            yield return null;
        }
    }

    private void StartCleanup()
    {
        cleanupStarted = true;

        for (int i = 0; i < spawnLimit; i++)
        {
            if (i < transform.childCount)
            {
                Transform child = transform.GetChild(i);
                StartCoroutine(DelayedDestroy(child.gameObject, i * 0.1f));
            }
        }
    }

    private IEnumerator DelayedDestroy(GameObject gameObject, float delay)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            yield return StartCoroutine(DecreaseAlphaOverTime(spriteRenderer, 0f));
        }

        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private IEnumerator DecreaseAlphaOverTime(SpriteRenderer spriteRenderer, float targetAlpha)
    {
        float currentAlpha = spriteRenderer.color.a;
        float elapsedTime = 0f;
        float duration = 1f; // Duration for alpha decrease

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, t);

            Color newColor = spriteRenderer.color;
            newColor.a = newAlpha;
            spriteRenderer.color = newColor;

            yield return null;
        }
    }
}
