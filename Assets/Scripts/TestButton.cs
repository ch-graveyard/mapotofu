using UnityEngine;
using UnityEngine.UI;

namespace CH.MapoTofu.UI
{

    public class TestButton : MonoBehaviour
    {
        [SerializeField]
        public BarHandler barHandler;

        /// <summary>
        /// How much to modify the bar per click.
        /// </summary>
        [SerializeField]
        public int delta = -100;

        /// <summary>
        /// Handles button OnClick event.
        /// </summary>
        public void OnButtonClicked()
        {
            barHandler.AddToValue(delta);
        }
    }

}
