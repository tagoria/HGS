using Enums;
using Events.Conditions;
using Personnage;

namespace Events
{
    public class EntrainementEvenement : EvenementDeuxChoix
    {
        public const int EntrainementAssiste=0;
        public const int EntrainementPasAssiste = 1;
        public EntrainementEvenement() : base(id : Evenement.TropheeSportifEvenement, proba : ProbaEnum.TropheeSportif,
            conditions: generateConditions(new ConditionEvenementProduit(new EventResult(Evenement.TropheeSportifEvenement,EntrainementAssiste),false,7*12)
                , new ConditionEvenementProduit(new EventResult(Evenement.TropheeSportifEvenement,EntrainementPasAssiste),false,7*12)),
            choix1: "y aller", choix2 : "ne pas y aller", titre:"entraînement ",
            texte:"Il est l'heure de s'entraîner dans votre sport de prédilection",
            creneaux : generateCreneau(4), texteSiChoix1 : "Vous avez beaucoup appris", texteSiChoix2 : "Pas le temps")
        {
        }

        public override void realiserChoix1()
        {
            Player.instance.AugmenterSocialActuel(15);
            Player.instance.DiminuerTravailActuel(5);
            Player.instance.DiminuerEnergieActuelle(10);
            Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(2);
            addResultatToHistorique(EntrainementAssiste);
        }

        public override void realiserChoix2()
        {
            Player.instance.DiminuerSocialActuel(5);
            addResultatToHistorique(EntrainementPasAssiste);
        }
    }
}