using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sauvegarde : MonoBehaviour
{
    public readonly static string TRAVAIL="travail";
    public readonly static string ENERGIE="energie";
    public readonly static string BONHEUR="bonheur";
    public readonly static string EVENEMENTPASSE="evenement";
    public readonly static string ATTRIBUTSJOUEUR="atbjoueur";
    public readonly static string SAUVEGARDEFLOTTANTE = "SauvegardeFloat";
    private static IDictionary valeursFlottantes;
    private static IDictionary evenementPasse;
    // Use this for initialization
    void Awake()
    {
        
        load();
        
    }
    public object get(string key)
    {
        return valeursFlottantes[key];
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void save()
    {
        PlayerPrefs.SetFloat(TRAVAIL, (float)valeursFlottantes[TRAVAIL]);
        PlayerPrefs.SetFloat(BONHEUR, (float)valeursFlottantes[BONHEUR]);
        PlayerPrefs.SetFloat(ENERGIE, (float)valeursFlottantes[ENERGIE]);
        string sauvegardeHistoriqueEvenement = JsonUtility.ToJson(evenementPasse);
        PlayerPrefs.SetString(EVENEMENTPASSE,sauvegardeHistoriqueEvenement);
        PlayerPrefs.Save();
    }
    public void load()
    {
        if (PlayerPrefs.HasKey(TRAVAIL)&&PlayerPrefs.HasKey(BONHEUR)&&PlayerPrefs.HasKey(ENERGIE))
        {
            valeursFlottantes[TRAVAIL] = PlayerPrefs.GetFloat(TRAVAIL);
            valeursFlottantes[ENERGIE] = PlayerPrefs.GetFloat(ENERGIE);
            valeursFlottantes[BONHEUR] = PlayerPrefs.GetFloat(BONHEUR);
        }
        else
        {
            valeursFlottantes = new Dictionary<string,float>();
            valeursFlottantes[TRAVAIL] = 50f;
            valeursFlottantes[ENERGIE] = 50f;
            valeursFlottantes[BONHEUR] = 50f;
        }
        if (PlayerPrefs.HasKey(EVENEMENTPASSE))
        {
            evenementPasse = JsonUtility.FromJson<Dictionary<int,Evenement>>(PlayerPrefs.GetString(EVENEMENTPASSE));
        }
        else
        {
            evenementPasse = new Dictionary<int, Evenement>();
            //evenementPasse.Add(0, new Evenement(1f, new ConditionSup(49f, TRAVAIL)));
        }
    }
    private void OnApplicationQuit()
    {
        save();
    }
    private void OnApplicationPause(bool pause)
    {
        save();
    }
    public void addEventToHistoric(Evenement evenement)
    {
        if (!evenementPasse.Contains(evenement.getId()))
        {
            evenementPasse.Add(evenement.getId(), evenement);
            save();
        }
    }
    public Dictionary<int,Evenement> getEventHistoric()
    {
        return (Dictionary<int, Evenement>) evenementPasse;
    }
    public void setTravail(float f)
    {
        valeursFlottantes[TRAVAIL] = f;
        save();
    }
}
