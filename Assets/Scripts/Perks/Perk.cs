using UnityEngine;
public abstract class Perk 
{
    public abstract void appliquer();
    public readonly int id;
    public readonly string nom;
    public Perk(int id , string nom)
    {
        this.id = id;
        this.nom = nom;
    }
    public override bool Equals(object obj)
    {
        return obj.GetType() == this.GetType();
    }

    public override int GetHashCode()
    {
        return 1877310944 + id.GetHashCode();
    }
}