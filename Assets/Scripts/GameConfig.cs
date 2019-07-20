using System;

namespace CH.MapoTofu
{

    /// <summary>
    /// Struct containing configuration of level.
    /// </summary>
    [Serializable]
    public struct GameConfig
    {
        /// <summary>
        /// Maximum HP.
        /// </summary>
        public int maxHp;

        /// <summary>
        /// Maximum water count.
        /// </summary>
        public int maxWater;

        /// <summary>
        /// Maximum tofu value.
        /// </summary>
        public int maxTofu;

        /// <summary>
        /// Maximum time for tofu to be eaten.
        /// </summary>
        public int maxTime;

        /// <summary>
        /// Tofu decrease per bite.
        /// </summary>
        public int tofuDecreasePerBite;

        /// <summary>
        /// HP decrease per tofu eaten per second.
        /// </summary>
        public float hpDecreasePerTofu;

        /// <summary>
        /// Time till the spiciness of the tofu stops being considered.
        /// </summary>
        public int timeSpicinessLasts;

        /// <summary>
        /// Time before spiciness of the tofu starts being considered.
        /// </summary>
        public int timeSpicinessStarts;

        /// <summary>
        /// HP recovery amount per drink of water.
        /// </summary>
        public int hpRecoveryPerDrink;

        /// <summary>
        /// Amount of tofu to negate in the same second as the drink.
        /// </summary>
        public int tofuNegationPerDrink;
    }

}