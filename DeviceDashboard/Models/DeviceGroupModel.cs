using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDashboard.Models
{
    public class DeviceGroupModel
    {
        public string Image { get; set; }
        public List<DeviceItemModel> DeviceList { get; set; }
    }
}
