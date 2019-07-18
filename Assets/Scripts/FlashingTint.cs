using UnityEngine;
using UnityEngine.UI;

namespace CH.MapoTofu.UI
{

    public class FlashingTint : MonoBehaviour
    {
        #region Serialized fields
        /// <summary>
        /// <see cref="BarHandler"/> script to get HP values from.
        /// </summary>
        [SerializeField]
        private BarHandler _hpBar;

        /// <summary>
        /// Maximum opacity to set fill to when HP is 0.
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float _maxOpacity;

        /// <summary>
        /// Amount to vary opacity during flashing.
        /// </summary>
        [Range(0.0f, 0.5f)]
        [SerializeField]
        private float _opacityVariation;

        /// <summary>
        /// Period of flashing in seconds.
        /// </summary>
        [SerializeField]
        private float _period = 1;

        /// <summary>
        /// Colour of tint.
        /// </summary>
        [SerializeField]
        private Color _color;
        #endregion

        /// <summary>
        /// Time passed so far in seconds in animation.
        /// </summary>
        private float _time = 0f;

        void Update()
        {
            // increase time
            _time += Time.deltaTime;
            if (_time > _period)
            {
                _time -= _period;
            }

            // set tint to transparent if HP is max
            if (_hpBar.Value >= _hpBar.MaxValue)
            {
                GetComponent<Image>().color = Color.clear;
                return;
            }

            // get base opacity
            float baseOpacity =
                (1.0f - (float)_hpBar.Value / _hpBar.MaxValue) * _maxOpacity;

            // calculate variation
            float variation =
                _opacityVariation *
                Mathf.Sin(2f * Mathf.PI * _time / _period);

            // set opacity of tint
            GetComponent<Image>().color =
                new Color(_color.r, _color.g, _color.b,
                    baseOpacity + variation);
        }
    }

}
