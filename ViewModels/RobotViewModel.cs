﻿using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using System.Reflection.Emit;
using MongoDB.Driver;
using Recycle.Services;
namespace Recycle.ViewModels
{
	public class RobotViewModel : BaseViewModel
	{
		#region [ Parameters ]
		public const string PARA_ARM_AXIS_1 = "arm_axis_1";
		public const string PARA_ARM_AXIS_2 = "arm_axis_2";
		public const string PARA_ARM_AXIS_3 = "arm_axis_3";
		public const string PARA_ARM_X = "arm_x";
		public const string PARA_ARM_Y = "arm_y";
		public const string PARA_ARM_Z = "arm_z";
		public const string PARA_CONTROLLER = "controller";
		public const string PARA_CONVEYOR_AXIS_1 = "conveyor_axis_1";
		public const string PARA_CURRENT_SPEED = "current_speed";
		public const string PARA_ENCODER_J1 = "encoder_j1";
		public const string PARA_ENCODER_J2 = "encoder_j2";
		public const string PARA_ENCODER_J3 = "encoder_j3";
		public const string PARA_ENCODER_X = "encoder_x";
		public const string PARA_ENCODER_Y = "encoder_y";
		public const string PARA_ENCODER_Z = "encoder_z";
		public const string PARA_MAX_SPEED = "max_speed";
		public const string PARA_REDUCER_STATUS = "reducer_status";
		public const string PARA_VISION_RECENTLY = "vision_recently";
		public const string PARA_VISION_STATUS = "vision_status";
		public const string PARA_VISION_TOTAL_TIME = "vision_total_time";
		#endregion
		
		public long pickTime1 ;
		private readonly RobotPickMongoServices _robotmongodbServices;
		private readonly RobotLogMongoServices robotLogMongoServices;
		public RobotViewModel()
		{
			ArmParameters = new RobotParameter[]
			{
				Parameters[PARA_REDUCER_STATUS],
				Parameters[PARA_CONTROLLER],
				Parameters[PARA_MAX_SPEED],
				Parameters[PARA_CURRENT_SPEED]
			};
			ConveyorParameters = new RobotParameter[]
			{
				Parameters[PARA_ARM_AXIS_1],
				Parameters[PARA_ARM_AXIS_2],
				Parameters[PARA_ARM_AXIS_3],
				Parameters[PARA_ARM_X],
				Parameters[PARA_ARM_Y],
				Parameters[PARA_ARM_Z],
				Parameters[PARA_CONVEYOR_AXIS_1]
			};
			VisionSysParameters = new RobotParameter[]
			{
				Parameters[PARA_VISION_RECENTLY],
				Parameters[PARA_VISION_STATUS],
				Parameters[PARA_VISION_TOTAL_TIME]
			};
			// for DB demo
			_robotmongodbServices = new RobotPickMongoServices();
			robotLogMongoServices = new RobotLogMongoServices();
			MainViewModel.ConfigClass.gMongoLogDBmodel = robotLogMongoServices;
			MainViewModel.ConfigClass.gMongoPickDBmodel = _robotmongodbServices;

			// TODO: for demo, remove it
			Timer = new DispatcherTimer
			{
				Interval = TimeSpan.FromSeconds(2)
			};
			Timer.Tick += Timer_Tick;
			Timer.Start();
		}

		// TODO: for demo, remove it
		private void Timer_Tick(object sender, EventArgs e)
		{
			Random rand = new Random(Environment.TickCount);
			ComponentStatus randStatus()
			{
				return rand.Next(0, 4) == 3 ? ComponentStatus.ERROR : ComponentStatus.GOOD;
			}
			string randDouble()
			{
				return (rand.NextDouble() * 100 - 50).ToString("0.00");
			}
			
			
			//----------------------------------------------------------------------------------------
			//Api1 : write db for Delta-Robot get what kind of pet bottle now
			// var conf1 = rand.Next(10, 90);
			// _robotmongodbServices.Dumpdata(
			// 	nameof(RobotPickMongoServices.Btype.OTHER),
			// 	nameof(RobotPickMongoServices.Bkind.PET),
			// 	conf1,
			// 	"SinkA",
			// 	ID);
			// Api2 : write db for encounting what kind of error(//RobotArm = 0,VisionSys = 1,ConveySys=2,ControSys=3,) 
			//  robotLogMongoServices.Dumpdata(
			//  	"Hi -->: "+rand.Next(10, 40).ToString(),
			//  	"bad",
			//  	nameof(RobotLogMongoServices.LEkind.VisionSys),
			//  	ID);
			//
			// var timetag = ((DateTimeOffset) DateTime.Now).ToUnixTimeMilliseconds();
			// var MaxSecond = MainViewModel.ConfigClass.MaxValue_Chart;

			SetArmStatus(randStatus());
			SetConveyorStatus(randStatus());
			SetVisionSysStatus(randStatus());

			// 機械手臂/手臂機構 參數
			Parameters[PARA_CONTROLLER].SetComponentStatus(randStatus());
			Parameters[PARA_REDUCER_STATUS].SetComponentStatus(randStatus());
			Parameters[PARA_CURRENT_SPEED].SetParameter(rand.Next(1, 10000), randStatus());
			Parameters[PARA_MAX_SPEED].SetParameter(rand.Next(1, 10000), randStatus());

			// 輸送帶參數
			Parameters[PARA_ARM_AXIS_1].SetParameter(randDouble());
			Parameters[PARA_ARM_AXIS_2].SetParameter(randDouble());
			Parameters[PARA_ARM_AXIS_3].SetParameter(randDouble());
			Parameters[PARA_ARM_X].SetParameter(randDouble());
			Parameters[PARA_ARM_Y].SetParameter(randDouble());
			Parameters[PARA_ARM_Z].SetParameter(randDouble());
			Parameters[PARA_CONVEYOR_AXIS_1].SetParameter($"{rand.Next(1, 100)} cm/s");

			// 視覺系統參數
			Parameters[PARA_VISION_RECENTLY].SetParameter(DateTime.Now.ToString("d"));
			Parameters[PARA_VISION_STATUS].SetComponentStatus(randStatus());
			Parameters[PARA_VISION_TOTAL_TIME].SetParameter(string.Format("{0:dd} days {0:hh} hours", DateTime.Now));

			// 編碼器回授資訊參數
			Parameters[PARA_ENCODER_J1].SetParameter(randDouble());
			Parameters[PARA_ENCODER_J2].SetParameter(randDouble());
			Parameters[PARA_ENCODER_J3].SetParameter(randDouble());
			Parameters[PARA_ENCODER_X].SetParameter(randDouble());
			Parameters[PARA_ENCODER_Y].SetParameter(randDouble());
			Parameters[PARA_ENCODER_Z].SetParameter(randDouble());

			SinkA.SetParameter(
				acc: SinkA.Accumulation + rand.Next(1, 100),
				status: randStatus());
			SinkB.SetParameter(
				acc: SinkB.Accumulation + rand.Next(1, 100),
				status: randStatus());
			SinkC.SetParameter(
				acc: SinkC.Accumulation + rand.Next(1, 100),
				status: randStatus());
			SinkD.SetParameter(
				acc: SinkD.Accumulation + rand.Next(1, 100),
				status: randStatus());
			TimePicks.Add(rand.Next(0, 45));

			SetEncodeFeedback(rand.Next(1, 100), rand.Next(1, 100));
		}

		// Fields
		private readonly DispatcherTimer Timer;

		public readonly Dictionary<string, RobotParameter> Parameters = new Dictionary<string, RobotParameter>
		{
			[PARA_ARM_AXIS_1] = new RobotParameter { Value = "46 cm/s", Subtitle = "Axis 1st" },
			[PARA_ARM_AXIS_2] = new RobotParameter { Value = "0.0", Subtitle = "Axis 2nd" },
			[PARA_ARM_AXIS_3] = new RobotParameter { Value = "0.0", Subtitle = "Axis 3rd" },
			[PARA_ARM_X] = new RobotParameter { Value = "0.0", Subtitle = "x" },
			[PARA_ARM_Y] = new RobotParameter { Value = "0.0", Subtitle = "y" },
			[PARA_ARM_Z] = new RobotParameter { Value = "0.0", Subtitle = "z" },
			[PARA_ENCODER_J1] = new RobotParameter { Value = "0.0", Subtitle = "J1" },
			[PARA_ENCODER_J2] = new RobotParameter { Value = "0.0", Subtitle = "J2" },
			[PARA_ENCODER_J3] = new RobotParameter { Value = "0.0", Subtitle = "J3" },
			[PARA_ENCODER_X] = new RobotParameter { Value = "46 cm/s", Subtitle = "X" },
			[PARA_ENCODER_Y] = new RobotParameter { Value = "0.0", Subtitle = "Y" },
			[PARA_ENCODER_Z] = new RobotParameter { Value = "0.0", Subtitle = "Z" },
			[PARA_CONTROLLER] = new RobotParameter { Value = "Good", Subtitle = new ResourceObject("strComController") },
			[PARA_CONVEYOR_AXIS_1] = new RobotParameter { Value = "46 cm/s", Subtitle = "Axis 1st" },
			[PARA_CURRENT_SPEED] = new RobotParameter { Value = "6800", Subtitle = new ResourceObject("strComCurrentSpeed") },
			[PARA_MAX_SPEED] = new RobotParameter { Value = "6000", Subtitle = new ResourceObject("strComMaxSpeed") },
			[PARA_REDUCER_STATUS] = new RobotParameter { Value = "Good", Subtitle = new ResourceObject("strComReducer") },
			[PARA_VISION_RECENTLY] = new RobotParameter { Value = "2021/01/01", Subtitle = "Recently" },
			[PARA_VISION_STATUS] = new RobotParameter { Value = "Good", Subtitle = new ResourceObject("strNaviStatus") },
			[PARA_VISION_TOTAL_TIME] = new RobotParameter { Value = "7 days 17 hours", Subtitle = "Total Time" },
		};

		private double dHe1;

		private double dHe2;

		private double dHr;

		private double dHre;

		private double acMaxSpeed;

		private double acSpeedRate;

		private double acLineRate;

		private double acP2pAcc;

		private double acP2pDsc;

		private double acLineAcc;

		private double acLineDsc;

		// Properties
		public string ID { get; set; }

		public string Name { get; set; }

		public double ImageWidth { get; set; }

		public double ImageHeight { get; set; }

		public string ImageFilename { get; set; }

		public string EncodeFeedback { get; private set; }

		public double DHe1
		{
			get => dHe1;
			set
			{
				dHe1 = value;
				RaisePropertyChanged(nameof(DHe1));
			}
		}

		public double DHe2
		{
			get => dHe2;
			set
			{
				dHe2 = value;
				RaisePropertyChanged(nameof(DHe2));
			}
		}

		public double DHr
		{
			get => dHr;
			set
			{
				dHr = value;
				RaisePropertyChanged(nameof(DHr));
			}
		}

		public double DHre
		{
			get => dHre;
			set
			{
				dHre = value;
				RaisePropertyChanged(nameof(DHre));
			}
		}

		public Point PointC { get; set; }

		public Point PointM { get; set; }

		public Point PointS { get; set; }

		public Point PointV { get; set; }

		public DateTime StartTime { get; private set; }

		public TimeSpan Duration { get; private set; }

		public ComponentStatus Status
		{
			get
			{
				ComponentStatus status = ArmStatus > ConveyorStatus ? ArmStatus : ConveyorStatus;
				return status > VisionSysStatus ? status : VisionSysStatus;
			}
		}

		public ComponentStatus ArmStatus { get; private set; }

		public ComponentStatus ConveyorStatus { get; private set; }

		public ComponentStatus VisionSysStatus { get; private set; }

		public List<HistogramItemViewModel> Picks { get; private set; } = new List<HistogramItemViewModel>
		{
			new HistogramItemViewModel
			{
				Header = ClassData.P,
				Value = 36000,
				Percent = 0.8
			},
			new HistogramItemViewModel
			{
				Header = ClassData.Color,
				Value = 80000,
				Percent = 1
			},
			new HistogramItemViewModel
			{
				Header = ClassData.Oil,
				Value = 36000,
				Percent = 0.7
			},
			new HistogramItemViewModel
			{
				Header = ClassData.Soy,
				Value = 88888,
				Percent = 0.27
			},
			new HistogramItemViewModel
			{
				Header = ClassData.Tray,
				Value = 55555,
				Percent = 0.50
			},
			new HistogramItemViewModel
			{
				Header = ClassData.Ch,
				Value = 66666,
				Percent = 0.72
			},
			new HistogramItemViewModel
			{
				Header = ClassData.Other,
				Value = 66666,
				Percent = 0.01
			}
		};

		public TimelineChartViewModel TimePicks { get; private set; } = new TimelineChartViewModel();

		public RobotParameter[] ArmParameters { get; private set; }

		public RobotParameter[] VisionSysParameters { get; private set; }

		public RobotParameter[] ConveyorParameters { get; private set; }

		public SinkViewModel SinkA { get; private set; } = new SinkViewModel
		{
			Label = "A Sink"
		};

		public SinkViewModel SinkB { get; private set; } = new SinkViewModel
		{
			Label = "B Sink"
		};

		public SinkViewModel SinkC { get; private set; } = new SinkViewModel
		{
			Label = "C Sink"
		};

		public SinkViewModel SinkD { get; private set; } = new SinkViewModel
		{
			Label = "D Sink"
		};

		public double AcMaxSpeed
		{
			get => acMaxSpeed;
			set
			{
				acMaxSpeed = value;
				RaisePropertyChanged(nameof(AcMaxSpeed));
			}
		}

		public double AcSpeedRate
		{
			get => acSpeedRate;
			set
			{
				acSpeedRate = value;
				RaisePropertyChanged(nameof(AcSpeedRate));
			}
		}

		public double AcLineRate
		{
			get => acLineRate;
			set
			{
				acLineRate = value;
				RaisePropertyChanged(nameof(AcLineRate));
			}
		}

		public double AcP2pAcc
		{
			get => acP2pAcc;
			set
			{
				acP2pAcc = value;
				RaisePropertyChanged(nameof(AcP2pAcc));
			}
		}

		public double AcP2pDsc
		{
			get => acP2pDsc;
			set
			{
				acP2pDsc = value;
				RaisePropertyChanged(nameof(AcP2pDsc));
			}
		}

		public double AcLineAcc
		{
			get => acLineAcc;
			set
			{
				acLineAcc = value;
				RaisePropertyChanged(nameof(AcLineAcc));
			}
		}

		public double AcLineDsc
		{
			get => acLineDsc;
			set
			{
				acLineDsc = value;
				RaisePropertyChanged(nameof(AcLineDsc));
			}
		}

		// Methods
		public void SetStartTime(DateTime dateTime)
		{
			StartTime = dateTime;
			RaisePropertyChanged(nameof(StartTime));
		}

		public void SetDuration(TimeSpan duration)
		{
			Duration = duration;
			RaisePropertyChanged(nameof(Duration));
		}

		public void SetEncodeFeedback(double p1, double p2)
		{
			EncodeFeedback = string.Format("{0} cm/s, {1} m/min", p1, p2);
			RaisePropertyChanged(nameof(EncodeFeedback));
		}

		// 機械手臂/手臂機構狀態
		public void SetArmStatus(ComponentStatus status)
		{
			ArmStatus = status;
			RaisePropertyChanged(nameof(ArmStatus));
			RefreshStatus();
		}

		// 輸送帶狀態
		public void SetConveyorStatus(ComponentStatus status)
		{
			ConveyorStatus = status;
			RaisePropertyChanged(nameof(ConveyorStatus));
			RefreshStatus();
		}

		// 視覺系統狀態
		public void SetVisionSysStatus(ComponentStatus status)
		{
			VisionSysStatus = status;
			RaisePropertyChanged(nameof(VisionSysStatus));
			RefreshStatus();
		}

		public override string ToString() => Name;

		// Private methods
		// Robot 狀態 = Max(手臂, 輸送帶, 視覺系統)
		private void RefreshStatus()
		{
			RaisePropertyChanged(nameof(Status));
			MainViewModel.Instance.RaisePropertyChanged(nameof(MainViewModel.RobotsStatus));
		}
	}

	public enum ComponentStatus : int
	{
		GOOD = 0,
		WARNING = 1,
		ERROR = 2
	}
}
