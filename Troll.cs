// A specific type of enemy using OOP pillar Inheritance, where Troll reuses Enemy's fields and methods instead of rewriting them
class Troll: Enemy
{
    public Troll(string name, int health, int mindamage, int maxdamage)
        : base(name, health, mindamage, maxdamage)  // Inherited fields
    {
    }

    // Override: Replaces the base class's version of Attack with this one
    // Method for attacking
    public override void Attack(Player target)
    {
        // Using OOP pillar Polymorphism, where Troll's Attack overrides Enemy's version with its own behavior, here the Console.WriteLine()
        Console.WriteLine(Name + " slams his club!");
        base.Attack(target);
    }
}
