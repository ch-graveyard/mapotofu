using UnityEngine;

namespace CH.MapoTofu
{

    public class GameLogic : MonoBehaviour
    {
        #region Serialized fields
        /// <summary>
        /// <see cref="BarHandler"/> for HP bar.
        /// </summary>
        [SerializeField]
        private UI.BarHandler _hpBar;

        /// <summary>
        /// Maximum HP.
        /// </summary>
        [SerializeField]
        private int _maxHp;

        /// <summary>
        /// <see cref="BarHandler"/> for water bar.
        /// </summary>
        [SerializeField]
        private UI.BarHandler _waterBar;

        /// <summary>
        /// Maximum water count.
        /// </summary>
        [SerializeField]
        private int _maxWater;

        /// <summary>
        /// <see cref="BarHandler"/> for tofu bar.
        /// </summary>
        [SerializeField]
        private UI.BarHandler _tofuBar;

        /// <summary>
        /// Maximum tofu value.
        /// </summary>
        [SerializeField]
        private int _maxTofu;
        #endregion

        #region Game state
        private int _currentHp;
        private int _currentWater;
        private int _currentTofu;
        #endregion

        #region Monobehaviour methods
        void Awake()
        {
            // set maximum values for bars
            _hpBar.SetMaxValue(_maxHp);
            _waterBar.SetMaxValue(_maxWater);
            _tofuBar.SetMaxValue(_maxTofu);

            // set initial game state
            _currentHp = _maxHp;
            _currentWater = _maxWater;
            _currentTofu = _maxTofu;
        }
        #endregion

        #region Button click handlers
        /// <summary>
        /// Handles eat button being clicked.
        /// </summary>
        public void EatButtonClicked()
        {
            // reduce HP and tofu
            _currentHp = Mathf.Max(_currentHp - 500, 0);
            _currentTofu = Mathf.Max(_currentTofu - 800, 0);

            // update BarHandlers
            UpdateBars();
        }

        /// <summary>
        /// Handles drink button being clicked.
        /// </summary>
        public void DrinkButtonClicked()
        {
            // check if still have water
            if (_currentWater > 0)
            {
                // reduce water
                _currentWater--;

                // increase HP
                _currentHp = Mathf.Min(_currentHp + 1000, _maxHp);
            }

            // update BarHandlers
            UpdateBars();
        }
        #endregion

        /// <summary>
        /// Updates all <see cref="BarHandler"/>s with current values.
        /// </summary>
        private void UpdateBars()
        {
            _hpBar.SetValue(_currentHp);
            _waterBar.SetValue(_currentWater);
            _tofuBar.SetValue(_currentTofu);
        }
    }

}