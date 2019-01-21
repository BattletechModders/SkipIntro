using System.Reflection;
using Harmony;
using HBS.Logging;

namespace SkipIntro
{
    public static class Main
    {
        internal static ILog HBSLog;

        public static void Init()
        {
            var harmony = HarmonyInstance.Create("io.github.mpstark.SkipIntro");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
