using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Class
{
    public class AddWorkerID
    {
        public static int workerID;
        public static void Worker(int WorkID)
        {
            workerID = WorkID;
            return;
        }
    }
}
