using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 1f;
    public float[] delayTimes;

    private Transform childTransform;
    protected int currentDelayIndex = 0;

    private void Update()
    {
        childTransform = transform.GetChild(0);
        if (currentDelayIndex < delayTimes.Length)
        {
            float delay = delayTimes[currentDelayIndex];
            if (delay <= 0f)
            {
                MoveObject();
            }
            else
            {
                delay -= Time.deltaTime;
                delayTimes[currentDelayIndex] = delay;
            }
        }
    }

    private void MoveObject()
    {
        float newZ = childTransform.localPosition.z - speed * Time.deltaTime;
        childTransform.localPosition = new Vector3(childTransform.localPosition.x, childTransform.localPosition.y, newZ);
    }

    public void TriggerToReset()
    {
        currentDelayIndex++;
        if (currentDelayIndex < delayTimes.Length)
        {
            float delay = delayTimes[currentDelayIndex];
            if (delay <= 0f)
            {
                MoveObject();
            }
        }
    }
}
