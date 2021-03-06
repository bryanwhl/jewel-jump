using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static int round;
    public static int Player1Flag;
    public static int Player2Flag;
    public static int Player3Flag;
    public static int Player4Flag;
    public static bool areAllInputsIn;
    public static bool isAnimationComplete;
    public Player1 Player1;
    public Player2 Player2;
    public Player3 Player3;
    public Player4 Player4;
    public static bool Player1CoinSettled;
    public static bool Player2CoinSettled;
    public static bool Player3CoinSettled;
    public static bool Player4CoinSettled;
    public static int numToSpawnPowerUp;
    public static bool isGameOver = false;
    public GameUI GameUI;
    public RuleChange RuleChange;
    public static int rankThatWins;

    void resetAllInputsIn()
    {
        isAnimationComplete = true;
    }

    // Comments by Bing Sen
    // I dunno where you start every round, but when u start everyone and for example, want to put a PowerUp at CentreTile
    // Make sure you do somewehere CentreTile.powerUp = new PowerUp(PowerUpBase theBaseTemplate)
    // And then CentreTile.powerUp.gameObject.SetActive(true);
    // You can obtain theBaseTemplate by taking a random PowerUpBase in the list above (the varaible named spawnablePowerUps);
    // If no powerUp on CentreTile then make sure you set CentreTile.powerUp = null;
    // And then CentreTile.powerUp.gameObject.SetActive(false);

    void Start()
    {
        round = 1;
        areAllInputsIn = false;
        isAnimationComplete = false;
        Player1 = GameObject.Find("Player 1").GetComponent<Player1>();
        Player2 = GameObject.Find("Player 2").GetComponent<Player2>();
        Player3 = GameObject.Find("Player 3").GetComponent<Player3>();
        Player4 = GameObject.Find("Player 4").GetComponent<Player4>();
        Player1CoinSettled = false;
        Player2CoinSettled = false;
        Player3CoinSettled = false;
        Player4CoinSettled = false;
        numToSpawnPowerUp = (int)Random.Range(1.0f, 10.0f);
        rankThatWins = 1;
        GameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Player1.GetComponent<Player1>().jewel);
        // Debug.Log(Player2.GetComponent<Player2>().jewel);
        // Debug.Log(Player3.GetComponent<Player3>().jewel);
        // Debug.Log(Player4.GetComponent<Player4>().jewel);
        // Debug.Log(round);
        // Debug.Log(Player1Flag);
        // Debug.Log(Player2Flag);
        // Debug.Log(Player3Flag);
        // Debug.Log(Player4Flag);
        // Debug.Log(areAllInputsIn);
        // Debug.Log(isAnimationComplete);
        // Debug.Log(Player1CoinSettled);
        // Debug.Log(Player2CoinSettled);
        // Debug.Log(Player3CoinSettled);
        // Debug.Log(Player4CoinSettled);
        Debug.Log("=================");
        if (round <= 10 && areAllInputsIn == false && !isGameOver && isAnimationComplete == false && Player1CoinSettled == false && Player2CoinSettled == false && Player3CoinSettled == false && Player4CoinSettled == false)
        {
            // Inputs for player 1
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Player1Flag = 1;
                Player1.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Player1Flag = 2;
                Player1.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Player1Flag = 3;
                Player1.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Player1Flag = 4;
                Player1.SetReady();
            }
            // Inputs for player 2
            if (Input.GetKeyDown(KeyCode.W))
            {
                Player2Flag = 1;
                Player2.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Player2Flag = 2;
                Player2.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Player2Flag = 3;
                Player2.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Player2Flag = 4;
                Player2.SetReady();
            }
            // Inputs for player 3
            if (Input.GetKeyDown(KeyCode.T))
            {
                Player3Flag = 1;
                Player3.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                Player3Flag = 2;
                Player3.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                Player3Flag = 3;
                Player3.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                Player3Flag = 4;
                Player3.SetReady();
            }
            // Inputs for player 4
            if (Input.GetKeyDown(KeyCode.I))
            {
                Player4Flag = 1;
                Player4.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                Player4Flag = 2;
                Player4.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                Player4Flag = 3;
                Player4.SetReady();
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                Player4Flag = 4;
                Player4.SetReady();
            }
        }

        if(round > 10 && !isGameOver) {
            
        }

        if (Player1Flag != 0 && Player2Flag != 0 && Player3Flag != 0 && Player4Flag != 0)
        {
            areAllInputsIn = true;
            
            Debug.Log("Game State Changed");
        }
        if (Player1Flag == 0 && Player2Flag == 0 && Player3Flag == 0 && Player4Flag == 0 && areAllInputsIn == true)
        {
            areAllInputsIn = false;
            
            Invoke("resetAllInputsIn", 2.0f);
        }
        if (isAnimationComplete == true)
        {
            // Add coins
            if (Player1CoinSettled == true && Player2CoinSettled == true && Player3CoinSettled == true && Player4CoinSettled == true)
            {
                areAllInputsIn = false;
                Player1.Reset();
                Player2.Reset();
                Player3.Reset();
                Player4.Reset();
                isAnimationComplete = false;
                Player1CoinSettled = false;
                Player2CoinSettled = false;
                Player3CoinSettled = false;
                Player4CoinSettled = false;
                numToSpawnPowerUp = (int)Random.Range(1.0f, 10.0f);
                round++;
                if (round == 4 || round == 8) {
                    rankThatWins = (int)Random.Range(1.0f, 4.99f);
                    // Display UI for change of winner
                    GameUI.ShowRuleChange("Rule change! the player with number of coins ranking " + rankThatWins + " shall win!");
                }
            }
        }
        if (round == 11 && !isGameOver) {
            isGameOver = true;

            // Game Ends
            Debug.Log(Player1.GetComponent<Player1>().jewel);
            Debug.Log(Player2.GetComponent<Player2>().jewel);
            Debug.Log(Player3.GetComponent<Player3>().jewel);
            Debug.Log(Player4.GetComponent<Player4>().jewel);
            ArrayList results = new ArrayList();
            results.Add(Player1.GetComponent<Player1>().jewel);
            results.Add(Player2.GetComponent<Player2>().jewel);
            results.Add(Player3.GetComponent<Player3>().jewel);
            results.Add(Player4.GetComponent<Player4>().jewel);
            results.Sort();
            int jewelNumOfWinner = (int)results[4 - rankThatWins];
            int winner = 0;
            if (Player1.GetComponent<Player1>().jewel == jewelNumOfWinner) {
                Debug.Log("Player 1 Wins");
                winner = 1;
            } else if (Player2.GetComponent<Player2>().jewel == jewelNumOfWinner) {
                Debug.Log("Player 2 Wins");
                winner = 2;
            } else if (Player3.GetComponent<Player3>().jewel == jewelNumOfWinner) {
                Debug.Log("Player 3 Wins");
                winner = 3;
            } else if (Player4.GetComponent<Player4>().jewel == jewelNumOfWinner) {
                Debug.Log("Player 4 Wins");
                winner = 4;
            }

            GameUI.TriggerGameOver(winner);
        }
    }
}
