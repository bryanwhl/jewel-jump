using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] JewelList jewelListPrefab;
    JewelList jewels;
    public ArrayList playersJumpingHere = new ArrayList();
    public GameController GameController;
    public Player1 player1;
    public Player2 player2;
    public Player3 player3;
    public Player4 player4;

    void Start()
    {
        jewels = Instantiate(jewelListPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        // jewels = new JewelList();
    }

    //Use this function to handle situtation when a player lands on this tile
    void landedOn(Player player)
    {
        player.gold += jewels.NumJewels;
        jewels.DestroyAllJewels();
    }

    //Just testing DestroyAllJewels function. Change this later.
    void Update()
    {
        if (GameController.isAnimationComplete == true) {
            if (playersJumpingHere.Count == 1) {
                // Debug.Log("Player 1 Jewel: ");
                // Debug.Log(player1.jewel);
                if ((int)playersJumpingHere[0] == 1) {
                  player1.jewel += jewels.NumJewels;
                } else if ((int)playersJumpingHere[0] == 2) {
                  player2.jewel += jewels.NumJewels;
                } else if ((int)playersJumpingHere[0] == 3) {
                  player3.jewel += jewels.NumJewels;
                } else if ((int)playersJumpingHere[0] == 4) {
                  player4.jewel += jewels.NumJewels;
                }
                jewels.DestroyAllJewels();
            }
            for (int i = 0; i < playersJumpingHere.Count; i++) {
                if ((int)playersJumpingHere[i] == 1) {
                  GameController.Player1CoinSettled = true;
                } else if ((int)playersJumpingHere[i] == 2) {
                  GameController.Player2CoinSettled = true;
                } else if ((int)playersJumpingHere[i] == 3) {
                  GameController.Player3CoinSettled = true;
                } else if ((int)playersJumpingHere[i] == 4) {
                  GameController.Player4CoinSettled = true;
                }
            }
            playersJumpingHere = new ArrayList();
        }
    }

}
