using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Nodes.Cards;

namespace RevertAncientBorder;

[HarmonyPatch(typeof(NCard), nameof(NCard.Reload))]
public static class NCardPatches
{
    public static void HideGlassOverlay(NCard __instance)
    {
        if (__instance.Model?.Rarity == CardRarity.Ancient)
        {
            __instance._ancientBorderGlassOverlay.Visible = false;
        }
    }
}
