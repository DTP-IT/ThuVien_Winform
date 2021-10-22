using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
namespace Bus
{ 
    public class homeBus
    {
        private static homeBus instance;
        public static homeBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new homeBus();
                return instance;
            }
        }
        private homeBus() { }

    }
}
