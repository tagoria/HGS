using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Evenement : IComparable<Evenement> {
    // Variables propres à l'événement
    private int id; // Son id pour retrouver
    private static int nbEvenement = 0; // Le nombre d'événement créé en tout
    private double proba; // Proba de tomber sur l'événement
    private List<Condition> conditions; // Conditions nécessaires à la réalisation de l'événement 
    public String getChoix1()
    {
        return choix1;
    }
    public String getTexte()
    {
        return texte;
    }

    // Variables textuelles
    private String choix1;
    
    private String titre;
    private String texte;
    
    public abstract void realiserChoix1();

    public Evenement(int id,float proba,List<Condition> conditions,String choix1,String titre,String texte) //Méthode pour créer un événement
    {
        this.id = id;
        nbEvenement++;
        this.proba = proba;
        this.conditions = conditions;
        this.choix1 = choix1;
        this.titre = titre;
        this.texte = texte;
    }
    public String getTitre()
    {
        return this.titre;
    }
    public double getProba()
    {
        return proba;
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
        var evenement = obj as Evenement;
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
    public int CompareTo(Evenement evenement)
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
}
