using System;

namespace CH.MapoTofu
{

    /// <summary>
    /// Struct containing current game state.
    /// </summary>
    [Serializable]
    public struct GameState
    {
        /// <summary>
        /// Current HP.
        /// </summary>
        public int currentHp;

        /// <summary>
        /// Current water.
        /// </summary>
        public int currentWater;

        /// <summary>
        /// Current tofu.
        /// </summary>
        public int currentTofu;

        /// <summary>
        /// Time since scene has been loaded.
        /// </summary>
        public float time;

        /// <summary>
        /// Array of tofu eaten in each second since scene loaded.
        /// </summary>
        public int[] tofuEaten;
    }

}