using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreationPersonnage : MonoBehaviour {

	// Use this for initialization
	void Start () {

        listePerkPerso = new Dictionary<int, Perk>();
        listePerkComplete = new Dictionary<int, Perk>();
        listePerkComplete.Add(1, new Perk1(1));
        listePerkComplete.Add(2, new Perk2(2));
        listePerkComplete.Add(3, new Perk1(1));
        listePerkComplete.Add(4, new Perk2(2));
        listePerkComplete.Add(5, new Perk1(1));
        listePerkComplete.Add(6, new Perk2(2));
        listePerkComplete.Add(7, new Perk1(1));
        listePerkComplete.Add(8, new Perk2(2));
        listePerkComplete.Add(9, new Perk1(1));
        listePerkComplete.Add(10, new Perk2(2));
        listePerkComplete.Add(11, new Perk1(1));
        listePerkComplete.Add(12, new Perk2(2));
        afficherPerks(listePerkComplete);
    }
    public GameObject buttonHolder;
    public Scrollbar scrollbar;
    private Personnage personnage;
    private Dictionary<int, Perk> listePerkPerso;
    private  Dictionary<int, Perk> listePerkComplete;
    private  GameObject perso;
    private string nom;
    public GameObject toggle;
    private void Update()
    {
        if (Component.FindObjectOfType<Personnage>() != null)
        {
            personnage = Component.FindObjectOfType<Personnage>();
            DontDestroyOnLoad(personnage.gameObject);
            personnage.setPerks(listePerkPerso);
            personnage.SetNom(nom);
            Destroy(this.gameObject);
        }
    }
    private void afficherPerks(Dictionary<int,Perk> listePerk)
    {
        int nbToggle = 0;
        foreach(Perk perk in listePerk.Values)
        {
            GameObject tog = Instantiate(toggle,buttonHolder.transform.parent);
            tog.transform.localPosition = new Vector2(0,nbToggle*-30);
            tog.GetComponentInChildren<PerkToggle>().perkId = perk.id;
            tog.GetComponentInChildren<Text>().text =perk.nom;
            nbToggle++;
        }
        scrollbar.size=Mathf.Clamp(0, 1, 1 - (listePerk.Count - 6) * 0.1f);

    }
    public void SlidePerks(float value)
    {
        scrollbar.transform.localPosition = new Vector2(0,-value*30);
    }
    public void AddPerk(int id)
    {
        if (!listePerkPerso.ContainsKey(id))
        {
            listePerkPerso.Add(id, listePerkComplete[id]);
        }
    }
    public void DeletePerk(int id)
    {
        if (!listePerkPerso.ContainsKey(id))
            listePerkPerso.Remove(id);
    }
    public  void CreatePersonnage()
    {
        DontDestroyOnLoad(this);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)NumeroScene.EcranPrincipal,UnityEngine.SceneManagement.LoadSceneMode.Single);
        
    }
    public  void SetName()
    {
        nom=GameObject.FindGameObjectWithTag("inputFieldPlayerName").GetComponentInChildren<InputField>().text;
    }
}
