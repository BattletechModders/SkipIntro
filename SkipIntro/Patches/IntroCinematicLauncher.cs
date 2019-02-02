using BattleTech;
using Harmony;

// ReSharper disable UnusedMember.Global

namespace SkipIntro.Patches
{
    [HarmonyPatch(typeof(IntroCinematicLauncher), "Init")]
    public static class IntroCinematicLauncher_Init_Patch
    {
        public static void Postfix()
        {
            Traverse.Create(typeof(IntroCinematicLauncher)).Field("state").SetValue(3);
        }
    }
}
