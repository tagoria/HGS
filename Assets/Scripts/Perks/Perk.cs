using Enums;
using System;
using System.Collections.Generic;

namespace Perks
{
    public abstract class Perk
    {
        public readonly int id;
        public readonly string nom;
        private static Dictionary<PerksEnum,Type> perksType;
        private static  Type[] emptyTypes=new List<Type>().ToArray();
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
        public static void populateListe()
        {
            perksType = new Dictionary<PerksEnum, Type>();
        }
        public static Perk turnIntoPerk(PerksEnum perks)
        {
            if (perksType == null)
            {
                populateListe();
            }
            return (Perk) perksType[perks].GetConstructor(emptyTypes).Invoke(emptyTypes);
        }
    }
}