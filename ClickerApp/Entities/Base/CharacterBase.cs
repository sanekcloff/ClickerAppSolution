using ClickerApp.Entities.Stats.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Base
{
    public abstract class CharacterBase
    {
        protected CharacterBase(string nickname, StatsComponentBase component)
        {
            _component = component;
            _nickname = nickname;
        }
        private string _nickname;
        private StatsComponentBase _component;

        public string Nickname => _nickname;
        public StatsComponentBase Component => _component;
    }
}
