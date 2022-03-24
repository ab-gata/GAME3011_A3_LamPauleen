using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Stats
    private int playerMatchCount = 0;
    private int playerMatchCriteria = 10;
    private int playerMoves = 20;

    // Game status
    private bool secondSquareClicked = false;
    public bool SecondSquareClicked { set { secondSquareClicked = value; } get { return secondSquareClicked; } }
    public SquareBehaviour firstSquare = null;

    // Game Tile Board
    [SerializeField]
    private TileGrid tileGrid;

    // UI References
    [SerializeField]
    private TMPro.TextMeshProUGUI criteriaText;
    [SerializeField]
    private TMPro.TextMeshProUGUI infoText;

    private void Start()
    {
        refreshUIText();
    }


    // Function to refresh the UI
    private void refreshUIText()
    {
        criteriaText.text = "MAKE " + playerMatchCriteria + " MATCHES\n" + playerMatchCount;
        infoText.text = "Moves Left : " + playerMoves;
    }

    public void CheckSquares()
    {
        tileGrid.CheckSquares();
        tileGrid.RemoveHighlights();
    }
}
