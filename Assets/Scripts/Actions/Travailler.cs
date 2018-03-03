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
            Personnage.Player.instance.augmenterTravailActuel(10);
            Personnage.Player.instance.diminuerEnergieActuelle(10);
            base.Act();
        }
    }
}