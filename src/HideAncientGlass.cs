using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Modding;

namespace HideAncientGlass;

[ModInitializer(nameof(Initialize))]
public partial class HideAncientGlass : Node
{
    public const string ModId = "HideAncientGlass";

    public static MegaCrit.Sts2.Core.Logging.Logger Logger { get; } = new(ModId, MegaCrit.Sts2.Core.Logging.LogType.Generic);

    public static void Initialize()
    {
        Harmony harmony = new(ModId);

        harmony.PatchAll();
    }
}
