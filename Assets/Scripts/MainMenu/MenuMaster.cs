using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CH.MapoTofu.UI
{

    public class MenuMaster : MonoBehaviour
    {

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
            throw new NotImplementedException();
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