using Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Perks
{
    public abstract class Perk
    {
        private static readonly Assembly _asm = Assembly.GetAssembly(typeof(Perk));
        public readonly int id;
        public readonly string nom;
        private static Dictionary<PerksEnum,Type> perksType;
        private static  Type[] emptyTypes=new Type[0];

        protected Perk(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public abstract void Appliquer();

        public override bool Equals(object obj)
        {
            return obj.GetType() == GetType();
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }

        private static void PopulateListe()
        {
            perksType = new Dictionary<PerksEnum, Type>();
            var valeurs = Enum.GetValues(typeof(PerksEnum));
            foreach (PerksEnum valeur in (valeurs))
            {
                perksType.Add( valeur,TurnIntoType(valeur));
            }
        }

        private static Type TurnIntoType(PerksEnum perk)
        {
            var type = "Perks."+perk;
            return _asm.GetType(type);
        } 
        public static Perk TurnIntoPerk(PerksEnum perks)
        {
            if (perksType == null)
            {
                PopulateListe();
            }
            return (Perk) perksType[perks].GetConstructor(emptyTypes).Invoke(emptyTypes);
        }
    }
}