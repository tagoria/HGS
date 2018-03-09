using Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Perks
{
    public abstract class Perk
    {
        private static Assembly _asm = Assembly.GetAssembly(typeof(Perk));
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