using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float hp, maxHp;
    private int damage;
    private PlayerAttribute pa;
    private int playernum;
    //collision stuff here?

    // Use this for initialization
    void Start() {
        playernum = GetComponent<PlayerControl>().GetPlayerNumber();
        pa = GetComponent<PlayerAttribute>();
        hp = pa.GetHP();
        maxHp = pa.GetMaxHP();
        damage = (int)pa.GetDamage();
    }

    // Update is called once per frame
    void Update() {
        GetStats();
        UIManager.instance.SetHealthBar(hp, maxHp, "player" + playernum);
      //  CamDelay();
    }
   
    private void GetStats()
    {
        hp = pa.GetHP();
    }

    public int GetDamage()
    {
        return damage;
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
