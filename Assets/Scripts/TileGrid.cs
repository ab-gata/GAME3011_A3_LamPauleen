using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGrid : MonoBehaviour
{
    // Tile Set Up
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

    public bool CheckSquares()
    {
        int rand = (int)Random.Range(1.0f, 6.0f);
        SquareBehaviour nextSquare;
        SquareBehaviour nextNextSquare;

        Debug.Log(rand);

        foreach (var item in squares)
        {
            // CHECK FOR HORIZONTAL MATCH
            if (item.PositionVector.x < dimentions - 2)
            {
                // get the square next to current one
                nextSquare = GetSquareBehaviourByPosition(item.PositionVector.x + 1.0f, item.PositionVector.y);

                if (item.CurrentSprite == nextSquare.CurrentSprite)
                {
                    // get the square next to that one
                    nextNextSquare = GetSquareBehaviourByPosition(item.PositionVector.x + 2.0f, item.PositionVector.y);

                    if(item.CurrentSprite == nextNextSquare.CurrentSprite)
                    {
                        Debug.Log("we have a horizontal match!");
                        return true;
                    }
                }
            }

            // CHECK FOR VERTICAL MATCH
            if (item.PositionVector.y < dimentions - 2)
            {
                // get the square next to current one
                nextSquare = GetSquareBehaviourByPosition(item.PositionVector.x, item.PositionVector.y + 1.0f);

                if (item.CurrentSprite == nextSquare.CurrentSprite)
                {
                    // get the square next to that one
                    nextNextSquare = GetSquareBehaviourByPosition(item.PositionVector.x, item.PositionVector.y + 2.0f);

                    if (item.CurrentSprite == nextNextSquare.CurrentSprite)
                    {
                        Debug.Log("we have a vertical match!");
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void RemoveHighlights()
    {
        foreach (var item in squares)
        {
            item.hightlightSquare(false);
        }
    }

    private SquareBehaviour GetSquareBehaviourByPosition(float x, float y)
    {
        // check for matches
        foreach (var item in squares)
        {
            if (item.PositionVector == new Vector2(x, y))
            {
                return item;
            }
        }
        return null;
    }

    private void DropColomn()
    {

    }
}
