using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Utils.Interfaces
{
    public interface IComponent
    {
        IComponent? Owner { get; set; }
    }
}
