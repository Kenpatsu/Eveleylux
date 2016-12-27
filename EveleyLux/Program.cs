﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace EveleyLux
{
    class Program
    {
        public static Spell q_, w_, e_, r_;
        public static Menu menu_;
        public static SpellSlot igniteslot_;
        //public static SpellSlot flashslot_; Need to find name
        //public static SpellSlot barrierslot_; need to find name
        public static Orbwalking.Orbwalker orbwalker_;
        static void Main(string[] args)
        {
            if (ObjectManager.Player.BaseSkinName == "Lux")
            {
                Game.PrintChat("EveleyLux Loaded");
                CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
            }
            else
            {
                Game.PrintChat("It's absolutly not a magical girl ! ");
                Game.PrintChat("EveleyLux has not been loaded");
                return;
            }
        }
        private static void Game_OnGameLoad(EventArgs args)
        {
            Game.PrintChat("Let's make them disappear !");
            q_ = new Spell(SpellSlot.Q, 1175f);
            w_ = new Spell(SpellSlot.W, 1075f);
            e_ = new Spell(SpellSlot.E, 1100f);
            r_ = new Spell(SpellSlot.R, 3340f);
            //public void SetSkillshot(float delay, float width, float speed, bool collision, SkillshotType type, Vector3 from = default(Vector3), Vector3 rangeCheckFrom = default(Vector3));
            q_.SetSkillshot(0.25f, 60f, 1150f, false, SkillshotType.SkillshotLine);
            w_.SetSkillshot(0.25f, 110f, 1200f, false, SkillshotType.SkillshotLine);
            e_.SetSkillshot(0.25f, 200f, 950f, false, SkillshotType.SkillshotCircle);
            r_.SetSkillshot(1f, 190f, float.MaxValue, false, SkillshotType.SkillshotLine);
            igniteslot_ = ObjectManager.Player.GetSpellSlot("SummonerDot");
            (menu_ = new Menu("EveleyLux", "Lux", true)).AddToMainMenu();
            orbwalker_ = new Orbwalking.Orbwalker(menu_.AddSubMenu(new Menu("Orbwalker", "Orbwalker")));
            TargetSelector.AddToMenu(menu_.AddSubMenu(new Menu("Target Selector", "Target Selector")));
            var drawing = menu_.AddSubMenu(new Menu("Drawing", "Drawing"));
            drawing.AddItem(new MenuItem("qdr", "Q range").SetValue(true));
            drawing.AddItem(new MenuItem("wdr", "W range").SetValue(false));
            drawing.AddItem(new MenuItem("edr", "E range").SetValue(true));
            drawing.AddItem(new MenuItem("rdr", "R range").SetValue(true));
        }
        private static void OnDraw(EventArgs args)
        {
            
        }
    }
}
