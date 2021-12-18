using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupTooltip : MonoBehaviour
{
    public Text powerupName;
    public Text powerupDescription;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPowerup(PowerUpBase powerUp) {
        powerupName.text = powerUp.PowerUpName;
        powerupDescription.text = powerUp.Description;
    }
}
