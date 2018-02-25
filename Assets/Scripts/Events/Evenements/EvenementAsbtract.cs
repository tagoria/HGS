using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EvenementAbstract : IComparable<EvenementAbstract> {
    // Variables propres à l'événement
    private int id; // Son id pour retrouver
    private static int nbEvenement = 0; // Le nombre d'événement créé en tout
    private double proba; // Proba de tomber sur l'événement
    private List<Condition> conditions; // Conditions nécessaires à la réalisation de l'événement 
    private List<int> creneaux; //les créneaux où l'événement peut se produire 0 correspond à minuit 1
    //à deux heures du matin 2 à quatre heures du matin , etc
    public String getChoix1()
    {
        return choix1;
    }
    public String getTexte()
    {
        return texte;
    }
    public List<int> getCreneaux()
    {
        return creneaux;
    }
    // Variables textuelles
    private String choix1;
    
    private String titre;
    private String texte;
    
    public abstract void realiserChoix1();

    public EvenementAbstract(int id,float proba,List<Condition> conditions,String choix1,String titre,String texte,List<int> creneaux) //Méthode pour créer un événement
    {
        this.id = id;
        nbEvenement++;
        this.proba = proba;
        this.conditions = conditions;
        this.choix1 = choix1;
        this.titre = titre;
        this.texte = texte;
        this.creneaux = creneaux;
    }
    public String getTitre()
    {
        return this.titre;
    }
    public virtual double getProba()
    {
        return this.proba;
    }

    internal int getId()
    {
        return id;
    }
    /**
     *retourne vrai ssi l'événement peut de produire càd si chaque conditon de l'évènement est vérifiée 
     *
     **/
    public bool isRealisable()
    {
        if (conditions == null)
        {
            return true;
        }
        else
        {
            foreach (Condition condition in conditions)
            {
                if (!condition.verify())
                {
                    return false;
                }
            }
            return true;
        }
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

    public abstract class Condition
    {
        public abstract bool verify(); //methode qui renvoie vraie ssi la condition est vérifiée
    }
    public int CompareTo(EvenementAbstract evenement)
    {
        if (evenement == null)
        {
            return 1;
        }
        else
        {
            return proba.CompareTo(evenement.getProba());
        }
    }
    protected static List<int> generateCreneau(params int[] creneaux)
    {
        List<int> list = new List<int>();
        foreach (int nb in creneaux)
        {
            list.Add(nb);
        }
        return list;

    }
    public abstract bool isEvenmentDeuxChoix();
    protected static List<Condition> generateConditions(params Condition[] conditions)
    {
        List<Condition> liste = new List<Condition>();
        foreach(Condition condition in conditions)
        {
            liste.Add(condition);
        }
        return liste;
    }
}
