using System.Collections.Generic;
using Enums;
using Perks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Personnage
{
    public class CreationPersonnage : MonoBehaviour
    {
        public GameObject buttonHolder;
        private Dictionary<int, Perk> listePerkComplete;
        private Dictionary<int, Perk> listePerkPerso;
        private string nom;
#pragma warning disable CS0169 // Le champ 'CreationPersonnage.perso' n'est jamais utilisé
        private GameObject perso;
#pragma warning restore CS0169 // Le champ 'CreationPersonnage.perso' n'est jamais utilisé
        private Player personnage;
        public Scrollbar scrollbar;
        public GameObject toggle;

        // Use this for initialization
        private void Start()
        {
            listePerkPerso = new Dictionary<int, Perk>();
            listePerkComplete = new Dictionary<int, Perk>();
            listePerkComplete.Add((int) PerksEnum.AbstenteistePerk, new AbstenteistePerk());
            listePerkComplete.Add((int) PerksEnum.DormeurPerk, new DormeurPerk());
            listePerkComplete.Add((int) PerksEnum.FetardPerk, new FetardPerk());
            listePerkComplete.Add((int) PerksEnum.GeekPerk, new GeekPerk());
            listePerkComplete.Add((int) PerksEnum.GloutonPerk, new GloutonPerk());
            listePerkComplete.Add((int) PerksEnum.InsomniaquePerk, new InsomniaquePerk());
            listePerkComplete.Add((int) PerksEnum.IntelloPerk, new IntelloPerk());
            listePerkComplete.Add((int) PerksEnum.MaladePerk, new MaladePerk());
            listePerkComplete.Add((int) PerksEnum.ProcrastinateurPerk, new ProcrastinateurPerk());
            listePerkComplete.Add((int) PerksEnum.RedoublantPerk, new RedoublantPerk());
            listePerkComplete.Add((int) PerksEnum.SportifPerk, new SportifPerk());
            listePerkComplete.Add((int) PerksEnum.StressePerk, new StressePerk());
            afficherPerks(listePerkComplete);
        }

        private void Update()
        {
            if (FindObjectOfType<Player>() != null)
            {
                personnage = FindObjectOfType<Player>();
                personnage.SetPerks(listePerkPerso);
                personnage.SetNom(nom);
                Destroy(gameObject);
            }
        }

        private void afficherPerks(Dictionary<int, Perk> listePerk)
        {
            var hauteurBase = buttonHolder.transform.parent.GetComponent<RectTransform>().sizeDelta.y / 2 - 60;
            var nbToggle = 0;
            foreach (var perk in listePerk.Values)
            {
                var tog = Instantiate(toggle, buttonHolder.transform.parent);
                tog.transform.localPosition = new Vector2(0, hauteurBase + nbToggle * -120);
                tog.GetComponentInChildren<PerkToggle>().perkId = perk.id;
                tog.GetComponentInChildren<Text>().text = perk.nom;
                nbToggle++;
            }

            scrollbar.size = Mathf.Clamp(0, 1, 1 - (listePerk.Count - 6) * 0.1f);
        }

        public void SlidePerks(float value)
        {
            scrollbar.transform.localPosition = new Vector2(0, -value * 30);
        }

        public void AddPerk(int id)
        {
            if (!listePerkPerso.ContainsKey(id)) listePerkPerso.Add(id, listePerkComplete[id]);
        }

        public void DeletePerk(int id)
        {
            if (!listePerkPerso.ContainsKey(id))
                listePerkPerso.Remove(id);
        }

        public void CreatePersonnage()
        {
            DontDestroyOnLoad(this);
            SceneManager.LoadSceneAsync((int) NumeroSceneEnum.EcranPrincipal, LoadSceneMode.Single);
        }

        public void SetName()
        {
            nom = GameObject.FindGameObjectWithTag("inputFieldPlayerName").GetComponentInChildren<InputField>().text;
            //NomDuJoueur.LeNom.NomJoueur = nom;
        }

        public string getName()
        {
            return nom;
        }
    }
}