using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class Recommencer : MonoBehaviour
    {
        public void recommencer()
        {
            Personnage.Player.instance.recommencer();
            SceneManager.LoadSceneAsync((int) NumeroSceneEnum.EcranPrincipal, LoadSceneMode.Single);
        }
    }
}