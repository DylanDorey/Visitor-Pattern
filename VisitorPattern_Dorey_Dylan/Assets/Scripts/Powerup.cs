using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/12/2024]
 * [A powerup scriptable object that alters the bikes various systems in different ways]
 */

[CreateAssetMenu(fileName = "Powerup", menuName = "Powerup")]
public class Powerup : ScriptableObject, IVisitor
{
    //the name, prefab, and description of the powerup
    public string powerupName;
    public GameObject powerupPrefab;
    public string powerupDescription;

    //fully heals the bike's shield system if true
    [Tooltip("Fully heal the shield")]
    public bool healShield;

    //increases the turbos boost settings
    [Range(0f, 50f)]
    [Tooltip("Boost turbo settings up to increments of 50/mph")]
    public float turboBoost;

    //increases the range of the bike's weapon
    [Range(0, 25)]
    [Tooltip("Boost weapon range in increments of up to 25 units (meters)")]
    public int weaponRange;

    //increases the strength of the bike's weapon
    [Range(0.0f, 50f)]
    [Tooltip("Boosts the wepon strength in increments of up to 50%")]
    public float weaponStrength;

    /// <summary>
    /// visitor for the bike shield system
    /// </summary>
    /// <param name="bikeShield"> the bike's shield component/class </param>
    public void Visit(BikeShield bikeShield)
    {
        //if heal shield is true
        if (healShield)
        {
            //set the bike's shield to full
            bikeShield.health = 100f;
        }
    }

    /// <summary>
    /// visitor for the bike weapon system
    /// </summary>
    /// <param name="bikeWeapon"> the bike's weapon component/class </param>
    public void Visit(BikeWeapon bikeWeapon)
    {
        //initialize a range float to equal the bike weapons range plus the powerup's weaponRange change
        int range = bikeWeapon.range += weaponRange;

        //if the new range value is greater than or equal to the bike weapons max range
        if (range>= bikeWeapon.maxRange)
        {
            //set the bike weapon's range to the max weapon range
            bikeWeapon.range = bikeWeapon.maxRange;
        }
        else
        {
            //otherwise set the bike weapons range to the new range value
            bikeWeapon.range = range;
        }

        //initialize a strength float to equal the bikes strength plus a the percentage of the powerup's strength change
        float strength = bikeWeapon.strength += Mathf.Round(bikeWeapon.strength * weaponStrength / 100);

        //if the new strength value is greater than or equal to the bike weapons max strength
        if (strength>= bikeWeapon.maxStrength)
        {
            //set the bike weapon's strength to the max weapon strength
            bikeWeapon.strength = bikeWeapon.maxStrength;
        }
        else
        {
            //otherwise set the bike weapons strength to the new strength value
            bikeWeapon.strength = strength;
        }
    }

    /// <summary>
    /// visitor for the bike engine system
    /// </summary>
    /// <param name="bikeEngine"> the bike's engine component/class </param>
    public void Visit(BikeEngine bikeEngine)
    {
        //initialize a boost float to equal the bike engine's turbo boost plus the powerup's turboBoost change
        float boost = bikeEngine.turboBoost += turboBoost;

        //if the new boost value is less than 0
        if (boost < 0.0f)
        {
            //set the turboBoost value to 0
            bikeEngine.turboBoost = 0.0f;
        }

        //if the new boost value is greater than or equal to the bike engine's max boost value
        if (boost >= bikeEngine.maxTurboBoost)
        {
            //set the bike engine's turboBoost value to the max turbo boost value
            bikeEngine.turboBoost = bikeEngine.maxTurboBoost;
        }
    }
}
