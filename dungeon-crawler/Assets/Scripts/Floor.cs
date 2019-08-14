using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Floor : MonoBehaviour {

    Tilemap tilemap;

    void Start () {
        tilemap = GetComponent<Tilemap>();

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++) {
            for (int y = 0; y < bounds.size.y; y++) {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null) {
                    // Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                } else {
                    // Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
            }
        }        
    }

    public Vector3 GetPlayerPositionOnGrid(Transform player)
    {
        Vector3 playerPositionOnGrid = tilemap.WorldToCell(player.position);
        Debug.Log(tilemap.WorldToCell(player.position));
        return playerPositionOnGrid;
    }  
}