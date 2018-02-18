﻿using System;
using UnityEngine;
using UnityEngine.UI;

// Bonjour, ce script va générer un événement
// Ce n'est pas lui qui décide quel événement aura été choisi

public class GenerationEvenement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private  Button[] buttons;
    private  Evenement evenement;
    private  Text corpsTexte;
    private Text titre;
    public void afficher(Evenement evenement)
    {
        this.evenement = evenement;
        fenetre = Instantiate(fenetreTemplate,transform.parent);
        Text[] textes = fenetre.GetComponentsInChildren<Text>();
        foreach(Text text in textes)
        {
            if (text.text.Equals("CorpsTexte"))
            {
                corpsTexte = text;
            }else if(text.text.Equals("Titre")){
                titre = text;
            }
        }
        buttons = fenetre.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(realiserChoix1);
        buttons[0].GetComponentInChildren<Text>().text = evenement.getChoix1();
        if (evenement.GetType() == typeof(EvenementDeuxChoix))
        {
            EvenementDeuxChoix evnmt = (EvenementDeuxChoix)evenement;
            buttons[1].onClick.AddListener(realiserChoix2);
            buttons[1].GetComponentInChildren<Text>().text = evnmt.getChoix2();
        }
        corpsTexte.text = evenement.getTexte();
        titre.text = evenement.getTitre();
    }
    private void supprimerEvenement()
    {
        Destroy(fenetre);
        
    }
       private void afficherResultat(String resultat)
    {
        corpsTexte.text = resultat;
        for(int i = 0; i < buttons.Length; i++)
        {
            if (i == 0)
            {
                buttons[i].GetComponentInChildren<Text>().text = "Ok";
                buttons[i].onClick.RemoveAllListeners();
                buttons[i].onClick.AddListener(supprimerEvenement);
            }
            else
            {
                Destroy(buttons[i].gameObject);
            }
        }
    }
    public  GameObject fenetreTemplate;
    private  GameObject fenetre;
    public void realiserChoix1()
    {
        if (evenement.GetType() == typeof(EvenementDeuxChoix))
        {
            EvenementDeuxChoix evnmt = (EvenementDeuxChoix) evenement;
            afficherResultat(evnmt.getTexteSiChoix1());

        }
        else
        {
            supprimerEvenement();
        }
        evenement.realiserChoix1();
    }
    public void realiserChoix2()
    {
        if (evenement.GetType() == typeof(EvenementDeuxChoix))
        {
            EvenementDeuxChoix evnmt =(EvenementDeuxChoix) evenement;
            afficherResultat(evnmt.getTexteSiCHoix2());
            evnmt.realiserChoix2();
        }
    }
}
