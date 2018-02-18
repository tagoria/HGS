
using System.Collections.Generic;

public abstract class EvenementUnSeulChoix : Evenement
{
    public EvenementUnSeulChoix(int id, float proba, List<Condition> conditions, string choix1, string titre, string texte) : base(id, proba, conditions, choix1, titre, texte)
    {
    }
}