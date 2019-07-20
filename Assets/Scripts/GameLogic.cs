using UnityEngine;
using UnityEngine.SceneManagement;

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
        /// <see cref="BarHandler"/> for water bar.
        /// </summary>
        [SerializeField]
        private UI.BarHandler _waterBar;

        /// <summary>
        /// <see cref="BarHandler"/> for tofu bar.
        /// </summary>
        [SerializeField]
        private UI.BarHandler _tofuBar;

        [SerializeField]
        private GameConfig _config;

        [SerializeField]
        private GameState _state;
        #endregion

        #region Monobehaviour methods
        void Awake()
        {
            // set maximum values for bars
            _hpBar.SetMaxValue(_config.maxHp);
            _waterBar.SetMaxValue(_config.maxWater);
            _tofuBar.SetMaxValue(_config.maxTofu);

            // set initial game state
            _state.currentHp = _config.maxHp;
            _state.currentWater = _config.maxWater;
            _state.currentTofu = _config.maxTofu;
            _state.time = 0f;
            _state.tofuEaten = new int[_config.maxTime];
        }

        void Update()
        {
            // increment time
            _state.time += Time.deltaTime;

            // check if time is up
            if ((int)_state.time > _config.maxTime) TimeOver();

            // update BarHandlers
            UpdateBars();
        }
        #endregion

        #region Button click handlers
        /// <summary>
        /// Handles eat button being clicked.
        /// </summary>
        public void EatButtonClicked()
        {
            // reduce HP and tofu
            _state.currentHp = Mathf.Max(_state.currentHp - 500, 0);
            _state.currentTofu = Mathf.Max(_state.currentTofu - 800, 0);
        }

        /// <summary>
        /// Handles drink button being clicked.
        /// </summary>
        public void DrinkButtonClicked()
        {
            // check if still have water
            if (_state.currentWater > 0)
            {
                // reduce water
                _state.currentWater--;

                // increase HP
                _state.currentHp = Mathf.Min(_state.currentHp + 1000, _config.maxHp);
            }
        }
        #endregion

        /// <summary>
        /// Handles time running out.
        /// </summary>
        private void TimeOver()
        {
            // reload scene for now
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        /// <summary>
        /// Updates all <see cref="BarHandler"/>s with current values.
        /// </summary>
        private void UpdateBars()
        {
            _hpBar.SetValue(_state.currentHp);
            _waterBar.SetValue(_state.currentWater);
            _tofuBar.SetValue(_state.currentTofu);
        }
    }

}