using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {

    public enum PickupType
    {
        HEALTH = 0,
        MAXHP,
        ARMOR,
        ATTACK,
        ATTACK_SPEED,
        MANA,
        INVERNERABLE,
    }

    public const int PlayerDefaultHP = 100; 
    
}
