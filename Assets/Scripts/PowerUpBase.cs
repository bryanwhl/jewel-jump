using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp/Create new powerup")]
public class PowerUpBase : ScriptableObject
{
    [SerializeField] string powerupName;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] int lastingTurns;
    [SerializeField] PowerupEffect effect;
    [SerializeField] EffectTarget effectTarget;
    [SerializeField] WhenToApplyEffect whenToApply;

    public string PowerUpName => powerupName;
    public string Description => description;
    public int LastingTurns => lastingTurns;
    public PowerupEffect Effect
    {
        get { return effect; }
    }
    public EffectTarget EffectTarget => effectTarget;
    public WhenToApplyEffect WhenToApply => whenToApply;
}

[System.Serializable]
public class PowerupEffect
{
    [SerializeField] EffectID effectId;

    public EffectID Id => effectId;

}

[System.Serializable]
public enum EffectTarget { Self, Opponent }

[System.Serializable]
public enum WhenToApplyEffect { StartingNow, StartingNextRound }