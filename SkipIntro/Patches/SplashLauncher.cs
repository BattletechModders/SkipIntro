using Harmony;

namespace SkipIntro
{
    [HarmonyPatch(typeof(SplashLauncher), "OnStart")]
    public static class SplashLauncher_OnStart_Patch
    {
        public static bool Prefix(SplashLauncher __instance)
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(SplashLauncher), "OnStep")]
    public static class SplashLauncher_OnStep_Patch
    {
        public static bool Prefix(SplashLauncher __instance)
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(SplashLauncher), "Start")]
    public static class SplashLauncher_Start_Patch
    {
        public static bool Prefix(SplashLauncher __instance)
        {
            Traverse.Create(__instance).Field("currentState").SetValue(3);

            var activate = Traverse.Create(__instance).Field("activate").GetValue<ActivateAfterInit>();
            activate.enabled = true;

            return false;
        }
    }

    [HarmonyPatch(typeof(SplashLauncher), "Update")]
    public static class SplashLauncher_Update_Patch
    {
        public static bool Prefix(SplashLauncher __instance)
        {
            return false;
        }
    }
}
