using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Stats
{
    public class LevelComponent
    {
        public LevelComponent(LevelData levelData)
        {
            _levelData = levelData;
        }
        private LevelData _levelData;

        public LevelData LevelData => _levelData;

        public void LvlUp()
        {
            _levelData.IncreeseLevel();
            Console.WriteLine("Level increesed!");
        }
    }
    public struct LevelData
    {
        public LevelData(int level, int maxExp)
        {
            _currentExp = MIN_EXP;
            _level = level;
            _maxExp = maxExp;
        }
        private int _level;
        private int _maxExp;
        private int _currentExp;

        public const int MIN_EXP = 0;

        public bool CanLvlUp => _currentExp >= _maxExp;

        public void IncreeseLevel()
        {
            _level++;
            _currentExp = MIN_EXP;
            _maxExp = (int)(_maxExp * 1.5f);
        }
    }
}
