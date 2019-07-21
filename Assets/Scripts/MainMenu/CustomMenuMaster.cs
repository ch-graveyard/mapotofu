using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CH.MapoTofu.UI
{

    public class CustomMenuMaster : MonoBehaviour
    {

        #region Serialized fields
        /// <summary>
        /// Default configuration.
        /// </summary>
        [SerializeField]
        private GameConfig _defaultConfig;

        // Option elements.
        [SerializeField]
        private InputField _maxHpOption, _maxWaterOption, _maxTofuOption,
            _maxTimeOption, _tofuDecreaseOption, _hpDecreaseOption,
            _dmgWindowEndOption, _dmgWindowStartOption, _hpRecoveryOption,
            _tofuNegationOption, _dmgCapOption;
        #endregion

        /// <summary>
        /// Current configuration.
        /// </summary>
        public GameConfig _config;

        void Awake()
        {
            // set all input field placeholders
            SetPlaceholder(_maxHpOption, "Maximum HP", _defaultConfig.maxHp);
            SetPlaceholder(_maxWaterOption, "Maximum Water",
                _defaultConfig.maxWater);
            SetPlaceholder(_maxTofuOption, "Maximum Tofu",
                _defaultConfig.maxTofu);
            SetPlaceholder(_maxTimeOption, "Maximum Time",
                _defaultConfig.maxTime);
            SetPlaceholder(_tofuDecreaseOption, "Tofu Per Bite",
                _defaultConfig.tofuDecreasePerBite);
            SetPlaceholder(_hpDecreaseOption, "Damage Scale",
                _defaultConfig.hpDecreasePerTofu);
            SetPlaceholder(_dmgWindowEndOption, "Dmg Window End",
                _defaultConfig.timeSpicinessLasts);
            SetPlaceholder(_dmgWindowStartOption, "Dmg Window Start",
                _defaultConfig.timeSpicinessStarts);
            SetPlaceholder(_hpRecoveryOption, "HP Recovery",
                _defaultConfig.hpRecoveryPerDrink);
            SetPlaceholder(_tofuNegationOption, "Tofu Negation",
                _defaultConfig.tofuNegationPerDrink);
            SetPlaceholder(_dmgCapOption, "Max Damage / s",
                _defaultConfig.maxHpDecreasePerSecond);

            // copy default config
            _config = _defaultConfig;

            // add listeners
            _maxHpOption.onEndEdit.AddListener(
                delegate { MaxHpListener(_maxHpOption); });
            _maxWaterOption.onEndEdit.AddListener(
                delegate { MaxWaterListener(_maxWaterOption); });
            _maxTofuOption.onEndEdit.AddListener(
                delegate { MaxTofuListener(_maxTofuOption); });
            _maxTimeOption.onEndEdit.AddListener(
                delegate { MaxTimeListener(_maxTimeOption); });
            _tofuDecreaseOption.onEndEdit.AddListener(
                delegate { TofuDecreaseListener(_tofuDecreaseOption); });
            _hpDecreaseOption.onEndEdit.AddListener(
                delegate { HpDecreaseListener(_hpDecreaseOption); });
            _dmgWindowEndOption.onEndEdit.AddListener(
                delegate { DmgEndListener(_dmgWindowEndOption); });
            _dmgWindowStartOption.onEndEdit.AddListener(
                delegate { DmgStartListener(_dmgWindowStartOption); });
            _hpRecoveryOption.onEndEdit.AddListener(
                delegate { HpRecoveryListener(_hpRecoveryOption); });
            _tofuNegationOption.onEndEdit.AddListener(
                delegate { TofuNegationListener(_tofuNegationOption); });
            _dmgCapOption.onEndEdit.AddListener(
                delegate { DmgCapListener(_dmgCapOption); });
        }

        #region Helper methods
        /// <summary>
        /// Sets placeholder text for an <see cref="InputField"/>.
        /// </summary>
        /// <param name="inputField">The InputField to set text for</param>
        /// <param name="description">Description of field</param>
        /// <param name="defaultValue">Default value</param>
        private void SetPlaceholder(InputField inputField, string description,
            int defaultValue)
        {
            Text placeholder = inputField.transform.Find("Placeholder").
                GetComponent<Text>();
            placeholder.text =
                description + " (" + defaultValue.ToString("0") + ")";
        }

        /// <summary>
        /// Sets placeholder text for an <see cref="InputField"/>.
        /// </summary>
        /// <param name="inputField">The InputField to set text for</param>
        /// <param name="description">Description of field</param>
        /// <param name="defaultValue">Default value</param>
        private void SetPlaceholder(InputField inputField, string description,
            float defaultValue)
        {
            Text placeholder = inputField.transform.Find("Placeholder").
                GetComponent<Text>();
            placeholder.text =
                description + " (" + defaultValue.ToString("0.0") + ")";
        }
        #endregion

        #region Listener methods
        /// <summary>
        /// Handles Begin button being clicked.
        /// </summary>
        public void BeginButtonClicked()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles exit button being clicked.
        /// </summary>
        public void ExitButtonClicked()
        {
            // return to menu
            SceneManager.LoadScene("MainMenu");
        }

        // input field listeners

        private void MaxHpListener(InputField field)
        {
            try
            {
                _config.maxHp = int.Parse(field.text);
            }
            catch
            {
                _config.maxHp = _defaultConfig.maxHp;
            }
        }

        private void MaxWaterListener(InputField field)
        {
            try
            {
                _config.maxWater = int.Parse(field.text);
            }
            catch
            {
                _config.maxWater = _defaultConfig.maxWater;
            }
        }

        private void MaxTofuListener(InputField field)
        {
            try
            {
                _config.maxTofu = int.Parse(field.text);
            }
            catch
            {
                _config.maxTofu = _defaultConfig.maxTofu;
            }
        }

        private void MaxTimeListener(InputField field)
        {
            try
            {
                _config.maxTime = int.Parse(field.text);
            }
            catch
            {
                _config.maxTime = _defaultConfig.maxTime;
            }
        }

        private void TofuDecreaseListener(InputField field)
        {
            try
            {
                _config.tofuDecreasePerBite = int.Parse(field.text);
            }
            catch
            {
                _config.tofuDecreasePerBite =
                    _defaultConfig.tofuDecreasePerBite;
            }
        }

        private void HpDecreaseListener(InputField field)
        {
            try
            {
                _config.hpDecreasePerTofu = int.Parse(field.text);
            }
            catch
            {
                _config.hpDecreasePerTofu = _defaultConfig.hpDecreasePerTofu;
            }
        }

        private void DmgEndListener(InputField field)
        {
            try
            {
                _config.timeSpicinessLasts = int.Parse(field.text);
            }
            catch
            {
                _config.timeSpicinessLasts = _defaultConfig.timeSpicinessLasts;
            }
        }

        private void DmgStartListener(InputField field)
        {
            try
            {
                _config.timeSpicinessStarts = int.Parse(field.text);
            }
            catch
            {
                _config.timeSpicinessStarts =
                    _defaultConfig.timeSpicinessStarts;
            }
        }

        private void HpRecoveryListener(InputField field)
        {
            try
            {
                _config.hpRecoveryPerDrink = int.Parse(field.text);
            }
            catch
            {
                _config.hpRecoveryPerDrink = _defaultConfig.hpRecoveryPerDrink;
            }
        }

        private void TofuNegationListener(InputField field)
        {
            try
            {
                _config.tofuNegationPerDrink = int.Parse(field.text);
            }
            catch
            {
                _config.tofuNegationPerDrink =
                    _defaultConfig.tofuNegationPerDrink;
            }
        }

        private void DmgCapListener(InputField field)
        {
            try
            {
                _config.maxHpDecreasePerSecond = int.Parse(field.text);
            }
            catch
            {
                _config.maxHpDecreasePerSecond =
                    _defaultConfig.maxHpDecreasePerSecond;
            }
        }
        #endregion

    }

}