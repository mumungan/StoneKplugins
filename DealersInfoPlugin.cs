//게임을 안해서 만들다가 중단했습니다. 게임을 다시 하게되면 다시 만들게 될지도 모릅니다
//원래 딜러 경고 메시지(보석, 스텟, 카나이)와 딜링 정보(막보때 강령, 별약법사)를 표시하게 만들려고 했는데
//딜러 스텟 경고메시지와 시체창 강령 막보 딜 정보 까지 만들고 중단합니다
//활력세팅 경고 메시지는 정복자 1500렙 이상이 되야 나옵니다

using Turbo.Plugins.Default;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Turbo.Plugins.Stone
{
    public class DealersInfoPlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection PlayerInfoDecorator { get; set; }
        public IFont InfoTextFont { get; set; }
        public IFont mainstatsettingFont { get; set; }
        public IFont vitalsettingFont { get; set; }
        public float ResourceCurPri { get; set; }
        public float MainStat { get; set; }
        public float HealthCur { get; set; }
        public float Vitality { get; set; }
        public float ResourceCurSec { get; set; }
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool showNecCoeLoop { get; set; }
        public bool showNecphyCoeLoop { get; set; }
        public bool forboss { get; set; }
        public bool warningmessage { get; set; }
        public float ElapsedtimeStarttick { get; set; }
        public float phyElapsedtimeStarttick { get; set; }
        private bool timerRunning = false;
        private bool phytimerRunning = false;
        

        public bool IsGuardianAlive
        {
            get
            {
                return riftQuest != null && (riftQuest.QuestStepId == 3 || riftQuest.QuestStepId == 16);
            }
        }

        public bool IsGuardianDead
        {
            get
            {
                if (Hud.Game.Monsters.Any(m => m.Rarity == ActorRarity.Boss && !m.IsAlive))
                    return true;

                return riftQuest != null && (riftQuest.QuestStepId == 5 || riftQuest.QuestStepId == 10 || riftQuest.QuestStepId == 34 || riftQuest.QuestStepId == 46);
            }
        }

        private IQuest riftQuest
        {
            get
            {
                return Hud.Game.Quests.FirstOrDefault(q => q.SnoQuest.Sno == 337492) ?? // rift
                       Hud.Game.Quests.FirstOrDefault(q => q.SnoQuest.Sno == 382695);   // gr
            }
        }

        public DealersInfoPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            showNecCoeLoop = true;
            showNecphyCoeLoop = true;
            warningmessage = true;
            forboss = true; 
            PlayerInfoDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud) 
		    {
                TextFont = Hud.Render.CreateFont("tahoma", 15f, 255, 255, 0, 0, true, false, 255, 0, 0, 0, true),
            });
            InfoTextFont = Hud.Render.CreateFont("tahoma", 7f, 128, 255, 255, 255, true, false, true);
            mainstatsettingFont = Hud.Render.CreateFont("tahoma", 7f, 255, 255, 255, 0, true, false, true);
            vitalsettingFont = Hud.Render.CreateFont("tahoma", 7f, 255, 255, 0, 0, true, false, true);

            XPos = 0.60f;
            YPos = 0.01f;
        }

       public void PaintWorld(WorldLayer layer)
       {
           float xPos = Hud.Window.Size.Width * XPos;
           float yPos = Hud.Window.Size.Width * YPos;
            foreach (var player in Hud.Game.Players)
            {
                if (player.HeroClassDefinition.HeroClass == HeroClass.Wizard || player.HeroClassDefinition.HeroClass == HeroClass.Necromancer)
                {
                    uint paragonstatpoint = (player.CurrentLevelParagon - 700) * 5;
                    xPos += 100.0f;
                    var text1 = string.Format(player.BattleTagAbovePortrait + "\n(" + player.HeroClassDefinition.HeroClass + ")\n" + "주스텟{0} \n활 력{1}\n리소스{2}", player.Stats.MainStat, player.Stats.Vitality, Math.Truncate(player.Stats.ResourceCurPri));
                    if (player.HeroClassDefinition.HeroClass == HeroClass.Necromancer && IsGuardianAlive && showNecphyCoeLoop && forboss)
                    {
                        if (!phytimerRunning)
                        {
                            if (player.Powers.BuffIsActive(430674, 6))
                            {
                                phyElapsedtimeStarttick = Hud.Game.CurrentGameTick;
                                phytimerRunning = true;
                            }
                        }
                        else
                        {
                            var NecphyCoeLoop = (Hud.Game.CurrentGameTick - phyElapsedtimeStarttick) / 720.0d;
                            text1 += "\n물리 " + Math.Truncate(NecphyCoeLoop) + "번";
                        }
                    }
                    if (player.HeroClassDefinition.HeroClass == HeroClass.Necromancer && IsGuardianAlive && showNecCoeLoop && forboss)
                    {
                        if (!timerRunning)
                        {
                            ElapsedtimeStarttick = Hud.Game.CurrentGameTick;
                            timerRunning = true;
                        }
                        else
                        {
                            var NecCoeLoop = (Hud.Game.CurrentGameTick - ElapsedtimeStarttick) / 720.0d;
                            text1 += " (" + Math.Truncate(NecCoeLoop) +")회동";
                        }
                    }
                    if (player.HeroClassDefinition.HeroClass == HeroClass.Wizard)
                    {

                    }

                    if (warningmessage && paragonstatpoint > 4000 && player.Stats.MainStat < paragonstatpoint)
                    {
                        PlayerInfoDecorator.Paint(layer, player, player.FloorCoordinate, "!!경고 활력세팅!!");
                    }
                    if (player.Powers.BuffIsActive(461650) && paragonstatpoint > 4000 && player.Stats.MainStat < paragonstatpoint)
                    {
                        PlayerInfoDecorator.Paint(layer, player, player.FloorCoordinate, "!!경고 활력세팅!!");
                    }
                    if (player.Stats.MainStat > paragonstatpoint)
                    {
                        var layer1 = mainstatsettingFont.GetTextLayout(text1);
                        mainstatsettingFont.DrawText(layer1, xPos, yPos);
                    }
                    else if (player.Stats.Vitality > paragonstatpoint)
                    {
                        var layer1 = vitalsettingFont.GetTextLayout(text1);
                        vitalsettingFont.DrawText(layer1, xPos, yPos);
                    }
                    else
                    {
                        var layer1 = InfoTextFont.GetTextLayout(text1);
                        InfoTextFont.DrawText(layer1, xPos, yPos);
                    }
                }
            }
        }
    }
}

// 시창 461650




   