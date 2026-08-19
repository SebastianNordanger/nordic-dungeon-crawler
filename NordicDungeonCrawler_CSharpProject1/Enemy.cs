// Characteristics of an enemy
class Enemy : Combatant
{
    // Constructor for a new enemy
    public Enemy(string name, int health, int mindamage, int maxdamage)
        : base (name, health, mindamage, maxdamage)
    {
    }

    // Method for enemy actions against the player
    public virtual void Attack(Player target)  // Virtual used so that subclasses are allowed to replace this method
    {
        Random rng = new Random();
        int damage = rng.Next(MinDamage, MaxDamage + 1);
        target.TakeDamage(damage);
    }
}
