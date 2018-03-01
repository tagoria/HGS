
using System.Collections.Generic;
using System;

public abstract class EvenementDeuxChoix : EvenementAbstract
{
    protected String choix2;
    public String getChoix2()
    {
        return choix2;
    }
    public String getTexteSiChoix1()
    {
        return texteSiChoix1;
    }
    public String getTexteSiCHoix2()
    {
        return texteSiChoix2;
    }
    protected String texteSiChoix1;
    protected String texteSiChoix2;

    public EvenementDeuxChoix(int id, float proba, List<Condition> conditions, string choix1,string choix2,string titre, string texte, List<int> creneaux , string texteSiChoix1 , string texteSiChoix2) : base(id, proba, conditions, choix1, titre, texte, creneaux)
    {
        this.texteSiChoix1 = texteSiChoix1;
        this.texteSiChoix2 = texteSiChoix2;
        this.choix2 = choix2;
    }
    public override bool isEvenmentDeuxChoix()
    {
        return true;
    }
    public abstract void realiserChoix2();
    protected void addResultatToHistorique(int resultat)
    {
        Horloge.instance.addToHistorique(new EventResult(this, resultat));
    }
}