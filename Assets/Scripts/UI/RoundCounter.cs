using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{

    public Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.round <= 10) {
            text.text = "Round " + GameController.round + " / 10";
        } else {
            text.text = "Game Over!";
        }
    }
}
