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

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = portraits[player - 1];
        if(playerName != null) {
            playerName.text = "Player " + player.ToString();
        }
        score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
