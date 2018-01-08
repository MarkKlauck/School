using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
   
    //collision stuff here?

    // Use this for initialization
    void Start() {
    
    }

    // Update is called once per frame
    void Update() {
      //  CamDelay();
    }
   

    public void PickupItem(Constants.PickupType type, int value)
    {
        switch (type)
        {
            case Constants.PickupType.HEALTH:
                {
                    GetComponent<Attribute>().AddHP(value);
                }
                break;
            case Constants.PickupType.MAXHP:
                {
                    GetComponent<Attribute>().AddMaxHP(value);
                }
                break;
            case Constants.PickupType.ARMOR:
                break;
            case Constants.PickupType.ATTACK:
                {
                    GetComponent<Attribute>().AddDamage(value);
                }
                break;
            case Constants.PickupType.ATTACK_SPEED:
                break;
            case Constants.PickupType.MANA:
                break;
            case Constants.PickupType.INVERNERABLE:
                break;
            default:
                break;
        }
    }

}
