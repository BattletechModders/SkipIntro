using Harmony;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace SkipIntro.Patches
{
    [HarmonyPatch(typeof(SplashLauncher), "Update")]
    public static class SplashLauncher_Update_Patch
    {
        public static bool Prefix(SplashLauncher __instance)
        {
            var activate = Traverse.Create(__instance).Field("activate").GetValue<ActivateAfterInit>();
            activate.enabled = true;
            return false;
        }
    }
}
