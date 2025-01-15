using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public enum PowerUps
    {
        XP,
        item,
        tempBoost
    }

[CreateAssetMenu(fileName = "new Power-Up", menuName = "ScriptableObjects/Power-Ups")]
public class PowerUpBase : ScriptableObject
{
    public PowerUps powerUps;

    public float valueIncrease;
}
