using ClickerApp.Entities.Stats;
using ClickerApp.Entities.Stats.Instances;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Base
{
    public class EnemyBase : CharacterBase
    {
        private static readonly string[] NAMES = ["Morennoth", "Seren Creighton", "Gralroch", "Dhehl", "Qouvir", "Blasnas"];
        private static readonly string[] IMAGES = ["\\Images\\enemy1.png", "\\Images\\enemy2.png", "\\Images\\enemy3.png", "\\Images\\enemy4.png"];
        private EnemyBase(StatsComponentBase component) : base(NAMES[new Random().Next(NAMES.Length)], component)
        {
            Debug.WriteLine($"Enemy {Nickname} was spawned!");
            Image = IMAGES[new Random().Next(IMAGES.Length)];
        }
        public string Image { get; set; }
        public static EnemyBase CreateEnemy()
        {
            var level = (lvl:1,maxExp:100);
            var health = (@base:100,perLvl:20);
            var damage = (@base:20,perLvl:5);

            var enemy = new EnemyBase(new StatsComponentBase(level, health,damage));

            return enemy;
        }

    }
}
