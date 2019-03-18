﻿using System;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Stone
{
    public class WizardBuffCustomizerPlugin : BasePlugin, ICustomizer
    {
        public WizardBuffCustomizerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void Customize()
        {
            Hud.GetPlugin<PlayerTopBuffListPlugin>().BuffPainter.TimeLeftFont = Hud.Render.CreateFont("tahoma", 12, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true);
            Hud.GetPlugin<PlayerTopBuffListPlugin>().BuffPainter.StackFont = Hud.Render.CreateFont("tahoma", 12, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true);
            Hud.GetPlugin<PlayerTopBuffListPlugin>().BuffPainter.ShowTooltips = true;
            Hud.GetPlugin<PlayerTopBuffListPlugin>().PositionOffset = -0.3f;
            Hud.GetPlugin<PlayerTopBuffListPlugin>().RuleCalculator.SizeMultiplier = 1.0f;

            Hud.GetPlugin<PlayerTopBuffListPlugin>().RuleCalculator.Rules.Add(new BuffRule(243141) { IconIndex = 5, MinimumIconCount = 1, ShowStacks = true, ShowTimeLeft = false }); // BlackHole
            Hud.GetPlugin<PlayerTopBuffListPlugin>().RuleCalculator.Rules.Add(new BuffRule(30796) { IconIndex = 2, MinimumIconCount = 1, ShowStacks = true, ShowTimeLeft = false }); // Wave of Force
            Hud.GetPlugin<PlayerTopBuffListPlugin>().RuleCalculator.Rules.Add(new BuffRule(208823) { IconIndex = 1, MinimumIconCount = 1, ShowStacks = true, ShowTimeLeft = false }); // ArcaneDynamo
            Hud.GetPlugin<PlayerTopBuffListPlugin>().RuleCalculator.Rules.Add(new BuffRule(74499) { IconIndex = 4, MinimumIconCount = 1, ShowStacks = true, ShowTimeLeft = false }); // HaloOfKarini
            Hud.GetPlugin<PlayerTopBuffListPlugin>().RuleCalculator.Rules.Add(new BuffRule(359581) { IconIndex = 5, MinimumIconCount = 1, ShowStacks = true, ShowTimeLeft = false }); // Firebird's Finery 6set
         }
	}
}