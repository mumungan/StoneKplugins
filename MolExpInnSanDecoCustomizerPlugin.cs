using System;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Stone
{
    public class MolExpInnSanDecoCustomizerPlugin : BasePlugin, ICustomizer
    {
        public MolExpInnSanDecoCustomizerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void Customize()
        {
		    Hud.TogglePlugin<ParagonCapturePlugin>(false);

			Hud.GetPlugin<EliteMonsterSkillPlugin>().
			    MoltenExplosionDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 0, 1),
                    Radius = 13f,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 3,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 255, 255, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 3,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(200, 255, 32, 32, 0),
                    Radius = 30,
                });

    		Hud.GetPlugin<PlayerSkillPlugin>().
            InnerSanctuaryDefaultDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 0, 8),
                    Radius = 11,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(100, 255, 30, 30, 0),
                    Radius = 35,
                }
            );

			Hud.GetPlugin<PlayerSkillPlugin>().
            InnerSanctuarySanctifiedGroundDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 0, 8),
                    Radius = 11,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 8,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 8,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(100, 255, 30, 30, 0),
                    Radius = 35,
                }
            );

			Hud.GetPlugin<PlayerSkillPlugin>().
            InnerSanctuaryTempleOfProtecteionDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 0, 8),
                    Radius = 11,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(100, 255, 204, 0, 0),
                    Radius = 35,
                }
            );

			 Hud.GetPlugin<PlayerSkillPlugin>().
            InnerSanctuarySafeHavenDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 0, 8),
                    Radius = 11,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(100, 255, 26, 179, 0),
                    Radius = 35,
                }
            );  
         }
	}
}