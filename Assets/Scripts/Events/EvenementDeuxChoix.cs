using System.Collections.Generic;
using Enums;

namespace Events
{
    public abstract class EvenementDeuxChoix : EvenementAbstract
    {
        protected string choix2;
        protected string texteSiChoix1;
        protected string texteSiChoix2;
        private Evenement pauseFalucheEvenement;
        private ProbaEnum pauseFaluche;
        private List<Condition> list1;
        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private List<int> list2;
        private string v5;
        private string v6;

        public EvenementDeuxChoix(Enums.Evenement id, float proba, List<Condition> conditions,
            string choix1, string choix2, string titre, string texte, List<int> creneaux,
            string texteSiChoix1, string texteSiChoix2) : base(id, proba, conditions, choix1, titre,
            texte, creneaux)
        {
            this.texteSiChoix1 = texteSiChoix1;
            this.texteSiChoix2 = texteSiChoix2;
            this.choix2 = choix2;
        }

        protected EvenementDeuxChoix(Evenement id, ProbaEnum proba, List<Condition> conditions, string choix1, string choix2, string titre, string texte, List<int> creneaux, string texteSiChoix1, string texteSiChoix2) :this(id, (int)proba, conditions, choix1, choix2, titre, texte, creneaux, texteSiChoix1, texteSiChoix2)
        {
            
        }


        public string getChoix2()
        {
            return choix2;
        }

        public string getTexteSiChoix1()
        {
            return texteSiChoix1;
        }

        public string getTexteSiCHoix2()
        {
            return texteSiChoix2;
        }

        private double mult(double a, double b)
        {
            return a * b;
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
}