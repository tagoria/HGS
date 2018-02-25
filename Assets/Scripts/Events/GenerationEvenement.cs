using System;
using UnityEngine;
using UnityEngine.UI;

// Bonjour, ce script va générer un événement
// Ce n'est pas lui qui décide quel événement aura été choisi

public class GenerationEvenement : MonoBehaviour {

    private void Awake()
    {
        instance = this;
    }

    private  Button[] buttons;
    private  EvenementAbstract evenement;
    private  Text corpsTexte;
    private Text titre;
    public static GenerationEvenement instance;
    public void afficher(EvenementAbstract evenement)
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
        if (evenement.GetType().GetInterface("EvenementEffetSiOccuppe") != null &&Personnage.main.occuppe)
        {
            EvenementEffetSiOccuppe evnmt = (EvenementEffetSiOccuppe)evenement;
            evnmt.onOccuppe();
            corpsTexte.text = "Vous ratez l'événement " + evenement.getTitre() + " car vous êtes occuppé";
            titre.text = evenement.getTitre()+" raté";
            buttons = fenetre.GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(supprimerEvenement);
            buttons[0].GetComponentInChildren<Text>().text = "Ok";
            Destroy(buttons[1].gameObject);
            return;
        }
        buttons = fenetre.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(realiserChoix1);
        buttons[0].GetComponentInChildren<Text>().text = evenement.getChoix1();
        if (evenement.isEvenmentDeuxChoix())
        {
            EvenementDeuxChoix evnmt = (EvenementDeuxChoix)evenement;
            buttons[1].onClick.AddListener(realiserChoix2);
            buttons[1].GetComponentInChildren<Text>().text = evnmt.getChoix2();
        }
        else
        {
            Destroy(buttons[1].gameObject);
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
        evenement.realiserChoix1();
        if (evenement.isEvenmentDeuxChoix())
        {
            EvenementDeuxChoix evnmt = (EvenementDeuxChoix) evenement;
            afficherResultat(evnmt.getTexteSiChoix1());

        }
        else
        {
            supprimerEvenement();
        }
    }
    public void realiserChoix2()
    {
        if (evenement.isEvenmentDeuxChoix())
        {
            EvenementDeuxChoix evnmt =(EvenementDeuxChoix) evenement;
            evnmt.realiserChoix2();
            afficherResultat(evnmt.getTexteSiCHoix2());
            
        }
    }
}
