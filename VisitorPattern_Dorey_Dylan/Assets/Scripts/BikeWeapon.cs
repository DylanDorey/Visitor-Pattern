using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/12/2024]
 * [A bike weapon system that has range and strength]
 */

public class BikeWeapon : MonoBehaviour, IBikeElement
{
    //the range and max range of the bike wweapon
    [Header("Range")]
    public int range = 5;
    public int maxRange = 25;

    //the strength and max strength of the bike weapon
    [Header("Strength")]
    public float strength = 25f;
    public float maxStrength = 50f;

    /// <summary>
    /// Fires the bike weapon 
    /// PLACEHOLDER FOR TESTING
    /// </summary>
    public void Fire()
    {
        //Just output a message that says the weapon was fired
        Debug.Log("Weapon Fired");
    }

    /// <summary>
    /// Accepts any visitor that changes the bike weapon system
    /// </summary>
    /// <param name="visitor"> the powerup/visitor that will alter the bike's weapon system </param>
    public void Accept(IVisitor visitor)
    {
        //accept/apply the change from the visitor element
        visitor.Visit(this);
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    public void OnGUI()
    {
        //change the UI text color to green
        GUI.color = Color.green;

        //create a label to display the weapons range
        GUI.Label(new Rect(125, 40, 200, 20), "Weapon Range: " + range);

        //create a label to display the weapons strength
        GUI.Label(new Rect(125, 60, 200, 20), "Weapon Strength: " + strength);
    }
}
