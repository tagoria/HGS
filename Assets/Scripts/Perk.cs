using UnityEngine;
internal abstract class Perk 
{
    public abstract void appliquer();
    public readonly int id;
    public readonly string nom;
    protected Perk(int id , string nom)
    {
        this.id = id;
        this.nom = nom;
    }
}