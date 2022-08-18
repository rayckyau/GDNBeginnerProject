public struct Attack
{
    public int damageAmount;
    public Critter target;
    public Critter sender;

    public Attack(int damage, Critter sendTo, Critter sendFrom)
    {
        damageAmount = damage;
        target = sendTo;
        sender = sendFrom;
    }
}