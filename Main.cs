using System.Reflection;
using Harmony;

// ReSharper disable UnusedMember.Global

namespace SkipIntro
{
    public static class Main
    {
        public static void Init()
        {
            var harmony = HarmonyInstance.Create("io.github.mpstark.SkipIntro");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
