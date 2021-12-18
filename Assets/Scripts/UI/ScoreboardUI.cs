using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreboardUI : MonoBehaviour
{
    public string gameScene;
    public List<PlayerScore> playerScores;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain() {
        SceneManager.LoadScene(gameScene);
    }

    public void Quit() {
        Application.Quit();
    }

    public void SetWinner(int winner) {
        playerScores[winner - 1].ShowWin();
    }
}
