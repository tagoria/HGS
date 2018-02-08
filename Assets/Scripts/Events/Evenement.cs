using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Evenement {
    // Variables propres à l'événement
    private int id; // Son id pour retrouver
    private static int nbEvenement = 0; // Le nombre d'événement créé en tout
    private double proba; // Proba de tomber sur l'événement
    private List<Condition> conditions; // Conditions nécessaires à la réalisation de l'événement 
    public String getChoix1()
    {
        return choix1;
    }
    public String getChoix2()
    {
        return choix2;
    }
    public String getTexte()
    {
        return texte;
    }
    public String getTexteSiChoix1(){
        return texteSiChoix1;
            }
    public String getTexteSiCHoix2()
    {
        return texteSiChoix2;
    }
    // Variables textuelles
    private String choix1;
    private String choix2;
    private String titre;
    private String texte;
    private String texteSiChoix1;
    private String texteSiChoix2;
    public abstract void realiserChoix1();
    public abstract void realiserChoix2();
    public Evenement(int id,float proba,List<Condition> conditions,String choix1,String choix2,String titre,String texte,String texteSiChoix1,String texteSiChoix2) //Méthode pour créer un événement
    {
        this.texteSiChoix1 = texteSiChoix1;
        this.texteSiChoix2 = texteSiChoix2;
        this.id = id;
        nbEvenement++;
        this.proba = proba;
        this.conditions = conditions;
        this.choix1 = choix1;
        this.choix2 = choix2;
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
        foreach(Condition condition in conditions)
        {
            if (!condition.verify())
            {
                return false;
            }
        }
        return true;
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
}
