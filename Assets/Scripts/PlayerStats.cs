using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Stats
    private int playerMatchCount = 0;
    private int playerMatchCriteria = 10;
    private int playerMovesCount = 0;
    private float timer = 5;

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
    private TMPro.TextMeshProUGUI movesText;
    [SerializeField]
    private TMPro.TextMeshProUGUI infoText;

    private SoundManager sound;

    bool loseSoundPlayed = false;

    private void Start()
    {
        refreshUIText();

        sound = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (tileGrid.isActiveAndEnabled)
        {
            if (timer < 0)
            {
                InfoMessage("OUT OF TIME!!");
                if (!loseSoundPlayed)
                {
                    sound.PlaySound(SoundManager.TrackID.LOSE);
                    loseSoundPlayed = true;
                }
            }
            else
            {
                timer -= Time.deltaTime;
                infoText.text = "Time left = " + (int)timer;
            }
        }
    }


    // Function to refresh the UI
    private void refreshUIText()
    {
        criteriaText.text = "colour whole\nboard to win";
        movesText.text = "Moves Made : " + playerMovesCount;
    }

    public void CheckSquares()
    {
        // check if there are matches
        tileGrid.CheckSquares();

        // clear any extra highlights
        tileGrid.RemoveHighlights();

        // check if player has completed objective
        if (tileGrid.CheckIfWin())
        {
            InfoMessage("YOU WIN!");
        }
    }

    public void IncreaseMatchCount(int val)
    {
        playerMatchCount += val;
        refreshUIText();
    }

    public void IncreaseMoveCount()
    {
        playerMovesCount++;
        refreshUIText();
    }

    public void InfoMessage(string msg)
    {
        infoText.text = msg;
    }
}
