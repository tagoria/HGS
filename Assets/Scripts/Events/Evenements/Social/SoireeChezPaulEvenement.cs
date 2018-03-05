using System.Collections.Generic;
using Enums;
using Events;
using Events.Conditions;


public class SoireeChezPaulEvenement : EvenementDeuxChoix {
    public SoireeChezPaulEvenement() : base(Evenement.SoireeChezPaul, (int)ProbaEnum.SoireeChezPaul, generateConditions(new ConditionJoueurOccupe(false)),
                "Y aller", "Ne pas y aller", "Bar Mitzva chez Paul",
                "Paul fête le premier jour du reste de notre vie, il t'a invité, mais tu ne le connais pas trop...",
                generateCreneau(10), "C'est l'occasion de se faire un ami", "Paule'temps")
    {
    }


    public override double getProba()
    {
        double add = Personnage.Player.instance.hasPerk(PerksEnum.Fetard) ? 10 : 0;
        add += Personnage.Player.instance.hasPerk(PerksEnum.Geek) ? -5 : 0;
        add += Personnage.Player.instance.hasPerk(PerksEnum.Stresse) ? -5 : 0;
        return base.getProba() + add;
    }

    private int TempsAleatoire()
    {
        int a = 0;
        if (Personnage.Player.instance.hasPerk(PerksEnum.Fetard))
        {// J'ai hésité à mettre un random, pour finir, je gère selon l'énergie du joueur
            if ((int)Personnage.Player.instance.getEnergieActuelle() <= 20) {  }
            if ((int)Personnage.Player.instance.getEnergieActuelle() >= 20) { a = a++; }
            if ((int)Personnage.Player.instance.getEnergieActuelle() >= 50) { a = a++; }
            }
        return a;
    }


    public override void realiserChoix1()
    {
        Personnage.Player.instance.AugmenterSocialActuel(30);
        Personnage.Player.instance.diminuerEnergieActuelle(10);
        Personnage.Player.instance.diminuerTravailActuel(5);
        Horloge.instance.avancerDePlusieursCreneauxEnEtantOccupe(2+TempsAleatoire());
    }

    public override void realiserChoix2()
    {
        Personnage.Player.instance.diminuerSocialActuel(5);
    }
}
