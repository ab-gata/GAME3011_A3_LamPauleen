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

    // position of square among the others
    private Vector2 positionVector = Vector2.zero;
    public Vector2 PositionVector { get { return positionVector; } }

    // The value of the resources in the square
    private SpriteNumber spriteNumber = SpriteNumber.ONE;

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

    private void changeSquare(SpriteNumber sn)
    {
        spriteNumber = sn;

        switch (spriteNumber)
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
}
