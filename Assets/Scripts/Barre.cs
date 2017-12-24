using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barre : MonoBehaviour  {

	// Use this for initialization
	public virtual void Start () {
        id = GetInstanceID();
        valeur=PlayerPrefs.GetFloat("ValeurBarre"+id);
	}
    private int id;
    private float valeur;
    public float valeurCap;
    public float valeurMini;
    ///<remarks>Remarque</remarks>
    ///<param name='f'> valeur à ajouter</param> 
    ///<returns>valeur après l'augmentation</returns>
	public virtual float Augmenter(float f)
    {
        valeur += f;
        if (valeur > valeurCap)
        {
            valeur = valeurCap;
        }
        PlayerPrefs.SetFloat("ValeurBarre" + id, valeur);
        return valeur;
    }

    public virtual void diminuer(float f)
    {
        valeur -= f;
        if (valeur < valeurMini)
        {
            valeur = valeurMini;
        }
        PlayerPrefs.SetFloat("ValeurBarre" + id, valeur);
    }
    // Update is called once per frame
    public virtual void Update () {
        switch (valeur.ToString())
        {

            case "0":
                GetComponent<Renderer>().material.color = new Color(1, 0, 0);
                break;
            case "1":
                GetComponent<Renderer>().material.color = new Color(0, 1, 0);
                break;
            case "2":
                GetComponent<Renderer>().material.color = new Color(1, 0, 1);
                break;
            default:
                GetComponent<Renderer>().material.color = new Color(1, 1, 1);
                break;
        }

	}

    public void OnMouseDown()
    {
        Augmenter(1);
    }



}
