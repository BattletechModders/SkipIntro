using System.Reflection;
using BattleTech;
using Harmony;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace SkipIntro
{
    [HarmonyPatch(typeof(IntroCinematicLauncher), "Init")]
    public static class IntroCinematicLauncher_Init_Patch
    {
        public static void Postfix()
        {
            Traverse.Create(typeof(IntroCinematicLauncher)).Field("state").SetValue(3);
        }
    }

    public static class Patches
    {
        public static void Init()
        {
            var harmony = HarmonyInstance.Create("io.github.mpstark.SkipIntro");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
