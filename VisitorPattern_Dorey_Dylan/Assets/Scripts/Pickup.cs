using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/12/2024]
 * [Powerup demo script]
 */

/// <summary>
/// IF THIS WAS IN AN ACTUAL GAME ATTACH SCRIPT TO A POWERUP PICKUP
/// </summary>

public class Pickup : MonoBehaviour
{
    //reference to the type of powerup scriptable object
    public Powerup powerup;

    private void OnTriggerEnter(Collider other)
    {
        //if the other collider has a bike controller script
        if(other.GetComponent<BikeController>())
        {
            //accept the powerup and then destroy it
            other.GetComponent<BikeController>().Accept(powerup);
            Destroy(gameObject);
        }
    }
}
