﻿using Enums;
using Events.Conditions;

namespace Events
{
    public class CoursClarifeEvenement : EvenementDeuxChoix, IEvenementEffetSiOccuppe
    {
        public static readonly int COURS_ASSISTE = 0;
        public static readonly int COURS_SECHE = 1;

        public CoursClarifeEvenement() : base(Evenement.CoursClarifeEvenement,
            20, generateConditions(
                new HasStatusCondition(StatusEnum.JourFerie, false)), "y aller", "ne pas y aller",
            "ouverture culturelle",
            "Vous avez cours au clarife", generateCreneau(9), "Vous avez appris plein de chose",
            "Pas aujourd'hui")
        {
        }

        public void onOccuppe()
        {
            realiserChoix2();
        }

        public override void realiserChoix1()
        {
            Personnage.Player.instance.AugmenterTravailActuel(25);
            Personnage.Player.instance.DiminuerEnergieActuelle(15);
            addResultatToHistorique(COURS_ASSISTE);
            Horloge.instance.setCreneauActuel(10);
        }

        public override void realiserChoix2()
        {
            //rien
            addResultatToHistorique(COURS_SECHE);
        }
    }
}