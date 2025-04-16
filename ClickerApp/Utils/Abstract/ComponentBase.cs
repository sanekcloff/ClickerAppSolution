using ClickerApp.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Utils.Abstract
{
    public abstract class ComponentBase : IComponent
    {
        protected ComponentBase(ComponentBase component)
        {
            if (component == null)
                Debug.WriteLine($"{GetType().Name} - имеет null значение владельца");
            else
            {
                _owner = component;
                Debug.WriteLine($"{GetType().Name} - имеет владельца {_owner}");
            }

        }
        private IComponent? _owner;
        public IComponent? Owner
        {
            get => _owner;
            set => _owner = value;
        }
    }
}
