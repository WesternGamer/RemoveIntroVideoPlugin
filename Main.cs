using Sandbox.Game;
using VRage.Plugins;

namespace RemoveIntroVideoPlugin
{
    /// <summary>
    /// Where the plugin is started.
    /// </summary>
    public class Main : IPlugin
    {
        /// <summary>
        /// The intro video is disabled here.
        /// </summary>
        public Main()
        {
            MyPlatformGameSettings.ENABLE_LOGOS = false;
        }
        /// <summary>
        /// Unused
        /// </summary>
        public void Dispose()
        {
        }
        /// <summary>
        /// Unused
        /// </summary>
        public void Init(object gameInstance)
        {
        }
        /// <summary>
        /// Unused
        /// </summary>
        public void Update()
        {           
        }
    }
}
