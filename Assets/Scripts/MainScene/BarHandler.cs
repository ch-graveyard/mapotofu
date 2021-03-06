﻿using UnityEngine;
using UnityEngine.UI;

namespace CH.MapoTofu.UI
{

    public class BarHandler : MonoBehaviour
    {
        #region UI elements
        /// <summary>
        /// Image object that represents the fill of the bar.
        /// </summary>
        private Image _fill;

        /// <summary>
        /// Text object with the value of the property.
        /// </summary>
        private Text _valueText;
        #endregion

        private int _value;

        /// <summary>
        /// Current value of the property.
        /// </summary>
        public int Value
        {
            get
            {
                return _value;
            }
        }

        private int _maxValue = 0;

        /// <summary>
        /// Maximum possible value of the property.
        /// </summary>
        public int MaxValue
        {
            get
            {
                return _maxValue;
            }
        }

        void Start()
        {
            // get UI elements
            _fill = transform.Find("Fill").GetComponent<Image>();
            _valueText = transform.Find("Value").GetComponent<Text>();
            _value = MaxValue;

            // initialize bar
            UpdateBar();
        }

        /// <summary>
        /// Updates progress bar fill and value.
        /// </summary>
        private void UpdateBar()
        {
            _fill.fillAmount = (float)Value / MaxValue;
            _valueText.text = Value.ToString("#,0");
        }

        #region Public functions
        /// <summary>
        /// Increases the value by the specified amount. Specify a negative
        /// number to decrease the value.
        /// </summary>
        /// <param name="change">Amount to increase the value by</param>
        public void AddToValue(int change)
        {
            _value += change;
            if (_value > MaxValue)
            {
                _value = MaxValue;
            }
            else if (_value < 0)
            {
                _value = 0;
            }
            UpdateBar();
        }

        /// <summary>
        /// Sets the value to the specified number.
        /// </summary>
        /// <param name="value">Number to set value to</param>
        public void SetValue(int value)
        {
            _value = value;
            if (_value > MaxValue)
            {
                _value = MaxValue;
            }
            else if (_value < 0)
            {
                _value = 0;
            }
            UpdateBar();
        }

        /// <summary>
        /// Sets the maximum value of the property.
        /// </summary>
        /// <param name="maxValue">Number to set maximum value to</param>
        public void SetMaxValue(int maxValue)
        {
            _maxValue = maxValue;
            if (_maxValue < 0)
            {
                _maxValue = 0;
            }
            if (_value > MaxValue)
            {
                _value = MaxValue;
            }
        }
        #endregion
    }

}
