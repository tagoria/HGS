using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class StatusHolder : MonoBehaviour
{
    public static StatusHolder instance;
    private void Awake()
    {
        instance = this;
        statusAffiches = new List<GameObject>();
    }
    public GameObject statusTemplate;
    private List<GameObject> statusAffiches;
    public void afficherStatus(List<StatusAbstract> status)
    {
        foreach(GameObject textes in statusAffiches)
        {
            Destroy(textes);
        }
        int hauteur = 0;
        foreach(StatusAbstract statu in status)
        {
            GameObject texte= Instantiate(statusTemplate,this.transform);
            texte.GetComponent<Text>().text = statu.ToString();
            texte.transform.localPosition = new Vector2(0,hauteur);
            hauteur -= 60;
        }
    }
}