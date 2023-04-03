using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPickup : MonoBehaviour
{
    public enum PickupObject{COIN/*,GEM*/};
    public PickupObject currentObject;
    public int pickupQuantity;

    void OnTriggerEnter (Collider other)
    {
        if(other.name == "Player")
        {
            if(currentObject == PickupObject.COIN)
            {
            PlayerStats.playerStats.coins += pickupQuantity;
            Debug.Log(PlayerStats.playerStats.coins);
            }
            /*else if(currentObject == PickupObject.GEM)
            {
            PlayerStats.playerStats.coins += pickupQuantity;
            Debug.Log(PlayerStats.playerStats.coins);
            }
            */
        }
        
    }
}
