using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map", menuName = "Map")]
public class Map : ScriptableObject
{
    public int height, width, playableArea, offset;

    public TerrainType edgeTerrain;

    public TerrainType[] terrain;
    public Toppers[] toppers;


}

public enum TerrainType
{
    bridge, cliff, dirt, grass1, grass2, lava, rock, sand, snow, tile, water, wood  
}

public enum Toppers
{
    none, bones, cactus, cornField, desertPlant, farmhouse, house1, house2, playerSpawn
}

