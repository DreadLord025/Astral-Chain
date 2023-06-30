using UnityEngine;
using System.Collections;

public class ButtonTapArea : MonoBehaviour
{
    private ObjectMovement ObjectScript1;
    private ObjectMovement ObjectScript2;
    private ObjectMovement ObjectScript3;
    private ObjectMovement ObjectScript4;

    public GameObject GameObjectScript1;
    public GameObject GameObjectScript2;
    public GameObject GameObjectScript3;
    public GameObject GameObjectScript4;

    public GameObject staticObject;

    public int scoreValue = 1;

    public void Start()
    {
        ObjectScript1 = GameObjectScript1.GetComponent<ObjectMovement>();
        ObjectScript2 = GameObjectScript2.GetComponent<ObjectMovement>();
        ObjectScript3 = GameObjectScript3.GetComponent<ObjectMovement>();
        ObjectScript4 = GameObjectScript4.GetComponent<ObjectMovement>();
    }
    public void OnTap()
    {
        CheckCollisionAndDestroy();
    }

    private void CheckCollisionAndDestroy()
    {
        Collider staticCollider = staticObject.GetComponent<Collider>();
        // Первый сегмент
        Collider child1 = GameObjectScript1.GetComponentInChildren<Collider>();
        Collider childCollider1 = child1;
        // Второй сегмент
        Collider child2 = GameObjectScript2.GetComponentInChildren<Collider>();
        Collider childCollider2 = child2;
        // Третий сегмент
        Collider child3 = GameObjectScript3.GetComponentInChildren<Collider>();
        Collider childCollider3 = child3;
        // Четвёртый сегмент
        Collider child4 = GameObjectScript4.GetComponentInChildren<Collider>();
        Collider childCollider4 = child4;

        if (childCollider1 != staticCollider && childCollider1.bounds.Intersects(staticCollider.bounds))
        {
            FindObjectOfType<Score>().ScoreUpdate();
            Destroy(childCollider1.gameObject);
            ObjectScript1.TriggerToReset();
        }
        if (childCollider2 != staticCollider && childCollider2.bounds.Intersects(staticCollider.bounds))
        {
            FindObjectOfType<Score>().ScoreUpdate();
            Destroy(childCollider2.gameObject);
            ObjectScript2.TriggerToReset();
        }
        if (childCollider3 != staticCollider && childCollider3.bounds.Intersects(staticCollider.bounds))
        {
            FindObjectOfType<Score>().ScoreUpdate();
            Destroy(childCollider3.gameObject);
            ObjectScript3.TriggerToReset();
        }
        if (childCollider4 != staticCollider && childCollider4.bounds.Intersects(staticCollider.bounds))
        {
            FindObjectOfType<Score>().ScoreUpdate();
            Destroy(childCollider4.gameObject);
            ObjectScript4.TriggerToReset();
        }
    }
}
