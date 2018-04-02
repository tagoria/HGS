using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondAnime : MonoBehaviour {

    // Comme je n'arrive pas à obtenir la position de l'image, j'ai mis une constante à compteur

    private float compteur= 1278f;
    private bool aller= true;

	// Fonction rafraichissement image
	void Update () {

        // Une condition pour bouger l'image
        if (aller)
            compteur+=0.7f;
        else
            compteur-=0.57f;

        // Une condition pour l'aller et l retour
        if (compteur > 1278)
            aller = false;
        if (compteur < 0)
            aller = true;
                
        // La fonction qui va bouger l'image
        transform.localPosition = new Vector2(compteur, transform.localPosition.y);
        

    }
}

