using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/12/2024]
 * [A bike engine system that has a turbo mode]
 */

public class BikeEngine : MonoBehaviour, IBikeElement
{
    //the turbo boost amount and max turbo boost amount 
    public float turboBoost = 25f;
    public float maxTurboBoost = 200f;

    //determines if the turbo is on or off
    private bool isTurboOn;

    //default engine speed
    private float defaultSpeed = 300f;

    //property for the current speed of the bike that changes based on the turbo's status
    public float CurrentSpeed
    {
        get
        {
            //if the turbo is on
            if(isTurboOn)
            {
                //return the turbo boost amount plus the default speed
                return defaultSpeed + turboBoost;
            }
            else
            {
                //otherwise return the default speed
                return defaultSpeed;
            }
        }
    }

    /// <summary>
    /// Turns the turbo mode on and off
    /// </summary>
    public void ToggleTurbo()
    {
        //flip the status of the turbo
        isTurboOn = !isTurboOn;
    }

    /// <summary>
    /// Accepts any visitor that changes the bike engine system
    /// </summary>
    /// <param name="visitor"> the powerup/visitor that will alter the bike's engine system </param>
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

        //create a label to display the weapons turbo boost amount
        GUI.Label(new Rect(125, 20, 200, 20), "Turbo boost: " + turboBoost);
    }
}
