namespace Actions
{
    public class Travailler : Action
    {
        private void Awake()
        {
            nom = "Travailler";
        }

        public override void Act()
        {
            Personnage.Player.instance.AugmenterTravailActuel(10);
            Personnage.Player.instance.DiminuerEnergieActuelle(10);
            base.Act();
        }
    }
}