
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    public class AppState
    {
        public int Val { get; set; }
        public int Progress { get; set; }
        public bool IsLoading { get; set; }
        public int Result { get; set; }

    }
}
