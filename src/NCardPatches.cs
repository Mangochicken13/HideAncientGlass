using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Nodes.Cards;

namespace RevertAncientBorder;

[HarmonyPatch(typeof(NCard))]
public static class NCardPatches
{
    [HarmonyPatch(nameof(NCard.Reload))]
    [HarmonyPostfix]
    public static void HideGlassOverlay(NCard __instance)
    {
        if (!__instance.IsNodeReady() || __instance == null) { return; }
        if (__instance.Model?.Rarity == CardRarity.Ancient)
        {
            __instance._ancientBorderGlassOverlay.Visible = false;
        }
    }
}
