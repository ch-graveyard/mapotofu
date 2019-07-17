using UnityEngine;
using UnityEngine.UI;

namespace CH.MapoTofu.UI
{

    public class IncrementButton : MonoBehaviour
    {
        /// <summary>
        /// Text object with number to increment.
        /// </summary>
        public Text counter;

        /// <summary>
        /// Current number.
        /// </summary>
        private int number = 0;

        void Awake()
        {
            number = 0;
        }

        /// <summary>
        /// Handles button OnClick event.
        /// </summary>
        public void OnButtonClicked()
        {
            // increment counter
            number++;

            // update text
            counter.text = "<b>" + number + "</b>";
        }
    }

}
