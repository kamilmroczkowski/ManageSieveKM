using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSieveKM
{
    public class SieveScript
    {
        private string _name, _script;
        private bool _active = false;

        public SieveScript(string name, string script, bool active = false)
        {
            _name = name;
            _script = script;
            _active = active;
        }

        public string Name { get => _name; set => _name = value; }
        public string Script { get => _script; set => _script = value; }
        public bool Active { get => _active; set => _active = value; }
    }
}
