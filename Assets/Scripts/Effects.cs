using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Effects
{
    public EffectID Id { get; set; }
    public string Name { get; set; }
    public Func<int, int> CoinsObtainedAfterEffect { get; set; }
}


