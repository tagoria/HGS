using UnityEngine;

namespace Utils
{
    public class Barre : MonoBehaviour
    {
        private int id;
        private Vector3 maxScale;
        public float valeur;
        public float valeurCap;
        internal float valeurMini;

        public float Valeur
        {
            get
            {
                return valeur;
            }

            set
            {
                valeur = value;
                if (valeur > valeurCap)
                    valeur = valeurCap;
                ChangeSize();
            }
        }

        private void Awake()
        {
            maxScale = new Vector3(1,1,1);
        }


        private void ChangeSize()
        {
            transform.localScale = new Vector3(maxScale.x * valeur / valeurCap, maxScale.y, maxScale.z);
        }
    }
}