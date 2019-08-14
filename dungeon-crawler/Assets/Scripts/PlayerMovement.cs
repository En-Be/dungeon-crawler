using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 playerPositionOnGrid;
    private Vector2 playerTargetGridLocation;
    private Vector2 playerTargetWorldLocation;

    public Floor floor;

    void Start()
    {
        floor = GameObject.Find("Floor").GetComponent<Floor>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // get player position in grid space
        GetPlayerPositionOnGrid();
        // get player direction to move(passed in param)
        // if top right, target tile = player tile x, player tile y + 1

        // get target tile position in world space
        // lerp player to target position
        // update player cell position
    }

    void GetPlayerPositionOnGrid()
    {
        playerPositionOnGrid = floor.GetPlayerPositionOnGrid(gameObject.transform);
    }
}
