public struct Heal
{
    public int healAmount;
    public Critter target; 
    public Critter sender;
    
    public Heal(int heal, Critter sendTo, Critter sendFrom)
    {
        healAmount = heal;
        target = sendTo;
        sender = sendFrom;
    }
}


