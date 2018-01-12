using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barre : MonoBehaviour  {
    private void Awake()
    {
        maxScale = transform.localScale;
    }
    // Use this for initialization
    public  void Start () {
        
	}
    public void setValeur(float valeur)
    {
        this.valeur = valeur;
        changeSize();
    }
    private Vector3 maxScale;
    private int id;
    public float valeur;
    public float valeurCap;
    internal float valeurMini;

    private void changeSize()
    {
        transform.localScale = new Vector3(maxScale.x*valeur/valeurCap,maxScale.y,maxScale.z);
    }




}
