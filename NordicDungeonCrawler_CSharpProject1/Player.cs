// Characteristics of an player
class Player : Combatant
{
    // Constructor for a new player
    public Player(string name, int health, int mindamage, int maxdamage)
        : base(name, health, mindamage, maxdamage)  // Inherited fields
    {
    }

    // Method for attacking
    public void Attack(Enemy target)
    {
        Console.WriteLine(Name + " casts his magic wand!");
        Random rng = new Random();
        int damage = rng.Next(MinDamage, MaxDamage + 1);
        target.TakeDamage(damage);
    }
}
