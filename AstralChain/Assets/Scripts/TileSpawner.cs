using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject Tile;
    public float delay = 0f;

    void Start()
    {
        spawnUntill();
    }
    void Update()
    {
        if(checkForEmpty())
        {
            spawnUntill();
        }
    }
    public void spawnUntill()
    {
        Transform position = freePosition();
        if (position)
        {
            GameObject piano = Instantiate(Tile, position.transform.position, Quaternion.identity);
            piano.transform.parent = position;

        }
        if (freePosition())
        {
            spawnUntill();
        }
    }
    bool checkForEmpty()
    {
        foreach (Transform child in transform)
        {
            if(child.childCount > 5)
            {
                return false;
            }
        }
        return true;
    }
    Transform freePosition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0 )
            {
                return child;
            }
        }
        return null;
    }
}
