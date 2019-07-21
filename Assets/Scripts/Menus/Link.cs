using UnityEngine;

namespace CH.MapoTofu.UI
{

    public class Link : MonoBehaviour
    {

        /// <summary>
        /// URL to open when button is clicked.
        /// </summary>
        public string url;

        public void ButtonClicked()
        {
            Application.OpenURL(url);
        }

    }

}
