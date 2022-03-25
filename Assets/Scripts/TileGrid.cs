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

    // Reference to player stats
    [SerializeField]
    private PlayerStats player;

    void Start()
    {
        gridArray = new int[dimentions, dimentions];

        int one = 0, two = 0;

        // Create the squares and set their value by chance
        for (int y = 0; y < gridArray.GetLength(0); y++)
        {
            for (int x = 0; x < gridArray.GetLength(1); x++)
            {
                // Get random tile value, and make sure it is not repeat three in a ROW
                int rand = (int)Random.Range(1.0f, 6.9f);
                if (rand == one && one == two)
                {
                    while (rand == one)
                    {
                        rand = (int)Random.Range(1.0f, 6.9f);
                    }
                }

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

    public void CheckSquares()
    {
        int matchCount = 0;
        // Mark squares that have matches
        foreach (var item in squares)
        {
            // Check HORIZONTAL match
            // Make sure square exists
            if (GetSquareBehaviourByPosition(item.PositionVector.x - 1, item.PositionVector.y) && GetSquareBehaviourByPosition(item.PositionVector.x + 1, item.PositionVector.y))
            {
                // Compare
                if (GetSquareBehaviourByPosition(item.PositionVector.x - 1, item.PositionVector.y).CurrentSprite == item.CurrentSprite &&
                    GetSquareBehaviourByPosition(item.PositionVector.x + 1, item.PositionVector.y).CurrentSprite == item.CurrentSprite)
                {
                    // Mark that they are matched
                    GetSquareBehaviourByPosition(item.PositionVector.x - 1, item.PositionVector.y).matched = true;
                    GetSquareBehaviourByPosition(item.PositionVector.x + 1, item.PositionVector.y).matched = true;
                    item.matched = true;

                    // TEEEEEEEEEMPPP HIGHLIGHT MATHC
                    GetSquareBehaviourByPosition(item.PositionVector.x - 1, item.PositionVector.y).hightlightSquare(true);
                    GetSquareBehaviourByPosition(item.PositionVector.x + 1, item.PositionVector.y).hightlightSquare(true);
                    item.hightlightSquare(true);

                    // Track player matched
                    matchCount++;
                }
            }


            // Check VERTICAL match
            // Make sure quare exists
            if (GetSquareBehaviourByPosition(item.PositionVector.x, item.PositionVector.y - 1) && GetSquareBehaviourByPosition(item.PositionVector.x, item.PositionVector.y + 1))
            {
                // Compare
                if (GetSquareBehaviourByPosition(item.PositionVector.x, item.PositionVector.y - 1).CurrentSprite == item.CurrentSprite &&
                GetSquareBehaviourByPosition(item.PositionVector.x, item.PositionVector.y + 1).CurrentSprite == item.CurrentSprite)
                {
                    // Mark that they are matched
                    GetSquareBehaviourByPosition(item.PositionVector.x, item.PositionVector.y - 1).matched = true;
                    GetSquareBehaviourByPosition(item.PositionVector.x, item.PositionVector.y + 1).matched = true;
                    item.matched = true;

                    // TEEEEEEEEEMPPP HIGHLIGHT MATHC
                    GetSquareBehaviourByPosition(item.PositionVector.x, item.PositionVector.y - 1).hightlightSquare(true);
                    GetSquareBehaviourByPosition(item.PositionVector.x, item.PositionVector.y + 1).hightlightSquare(true);
                    item.hightlightSquare(true);

                    // Track player matched
                    matchCount++;
                }
            }
        }

        // Increase player score
        player.IncreaseMatchCount(matchCount);

        // Shuffle matched squares
        for (int i = squares.Count - 1; i >= 0; i--)
        {
            if (squares[i].matched)
            {
                squares[i].changeSquare((int)Random.Range(1.0f, 6.9f));
                //squares[i].matched = false;
            }
        }
    }

    public bool CheckIfWin()
    {
        bool win = true;
        foreach (var item in squares)
        {
            if (!item.matched)
            {
                win = false;
            }
        }
        return win;
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





    private void DropColumn(float xPos, float yPos)
    {
        for (int y = (int)yPos; y < dimentions - 1; y++)
        {
            // apply top tile sprite to below
            GetSquareBehaviourByPosition(xPos, y).changeSquare(GetSquareBehaviourByPosition(xPos, y + 1).CurrentSprite);
        }

        // Randomly set the last tile
        int rand = (int)Random.Range(1.0f, 6.9f);
        GetSquareBehaviourByPosition(xPos, dimentions - 1).changeSquare(rand);
    }
}
