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
    }

}