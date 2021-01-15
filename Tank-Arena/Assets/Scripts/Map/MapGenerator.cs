using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Map map;

    public GameObject[] terrainPrefabs;

    [Header("Terrain Toppers")]
    public GameObject[] toppers;

    private void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        float centerX = ((map.width - 1) / 2);
        float centerZ = ((map.height - 1) / 2);

        Debug.Log("(" + centerX + ", " + centerZ + ")");

        float playRadius = ((map.playableArea - 1) / 2);

        float rowsFromPlayEdgeToBottomEdge = Mathf.Abs(0 - (centerZ - playRadius));
        float rowsFromPlayEdgeToTopEdge = Mathf.Abs((map.height - 1) - (centerZ + playRadius));
        float colsFromPlayEdgeToLeftEdge = Mathf.Abs(0 - (centerX - playRadius));
        float colsFromPlayEdgeToRightEdge = Mathf.Abs((map.width - 1) - (centerX + playRadius));

        Debug.Log("Number of rows to bottom edge: " + rowsFromPlayEdgeToBottomEdge);
        Debug.Log("Number of rows to top edge: " + rowsFromPlayEdgeToTopEdge);
        Debug.Log("Number of cols to left edge: " + colsFromPlayEdgeToLeftEdge);
        Debug.Log("Number of cols to right edge: " + colsFromPlayEdgeToRightEdge);

        for (int z = 0; z < map.height; z++)
        {
            for (int x = 0; x < map.width; x++)
            {
                TerrainType type = map.terrain[x + map.width * z];
                Vector3 position;
                position.x = x * map.offset;

                if (type == TerrainType.water || type == TerrainType.lava)
                {
                    position.y = -1.5f + (-1.5f * .25f);
                }
                else
                {
                    position.y = -1.5f;
                }

               

                if (z < rowsFromPlayEdgeToBottomEdge)
                {
                    if (z == rowsFromPlayEdgeToBottomEdge - 1)
                    {
                        position.y = Random.Range(-0.5f, 0.5f);
                    }
                    else if (z == rowsFromPlayEdgeToBottomEdge - 2)
                    {
                        position.y = Random.Range(1f, 2f);
                    }
                    else if (z == rowsFromPlayEdgeToBottomEdge - 3)
                    {
                        position.y = Random.Range(2.5f, 3.5f);
                    }
                }

                if (z > ((map.height - 1) - rowsFromPlayEdgeToTopEdge))
                {
                    if (z == (centerZ + playRadius) + 1)
                    {
                        position.y = Random.Range(-0.5f, 0.5f);
                    }
                    else if (z == (centerZ + playRadius) + 2)
                    {
                        position.y = Random.Range(1f, 2f);
                    }
                    else if (z == (centerZ + playRadius) + 3)
                    {
                        position.y = Random.Range(2.5f, 3.5f);
                    }
                }

                if (x < colsFromPlayEdgeToLeftEdge)
                {
                    if (x == colsFromPlayEdgeToLeftEdge - 1)
                    {
                        position.y = Random.Range(-0.5f, 0.5f);
                    }
                    else if (x == colsFromPlayEdgeToLeftEdge - 2)
                    {
                        position.y = Random.Range(1f, 2f);
                    }
                    else if (x == colsFromPlayEdgeToLeftEdge - 3)
                    {
                        position.y = Random.Range(2.5f, 3.5f);
                    }
                }

                if (x > ((map.width - 1) - colsFromPlayEdgeToRightEdge))
                {
                    if (x == (centerX + playRadius) + 1)
                    {
                        position.y = Random.Range(-0.5f, 0.5f);
                    }
                    else if (x == (centerX + playRadius) + 2)
                    {
                        position.y = Random.Range(1f, 2f);
                    }
                    else if (x == (centerX + playRadius) + 3)
                    {
                        position.y = Random.Range(2.5f, 3.5f);
                    }
                }

                position.z = z * map.offset;

                GameObject tile = Instantiate(terrainPrefabs[(int)type]);
                tile.transform.SetParent(this.transform, false);
                tile.transform.localPosition = position;

                Toppers topperType = map.toppers[x + map.width * z];

                GameObject topper = Instantiate(toppers[(int)topperType]);
                topper.transform.SetParent(this.transform, false);
                topper.transform.localPosition = position;

                if (topperType == Toppers.playerSpawn)
                {
                    GameManager.instance.availableSpawnLocations.Add(topper.transform.GetChild(0).transform);

                    if (z == (centerZ - playRadius) + 1)
                    {

                        topper.transform.forward = -topper.transform.right;

                    }

                    if(z == (centerZ + playRadius) - 1)
                    {
                        topper.transform.forward = topper.transform.right;
                    }

                    if (x == (centerX + playRadius) - 1)
                    {
                        topper.transform.forward = -topper.transform.forward;
                    }
                }
            }
        }

        GameManager.instance.StartGame();
    }
}
