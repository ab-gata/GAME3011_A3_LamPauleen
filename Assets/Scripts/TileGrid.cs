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
                // Get random tile value
                int rand = (int)Random.Range(1.0f, 6.0f);

                // Instantiate square
                Image temp = Instantiate(squarePrefab);
                temp.transform.SetParent(gameObject.transform);
                temp.transform.position = new Vector3(x * distanceBetween + (distanceBetween * dimentions / 8), y * distanceBetween + (distanceBetween * dimentions / 8), 0);
                temp.GetComponent<SquareBehaviour>().setPositionVector(x, y);
                temp.GetComponent<SquareBehaviour>().changeSquare(rand);
                squares.Add(temp.GetComponent<SquareBehaviour>());
            }
        }
    }

    private void helooooooooooo()
    {
        int rand = (int)Random.Range(1.0f, 6.0f);

        Debug.Log(rand);


        // check for matches
        foreach (var item in squares)
        {
            //if (item.PositionVector.x >= (randX - 2) && item.PositionVector.x <= (randX + 2))
            //{
            //    if (item.PositionVector.y >= (randY - 2) && item.PositionVector.y <= (randY + 2))
            //    {
            //        item.setValue(m, Cut.QUARTER);
            //    }
            //}
            //if (item.PositionVector.x >= (randX - 1) && item.PositionVector.x <= (randX + 1))
            //{
            //    if (item.PositionVector.y >= (randY - 1) && item.PositionVector.y <= (randY + 1))
            //    {
            //        item.setValue(m, Cut.HALF);
            //    }
            //}
            //if (item.PositionVector.x == randX && item.PositionVector.x == randX)
            //{
            //    if (item.PositionVector.y == randY && item.PositionVector.y == randY)
            //    {
            //        item.setValue(m, Cut.FULL);
            //    }
            //}
        }
    }
}
