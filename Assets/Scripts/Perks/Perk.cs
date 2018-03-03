namespace Perks
{
    public abstract class Perk
    {
        public readonly int id;
        public readonly string nom;

        public Perk(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public abstract void appliquer();

        public override bool Equals(object obj)
        {
            return obj.GetType() == GetType();
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }
    }
}