using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
            HBSLog = Logger.GetLogger("SkipIntro");
        }
    }
}
