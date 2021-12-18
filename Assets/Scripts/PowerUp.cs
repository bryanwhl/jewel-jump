using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUp : MonoBehaviour
{
    private PowerUpBase powerupBase { get; set; }
    public int TurnsLeft { get; set; }
    public PowerUpBase Base => powerupBase;

    public void SetPowerUp(PowerUpBase powerUp) {
        this.powerupBase = powerUp;
        TurnsLeft = powerupBase.LastingTurns;
    }

    public void Reset() {
        this.powerupBase = null;
    }
}