using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDashboard.Models
{
    public class DeviceItemModel
    {
        public int Index { get; set; }
        public bool IsWarning { get; set; }
        public List<VariableModel> VarableList { get; set; }
    }
}
