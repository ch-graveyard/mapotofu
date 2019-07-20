using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        /// <summary>
        /// <see cref="Text"/> representing time remaining.
        /// </summary>
        [SerializeField]
        private Text _timer;

        /// <summary>
        /// Object containing <see cref="Text"/> for displaying messages at
        /// game end.
        /// </summary>
        [SerializeField]
        private GameObject _gameEndText;

        [SerializeField]
        private GameConfig _config;

        [SerializeField]
        private GameState _state;
        #endregion

        /// <summary>
        /// True if game is over due to time / HP / tofu depleted.
        /// </summary>
        private bool _gameOver = false;

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
            // don't apply update loop if game is over
            if (_gameOver)
                return;

            // increment time
            _state.time += Time.deltaTime;

            // update timer
            _timer.text = ((int)(_config.maxTime - _state.time)).ToString("0");

            // check if time is up
            if ((int)_state.time > _config.maxTime) TimeOver();

            // check if we crossed a second
            if ((int)(_state.time - Time.deltaTime) < (int)_state.time)
            {
                // calculate times from which to get tofu
                int startTime = (int)_state.time - _config.timeSpicinessLasts;
                int endTime = (int)_state.time - _config.timeSpicinessStarts;
                if (startTime < 0) startTime = 0;
                if (endTime < 0) endTime = 0;

                // sum tofu eaten in window
                int tofu = 0;
                for (int i = startTime; i <= endTime; i++)
                {
                    tofu += _state.tofuEaten[i];
                }

                // reduce HP
                _state.currentHp -= (int)(_config.hpDecreasePerTofu * tofu);
            }

            // check if HP or tofu is depleted
            if (_state.currentHp <= 0)
            {
                GameOver();
            }
            if (_state.currentTofu <= 0)
            {
                Win();
            }

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
            // reduce tofu
            _state.currentTofu -= _config.tofuDecreasePerBite;

            // log tofu eaten
            _state.tofuEaten[(int)_state.time] += _config.tofuDecreasePerBite;
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

                // recover HP
                _state.currentHp += _config.hpRecoveryPerDrink;

                // negate tofu
                _state.tofuEaten[(int)_state.time] -=
                    _config.tofuNegationPerDrink;
            }
        }
        #endregion

        #region Game ending handlers
        /// <summary>
        /// Handles time running out.
        /// </summary>
        private void TimeOver()
        {
            // set game over so update loop does not run
            _gameOver = true;

            // display game over
            _gameEndText.SetActive(true);
            _gameEndText.GetComponent<Text>().text = "Time Over";
        }

        /// <summary>
        /// Handles HP running out.
        /// </summary>
        private void GameOver()
        {
            // set game over so update loop does not run
            _gameOver = true;

            // display game over
            _gameEndText.SetActive(true);
            _gameEndText.GetComponent<Text>().text = "Game Over";
        }

        /// <summary>
        /// Handles tofu being finished.
        /// </summary>
        private void Win()
        {
            // set game over so update loop does not run
            _gameOver = true;

            // display game over
            _gameEndText.SetActive(true);
            _gameEndText.GetComponent<Text>().text = "Level Clear";
        }
        #endregion

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