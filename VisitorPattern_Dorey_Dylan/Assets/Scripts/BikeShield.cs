using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/12/2024]
 * [A bike shield system that has health]
 */

public class BikeShield : MonoBehaviour, IBikeElement
{
    //the shields health amount
    public float health = 50f;

    /// <summary>
    /// Removes health from the bike's shield system
    /// </summary>
    /// <param name="damage"> the incoming damage to the shield </param>
    /// <returns> the new updated health amount </returns>
    public float Damage(float damage)
    {
        //remove the incoming damage from the current shield health
        health -= damage;

        //return the updated health value
        return health;
    }

    /// <summary>
    /// Accepts any visitor that changes the bike shield system
    /// </summary>
    /// <param name="visitor"> the powerup/visitor that will alter the bike's shield system </param>
    public void Accept(IVisitor visitor)
    {
        //accept/apply the change from the visitor element
        visitor.Visit(this);
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //change the UI text color to green
        GUI.color = Color.green;

        //create a label to display the shield's health amount
        GUI.Label(new Rect(125, 0, 200, 20), "Shield Health: " + health);
    }
}
