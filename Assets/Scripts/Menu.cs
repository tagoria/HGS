using System;
using Personnage;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject popupModel;
    private GameObject popupInstancie;
    public void NewGame()
    {
        DeleteSave();
        SceneManager.LoadSceneAsync((int)Enums.NumeroSceneEnum.CreationPerso);

    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey(Horloge.keyNbJoursEcoules))
        {
            SceneManager.LoadSceneAsync((int) Enums.NumeroSceneEnum.EcranPrincipal);
        }
        else
        {
          AffichePasDeSauvegarde();  
        }
    }

    public void DeleteSave()
    {
        if (PlayerPrefs.HasKey(Horloge.keyCreneauActuel))
        {
            PlayerPrefs.DeleteAll();
        }
        else
        {
            AffichePasDeSauvegarde();
        }
    }

    private void AffichePasDeSauvegarde()
    {
        popupInstancie=Instantiate(popupModel,transform.position,Quaternion.identity,transform.parent);
        popupInstancie.GetComponentInChildren<Text>().text = "Pas de sauvegarde détectée";
        Button[] buttons = popupInstancie.GetComponentsInChildren<Button>();
        Destroy(buttons[0].transform.gameObject);
        buttons[1].onClick.AddListener(ClearPopups);
        buttons[1].GetComponentInChildren<Text>().text = "OK";
    }

    private void ClearPopups()
    {
        Destroy(popupInstancie);
    }
}
