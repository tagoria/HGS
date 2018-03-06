using UnityEngine;

namespace Utils
{
    public class Barre : MonoBehaviour
    {
        private int id;
        private Vector3 maxScale;
        private float valeur;
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
                ChangeSize();
            }
        }

        private void Awake()
        {
            maxScale = transform.localScale;
        }


        private void ChangeSize()
        {
            transform.localScale = new Vector3(maxScale.x * Valeur / valeurCap, maxScale.y, maxScale.z);
        }
    }
}