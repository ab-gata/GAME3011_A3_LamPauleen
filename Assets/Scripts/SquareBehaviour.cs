using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum SpriteNumber
{
    ONE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX
}

public class SquareBehaviour : MonoBehaviour
{
    // Sprite images
    [SerializeField]
    private Sprite sprite1;
    [SerializeField]
    private Sprite sprite2;
    [SerializeField]
    private Sprite sprite3;
    [SerializeField]
    private Sprite sprite4;
    [SerializeField]
    private Sprite sprite5;
    [SerializeField]
    private Sprite sprite6;

    // Hightlight colour when pressed
    [SerializeField]
    private Color highlightColour;
    [SerializeField]
    private Color matchedColour;

    // position of square among the others
    private Vector2 positionVector = Vector2.zero;
    public Vector2 PositionVector { get { return positionVector; } }

    // The value of the resources in the square
    private SpriteNumber currentSprite = SpriteNumber.ONE;
    public SpriteNumber CurrentSprite { get { return currentSprite; } }

    // bools for flagging matches
    public bool matched = false;

    // Reference to playerstats
    PlayerStats player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
    }

    // Vector to keep track of the square's position in the grid
    public void setPositionVector(int x, int y)
    {
        positionVector = new Vector2(x, y);
    }

    // When square is clicked, highlight
    public void SquareClicked()
    {
        if (player.SecondSquareClicked)
        {
            // Swap tiles
            SpriteNumber firstSprite = player.firstSquare.currentSprite;
            player.firstSquare.changeSquare(currentSprite);
            changeSquare(firstSprite);

            // reset click state checker
            player.SecondSquareClicked = false;
            player.IncreaseMoveCount();

            // check for matches
            player.CheckSquares();
        }
        else
        {
            // highlight click
            hightlightSquare(true);

            // Save square for later reference
            player.firstSquare = GetComponent<SquareBehaviour>();

            // set click state checker
            player.SecondSquareClicked = true;
        }
        player.InfoMessage("");
    }

    // Function to highlight that the square has been clicked
    public void hightlightSquare(bool b)
    {
        if (b)
        {
            if (matched)
            {
                GetComponent<Image>().color = matchedColour;
            }
            else
            {
                GetComponent<Image>().color = highlightColour;
            }
        }
        else
        {
            if (!matched)
            {
                GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }

    // Functions to change square
    public void changeSquare(SpriteNumber sn)
    {
        currentSprite = sn;

        switch (currentSprite)
        {
            case SpriteNumber.ONE:
                GetComponent<Image>().sprite = sprite1;
                break;
            case SpriteNumber.TWO:
                GetComponent<Image>().sprite = sprite2;
                break;
            case SpriteNumber.THREE:
                GetComponent<Image>().sprite = sprite3;
                break;
            case SpriteNumber.FOUR:
                GetComponent<Image>().sprite = sprite4;
                break;
            case SpriteNumber.FIVE:
                GetComponent<Image>().sprite = sprite5;
                break;
            case SpriteNumber.SIX:
                GetComponent<Image>().sprite = sprite6;
                break;
        }
    }

    public void changeSquare(int sn)
    {
        switch (sn)
        {
            case 1:
                GetComponent<Image>().sprite = sprite1;
                currentSprite = SpriteNumber.ONE;
                break;
            case 2:
                GetComponent<Image>().sprite = sprite2;
                currentSprite = SpriteNumber.TWO;
                break;
            case 3:
                GetComponent<Image>().sprite = sprite3;
                currentSprite = SpriteNumber.THREE;
                break;
            case 4:
                GetComponent<Image>().sprite = sprite4;
                currentSprite = SpriteNumber.FOUR;
                break;
            case 5:
                GetComponent<Image>().sprite = sprite5;
                currentSprite = SpriteNumber.FIVE;
                break;
            case 6:
                GetComponent<Image>().sprite = sprite6;
                currentSprite = SpriteNumber.SIX;
                break;
        }
    }
}
