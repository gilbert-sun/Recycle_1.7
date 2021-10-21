using Recycle.Models;
using Recycle.Libraries;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
//-------------------------------------gilbert start 2021.0905
using Recycle.Services;
using System.Diagnostics;
using System.Text.Json;
//-------------------------------------gilbert end

namespace Recycle.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		public static MainViewModel Instance => App.Current.Resources["mainViewModel"] as MainViewModel;		

		public static Lazy<int[]> ClassPercentsFactory = new Lazy<int[]>(() =>
		{
			List<int> values = new List<int>();
			for (int i = 99; i >= 0; i--)
			{
				values.Add(i);
			}
			return values.ToArray();
		});

		public MainViewModel()
		{
			Initialize();
			SelectedRobot = Robots.FirstOrDefault();
			load_defaultSetting();
		}

		private string picksUnit = TimeUnit.MINUTE;

		public string CurrentLanguage { get; private set; }

		public void ChangeLanguage(string language)
		{
			if (CurrentLanguage == language ||
				!App.ChangeCulture(language))
			{
				return;
			}
			CurrentLanguage = language;
			RaisePropertyChanged(nameof(CurrentLanguage));
		}

		// Privilege
		public Role Role { get; private set; } = Role.OPERATOR;

		public bool IsAdmin => Role == Role.ADMINISTRATOR;

		public bool CanAdjust => IsAdmin;// && !IsRunning;

		public void SetRole(Role role)
		{
			Role = role;
			RaisePropertyChanged("IsAdmin");
			RaisePropertyChanged("CanAdjust");
		}

		// Robots
		private readonly Dictionary<string, RobotViewModel> robotsSrc = new Dictionary<string, RobotViewModel>();

		private RobotViewModel selectedRobot;

		public bool IsRunning { get; private set; }

		public ObservableCollection<RobotViewModel> Robots { get; private set; } = new ObservableCollection<RobotViewModel>();

		public RobotViewModel SelectedRobot
		{
			get => selectedRobot;
			set
			{
				selectedRobot = value;
				RaisePropertyChanged(nameof(SelectedRobot));
			}
		}

		public IEnumerable<RobotViewModel> RobotsStatus => Robots.Where(i => i.Status != ComponentStatus.GOOD);

		public string PicksUnit
		{
			get => picksUnit;
			set
			{
				if (picksUnit != value)
				{
					picksUnit = value;
					RaisePropertyChanged(nameof(PicksUnit));

					// TODO: 第1頁 變更單位
				}
			}
		}

		public void Start()
		{
			IsRunning = true;
			RaisePropertyChanged(nameof(CanAdjust));
		}

		public RobotViewModel GetRobot(string robotID)
		{
			robotsSrc.TryGetValue(robotID, out RobotViewModel value);
			return value;
		}

		private void Initialize()
		{
			var dir = Properties.Settings.Default.RobotDir;
			var root = new DirectoryInfo(dir);
			if (!root.Exists)
			{
				Console.WriteLine("!root.Exists");
				return;
			}
			foreach (var dirInfo in root.GetDirectories())
			{
				if (dirInfo.GetFiles("index.ini").FirstOrDefault() is FileInfo fileInfo)
				{
					
					CreateRobotViewModel(fileInfo);
					if (Robots.Count >= 4)
					{
						return;
					}
				}
			}
		}

		private void CreateRobotViewModel(FileInfo fileInfo)
		{
			Dictionary<string, string> data = new Dictionary<string, string>
			{
				{ "id", null },
				{ "name", null },
				{ "image", null },
				{ "width", null },
				{ "height", null },
				{ "point_c", null },
				{ "point_m", null },
				{ "point_s", null },
				{ "point_v", null }
			};
			data.ReadFromINI("Main", fileInfo.FullName);

			if (string.IsNullOrEmpty(data["id"]) ||
				string.IsNullOrEmpty(data["name"]) ||
				Robots.Any(i => i.ID == data["id"]))
			{
				return;
			}
			var robot = new RobotViewModel			
			{
				ID = data["id"],
				Name = data["name"],
				ImageFilename = Path.Combine(fileInfo.DirectoryName, data["image"])
			};
			if (double.TryParse(data["width"], out double width))
			{
				robot.ImageWidth = width;
			}
			if (double.TryParse(data["height"], out double height))
			{
				robot.ImageHeight = height;
			}
			#region points
			try
			{
				robot.PointC = Point.Parse(data["point_c"]);
				robot.PointM = Point.Parse(data["point_m"]);
				robot.PointS = Point.Parse(data["point_s"]);
				robot.PointV = Point.Parse(data["point_v"]);
			}
			catch { }
			#endregion

			robotsSrc.Add(robot.ID, robot);
			Robots.Add(robot);
		}
		//-------------------------------------gilbert start 2021.0905
		public  static ClassData getSinkData(string st)
		{
			var val = new ClassData();
			switch (st)
			{
				case "P":
					val = ClassData.P;
					break;
				case "CH":
					val = ClassData.Ch;
					break;
				case "SOY":
					val = ClassData.Soy;
					break;
				case "OIL":
					val = ClassData.Oil;
					break;
				case "OTHER":
					val = ClassData.Other;
					break;
				case "COLOR":
					val = ClassData.Color;
					break;
				case "TRAY":
					val = ClassData.Tray;
					break;
			}
			return val;
		}
		//-------------------------------------gilbert end 2021.0905
		// Classes
		private ClassData selectedClassA = getSinkData(ConfigClass.sinkA);

		private ClassData selectedClassB = getSinkData(ConfigClass.sinkB);

		private ClassData selectedClassC = getSinkData(ConfigClass.sinkC);

		private ClassData selectedClassD = getSinkData(ConfigClass.sinkD);//ClassData.P;

		// private static int selectedPercentA = (ConfigClass.sinkValA);

		// TODO: 第1/2頁 global value選單
		//-------------------------------------------------------------------------------gilbert start 2021.09.05
		public class SinkConfigSetting
		{
			public DateTime  _Date { get; set; }
			public string _RobotID { get; set; }
			
			public string SinkA_class { get; set; }
			public int SinkA_conf { get; set; }
			public string SinkB_class { get; set; }
			public int SinkB_conf { get; set; }
			public string SinkC_class { get; set; }
			public int SinkC_conf { get; set; }
			public string SinkD_class { get; set; }
			public int SinkD_conf { get; set; }
		}
		
		public static class ConfigClass
		{
            //public static string sinkA { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("C:/Users/e300/PetSinkSetting1.json")).SinkA_class;//"P";//other
            //public static string sinkB { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("C:/Users/e300/PetSinkSetting1.json")).SinkB_class;//"P";//oil
            //public static string sinkC { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("C:/Users/e300/PetSinkSetting1.json")).SinkC_class;//"C Sink";//"P";//P
            //public static string sinkD { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("C:/Users/e300/PetSinkSetting1.json")).SinkD_class;//"D Sink";//"P";//soy
            //public static int sinkValA { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("C:/Users/e300/PetSinkSetting1.json")).SinkA_conf;
            //public static int sinkValB { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("C:/Users/e300/PetSinkSetting1.json")).SinkB_conf; 
            //public static int sinkValC { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("C:/Users/e300/PetSinkSetting1.json")).SinkC_conf; 		
            //public static int sinkValD { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("C:/Users/e300/PetSinkSetting1.json")).SinkD_conf;


            

            public static string sinkA { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("PetSinkSetting1.json")).SinkA_class;//"P";//other
            public static string sinkB { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("PetSinkSetting1.json")).SinkB_class;//"P";//oil
            public static string sinkC { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("PetSinkSetting1.json")).SinkC_class;//"C Sink";//"P";//P
            public static string sinkD { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("PetSinkSetting1.json")).SinkD_class;//"D Sink";//"P";//soy
            public static int sinkValA { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("PetSinkSetting1.json")).SinkA_conf;
            public static int sinkValB { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("PetSinkSetting1.json")).SinkB_conf;
            public static int sinkValC { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("PetSinkSetting1.json")).SinkC_conf;
            public static int sinkValD { get; set; } = JsonSerializer.Deserialize<SinkConfigSetting>(File.ReadAllText("PetSinkSetting1.json")).SinkD_conf;

            public static double MaxValue_Chart { get; set; } = 15 ;
			
			public static RobotLogMongoServices gMongoLogDBmodel { get; set; }
			
			public static RobotPickMongoServices gMongoPickDBmodel { get; set; }

			public static SinkConfigSetting sinkSaving { get; set; } = new SinkConfigSetting
			{
				_RobotID = "robot000001",
				SinkD_class = "OIL",
				SinkD_conf = 50,
				SinkC_class = "SOY",
				SinkC_conf = 50,
				SinkB_class = "COLOR",
				SinkB_conf = 50,
				SinkA_class = "OTHER",
				SinkA_conf = 50,
			};

		}

		public void load_defaultSetting()
		{
			try
			{
				
				//var tmpBuf = File.ReadAllText("C:/Users/e300/PetSinkSetting1.json");
                var tmpBuf = File.ReadAllText("PetSinkSetting1.json");
                ConfigClass.sinkSaving.SinkA_class = JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkA_class;
				ConfigClass.sinkSaving.SinkA_conf = JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkA_conf;
				ConfigClass.sinkSaving.SinkB_class = JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkB_class;
				ConfigClass.sinkSaving.SinkB_conf = JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkB_conf;
				ConfigClass.sinkSaving.SinkC_class = JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkC_class;
				ConfigClass.sinkSaving.SinkC_conf = JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkC_conf;
				ConfigClass.sinkSaving.SinkD_class = JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkD_class;
				ConfigClass.sinkSaving.SinkD_conf = JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkD_conf;
				// Console.WriteLine("--------------------------------------------Read OldFile----------------------------------------------------------");
				// Console.WriteLine(JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkA_conf);
				// Console.WriteLine(JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkB_conf);
				// Console.WriteLine(JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkC_conf);
				// Console.WriteLine(JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkD_conf);
			}
			catch
			{
				// Console.WriteLine("--------------------------------------------Err & Open NewFile----------------------------------------------------------");
				//File.WriteAllText("C:/Users/e300/PetSinkSetting1.json",JsonSerializer.Serialize(ConfigClass.sinkSaving));
                File.WriteAllText("PetSinkSetting1.json", JsonSerializer.Serialize(ConfigClass.sinkSaving));

                // Console.WriteLine("--------------------------------------------Read NewFile----------------------------------------------------------");
                //var tmpBuf = File.ReadAllText("C:/Users/e300/PetSinkSetting1.json");
                var tmpBuf = File.ReadAllText("PetSinkSetting1.json");
                // Console.WriteLine(JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkA_conf);
                // Console.WriteLine(JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkB_conf);
                // Console.WriteLine(JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkC_conf);
                // Console.WriteLine(JsonSerializer.Deserialize<SinkConfigSetting>(tmpBuf).SinkD_conf);
            }
		}

		public static void write_settingconfig(int SinkA_conf,string SinkA_class,int SinkB_conf,string SinkB_class,int SinkC_conf,string SinkC_class,int SinkD_conf,string SinkD_class )
		{
			var sink1 = new SinkConfigSetting();
			sink1._RobotID = "robot000001";
			sink1.SinkA_class = SinkA_class;
			sink1.SinkA_conf = SinkA_conf;
			sink1.SinkB_class = SinkB_class;
			sink1.SinkB_conf = SinkB_conf;
			sink1.SinkC_class = SinkC_class;
			sink1.SinkC_conf = SinkC_conf;
			sink1.SinkD_class = SinkD_class;
			sink1.SinkD_conf = SinkD_conf;
			sink1._Date = DateTime.Now;
            //File.WriteAllText("C:/Users/e300/PetSinkSetting1.json",JsonSerializer.Serialize(sink1));
            File.WriteAllText("PetSinkSetting1.json", JsonSerializer.Serialize(sink1));
        }
		//-------------------------------------------------------------------------------gilbert end 2021.09.
		public ClassData SelectedClassA
		{
			get => selectedClassA;
			set
			{
				if (selectedClassA.Type != value.Type)
				{
					selectedClassA = value;
					RaisePropertyChanged(nameof(SelectedClassA));
					//-------------------------------------------------------------------------------gilbert 2021.08.05
					// TODO: 第2頁 下拉選單
					ConfigClass.sinkA =value.Type.ToString() ;
					write_settingconfig(ConfigClass.sinkValA, ConfigClass.sinkA, ConfigClass.sinkValB,
						ConfigClass.sinkB, ConfigClass.sinkValC, ConfigClass.sinkC, ConfigClass.sinkValD,
						ConfigClass.sinkD);
					//-------------------------------------------------------------------------------gilbert 2021.08.05
				}
			}
		}

		public ClassData SelectedClassB
		{
			get => selectedClassB;
			set
			{
				if (selectedClassB.Type != value.Type)
				{
					selectedClassB = value;
					RaisePropertyChanged(nameof(SelectedClassB));
					//-------------------------------------------------------------------------------gilbert 2021.08.05
					// TODO: 第2頁 下拉選單
					ConfigClass.sinkB = value.Type.ToString() ;
					write_settingconfig(ConfigClass.sinkValA, ConfigClass.sinkA, ConfigClass.sinkValB,
						ConfigClass.sinkB, ConfigClass.sinkValC, ConfigClass.sinkC, ConfigClass.sinkValD,
						ConfigClass.sinkD);
				}
			}
		}

		public ClassData SelectedClassC
		{
			get => selectedClassC;
			set
			{
				if (selectedClassC.Type != value.Type)
				{
					selectedClassC = value;
					RaisePropertyChanged(nameof(SelectedClassC));
					//-------------------------------------------------------------------------------gilbert 2021.08.05
					// TODO: 第2頁 下拉選單
					ConfigClass.sinkC = value.Type.ToString() ;
					write_settingconfig(ConfigClass.sinkValA, ConfigClass.sinkA, ConfigClass.sinkValB,
						ConfigClass.sinkB, ConfigClass.sinkValC, ConfigClass.sinkC, ConfigClass.sinkValD,
						ConfigClass.sinkD);
					//-------------------------------------------------------------------------------gilbert 2021.08.05
				}
			}
		}

		public ClassData SelectedClassD
		{
			get => selectedClassD;
			set
			{
				if (selectedClassD.Type != value.Type)
				{
					selectedClassD = value;
					RaisePropertyChanged(nameof(SelectedClassD));
					//-------------------------------------------------------------------------------gilbert 2021.08.05
					// TODO: 第2頁 下拉選單
					ConfigClass.sinkD = value.Type.ToString() ;
					write_settingconfig(ConfigClass.sinkValA, ConfigClass.sinkA, ConfigClass.sinkValB,
						ConfigClass.sinkB, ConfigClass.sinkValC, ConfigClass.sinkC, ConfigClass.sinkValD,
						ConfigClass.sinkD);
					//-------------------------------------------------------------------------------gilbert 2021.08.05
				}
			}
		}

		private int selectedPercentA = ConfigClass.sinkValA;

		private int selectedPercentB = ConfigClass.sinkValB;

		private int selectedPercentC = ConfigClass.sinkValC;

		private int selectedPercentD = ConfigClass.sinkValD;

		public int SelectedPercentA
		{
			get => selectedPercentA;//ConfigClass.sinkValA ;
			set  
			{
			
					selectedPercentA = value;
					//-------------------------------------------------------------------------------gilbert 2021.08.05
					// TODO: 第2頁 下拉選單
					
					RaisePropertyChanged(nameof(selectedPercentA));
					ConfigClass.sinkValA = selectedPercentA ;
					write_settingconfig(ConfigClass.sinkValA, ConfigClass.sinkA, ConfigClass.sinkValB,
						ConfigClass.sinkB, ConfigClass.sinkValC, ConfigClass.sinkC, ConfigClass.sinkValD,
						ConfigClass.sinkD);

					//-------------------------------------------------------------------------------gilbert 2021.08.05
			} 
			// => selectedPercentA = value;
		}

		public int SelectedPercentB
		{
			get => selectedPercentB;//ConfigClass.sinkValB;
			set  
			{
			
				selectedPercentB = value;
				//-------------------------------------------------------------------------------gilbert 2021.08.05
				// TODO: 第2頁 下拉選單
					
				RaisePropertyChanged(nameof(selectedPercentB));
				ConfigClass.sinkValB = selectedPercentB ;
				write_settingconfig(ConfigClass.sinkValA, ConfigClass.sinkA, ConfigClass.sinkValB,
					ConfigClass.sinkB, ConfigClass.sinkValC, ConfigClass.sinkC, ConfigClass.sinkValD,
					ConfigClass.sinkD);
				//-------------------------------------------------------------------------------gilbert 2021.08.05
			} 
			// set => selectedPercentB = value;
		}

		public int SelectedPercentC
		{
			get => selectedPercentC;//ConfigClass.sinkValC;
			
			//-------------------------------------------------------------------------------gilbert 2021.08.05
			set  
			{
				selectedPercentC = value;
				// TODO: 第2頁 下拉選單
				RaisePropertyChanged(nameof(selectedPercentC));
				ConfigClass.sinkValC = selectedPercentC ;
				write_settingconfig(ConfigClass.sinkValA, ConfigClass.sinkA, ConfigClass.sinkValB,
					ConfigClass.sinkB, ConfigClass.sinkValC, ConfigClass.sinkC, ConfigClass.sinkValD,
					ConfigClass.sinkD);
			} 
			//-------------------------------------------------------------------------------gilbert 2021.08.05
			// set => selectedPercentC = value;
		}

		public int SelectedPercentD
		{
			get => selectedPercentD;//ConfigClass.sinkValD;
			
			//-------------------------------------------------------------------------------gilbert 2021.08.05
			set  
			{
				selectedPercentD = value;
				// TODO: 第2頁 下拉選單
				RaisePropertyChanged(nameof(selectedPercentD));
				ConfigClass.sinkValD = selectedPercentD ;
				write_settingconfig(ConfigClass.sinkValA, ConfigClass.sinkA, ConfigClass.sinkValB,
					ConfigClass.sinkB, ConfigClass.sinkValC, ConfigClass.sinkC, ConfigClass.sinkValD,
					ConfigClass.sinkD);
			} 
			//-------------------------------------------------------------------------------gilbert 2021.08.05
			// set => selectedPercentC = value;
		}

		public ClassData[] ClassDatas { get; private set; } = new[]
		{
			ClassData.P,
			ClassData.Color,
			ClassData.Oil,
			ClassData.Soy,
			ClassData.Ch,
			ClassData.Tray,
			ClassData.Other,
			ClassData.None
		};

		public int[] ClassPercents => ClassPercentsFactory.Value;

		// Page
		public PageViewModel CurrentContent { get; private set; }

		public void SelectPage(PageIndex value)
		{
			switch (value)
			{
				case PageIndex.HOME:
					CurrentContent = new HomePageViewModel(Robots);
					break;
				case PageIndex.TASK:
					CurrentContent = new TaskPageViewModel();
					break;
				case PageIndex.STATUS:
					CurrentContent = new StatusPageViewModel();
					break;
				case PageIndex.ADJUST:
					CurrentContent = new AdjustPageViewModel();
					break;
				case PageIndex.LOG:
					CurrentContent = new LogPageViewModel();
					break;
				default:
					CurrentContent = null;
					break;
			}
			RaisePropertyChanged("CurrentContent");
		}


		public void setConfidence()
        {

        }


		public delegate void DelegateClick(object sender, RoutedEventArgs e);

        public DelegateClick delegateClickHome;
        public DelegateClick delegateClickDemo;        
        public DelegateClick delegateClickCircle2D;
        public DelegateClick delegateClickArc;
        public DelegateClick delegateClickRect;
        public DelegateClick delegateClickMoveU;

        public DelegateClick delegateClickXp;
        public DelegateClick delegateClickXn;
        public DelegateClick delegateClickYp;
        public DelegateClick delegateClickYn;
        public DelegateClick delegateClickZp;
        public DelegateClick delegateClickZn;

        public DelegateClick delegateClickCameraPauseResume;
		public DelegateClick delegateClickAbort;
		public DelegateClick delegateClickServoOn;
		public DelegateClick delegateClickServoOff;
		public DelegateClick delegateClickCleanError;

		public DelegateClick delegateClickApplyConfidence;
	}
}
