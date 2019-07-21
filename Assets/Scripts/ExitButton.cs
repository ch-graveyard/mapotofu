using UnityEngine;
using UnityEngine.SceneManagement;

namespace CH.MapoTofu.UI
{

    public class ExitButton : MonoBehaviour
    {

        public void ExitButtonClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }

    }

}
