using Redux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    public class SetProgress : IAction
    {
        public int Progress { get; set; }
    }
}
