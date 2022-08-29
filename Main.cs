using Sandbox.Game;
using Sandbox.Graphics;
using Sandbox.Graphics.GUI;
using SpaceEngineers.Game.GUI;
using VRage.Plugins;
using HarmonyLib;
using System;
using Sandbox.Game.Gui;
using System.Threading;
using VRageMath;
using System.IO;
using System.Xml;
using VRage.FileSystem;
using VRage.Utils;
using Sandbox.Game.Screens;

namespace RemoveIntroVideoPlugin
{
    /// <summary>
    /// Where the plugin is started.
    /// </summary>
    public class Main : IPlugin
    {
        private Type SEWorldGenMainMenu = AccessTools.TypeByName("SEWorldGenPlugin.GUI.MyPluginMainMenu");
        private Type CustomLoadingBackgroundsMenu = AccessTools.TypeByName("CustomScreenBackgrounds.GUI.BackgroundScreen");
        private bool MenuFixed = false;

        /// <summary>
        /// The intro video is disabled here. It is disabled in the constucter as it is called before the intro video plays. 
        /// We cant disable the video in Init(object gameInstance) as it is called after the video started playing.
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
        /// Fix for certain main menu modifications not working with this plugin.
        /// </summary>
        public void Update()
        {
            if (MenuFixed)
            {
                return;
            }

            if (MyScreenManager.IsScreenOfTypeOpen(typeof(MyGuiScreenMainMenu)) && SEWorldGenMainMenu != null) //Checks if SEWorldGen is installed and if the main menu is open.
            {
                //Replaces the wrong main menu with the right one
                MyScreenManager.CloseScreenNow(typeof(MyGuiScreenMainMenu));
                MyScreenManager.RemoveScreenByType(typeof(MyGuiScreenMainMenu));
                MyScreenManager.AddScreen(MyGuiSandbox.CreateScreen(SEWorldGenMainMenu, false));       
                MenuFixed = true;
                return;
            }


            if (MyScreenManager.IsScreenOfTypeOpen(typeof(MyGuiScreenMainMenu)) && CustomLoadingBackgroundsMenu != null)
            {
                MyScreenManager.CloseScreenNow(typeof(MyGuiScreenMainMenu));
                MyScreenManager.RemoveScreenByType(typeof(MyGuiScreenMainMenu));
                MyScreenManager.AddScreen(MyGuiSandbox.CreateScreen(typeof(MyGuiScreenMainMenu), false));
                MenuFixed = true;
                return;
            }
        }
    }
}
