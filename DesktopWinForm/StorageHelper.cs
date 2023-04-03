using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopWinForm
{

    public class StorageHelper
    {
        private static StorageHelper _Instance;

        private StorageHelper()
        {
        }

        public static StorageHelper Instance
        {
            get
            {
                if (null == _Instance)
                {
                    _Instance = new StorageHelper();
                }
                return _Instance;
            }
        }

        public string Account;
        public LoginForm LoginForm;
        public MainForm MainForm;
    }
}
