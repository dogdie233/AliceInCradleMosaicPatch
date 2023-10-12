using BepInEx;
using BepInEx.Logging;

using HarmonyLib;

using nel;

namespace AliceInCradleMosaicPatch
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("AliceInCradle.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource myLogger;

        private void Awake()
        {
            myLogger = Logger;

            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            Harmony.CreateAndPatchAll(typeof(MosaicShowerPatch));
            Logger.LogInfo("Patch MosaicShowerPatch succeed");
        }
    }

    [HarmonyPatch]
    public class MosaicShowerPatch
    {
        [HarmonyPatch(typeof(MosaicShower), "FnDrawMosaic")]
        [HarmonyPrefix]
        static void FnDrawMosaic(ref bool __runOriginal)
        {
            __runOriginal = !__runOriginal ? false : XX.X.SENSITIVE;
        }
    }
}
