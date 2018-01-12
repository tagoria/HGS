using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Sauvegarde sauvegarde = GameObject.FindGameObjectWithTag(Sauvegarde.SAUVEGARDEFLOTTANTE).GetComponent<Sauvegarde>();
		evenement=  new Evenement(1.0f,new ConditionSup(10,Sauvegarde.TRAVAIL));
        sauvegarde.addEventToHistoric(evenement);
        Dictionary<int,Evenement> dictionary = sauvegarde.getEventHistoric();
        string path = "Assets/Resources/Events/Main.txt";
        
        foreach(Evenement eve in dictionary.Values)
        {
            Debug.Log(eve.getId());
        }
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("");
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset) Resources.Load("Events/Main");

        //Print the text from the file
        Debug.Log(asset.text);
        
    }
    public TextAsset evenements;
    public Evenement evenement;
	// Update is called once per frame
	void Update () {
        
	}
}
