/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/12/2024]
 * [A method that visits the three different bike systems. A bike system must implement at least one of the Visit methods with a specific signature.]
 */

public interface IVisitor
{
    void Visit(BikeShield bikeShield);
    void Visit(BikeEngine bikeEngine);
    void Visit(BikeWeapon bikeWeapon);
}
