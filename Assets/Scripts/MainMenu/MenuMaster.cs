using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CH.MapoTofu.UI
{

    public class MenuMaster : MonoBehaviour
    {

        void Awake()
        {
            // reset custom game options
            ConfigCarrier.isCustomGame = false;
        }

        /// <summary>
        /// Handles play button clicked.
        /// </summary>
        public void PlayButtonClicked()
        {
            SceneManager.LoadScene("MainScene");
        }

        /// <summary>
        /// Handles custom game button clicked.
        /// </summary>
        public void CustomButtonClicked()
        {
            SceneManager.LoadScene("CustomMenu");
        }

        /// <summary>
        /// Handles about button clicked.
        /// </summary>
        public void AboutButtonClicked()
        {
            throw new NotImplementedException();
        }

    }

}