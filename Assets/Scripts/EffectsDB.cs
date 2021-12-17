using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsDB : MonoBehaviour
{
    public static Dictionary<EffectID, Effects> Effects { get; set; } = new Dictionary<EffectID, Effects>(){
        {
            EffectID.Double,
            new Effects() {
                Id = EffectID.Double,
                Name = "Double coins obtained from tile",
                CoinsObtainedAfterEffect = (int coinsOnTile) => {
                    return 2 * coinsOnTile;
                }
            }
        },
        {
            EffectID.Triple,
            new Effects() {
                Id = EffectID.Triple,
                Name = "Triple coins obtained from tile",
                CoinsObtainedAfterEffect = (int coinsOnTile) => {
                    return 3 * coinsOnTile;
                }
            }
        },
        {
            EffectID.ReduceFour,
            new Effects() {
                Id = EffectID.ReduceFour,
                Name = "Reduce coins obtained from tile by 3, lower bound at 0",
                CoinsObtainedAfterEffect = (int coinsOnTile) => {
                    if (coinsOnTile - 4 < 0) {
                        return 0;
                    }
                    return coinsOnTile - 4;
                }
            }
        },
        {
            EffectID.ReduceTwo,
            new Effects() {
                Id = EffectID.ReduceTwo,
                Name = "Reduce coins obtained from tile by 2, lower bound at 0",
                CoinsObtainedAfterEffect = (int coinsOnTile) => {
                    if (coinsOnTile - 2 < 0) {
                        return 0;
                    }
                    return coinsOnTile - 2;
                }
            }
        },
        {
            EffectID.DoubleAllCoins,
            new Effects() {
                Id = EffectID.DoubleAllCoins,
                Name = "Double all coins player currently has",
                CoinsObtainedAfterEffect = (int coinsPlayerHas) => {
                    return 2 * coinsPlayerHas;
                }
            }
        },
        {
            EffectID.HalfAllCoins,
            new Effects() {
                Id = EffectID.DoubleAllCoins,
                Name = "Half all coins player currently has, taking floor function",
                CoinsObtainedAfterEffect = (int coinsPlayerHas) => {
                    return Mathf.FloorToInt(coinsPlayerHas / 2f);
                }
            }
        }
    };
}

[System.Serializable]
public enum EffectID
{
    none, Double, Triple, ReduceTwo, ReduceFour, DoubleAllCoins, HalfAllCoins
}
