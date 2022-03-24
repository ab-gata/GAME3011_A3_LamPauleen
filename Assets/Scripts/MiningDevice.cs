using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningDevice : MonoBehaviour
{
    [SerializeField]
    private GameObject tileGame;

    // Start is called before the first frame update
    void Start()
    {
        tileGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        tileGame.SetActive(true);
        gameObject.SetActive(false);
    }
}
