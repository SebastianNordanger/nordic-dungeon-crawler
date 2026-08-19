// Using OOP pillar Abstraction, with shareed fields/methods common to Player and Enemy
// Absract class: can't be created directly, only inherited from
public abstract class Combatant
{
    // Using OOP pillar Encapsulation, keeping data and the actions on that data together in one class
    public string Name;
    public int Health;
    public int MinDamage;
    public int MaxDamage;

    // Constructor for a new combatant
    public Combatant(string name, int health, int mindamage, int maxdamage)
    {
        Name = name;
        Health = health;
        MinDamage = mindamage;
        MaxDamage = maxdamage;
    }

    // Methods for different actions of the combatant
    public void TakeDamage(int amount)
    {
        Health -= amount;
        // Make sure health does not go in the negative
        if (Health < 0)
        {
            Health = 0;
        }
        Console.WriteLine(Name + " took " + amount + " damage. Health is now " + Health + ".");
        // Display if the player has fallen
        if (Health == 0)
        {
            Console.WriteLine(Name + " has been slain!");
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}
