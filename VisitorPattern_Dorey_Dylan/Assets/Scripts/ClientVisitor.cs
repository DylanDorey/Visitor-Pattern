using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/12/2024]
 * [The client component that allows the user to interact with the demo]
 */

public class ClientVisitor : MonoBehaviour
{
    //references to the different powerup scriptable objects
    public Powerup enginePowerup;
    public Powerup weaponPowerup;
    public Powerup shieldPowerup;

    //reference to the bike controller
    private BikeController bikeController;

    private void Start()
    {
        //initialize the bike controller and add the bike controller component to this game object
        bikeController = gameObject.AddComponent<BikeController>();
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //create a shield powerup button
        if (GUILayout.Button("Powerup Shield"))
        {
            //if pressed, pickup a shield powerup and accept it as a visitor
            bikeController.Accept(shieldPowerup);
        }

        //create a engine powerup button
        if (GUILayout.Button("Powerup Engine"))
        {
            //if pressed, pickup a engine powerup and accept it as a visitor
            bikeController.Accept(enginePowerup);
        }

        //create a weapon powerup button
        if (GUILayout.Button("Powerup Weapon"))
        {
            //if pressed, pickup a weapon powerup and accept it as a visitor
            bikeController.Accept(weaponPowerup);
        }
    }
}
