using System.Collections.Generic;
using Actions;
using Enums;
using Events.Conditions;
using UnityEngine;

namespace Events
{
    public class EvenementCanette : EvenementDeuxChoix
    {
        public static int CANETTE_BUE = 0;
        public static int CANETTE_JETEE = 1;

        private static readonly List<Condition> conditions = new List<Condition>
        {
            new ConditionDerniereAction(typeof(Travailler)),
            new ConditionJoueurOccupe(false)
        };

        public EvenementCanette() : base( Evenement.EvenementCanette, 5, conditions, "La boire", "La jeter",
            "Canette oubliée",
            "Vous retrouvez une canette énergétique bombée derrière votre bureau pendant vos révisions",
            generateCreneau(5, 6, 7), "Une énergie nouvelle vous envahit +10 énergie",
            "Vous décidez que ça n'en vaut pas le coup")
        {
        }

        public override void realiserChoix1()
        {
            Object.FindObjectOfType<Personnage.Player>().AugmenterEnergieActuelle(10);
            Horloge.instance.addToHistorique(new EventResult(this, CANETTE_BUE));
        }

        public override void realiserChoix2()
        {
            Horloge.instance.addToHistorique(new EventResult(this, CANETTE_JETEE));
        }
    }
}