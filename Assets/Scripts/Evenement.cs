using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evenement  {
    private int id;
	private static int nbEvenement=2;
    public float proba;
    public String conditions;
	public Evenement(float proba,String conditions)
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
