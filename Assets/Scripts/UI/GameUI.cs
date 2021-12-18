using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject gameOverScreen;
    public PowerupTooltip powerupTooltip;
    public RuleChange ruleChangeUI;
    public AudioClip gameOverMusic;
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
        AudioManager.instance.PlayMusic(gameOverMusic);
    }

    public void ShowPowerUpTooltip(PowerUpBase powerUp) {
        powerupTooltip.SetPowerup(powerUp);
        powerupTooltip.gameObject.SetActive(true);
    }

    public void HidePowerUpTooltip() {
        powerupTooltip.gameObject.SetActive(false);
    }

    public void ShowRuleChange() {
        ruleChangeUI.gameObject.SetActive(true);
    }
}
