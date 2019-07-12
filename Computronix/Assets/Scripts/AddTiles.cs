using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AddTiles : MonoBehaviour
{
    public int xStart = -5;
    public int yStart = 1;
    public int numOfVertCells = 6;
    public int numOfHorCells = 10;
    public TileBase[] TB;

    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        for(int x = 0; x < numOfHorCells; x++)
        {
            for(int y = 0; y < numOfVertCells; y++)
            {
                tilemap.SetTile(new Vector3Int(xStart + x, yStart + y, 0), TB[Random.Range(0,TB.Length)]);
            }
        }
    }
}
