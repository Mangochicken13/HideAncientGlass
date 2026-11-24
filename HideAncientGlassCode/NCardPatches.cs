using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Nodes.Cards;

namespace HideAncientGlass;

[HarmonyPatch(typeof(NCard))]
public static class NCardPatches
{
    [HarmonyPatch(nameof(NCard.Reload))]
    [HarmonyPostfix]
    public static void HideGlassOverlay(NCard __instance)
    {
        if (!__instance.IsNodeReady() || __instance.Model == null) { return; }
        var glassOverelay = __instance.Get("_ancientBorderGlassOverlay").As<Control>();
        if (glassOverelay != null) { glassOverelay.Visible = false; }
        else {
            var shader = __instance._portraitCanvasGroup.Material as ShaderMaterial;
            shader?.SetShaderParameter("glass", false);
        }
    }
}
