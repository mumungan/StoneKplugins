using System.Collections.Generic;
using Turbo.Plugins.Default;
using System.Linq;
using System;

namespace Turbo.Plugins.Stone
{
    public class BossCCDebuffplugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection BossCCDecorator { get; set; }
        public WorldDecoratorCollection BossDebuffDecorator { get; set; }
        public IFont BossCCDebuffFont { get; set; }
        public bool showCC { get; set; }
        public bool showDebuff { get; set; }
        public bool showCCoffMessage { get; set; }
        public float CCoffStarttick { get; set; }
        private bool CCofftimerRunning = false;

        public BossCCDebuffplugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            showCC = true;
            showDebuff = true;
            showCCoffMessage = true;
            BossCCDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) 
		    {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 255, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 112, 48, 160, -1),
                    TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 112, 48, 160, true, false, 255, 0, 0, 0, true),
            });
            BossDebuffDecorator = new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 128, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 112, 48, 160, -1),
                    TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 112, 48, 160, true, false, 255, 0, 0, 0, true),
            });
        }

        public void PaintWorld(WorldLayer layer)
        {
            var monsters = Hud.Game.AliveMonsters;
            foreach (var monster in monsters)
                if (monster.Rarity == ActorRarity.Boss)
                {
                    if (showCCoffMessage && !monster.Frozen && !monster.Chilled && !monster.Slow && !monster.Stunned && !monster.Blind)
                    {
                        var CCofftime = (Hud.Game.CurrentGameTick - CCoffStarttick) / 60.0d;
                        String CCofftimetext = "CC ¾øÀ½ " + Math.Truncate(CCofftime) + "ÃÊ";
                        if (!CCofftimerRunning)
                        {
                            CCoffStarttick = Hud.Game.CurrentGameTick;
                            CCofftimerRunning = true;
                        }
                        BossCCDecorator.Paint(layer, monster, monster.FloorCoordinate, CCofftimetext);
                    }

                    if (showCCoffMessage && monster.Frozen || monster.Chilled || monster.Slow || monster.Stunned || monster.Blind)
                        if (CCofftimerRunning)
                        {
                            CCofftimerRunning = false;
                        }
                    if (monster.Frozen && showCC)
                    { BossCCDecorator.Paint(layer, monster, monster.FloorCoordinate, "ºù°á"); }
                    if (monster.Chilled && showCC)
                    { BossCCDecorator.Paint(layer, monster, monster.FloorCoordinate, "¿ÀÇÑ"); }
                    if (monster.Slow && showCC)
                    { BossCCDecorator.Paint(layer, monster, monster.FloorCoordinate, "´À¸²"); }
                    if (monster.Stunned && showCC)
                    { BossCCDecorator.Paint(layer, monster, monster.FloorCoordinate, "±âÀý"); }
                    if (monster.Blind && showCC)
                    { BossCCDecorator.Paint(layer, monster, monster.FloorCoordinate, "½Ç¸í"); }
                    if (monster.Locust && showDebuff)
                    { BossDebuffDecorator.Paint(layer, monster, monster.FloorCoordinate, "¸Þ¶Ñ±â"); }
                    if (monster.Haunted && showDebuff)
                    { BossDebuffDecorator.Paint(layer, monster, monster.FloorCoordinate, "È¥Ãâ"); }
                    if (monster.Palmed && showDebuff)
                    { BossDebuffDecorator.Paint(layer, monster, monster.FloorCoordinate, "ÆøÀå"); }
                    if (monster.MarkedForDeath && showDebuff)
                    { BossDebuffDecorator.Paint(layer, monster, monster.FloorCoordinate, "Á×Ç¥"); }
                    if (monster.Strongarmed && showDebuff)
                    { BossDebuffDecorator.Paint(layer, monster, monster.FloorCoordinate, "ÆÈ¾¾¸§"); }

                }
        }
    }
}





   