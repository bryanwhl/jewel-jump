using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUp : MonoBehaviour
{
    private PowerUpBase powerupBase { get; set; }
    public int TurnsLeft { get; set; }
    public PowerUp(PowerUpBase powerupBase)
    {
        this.powerupBase = powerupBase;
        TurnsLeft = powerupBase.LastingTurns;
    }

    public PowerUpBase Base => powerupBase;
}