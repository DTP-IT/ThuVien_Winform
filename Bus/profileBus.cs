using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
namespace Bus
{
    public class profileBus
    {
        private static profileBus instance;
        public static profileBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new profileBus();
                return instance;
            }
        }
        private profileBus() { }
        
        public void profile(int userName,Label lblUserName)
        {
            lblUserName.Text = profileModel.Instance.profile(userName);
        }
    }
   
}
