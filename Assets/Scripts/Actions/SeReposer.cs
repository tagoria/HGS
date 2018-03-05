namespace Actions
{
    public class SeReposer : Action
    {
        public override void Act()
        {
            Personnage.Player.instance.DiminuerTravailActuel(10);
            Personnage.Player.instance.AugmenterEnergieActuelle(10);
            Personnage.Player.instance.AugmenterSocialActuel(5);
            base.Act();
        }

        // Use this for initialization
        private void Awake()
        {
            nom = "Se Reposer";
        }
    }
}