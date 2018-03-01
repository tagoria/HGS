using System.Collections.Generic;

internal class RdvAvrinEvenement : EvenementDeuxChoix
{
    public RdvAvrinEvenement() : base(id:(int)EvenementsEnum.RdvAvrin, proba:100, conditions:generateConditions(),
        choix1:"Y aller", choix2:"Ne pas y aller", titre:"Rdv Avrin", texte:"Mr.Avrin vous attends dans son bureau. Y aller?", creneaux:generateCreneau(9),
        texteSiChoix1:"Vos absences sont clarifiées", texteSiChoix2:"Avrin s'en souviendra")
    {
    }

    public override void realiserChoix1()
    {
        //je sais pas
    }

    public override void realiserChoix2()
    {
        //la non plus
    }
}