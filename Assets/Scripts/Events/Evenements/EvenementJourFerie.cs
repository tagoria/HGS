

public class EvenementJourFerie : EvenementUnSeulChoix
{
    public EvenementJourFerie() : base(30, 100, null,"super", "Jour férié", "jour férié")
    {
    }
    public override void realiserChoix1()
    {
        Personnage.main.ajouterStatus(new StatusJourFerie());
    }

    
}