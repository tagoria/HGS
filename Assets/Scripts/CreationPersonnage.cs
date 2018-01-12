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
        perso =(GameObject) Instantiate(Resources.Load("Personnage"));
        personnage = perso.GetComponentInChildren<Personnage>();
        afficherPerks(listePerkComplete);
    }
    private Personnage personnage;
    private Dictionary<int, Perk> listePerkPerso;
    private  Dictionary<int, Perk> listePerkComplete;
    private  GameObject perso;
    private string nom;
    public GameObject toggle;
	
    private void afficherPerks(Dictionary<int,Perk> listePerk)
    {
        int nbToggle = 0;
        foreach(Perk perk in listePerk.Values)
        {
            GameObject tog = Instantiate(toggle,transform);
            tog.transform.localPosition = new Vector2(0,nbToggle*-30);
            tog.GetComponentInChildren<PerkToggle>().perkId = perk.id;
            tog.GetComponentInChildren<Text>().text =perk.nom;
            nbToggle++;
        }
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
        personnage.setPerks(listePerkPerso);
        DontDestroyOnLoad(perso);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)NumeroScene.EcranPrincipal,UnityEngine.SceneManagement.LoadSceneMode.Single);
        
    }
    public  void SetName()
    {
        personnage.SetNom( GameObject.FindGameObjectWithTag("inputFieldPlayerName").GetComponentInChildren<InputField>().text);
    }
}
