using System;
using System.Collections.Generic;
using System.Reflection;
using Enums;
using UnityEngine;

namespace Events
{
    public abstract partial class EvenementAbstract : IComparable<EvenementAbstract>
    {
        private static int nbEvenement; // Le nombre d'événement créé en tout

        private static readonly Assembly _assembly = typeof(EvenementAbstract).Assembly;

        // Variables textuelles
        private readonly string choix1;
        private readonly List<Condition> conditions; // Conditions nécessaires à la réalisation de l'événement 

        private readonly List<int> creneaux; //les créneaux où l'événement peut se produire 0 correspond à minuit 1

        //à deux heures du matin 2 à quatre heures du matin , etc
        // Variables propres à l'événement
        private readonly Evenement id; // Son id pour retrouver
        private readonly double proba; // Proba de tomber sur l'événement
        private readonly string texte;

        private readonly string titre;
        private static List<Condition> conditionsDejaInstanciees;

        public EvenementAbstract(Evenement id, float proba, List<Condition> conditions, string choix1, string titre,
            string texte, List<int> creneaux) //Méthode pour créer un événement
        
        {
            if (conditionsDejaInstanciees == null)
            {
                conditionsDejaInstanciees = new List<Condition>();
                conditionsDejaInstanciees.Add(new Conditions.ConditionJoueurOccupe(false));
            }
            this.id = id;
            nbEvenement++;
            this.proba = proba;
            this.conditions = conditions;
            this.choix1 = choix1;
            this.titre = titre;
            this.texte = texte;
            this.creneaux = creneaux;
        }

        public int CompareTo(EvenementAbstract evenement)
        {
            if (evenement == null)
                return 1;
            return proba.CompareTo(evenement.getProba());
        }

        public string getChoix1()
        {
            return choix1;
        }

        public string getTexte()
        {
            return texte;
        }

        public List<int> getCreneaux()
        {
            return creneaux;
        }

        public abstract void realiserChoix1();

        public string getTitre()
        {
            return titre;
        }

        public virtual double getProba()
        {
            return proba;
        }

        internal Evenement getId()
        {
            return id;
        }

        /**
     *retourne vrai ssi l'événement peut de produire càd si chaque conditon de l'évènement est vérifiée 
     *
     **/
        public bool isRealisable()
        {
            if (conditions == null) return true;

            foreach (var condition in conditions)
                if (!condition.verify())
                    return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            var evenement = obj as EvenementAbstract;
            return evenement != null &&
                   id == evenement.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }

        protected static List<int> generateCreneau(params int[] creneaux)
        {
            var list = new List<int>();
            foreach (var nb in creneaux) list.Add(nb);
            return list;
        }

        public abstract bool isEvenmentDeuxChoix();

        protected static List<Condition> generateConditions(params Condition[] conditions)
        {
            var liste = new List<Condition>();
            foreach (var condition in conditions)
            {
                var index = conditionsDejaInstanciees.LastIndexOf(condition);
                if (index==-1)
                {
                    liste.Add(condition);
                    conditionsDejaInstanciees.Add(condition);
                }
                else
                {
                    liste.Add(conditionsDejaInstanciees[index]);
                }
            }
            return liste;
        }

        public static List<EvenementAbstract> loopThrough()
        {
            var array = Enum.GetValues(typeof(Evenement));
            var list = new List<Type>();
            var listEvenementAbstracts = new List<EvenementAbstract>();
            foreach (var membre in array)
            {
                var type = TurnIntoType((Evenement) membre);
                if (type != null) list.Add(type);
            }

            var empTypes = new List<Type>().ToArray();
            foreach (var membre in list)
            {
                var constructorInfo = membre.GetConstructor(empTypes);
                if (constructorInfo != null)
                {
                    var evenementAbstract = (EvenementAbstract) constructorInfo.Invoke(empTypes);
                    listEvenementAbstracts.Add(evenementAbstract);
                }
            }

            return listEvenementAbstracts;
        }

        public static Type TurnIntoType(Evenement enumEvenements)
        {
            var type = _assembly.GetType("Events." + enumEvenements);
            return type;
        }
    }
}