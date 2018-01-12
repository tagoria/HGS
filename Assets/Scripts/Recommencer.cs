using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recommencer : MonoBehaviour {

    public void recommencer()
    {
        Personnage.main.recommencer();
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)NumeroScene.EcranPrincipal, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
