using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit() {
        SceneManager.LoadScene("MainMenu");
    }

    public void TriggerGameOver() {
        gameOverScreen.SetActive(true);
    }
}
