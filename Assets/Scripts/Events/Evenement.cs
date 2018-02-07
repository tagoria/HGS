using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evenement  {
    // Variables propres à l'événement
    private int id; // Son id pour retrouver
	private static int nbEvenement=2; // Le nombre d'événement (instance?) crée en tout
    public float proba; // Proba de tomber sur l'événement
    public String conditions; // Alors ça ??
    
    // Variables textuelles
    public String choix1;
    public String choix2;
    public String titre;
    public String texte;


	public Evenement(float proba,String conditions) //Méthode pour créer un événement
    {
        id = nbEvenement;
        nbEvenement++;
        this.proba = proba;
        this.conditions = conditions;
    }

    internal object getId()
    {
        return id;
    }
}
