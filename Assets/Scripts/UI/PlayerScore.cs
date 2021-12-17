using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int player;
    public List<Sprite> portraits;
    public Image spriteRenderer;
    public Text playerName;
    public Text score;
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        spriteRenderer.sprite = portraits[player - 1];
        if(playerName != null) {
            playerName.text = "Player " + player.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player == 1) {
            score.text = gameController.Player1.jewel.ToString();
        } else if(player == 2) {
            score.text = gameController.Player2.jewel.ToString();
        } else if(player == 3) {
            score.text = gameController.Player3.jewel.ToString();
        } else if(player == 4) {
            score.text = gameController.Player4.jewel.ToString();
        }
    }
}
