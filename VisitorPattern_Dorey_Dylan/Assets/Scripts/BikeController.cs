using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/12/2024]
 * [The user controlled bike controller]
 */

public class BikeController : MonoBehaviour, IBikeElement
{
    //list of the bike's added systems/components
    private List<IBikeElement> bikeElements = new List<IBikeElement>();

    private void Start()
    {
        //add the BikeSHield, BikeWeapon, and BikeEngine class to game object and the bike elements list
        bikeElements.Add(gameObject.AddComponent<BikeShield>());
        bikeElements.Add(gameObject.AddComponent<BikeWeapon>());
        bikeElements.Add(gameObject.AddComponent<BikeEngine>());
    }

    /// <summary>
    /// Accept all incoming bike system changes when a powerup is interacted with
    /// </summary>
    /// <param name="visitor"> the powerup/visitor that will alter the bike's system </param>
    public void Accept(IVisitor visitor)
    {
        //for each bike system in the bike elements list
        foreach (IBikeElement element in bikeElements)
        {
            //accept/apply the powerup change from the visitor element
            element.Accept(visitor);
        }
    }
}
