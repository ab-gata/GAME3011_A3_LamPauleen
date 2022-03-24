using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGrid : MonoBehaviour
{
    [SerializeField, Header("Tile Set Up")]
    private Image squarePrefab;
    [SerializeField]
    private int dimentions;
    [SerializeField]
    private float distanceBetween = 4;

    private int[,] gridArray;
    List<SquareBehaviour> squares = new List<SquareBehaviour>();

    void Start()
    {
        gridArray = new int[dimentions, dimentions];

        // Create the squares and set their value by chance
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                // Instantiate square
                Image temp = Instantiate(squarePrefab);
                temp.transform.SetParent(gameObject.transform);
                temp.transform.position = new Vector3(x * distanceBetween + (distanceBetween * dimentions / 8), y * distanceBetween + (distanceBetween * dimentions / 8), 0);
                temp.GetComponent<SquareBehaviour>().setPositionVector(x, y);
                squares.Add(temp.GetComponent<SquareBehaviour>());
            }
        }

        //for (int i = 0; i < goldMax; i++)
        //{
        //    setTileValues(Metal.GOLD);
        //}
        //for (int i = 0; i < silverMax; i++)
        //{
        //    setTileValues(Metal.SILVER);
        //}
        //for (int i = 0; i < bronzeMax; i++)
        //{
        //    setTileValues(Metal.BRONZE);
        //}
    }

    //private void setTileValues(Metal m)
    //{
    //    int randX = (int)Random.Range(0.0f, dimentions);
    //    int randY = (int)Random.Range(0.0f, dimentions);

    //    Debug.Log(randX + ", " + randY + ", " + m);

    //    foreach (var item in squares)
    //    {
    //        if (item.PositionVector.x >= (randX - 2) && item.PositionVector.x <= (randX + 2))
    //        {
    //            if (item.PositionVector.y >= (randY - 2) && item.PositionVector.y <= (randY + 2))
    //            {
    //                item.setValue(m, Cut.QUARTER);
    //            }
    //        }
    //        if (item.PositionVector.x >= (randX - 1) && item.PositionVector.x <= (randX + 1))
    //        {
    //            if (item.PositionVector.y >= (randY - 1) && item.PositionVector.y <= (randY + 1))
    //            {
    //                item.setValue(m, Cut.HALF);
    //            }
    //        }
    //        if (item.PositionVector.x == randX && item.PositionVector.x == randX)
    //        {
    //            if (item.PositionVector.y == randY && item.PositionVector.y == randY)
    //            {
    //                item.setValue(m, Cut.FULL);
    //            }
    //        }
    //    }
    //}
}
