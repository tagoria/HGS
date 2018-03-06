using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class Recommencer : MonoBehaviour
    {
        public void recommencer()
        {
            SceneManager.LoadScene((int) NumeroSceneEnum.CreationPerso, LoadSceneMode.Single);
        }
    }
}