

using System.Collections.Generic;

public class EvenementJourFerie : EvenementUnSeulChoix
{
    public EvenementJourFerie() : base((int) EvenementsEnum.JourFerie, 30, null,"super", "Jour férié", "jour férié",creneaux)
    {
    }
    private static List<int> creneaux = new List<int>
    {
        0
    };
    public override void realiserChoix1()
    {
        Personnage.main.ajouterStatus(new StatusJourFerie());
        addEventResultToHistorique();
    }

    
}