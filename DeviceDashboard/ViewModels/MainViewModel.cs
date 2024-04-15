using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeviceDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDashboard.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        //基本信息池
        public List<DeviceGroupModel> DeviceGroup { get; set; }


        public List<AlarmItemModel> AlarmList { get; set; }

        private List<DeviceItemModel> _deviceList;

        public List<DeviceItemModel> DeviceList
        {
            get { return _deviceList; }
            set { SetProperty(ref _deviceList, value); }
        }





        private string _currentImage;

        public string CurrentImage
        {
            get { return _currentImage; }
            set { SetProperty(ref _currentImage, value); }
        }

        public RelayCommand<object> NavCommand { get; set; }
        public MainViewModel()
        {
            DeviceGroup = new List<DeviceGroupModel>();
            for (int i = 0; i < 5; i++)
            {
                //有多少台设备组
                DeviceGroup.Add(new DeviceGroupModel()
                {
                    //Image = $"/DeviceDashboard;components/Assets/Images/Devices/d_{i + 1}.png",
                    Image = $"../Assets/Images/Devices/d_{i + 1}.png",
                    //里面对应多少台设备
                    DeviceList = new List<DeviceItemModel>()
                {
                    new DeviceItemModel()
                    {
                        Index=(i+1)*10+1,
                        IsWarning=false,
                        //每台设备有多少个变量
                        VarableList=new List<VariableModel>()
                        {
                            new VariableModel()
                            {
                                Name="工作模式-1",
                                Value="AUTO"
                            },

                             new VariableModel()
                            {
                                Name="进给倍率",
                                Value="0"
                            }
                             ,
                              new VariableModel()
                            {
                                Name="主轴转速",
                                Value="0",
                                Unit="r/min"
                            },
                               new VariableModel()
                            {
                                Name="机床坐标X",
                                Value="-500.000",
                                Unit="mm"

                            },
                                new VariableModel()
                            {
                                Name="机床坐标Y",
                                Value="-122.002",
                                Unit="mm"
                            }
                        }
                    },
                    new DeviceItemModel()
                    {
                        Index=(i+1)*10+2,
                        IsWarning=true,
                        //每台设备有多少个变量
                        VarableList=new List<VariableModel>()
                        {
                            new VariableModel()
                            {
                                Name="工作模式-2",
                                Value="AUTO"
                            },

                             new VariableModel()
                            {
                                Name="进给倍率",
                                Value="0"
                            }
                             ,
                              new VariableModel()
                            {
                                Name="主轴转速",
                                Value="0",
                                Unit="r/min"
                            },
                               new VariableModel()
                            {
                                Name="机床坐标X",
                                Value="-500.000",
                                Unit="mm"

                            },
                                new VariableModel()
                            {
                                Name="机床坐标Y",
                                Value="-122.002",
                                Unit="mm"
                            }
                        }
                    },
                    new DeviceItemModel()
                    {
                        Index=(i+1)*10+3,
                        IsWarning=false,
                        //每台设备有多少个变量
                        VarableList=new List<VariableModel>()
                        {
                            new VariableModel()
                            {
                                Name="工作模式-3",
                                Value="AUTO"
                            },

                             new VariableModel()
                            {
                                Name="进给倍率",
                                Value="0"
                            }
                             ,
                              new VariableModel()
                            {
                                Name="主轴转速",
                                Value="0",
                                Unit="r/min"
                            },
                               new VariableModel()
                            {
                                Name="机床坐标X",
                                Value="-500.000",
                                Unit="mm"

                            },
                                new VariableModel()
                            {
                                Name="机床坐标Y",
                                Value="-122.002",
                                Unit="mm"
                            }
                        }
                    },
                    new DeviceItemModel()
                    {
                       Index=(i+1)*10+4,
                        IsWarning=false,
                        //每台设备有多少个变量
                        VarableList=new List<VariableModel>()
                        {
                            new VariableModel()
                            {
                                Name="工作模式-4",
                                Value="AUTO"
                            },

                             new VariableModel()
                            {
                                Name="进给倍率",
                                Value="0"
                            }
                             ,
                              new VariableModel()
                            {
                                Name="主轴转速",
                                Value="0",
                                Unit="r/min"
                            },
                               new VariableModel()
                            {
                                Name="机床坐标X",
                                Value="-500.000",
                                Unit="mm"

                            },
                                new VariableModel()
                            {
                                Name="机床坐标Y",
                                Value="-122.002",
                                Unit="mm"
                            }
                        }
                    },
                }
                });
            }


            AlarmList = new List<AlarmItemModel>();

            for (int i = 0; i < 15; i++)
            {
                AlarmList.Add(new AlarmItemModel()
                {
                    Index = i + 1,
                    Time = DateTime.Now,
                    Message = $"Message_{i + 1}",
                    Status = $"{i + 1}",
                });
            }

            NavCommand = new RelayCommand<object>(OnNav);
            OnNav("0");
            StartMonitor();
        }
        private void OnNav(object arg)
        {
            var group = DeviceGroup[int.Parse(arg.ToString())];
            CurrentImage = group.Image;
            DeviceList = group.DeviceList;
        }

        /// <summary>
        /// 监听设备信息
        /// </summary>
        private void StartMonitor()
        {

        }
    }
}
