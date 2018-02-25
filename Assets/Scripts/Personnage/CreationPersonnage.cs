using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreationPersonnage : MonoBehaviour {

	// Use this for initialization
	void Start () {

        listePerkPerso = new Dictionary<int, Perk>();
        listePerkComplete = new Dictionary<int, Perk>();
        listePerkComplete.Add((int)PerksEnum.Abstenteiste, new AbstenteistePerk());
        listePerkComplete.Add((int)PerksEnum.Dormeur, new DormeurPerk());
        listePerkComplete.Add((int)PerksEnum.Fetard, new FetardPerk());
        listePerkComplete.Add((int)PerksEnum.Geek, new GeekPerk());
        listePerkComplete.Add((int)PerksEnum.Glouton, new GloutonPerk());
        listePerkComplete.Add((int)PerksEnum.Insomniaque, new InsomniaquePerk());
        listePerkComplete.Add((int)PerksEnum.Intello, new IntelloPerk());
        listePerkComplete.Add((int)PerksEnum.Malade, new MaladePerk());
        listePerkComplete.Add((int)PerksEnum.Procrastinateur, new ProcrastinateurPerk());
        listePerkComplete.Add((int)PerksEnum.Redoublant, new RedoublantPerk());
        listePerkComplete.Add((int)PerksEnum.Sportif, new SportifPerk());
        listePerkComplete.Add((int)PerksEnum.Stresse, new StressePerk());
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
            personnage.setPerks(listePerkPerso);
            personnage.SetNom(nom);
            Destroy(this.gameObject);
        }
    }
    private void afficherPerks(Dictionary<int,Perk> listePerk)
    {
        float hauteurBase = buttonHolder.transform.parent.GetComponent<RectTransform>().sizeDelta.y/2-60;
        int nbToggle = 0;
        foreach(Perk perk in listePerk.Values)
        {
            GameObject tog = Instantiate(toggle,buttonHolder.transform.parent);
            tog.transform.localPosition = new Vector2(0,hauteurBase+nbToggle*-120);
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
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)NumeroSceneEnum.EcranPrincipal,UnityEngine.SceneManagement.LoadSceneMode.Single);
        
    }
    public  void SetName()
    {
        nom=GameObject.FindGameObjectWithTag("inputFieldPlayerName").GetComponentInChildren<InputField>().text;
    }
}
