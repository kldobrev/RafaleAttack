using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SeaGeneratorController : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Transform centerPointTransform;
    [SerializeField]
    private int numberOfTilesLength;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Generating ground tiles...");
        Bounds tilePrefabBounds = tilePrefab.GetComponent<MeshRenderer>().bounds;
        Vector3 tileGlobalSize = tilePrefabBounds.max - tilePrefabBounds.min;
        Vector3 startingTilePosition = centerPointTransform.position;
        startingTilePosition.x += (((numberOfTilesLength / 2) * tileGlobalSize.x) - (numberOfTilesLength % 2 == 0 ?  tileGlobalSize.x / 2 : 0));
        startingTilePosition.y = 0f;
        startingTilePosition.z += (((numberOfTilesLength / 2) * tileGlobalSize.z) - (numberOfTilesLength % 2 == 0 ? tileGlobalSize.z / 2 : 0));

        Vector3 currentTilePosition = Vector3.zero;
        for(int i = 0; i != numberOfTilesLength; i++)
        {
            currentTilePosition.x = startingTilePosition.x - (i * tileGlobalSize.x);
            for (int j = 0; j != numberOfTilesLength; j++)
            {
                currentTilePosition.z = startingTilePosition.z - (j * tileGlobalSize.z);
                GameObject tile = GameObject.Instantiate(tilePrefab, currentTilePosition, Quaternion.identity);
                tile.transform.parent = transform;
                Debug.Log("Ground tile (" + i + ", " + j + ") generated."  );
            }
        }
        Debug.Log("Generating ground tiles completed successfully.");
    }

}
