using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 positionOnGrid;
    private Vector3 targetGridLocation;
    private Vector3 targetWorldLocation;

    private Rigidbody rigidBody;

    public Floor floor;

    void Start()
    {
        rigidBody = GetComponent <Rigidbody> ();
        floor = GameObject.Find("Floor").GetComponent<Floor>();
    }

    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            Move("TR");
        }
        if (Input.GetKeyDown("down"))
        {
            Move("BL");
        }
        if (Input.GetKeyDown("left"))
        {
            Move("TL");
        }
        if (Input.GetKeyDown("right"))
        {
            Move("BR");
        }
    }

    void Move(string direction)
    {
        // get player position in grid space
        GetPositionOnGrid();
        // get target tile in world space
        GetTargetPosition(direction);
        // lerp player to target position
        // StartCoroutine("LerpToTarget");
        MovePlayer();
    }


    void GetPositionOnGrid()
    {
        positionOnGrid = floor.GetPlayerPositionOnGrid(gameObject.transform.position);
    }

    void GetTargetPosition(string direction)
    {
        // get target tile in grid space
        switch(direction)
        {
            case("TL"):
                targetGridLocation = new Vector3(positionOnGrid.x, positionOnGrid.y + 1, positionOnGrid.z);
                break;
            case("TR"):
                targetGridLocation = new Vector3(positionOnGrid.x + 1, positionOnGrid.y, positionOnGrid.z);
                break;
            case("BL"):
                targetGridLocation = new Vector3(positionOnGrid.x - 1, positionOnGrid.y, positionOnGrid.z);
                break;
            case("BR"):
                targetGridLocation = new Vector3(positionOnGrid.x, positionOnGrid.y - 1, positionOnGrid.z);
                break;
        }

        // get target tile position in world space
        targetWorldLocation = floor.GetTilePositionInWorld(targetGridLocation);
        // Debug.Log(targetWorldLocation);
    }

    void MovePlayer()
    {
        transform.position = targetWorldLocation;
    }

    IEnumerator LerpToTarget()
    {


        float sqrRemainingDistance = (transform.position - targetWorldLocation).sqrMagnitude;
        while(sqrRemainingDistance > float.Epsilon)
        {


            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }
    }
}
