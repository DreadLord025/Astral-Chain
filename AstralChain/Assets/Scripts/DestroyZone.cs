using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public GameObject staticObject;
    public GameObject[] AllTiles;

    void Update()
    {
        Collider staticCollider = staticObject.GetComponent<Collider>();

        foreach (GameObject tile in AllTiles)
        {
            ObjectMovement template = tile.GetComponent<ObjectMovement>();
            Collider childCollider = tile.GetComponentInChildren<Collider>();

            GameObject otherGO = childCollider.gameObject;

                // ��������� ����������� ������������ ���������� � ���������� ������������
                if (childCollider != staticCollider && childCollider.bounds.Intersects(staticCollider.bounds))
                {
                    // �������� GameObject � �����������
                    Destroy(otherGO);
                    template.TriggerToReset();
                }
        }
    }
}
