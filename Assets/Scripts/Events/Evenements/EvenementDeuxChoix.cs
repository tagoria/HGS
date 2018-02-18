
using System.Collections.Generic;
using System;

public abstract class EvenementDeuxChoix : Evenement
{
    private String choix2;
    public EvenementDeuxChoix(int id, float proba, List<Condition> conditions, string choix1, string choix2, string titre, string texte, string texteSiChoix1, string texteSiChoix2) : base(id, proba, conditions, choix1, titre, texte)
    {
        this.choix2 = choix2;
        this.texteSiChoix1 = texteSiChoix1;
        this.texteSiChoix2 = texteSiChoix2;
    }
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
    private String texteSiChoix1;
    private String texteSiChoix2;
    public abstract void realiserChoix2();
}