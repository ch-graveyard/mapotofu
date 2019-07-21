namespace CH.MapoTofu
{

    /// <summary>
    /// Static class carrying a configuration struct across scenes.
    /// </summary>
    public static class ConfigCarrier
    {
        /// <summary>
        /// True if custom game is being started.
        /// </summary>
        public static bool isCustomGame = false;

        /// <summary>
        /// True if <see cref="Config"/> has been set before.
        /// </summary>
        public static bool configSet = false;

        /// <summary>
        /// <see cref="GameConfig"/> configuration.
        /// </summary>
        public static GameConfig Config { get; set; }
    }

}
