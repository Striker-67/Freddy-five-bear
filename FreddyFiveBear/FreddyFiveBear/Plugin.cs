using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace FreddyFiveBear
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        GameObject freddy;
        float speed = 1;
        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            var bundle = LoadAssetBundle("FreddyFiveBear.Assets.ffb");
            freddy = bundle.LoadAsset<GameObject>("ffb");
            for (int i = 0; i < 10; i++)
            {
                freddy = Instantiate(freddy);
                freddy.AddComponent<move>().freddy = freddy;
                freddy.GetComponent<move>().speed = UnityEngine.Random.Range(1, 1.5f);
                freddy.transform.position = new Vector3(UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100));
            }
                

        }
        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }

        

      

    }
}
