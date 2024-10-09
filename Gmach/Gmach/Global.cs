using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmach.MyProjectService;

namespace Gmach
{
    class Global
    {
        public static MyProjectService.ServiceClient proxy = new MyProjectService.ServiceClient();
        public static MyProjectService.MUser CurrentUser = new MyProjectService.MUser();
        public static bool IsBorrower;
        public static bool IsManager;
        public static MyProjectService.MUser LastUser = new MyProjectService.MUser();
        public static int pNUM;
        public static int pSUM;
    }
}
