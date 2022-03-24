using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Stats
    private int playerMatchCount = 0;
    private int playerMatchCriteria = 10;
    private int playerMoves = 20;


    // UI References
    [SerializeField]
    private TMPro.TextMeshProUGUI criteriaText;
    [SerializeField]
    private TMPro.TextMeshProUGUI infoText;


    // Function to refresh the UI
    private void refreshUIText()
    {
        criteriaText.text = "MAKE " + playerMatchCriteria + " MATCHES\n" + playerMatchCount;
        infoText.text = "Moves Left : " + playerMoves;
    }

}
