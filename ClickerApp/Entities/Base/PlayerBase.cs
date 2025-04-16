using ClickerApp.Entities.Stats.Instances;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Base
{
    public class PlayerBase : CharacterBase
    {

        public PlayerBase(string nickname, StatsComponentBase component, uint potions) : base(nickname, component)
        {
            _healthPotions = potions;
            Debug.WriteLine($"Player {Nickname} was spawned!");
        }

        private uint _healthPotions;
        public uint HealthPotions { get => _healthPotions; set => _healthPotions = value; }

    }
}
