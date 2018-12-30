using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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

    [HarmonyPatch(typeof(SplashLauncher), "Update")]
    public static class SplashLauncher_Update_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codeInstructions = instructions.ToList();
            foreach (var instruction in codeInstructions)
            {
                if (instruction.opcode == OpCodes.Call && instruction.operand.ToString().Contains("get_anyKeyDown"))
                {
                    instruction.opcode = OpCodes.Nop;
                }
                else if (instruction.opcode == OpCodes.Brfalse)
                {
                    instruction.opcode = OpCodes.Nop;
                }
            }

            return codeInstructions;
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
