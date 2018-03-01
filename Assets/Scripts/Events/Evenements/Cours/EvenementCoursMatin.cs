
using System.Collections.Generic;

public class EvenementCoursMatin : EvenementDeuxChoix
{
    public static int COURS_ASSISTE = 0;
    public static int COURS_SECHE = 1;
    public EvenementCoursMatin() : base((int) EvenementsEnum.CoursMatin,  30,  generateConditions(new HasStatusCondition(StatusEnum.JourFerie,false)), "oui", "non", "Cours", "aller en cours?", generateCreneau(4), "Vous allez en cours", "Vous allez pas en cours")
    {
    }
    public override void realiserChoix1()
    {
        Personnage.main.augmenterTravailActuel(20);
        Personnage.main.diminuerEnergieActuelle(10);
        Horloge.instance.setCreneauActuel(Horloge.instance.getCreneauActuel() + 2);
        Horloge.instance.addToHistorique(new EventResult(this, COURS_ASSISTE));
    }
    

    public override void realiserChoix2()
    {
        //rien
        Horloge.instance.addToHistorique(new EventResult(this, COURS_SECHE));
    }
    
}