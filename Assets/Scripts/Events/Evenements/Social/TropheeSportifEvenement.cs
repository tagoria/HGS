using System.Collections.Generic;
using Enums;
using Events.Conditions;
using Personnage;

namespace Events
{
    public class TropheeSportifEvenement : EvenementDeuxChoix
    {
        public const int TropheeAssiste=0;
        public const int TropheePasAssiste = 1;
        public TropheeSportifEvenement() : base(id : Evenement.TropheeSportifEvenement, proba : ProbaEnum.TropheeSportif,
            conditions: generateConditions(new ConditionEvenementProduit(new EventResult(Evenement.TropheeSportifEvenement,TropheeAssiste),false,365*12)
            , new ConditionEvenementProduit(new EventResult(Evenement.TropheeSportifEvenement,TropheePasAssiste),false,365*12)),
            choix1: "y aller", choix2 : "ne pas y aller", titre:"trophée sportif ",
            texte:"Il est l'heure de du trophée sportif d'HEI",
            creneaux : generateCreneau(4), texteSiChoix1 : "C'était bien", texteSiChoix2 : "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Player.instance.AugmenterSocialActuel(25);
            Player.instance.DiminuerTravailActuel(5);
            Player.instance.DiminuerEnergieActuelle(15);
            Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(4);
            addResultatToHistorique(TropheeAssiste);
        }

        public override void realiserChoix2()
        {
            Player.instance.DiminuerSocialActuel(5);
            addResultatToHistorique(TropheePasAssiste);
        }
    }
}