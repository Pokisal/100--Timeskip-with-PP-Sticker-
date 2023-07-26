using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DR_RTM
{

    public class Form1 : Form
    {
        private delegate void TimeDisplayUpdateCallback(string text);

        KeyboardHook keyboardHook = new KeyboardHook();

        public Button button1;

        public Label label1;

        public Label label2;

        public static List<string> AllowedHotkeys = new() { "LBUTTON", "RBUTTON", "CANCEL_KEY", "MBUTTON", "XBUTTON1", "XBUTTON2", "KEY_BACK", "TAB_KEY", "CLEAR", "RETURN_KEY", "SHIFT", "CONTROL", "MENU", "PAUSE", "CAPITAL", "KANA", "HANGUL", "JUNJA", "FINAL", "HANJA", "KANJI", "ESCAPE", "CONVERT", "NONCONVERT", "ACCEPT", "MODECHANGE", "SPACE_KEY", "PRIOR", "NEXT_KEY", "END_KEY", "HOME", "LEFT_KEY", "UP", "RIGHT_KEY", "DOWN", "SELECT_KEY", "PRINT_KEY", "EXECUTE", "SNAPSHOT", "INSERT", "DELETE", "HELP", "KEY_0", "KEY_1", "KEY_2", "KEY_3", "KEY_4", "KEY_5", "KEY_6", "KEY_7", "KEY_8", "KEY_9", "KEY_A", "KEY_B", "KEY_C", "KEY_D", "KEY_E", "KEY_F", "KEY_G", "KEY_H", "KEY_I", "KEY_J", "KEY_K", "KEY_L", "KEY_M", "KEY_N", "KEY_O", "KEY_P", "KEY_Q", "KEY_R", "KEY_S", "KEY_T", "KEY_U", "KEY_V", "KEY_W", "KEY_X", "KEY_Y", "KEY_Z", "LWIN", "RWIN", "APPS", "SLEEP", "NUMPAD0", "NUMPAD1", "NUMPAD2", "NUMPAD3", "NUMPAD4", "NUMPAD5", "NUMPAD6", "NUMPAD7", "NUMPAD8", "NUMPAD9", "MULTIPLY", "ADD", "SEPARATOR", "SUBTRACT", "DECIMAL_KEY", "DIVIDE", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "NUMLOCK", "SCROLL", "LSHIFT", "RSHIFT", "LCONTROL", "RCONTROL", "LMENU", "RMENU", "BROWSER_BACK", "BROWSER_FORWARD", "BROWSER_REFRESH", "BROWSER_STOP", "BROWSER_SEARCH", "BROWSER_FAVORITES", "BROWSER_HOME", "VOLUME_MUTE", "VOLUME_DOWN", "VOLUME_UP", "MEDIA_NEXT_TRACK", "MEDIA_PREV_TRACK", "MEDIA_STOP", "MEDIA_PLAY_PAUSE", "LAUNCH_MAIL", "LAUNCH_MEDIA_SELECT", "LAUNCH_APP1", "LAUNCH_APP2", "OEM_1", "OEM_PLUS", "OEM_COMMA", "OEM_MINUS", "OEM_PERIOD", "OEM_2", "OEM_3", "OEM_4", "OEM_5", "OEM_6", "OEM_7", "OEM_8", "OEM_102", "PROCESSKEY", "PACKET", "ATTN", "CRSEL", "EXSEL", "EREOF", "PLAY", "ZOOM", "NONAME", "PA1", "OEM_CLEAR" };

        public static bool PerfectGunner;

        public static bool ActivateTextbox = false;

        public static string CurrentScreen = "PP Collector/Miscellanous";
        public static string NextTracker = "Gourmet/Clothes Horse";

        public static string Hotkey1 = Tracker.Properties.Settings.Default.Hotkey1;
        public static string Hotkey2 = Tracker.Properties.Settings.Default.Hotkey2;

        public static string TextboxText = "";

        public static string ToolTip = "";

        public static int TransmissionCount;

        public static int ClothesHorseCount;

        public static int GourmetCount;

        public static int MarathonCount;

        public static uint ReducedMarathonRunner;

        public static string MarathonRunner;

        public static string MarathonRunner2;

        public static string SecurityBench;

        public static string VentPhoto;

        public static string BirdClock;

        public static string ServbotMask;

        public static string ParadiseCDShopPoster;

        public static string KidsChoiceSign;

        public static string GlassesStoreClock;

        public static string SkateshopHoop;

        public static string ParadiseStaircasePoster;

        public static string ParadiseGreenVase;

        public static string ParadiseRoastmastersSign;

        public static string ParadiseGreenShirt;

        public static string ParadiseTeddyBear;

        public static string TykeNTotsSign;

        public static string TunemakersSign;

        public static string JillsSandwichesSign;

        public static string ColbysSign;

        public static string RatmanPoster;

        public static string MegamanPoster;

        public static string MoviePoster1;

        public static string MoviePoster2;

        public static string MoviePoster3;

        public static string MoviePoster4;

        public static string ColbysFoxPoster1;

        public static string ColbysFoxPoster2;

        public static string ColbysRatman;

        public static string NorthClock;

        public static string SouthClock;

        public static string EastClock;

        public static string TunnelSign;

        public static string Bomb1;

        public static string Bomb2;

        public static string Bomb3;

        public static string Bomb4;

        public static string Bomb5;

        public static string CowPoster;

        public static string ConveyorBelt;

        public static string BookStoreSign;

        public static string WonderlandNorthPlazaEndRedHouse;

        public static string BaseballStorePhoto;

        public static string ScuffsNScrapesShirt;

        public static string WonderlandWindmill;

        public static string WonderlandFoodCourtEndRedHouse;

        public static string WonderlandFoodCourtEndBunny;

        public static string SpaceRiderJoSideRocket;

        public static string WonderlandGreenBalloon;

        public static string SmallFryDudsPoster;

        public static string KokonutzSign;

        public static string SpaceRiderAlien;

        public static string SpaceRiderSign;

        public static string SpaceRiderRocket;

        public static string WonderlandNorthPlazaEndBunny;

        public static string ShieldRack;

        public static string SwordRack;

        public static string SeonsSign;

        public static string GunstoreShotguns;

        public static string GunstoreHunter;

        public static string GunstoreMoose1;

        public static string GunstoreMoose2;

        public static string NorthPlazaCupid;

        public static string CrislipsSign;

        public static string CrislipsLifestyleSign;

        public static string CrislipsGardeningSign;

        public static string PharmacySign;

        public static string Seafood;

        public static string SeonsMeatsSign;

        public static string FoodCourtChrisSign;

        public static string FoodCourtChrisDishes;

        public static string FoodCourtCowboy;

        public static string FoodCourtWillabee;

        public static string FoodCourtBull;

        public static string CentralTacos;

        public static string TheDarkBean;

        public static string MeatyBurger;

        public static string FrozenDream;

        public static string JadeParadise;

        public static string TeresasOven;

        public static string AlFrescaFoodCourtSign;

        public static string FlexinBuffPoster;

        public static string FlexinSign;

        public static string FlexinTreadmill;

        public static string FlexinExerciseBike;

        public static string FlexinWeightMachine;

        public static string FlexinBehindCounterPosters;

        public static string AlFrescaBrandNewUShoes;

        public static string EyesLikeUsPoster;

        public static string AlFrescaRoastmastersSign;

        public static string HamburgerFiefdomPrices;

        public static string FrontDoor;

        public static string CampingTent;

        public static string ChildrensCastleBear;

        public static string RefinedClassDisplay;

        public static string MrWillabeeClock;

        public static string EntranceCDShopPoster;

        public static string EntranceFoxPoster;

        public static string KnickknackeryCrown;

        public static string EntranceGreenVase;

        public static string EntrancePerfumeShopPoster;

        public static string CultistsFoxPoster;

        public static string CultistsTrueEye;

        public Label timeDisplay;

        public Label label4;

        public Label label5;

        public Label label6;

        public Label label7;

        public Label label8;

        public Label label9;

        public Label label10;

        public Label label11;

        public Label label12;

        public Label label13;

        public Label label14;

        public Label label15;

        public Label label16;

        public Label label17;

        public Label label18;

        public Label label19;

        public Label label20;

        public Label label21;

        public Label label22;

        public Label label23;

        public Label label24;

        public Label label25;

        public Label label26;

        public Label label27;

        public Label label28;

        public Label label29;

        public Label label30;

        public Label label31;

        public Label label32;

        public Label label33;

        public Label label34;

        public Label label35;

        public Label label36;

        public Label label37;

        public Label label38;

        public Label label39;

        public Label label40;

        public Label label41;

        public Label label42;

        public Label label43;

        public Label label44;

        public Label label45;

        public Label label46;

        public Label label47;

        public Label label48;

        public Label label49;

        public Label label50;

        public Label label51;

        public Label label52;

        public Label label53;

        public Label label54;

        public Label label55;

        public Label label56;

        public Label label57;

        public Label label58;

        public Label label59;

        public Label label60;

        public Label label61;

        public Label label62;

        public Label label63;

        public Label label64;

        public Label label65;

        public Label label66;

        public Label label67;

        public Label label68;

        public Label label69;

        public Label label70;

        public Label label71;

        public Label label72;

        public Label label73;

        public Label label74;

        public Label label76;

        public Label label77;

        public Label label78;

        public Label label79;

        public Label label80;

        public Label label81;

        public Label label82;

        public Label label83;

        public Label label85;

        public Label label86;

        public Label label87;

        public Label label88;

        public Label label89;

        public Label label90;

        public Label label91;

        public Label label92;

        public Label label93;

        public Label label94;

        public Label label95;

        public Label label96;

        public Label label97;

        public Label label98;

        public Label label100;

        public Label label101;

        public Label label102;

        public Label label103;

        public Label label104;

        public Label label105;

        public Label label106;

        public Label label107;

        public Label label108;

        public Label label109;

        public Label label110;

        public Label label111;

        public Label label112;

        public Label label113;

        public Label label114;

        public Label label115;

        public Label label116;

        public Label label117;

        public Label label118;

        public Label label119;

        public Label label75;

        public Label label84;

        private Label label99;

        private Label label120;

        private Label label121;

        private Label label122;

        private Label label123;

        private Label label124;

        private Label label125;

        private Label label126;

        private Label label127;

        private CheckBox checkBox1;

        private Label label128;

        private Label label129;

        private Label label130;
        private Label label131;
        private Label label132;
        private CheckBox checkBox2;
        private Label label133;
        private Label label134;
        private Label label135;
        private Label label136;
        private Label label137;
        private Label label138;
        private Label label139;
        private Label label140;
        private Label label141;
        private Label label142;
        private Label label143;
        private Label label144;
        private Label label145;
        private Label label146;
        private Label label147;
        private Label label148;
        private Label label149;
        private Label label150;
        private Label label151;
        private Label label152;
        private Label label153;
        private Label label154;
        private Label label155;
        private Label label156;
        private Label label157;
        private Label label158;
        private Label label159;
        private Label label160;
        private Label label161;
        private Label label162;
        private Label label163;
        private Label label164;
        private Label label165;
        private Label label166;
        private Label label167;
        private Label label168;
        private Label label169;
        private Label label170;
        private Label label171;
        private Label label172;
        private Label label173;
        private ToolTip toolTip1;
        private System.ComponentModel.IContainer components;
        private Label label174;
        private Label label175;
        private Label label176;
        private Label label177;
        private Label label178;
        private Label label179;
        private Label label180;
        private Label label181;
        private Label label182;
        private Label label183;
        private Label label184;
        private Label label185;
        private Label label186;
        private Label label187;
        private Label label188;
        private Label label189;
        private Label label190;
        private Label label191;
        private Label label192;
        private Label label193;
        private Label label194;
        private Label label195;
        private Label label196;
        private Label label197;
        private Label label198;
        private Label label199;
        private Label label200;
        private Label label201;
        private Label label202;
        private Label label203;
        private Label label204;
        private Label label205;
        private Label label206;
        private Label label207;
        private Label label208;
        private Label label209;
        private Label label210;
        private Label label211;
        private Label label212;
        private Label label213;
        private Label label214;
        private Label label215;
        private Label label216;
        private Label label217;
        private Label label218;
        private Label label219;
        private Label label220;
        private Label label221;
        public Label label3;

        public Form1()
        {
            InitializeComponent();
            keyboardHook.Install();
            label133.Text = $"Click to cycle to {NextTracker}";
            toolTip1.OwnerDraw = true;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            for (int i = 135; i < 222; i++)
            {
                string LabelI = $"label{i}";
                Label label = this.Controls[LabelI] as Label;
                label.Visible = false;
            }
            label175.Visible = true;
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private unsafe static extern bool WriteProcessMemory(IntPtr hProcess, uint lpBaseAddress, byte[] lpBuffer, int nSize, void* lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern int CloseHandle(IntPtr hObject);

        public static IntPtr MemoryOpen(int ProcessID)
        {
            return OpenProcess(2035711u, bInheritHandle: false, ProcessID);
        }

        public unsafe void Write(uint mAddress, byte[] Buffer, int ProcessID)
        {
            if (!(MemoryOpen(ProcessID) == (IntPtr)0))
            {
                WriteProcessMemory(MemoryOpen(ProcessID), mAddress, Buffer, Buffer.Length, null);
            }
        }

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(base.Handle, 19, new int[1] { 1 }, 4) != 0)
            {
                DwmSetWindowAttribute(base.Handle, 20, new int[1] { 1 }, 4);
            }
        }

        void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font f = new Font("Arial", 9.0f);
            toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.White, new PointF(2, 2));
        }

        public void TimeDisplayUpdate(string text)
        {
            if (timeDisplay.InvokeRequired)
            {
                TimeDisplayUpdateCallback method = TimeDisplayUpdate;
                try
                {
                    Invoke(method, text);
                    return;
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
            }
            TimeSkip.UpdatePPStickers();
            ReducedMarathonRunner = TimeSkip.MarathonRunner / 100u;
            label175.Text = $"Clothes Horse = {ClothesHorseCount}/46";
            timeDisplay.Text = text;
            label17.Text = SecurityBench;
            label18.Text = VentPhoto;
            label19.Text = CultistsTrueEye;
            label20.Text = CultistsFoxPoster;
            label21.Text = CowPoster;
            label22.Text = ConveyorBelt;
            label23.Text = CrislipsLifestyleSign;
            label24.Text = CrislipsGardeningSign;
            label25.Text = BirdClock;
            label26.Text = ServbotMask;
            label27.Text = KidsChoiceSign;
            label28.Text = ParadiseCDShopPoster;
            label29.Text = GlassesStoreClock;
            label30.Text = SkateshopHoop;
            label31.Text = ParadiseGreenVase;
            label32.Text = ParadiseRoastmastersSign;
            label33.Text = ParadiseTeddyBear;
            label34.Text = ParadiseStaircasePoster;
            label35.Text = ParadiseGreenShirt;
            label36.Text = TykeNTotsSign;
            label37.Text = TunemakersSign;
            label38.Text = JillsSandwichesSign;
            label39.Text = ColbysSign;
            label40.Text = RatmanPoster;
            label41.Text = MegamanPoster;
            label42.Text = MoviePoster1;
            label43.Text = MoviePoster2;
            label44.Text = MoviePoster3;
            label45.Text = MoviePoster4;
            label46.Text = ColbysRatman;
            label47.Text = ColbysFoxPoster1;
            label48.Text = ColbysFoxPoster2;
            label50.Text = NorthClock;
            label51.Text = SouthClock;
            label52.Text = EastClock;
            label53.Text = TunnelSign;
            label55.Text = Bomb1;
            label56.Text = Bomb2;
            label57.Text = Bomb3;
            label58.Text = Bomb4;
            label59.Text = Bomb5;
            label60.Text = BookStoreSign;
            label61.Text = WonderlandNorthPlazaEndRedHouse;
            label62.Text = BaseballStorePhoto;
            label63.Text = ScuffsNScrapesShirt;
            label64.Text = WonderlandWindmill;
            label65.Text = WonderlandFoodCourtEndRedHouse;
            label66.Text = WonderlandFoodCourtEndBunny;
            label67.Text = SpaceRiderJoSideRocket;
            label68.Text = WonderlandGreenBalloon;
            label69.Text = SmallFryDudsPoster;
            label70.Text = KokonutzSign;
            label71.Text = SpaceRiderAlien;
            label72.Text = SpaceRiderSign;
            label73.Text = SpaceRiderRocket;
            label74.Text = WonderlandNorthPlazaEndBunny;
            label76.Text = ShieldRack;
            label77.Text = SwordRack;
            label78.Text = SeonsSign;
            label79.Text = GunstoreShotguns;
            label80.Text = GunstoreHunter;
            label81.Text = GunstoreMoose1;
            label82.Text = GunstoreMoose2;
            label83.Text = CrislipsSign;
            label84.Text = NorthPlazaCupid;
            label85.Text = PharmacySign;
            label86.Text = Seafood;
            label87.Text = SeonsMeatsSign;
            label88.Text = AlFrescaFoodCourtSign;
            label89.Text = FlexinBuffPoster;
            label90.Text = FlexinSign;
            label91.Text = FlexinTreadmill;
            label92.Text = FlexinExerciseBike;
            label93.Text = FlexinWeightMachine;
            label94.Text = FlexinBehindCounterPosters;
            label95.Text = EyesLikeUsPoster;
            label96.Text = AlFrescaBrandNewUShoes;
            label97.Text = AlFrescaRoastmastersSign;
            label98.Text = HamburgerFiefdomPrices;
            label100.Text = FrontDoor;
            label101.Text = CampingTent;
            label102.Text = ChildrensCastleBear;
            label103.Text = RefinedClassDisplay;
            label104.Text = MrWillabeeClock;
            label105.Text = EntranceCDShopPoster;
            label106.Text = EntranceFoxPoster;
            label107.Text = EntranceGreenVase;
            label108.Text = KnickknackeryCrown;
            label109.Text = EntrancePerfumeShopPoster;
            label110.Text = FoodCourtChrisSign;
            label111.Text = FoodCourtChrisDishes;
            label112.Text = FoodCourtWillabee;
            label113.Text = FoodCourtBull;
            label114.Text = FoodCourtCowboy;
            label115.Text = CentralTacos;
            label116.Text = TheDarkBean;
            label117.Text = MeatyBurger;
            label118.Text = FrozenDream;
            label119.Text = JadeParadise;
            label75.Text = TeresasOven;
            label134.Text = $"Gourmet = {GourmetCount} / 39";
            label121.Text = "Karate Champ:";
            label124.Text = "Item Smasher:";
            label126.Text = "Census Taker:";
            label128.Text = "Legendary Soldier:";
            label122.Text = Convert.ToString(TimeSkip.KarateChamp);
            label125.Text = Convert.ToString(TimeSkip.ItemSmasher);
            label129.Text = Convert.ToString(TimeSkip.LegendarySoldier);
            label127.Text = $"{TimeSkip.CensusTaker}/50";
            if (TimeSkip.ReadPPArray.ElementAt(98) > 0)
            {
                label17.ForeColor = Color.Green;
            }
            else
            {
                label17.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(46) > 0)
            {
                label18.ForeColor = Color.Green;
            }
            else
            {
                label18.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(99) > 0)
            {
                label19.ForeColor = Color.Green;
            }
            else
            {
                label19.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(96) > 0)
            {
                label20.ForeColor = Color.Green;
            }
            else
            {
                label20.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(79) > 0)
            {
                label21.ForeColor = Color.Green;
            }
            else
            {
                label21.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(80) > 0)
            {
                label22.ForeColor = Color.Green;
            }
            else
            {
                label22.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(64) > 0)
            {
                label23.ForeColor = Color.Green;
            }
            else
            {
                label23.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(65) > 0)
            {
                label24.ForeColor = Color.Green;
            }
            else
            {
                label24.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(15) > 0)
            {
                label25.ForeColor = Color.Green;
            }
            else
            {
                label25.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(40) > 0)
            {
                label26.ForeColor = Color.Green;
            }
            else
            {
                label26.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(56) > 0)
            {
                label27.ForeColor = Color.Green;
            }
            else
            {
                label27.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(39) > 0)
            {
                label28.ForeColor = Color.Green;
            }
            else
            {
                label28.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(17) > 0)
            {
                label29.ForeColor = Color.Green;
            }
            else
            {
                label29.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(26) > 0)
            {
                label30.ForeColor = Color.Green;
            }
            else
            {
                label30.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(0) > 0)
            {
                label31.ForeColor = Color.Green;
            }
            else
            {
                label31.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(25) > 0)
            {
                label32.ForeColor = Color.Green;
            }
            else
            {
                label32.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(16) > 0)
            {
                label33.ForeColor = Color.Green;
            }
            else
            {
                label33.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(55) > 0)
            {
                label34.ForeColor = Color.Green;
            }
            else
            {
                label34.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(34) > 0)
            {
                label35.ForeColor = Color.Green;
            }
            else
            {
                label35.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(37) > 0)
            {
                label36.ForeColor = Color.Green;
            }
            else
            {
                label36.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(35) > 0)
            {
                label37.ForeColor = Color.Green;
            }
            else
            {
                label37.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(36) > 0)
            {
                label38.ForeColor = Color.Green;
            }
            else
            {
                label38.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(3) > 0)
            {
                label39.ForeColor = Color.Green;
            }
            else
            {
                label39.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(67) > 0)
            {
                label40.ForeColor = Color.Green;
            }
            else
            {
                label40.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(66) > 0)
            {
                label41.ForeColor = Color.Green;
            }
            else
            {
                label41.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(70) > 0)
            {
                label42.ForeColor = Color.Green;
            }
            else
            {
                label42.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(71) > 0)
            {
                label43.ForeColor = Color.Green;
            }
            else
            {
                label43.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(72) > 0)
            {
                label44.ForeColor = Color.Green;
            }
            else
            {
                label44.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(73) > 0)
            {
                label45.ForeColor = Color.Green;
            }
            else
            {
                label45.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(2) > 0)
            {
                label46.ForeColor = Color.Green;
            }
            else
            {
                label46.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(69) > 0)
            {
                label47.ForeColor = Color.Green;
            }
            else
            {
                label47.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(68) > 0)
            {
                label48.ForeColor = Color.Green;
            }
            else
            {
                label48.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(33) > 0)
            {
                label50.ForeColor = Color.Green;
            }
            else
            {
                label50.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(82) > 0)
            {
                label51.ForeColor = Color.Green;
            }
            else
            {
                label51.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(81) > 0)
            {
                label52.ForeColor = Color.Green;
            }
            else
            {
                label52.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(83) > 0)
            {
                label53.ForeColor = Color.Green;
            }
            else
            {
                label53.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(78) > 0)
            {
                label55.ForeColor = Color.Green;
            }
            else
            {
                label55.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(75) > 0)
            {
                label56.ForeColor = Color.Green;
            }
            else
            {
                label56.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(74) > 0)
            {
                label57.ForeColor = Color.Green;
            }
            else
            {
                label57.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(76) > 0)
            {
                label58.ForeColor = Color.Green;
            }
            else
            {
                label58.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(77) > 0)
            {
                label59.ForeColor = Color.Green;
            }
            else
            {
                label59.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(8) > 0)
            {
                label60.ForeColor = Color.Green;
            }
            else
            {
                label60.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(49) > 0)
            {
                label61.ForeColor = Color.Green;
            }
            else
            {
                label61.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(50) > 0)
            {
                label62.ForeColor = Color.Green;
            }
            else
            {
                label62.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(45) > 0)
            {
                label63.ForeColor = Color.Green;
            }
            else
            {
                label63.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(22) > 0)
            {
                label64.ForeColor = Color.Green;
            }
            else
            {
                label64.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(48) > 0)
            {
                label65.ForeColor = Color.Green;
            }
            else
            {
                label65.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(7) > 0)
            {
                label66.ForeColor = Color.Green;
            }
            else
            {
                label66.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(60) > 0)
            {
                label67.ForeColor = Color.Green;
            }
            else
            {
                label67.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(6) > 0)
            {
                label68.ForeColor = Color.Green;
            }
            else
            {
                label68.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(32) > 0)
            {
                label69.ForeColor = Color.Green;
            }
            else
            {
                label69.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(57) > 0)
            {
                label70.ForeColor = Color.Green;
            }
            else
            {
                label70.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(61) > 0)
            {
                label71.ForeColor = Color.Green;
            }
            else
            {
                label71.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(59) > 0)
            {
                label72.ForeColor = Color.Green;
            }
            else
            {
                label72.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(58) > 0)
            {
                label73.ForeColor = Color.Green;
            }
            else
            {
                label73.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(47) > 0)
            {
                label74.ForeColor = Color.Green;
            }
            else
            {
                label74.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(28) > 0)
            {
                label76.ForeColor = Color.Green;
            }
            else
            {
                label76.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(27) > 0)
            {
                label77.ForeColor = Color.Green;
            }
            else
            {
                label77.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(23) > 0)
            {
                label78.ForeColor = Color.Green;
            }
            else
            {
                label78.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(51) > 0)
            {
                label79.ForeColor = Color.Green;
            }
            else
            {
                label79.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(52) > 0)
            {
                label80.ForeColor = Color.Green;
            }
            else
            {
                label80.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(29) > 0)
            {
                label81.ForeColor = Color.Green;
            }
            else
            {
                label81.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(30) > 0)
            {
                label82.ForeColor = Color.Green;
            }
            else
            {
                label82.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(24) > 0)
            {
                label83.ForeColor = Color.Green;
            }
            else
            {
                label83.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(5) > 0)
            {
                label84.ForeColor = Color.Green;
            }
            else
            {
                label84.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(4) > 0)
            {
                label85.ForeColor = Color.Green;
            }
            else
            {
                label85.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(54) > 0)
            {
                label86.ForeColor = Color.Green;
            }
            else
            {
                label86.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(53) > 0)
            {
                label87.ForeColor = Color.Green;
            }
            else
            {
                label87.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(11) > 0)
            {
                label88.ForeColor = Color.Green;
            }
            else
            {
                label88.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(87) > 0)
            {
                label89.ForeColor = Color.Green;
            }
            else
            {
                label89.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(88) > 0)
            {
                label90.ForeColor = Color.Green;
            }
            else
            {
                label90.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(89) > 0)
            {
                label91.ForeColor = Color.Green;
            }
            else
            {
                label91.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(84) > 0)
            {
                label92.ForeColor = Color.Green;
            }
            else
            {
                label92.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(86) > 0)
            {
                label93.ForeColor = Color.Green;
            }
            else
            {
                label93.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(85) > 0)
            {
                label94.ForeColor = Color.Green;
            }
            else
            {
                label94.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(91) > 0)
            {
                label95.ForeColor = Color.Green;
            }
            else
            {
                label95.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(90) > 0)
            {
                label96.ForeColor = Color.Green;
            }
            else
            {
                label96.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(9) > 0)
            {
                label97.ForeColor = Color.Green;
            }
            else
            {
                label97.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(10) > 0)
            {
                label98.ForeColor = Color.Green;
            }
            else
            {
                label98.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(95) > 0)
            {
                label100.ForeColor = Color.Green;
            }
            else
            {
                label100.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(97) > 0)
            {
                label101.ForeColor = Color.Green;
            }
            else
            {
                label101.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(41) > 0)
            {
                label102.ForeColor = Color.Green;
            }
            else
            {
                label102.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(31) > 0)
            {
                label103.ForeColor = Color.Green;
            }
            else
            {
                label103.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(38) > 0)
            {
                label104.ForeColor = Color.Green;
            }
            else
            {
                label104.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(62) > 0)
            {
                label105.ForeColor = Color.Green;
            }
            else
            {
                label105.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(63) > 0)
            {
                label106.ForeColor = Color.Green;
            }
            else
            {
                label106.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(42) > 0)
            {
                label107.ForeColor = Color.Green;
            }
            else
            {
                label107.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(43) > 0)
            {
                label108.ForeColor = Color.Green;
            }
            else
            {
                label108.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(44) > 0)
            {
                label109.ForeColor = Color.Green;
            }
            else
            {
                label109.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(12) > 0)
            {
                label110.ForeColor = Color.Green;
            }
            else
            {
                label110.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(18) > 0)
            {
                label111.ForeColor = Color.Green;
            }
            else
            {
                label111.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(13) > 0)
            {
                label112.ForeColor = Color.Green;
            }
            else
            {
                label112.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(14) > 0)
            {
                label113.ForeColor = Color.Green;
            }
            else
            {
                label113.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(21) > 0)
            {
                label114.ForeColor = Color.Green;
            }
            else
            {
                label114.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(92) > 0)
            {
                label115.ForeColor = Color.Green;
            }
            else
            {
                label115.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(93) > 0)
            {
                label116.ForeColor = Color.Green;
            }
            else
            {
                label116.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(19) > 0)
            {
                label117.ForeColor = Color.Green;
            }
            else
            {
                label117.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(20) > 0)
            {
                label118.ForeColor = Color.Green;
            }
            else
            {
                label118.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(1) > 0)
            {
                label119.ForeColor = Color.Green;
            }
            else
            {
                label119.ForeColor = Color.Red;
            }
            if (TimeSkip.ReadPPArray.ElementAt(94) > 0)
            {
                label75.ForeColor = Color.Green;
            }
            else
            {
                label75.ForeColor = Color.Red;
            }
            int LocalGourmetCount = 0;
            int GourmetByte1 = TimeSkip.ReadGourmetArray.ElementAt(0);
            int GourmetByte2 = TimeSkip.ReadGourmetArray.ElementAt(1);
            int GourmetByte3 = TimeSkip.ReadGourmetArray.ElementAt(2);
            int GourmetByte4 = TimeSkip.ReadGourmetArray.ElementAt(3);
            int GourmetByte5 = TimeSkip.ReadGourmetArray.ElementAt(4);
            if (GourmetByte1 >= 128)
            {
                label148.Text = "Raw Meat Acquired!";
                label148.ForeColor = Color.Green;
                GourmetByte1 = GourmetByte1 - 128;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label148.Text = "Raw Meat Missing!";
                label148.ForeColor = Color.Red;
            }
            if (GourmetByte1 >= 64)
            {
                label147.Text = "Lettuce Acquired!";
                label147.ForeColor = Color.Green;
                GourmetByte1 = GourmetByte1 - 64;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label147.Text = "Lettuce Missing!";
                label147.ForeColor = Color.Red;
            }
            if (GourmetByte1 >= 32)
            {
                label146.Text = "Japanese Radish Acquired!";
                label146.ForeColor = Color.Green;
                GourmetByte1 = GourmetByte1 - 32;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label146.Text = "Japanese Radish Missing!";
                label146.ForeColor = Color.Red;
            }
            if (GourmetByte1 >= 16)
            {
                label145.Text = "Snack Acquired!";
                label145.ForeColor = Color.Green;
                GourmetByte1 = GourmetByte1 - 16;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label145.Text = "Snack Missing!";
                label145.ForeColor = Color.Red;
            }
            if (GourmetByte1 >= 8)
            {
                label144.Text = "Cabbage Acquired!";
                label144.ForeColor = Color.Green;
                GourmetByte1 = GourmetByte1 - 8;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label144.Text = "Cabbage Missing!";
                label144.ForeColor = Color.Red;
            }
            if (GourmetByte1 >= 4)
            {
                label143.Text = "Squash Acquired!";
                label143.ForeColor = Color.Green;
                GourmetByte1 = GourmetByte1 - 4;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label143.Text = "Squash Missing!";
                label143.ForeColor = Color.Red;
            }
            if (GourmetByte1 >= 2)
            {
                label142.Text = "Corn Acquired!";
                label142.ForeColor = Color.Green;
                GourmetByte1 = GourmetByte1 - 2;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label142.Text = "Corn Missing!";
                label142.ForeColor = Color.Red;
            }
            if (GourmetByte1 >= 1)
            {
                label141.Text = "Zucchini Acquired!";
                label141.ForeColor = Color.Green;
                GourmetByte1 = GourmetByte1 - 1;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label141.Text = "Zucchini Missing!";
                label141.ForeColor = Color.Red;
            }
            if (GourmetByte2 >= 128)
            {
                label140.Text = "Orange Juice Acquired!";
                label140.ForeColor = Color.Green;
                GourmetByte2 = GourmetByte2 - 128;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label140.Text = "Orange Juice Missing!";
                label140.ForeColor = Color.Red;
            }
            if (GourmetByte2 >= 64)
            {
                label139.Text = "Orange Acquired!";
                label139.ForeColor = Color.Green;
                GourmetByte2 = GourmetByte2 - 64;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label139.Text = "Orange Missing!";
                label139.ForeColor = Color.Red;
            }
            if (GourmetByte2 >= 32)
            {
                label172.Text = "Wine Acquired!";
                label172.ForeColor = Color.Green;
                GourmetByte2 = GourmetByte2 - 32;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label172.Text = "Wine Missing!";
                label172.ForeColor = Color.Red;
            }
            if (GourmetByte2 >= 16)
            {
                label138.Text = "Grapefuit Acquired!";
                label138.ForeColor = Color.Green;
                GourmetByte2 = GourmetByte2 - 16;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label138.Text = "Grapefruit Missing!";
                label138.ForeColor = Color.Red;
            }
            if (GourmetByte2 >= 8)
            {
                label137.Text = "Melon Acquired!";
                label137.ForeColor = Color.Green;
                GourmetByte2 = GourmetByte2 - 8;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label137.Text = "Melon Missing!";
                label137.ForeColor = Color.Red;
            }
            if (GourmetByte2 >= 4)
            {
                label136.Text = "Baguette Acquired!";
                label136.ForeColor = Color.Green;
                GourmetByte2 = GourmetByte2 - 4;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label136.Text = "Baguette Missing!";
                label136.ForeColor = Color.Red;
            }
            if (GourmetByte2 >= 2)
            {
                label135.Text = "Rotten Meat Acquired!";
                label135.ForeColor = Color.Green;
                GourmetByte2 = GourmetByte2 - 2;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label135.Text = "Rotten Meat Missing!";
                label135.ForeColor = Color.Red;
            }
            if (GourmetByte2 >= 1)
            {
                label173.Text = "Cooked Meat Acquired!";
                label173.ForeColor = Color.Green;
                GourmetByte2 = GourmetByte2 - 1;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label173.Text = "Cooked Meat Missing!";
                label173.ForeColor = Color.Red;
            }
            if (GourmetByte3 >= 128)
            {
                label149.Text = "Rotten Pizza Acquired!";
                label149.ForeColor = Color.Green;
                GourmetByte3 = GourmetByte3 - 128;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label149.Text = "Rotten Pizza Missing!";
                label149.ForeColor = Color.Red;
            }
            if (GourmetByte3 >= 64)
            {
                label150.Text = "Cooked Pizza Acquired!";
                label150.ForeColor = Color.Green;
                GourmetByte3 = GourmetByte3 - 64;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label150.Text = "Cooked Pizza Missing!";
                label150.ForeColor = Color.Red;
            }
            if (GourmetByte3 >= 32)
            {
                label151.Text = "Uncooked Pizza Acquired!";
                label151.ForeColor = Color.Green;
                GourmetByte3 = GourmetByte3 - 32;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label151.Text = "Uncooked Pizza Missing!";
                label151.ForeColor = Color.Red;
            }
            if (GourmetByte3 >= 16)
            {
                label152.Text = "Red Cabbage Acquired!";
                label152.ForeColor = Color.Green;
                GourmetByte3 = GourmetByte3 - 16;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label152.Text = "Red Cabbage Missing!";
                label152.ForeColor = Color.Red;
            }
            if (GourmetByte3 >= 8)
            {
                label153.Text = "Cheese Acquired!";
                label153.ForeColor = Color.Green;
                GourmetByte3 = GourmetByte3 - 8;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label153.Text = "Cheese Missing!";
                label153.ForeColor = Color.Red;
            }
            if (GourmetByte3 >= 4)
            {
                label154.Text = "Yogurt Acquired!";
                label154.ForeColor = Color.Green;
                GourmetByte3 = GourmetByte3 - 4;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label154.Text = "Yogurt Missing!";
                label154.ForeColor = Color.Red;
            }
            if (GourmetByte3 >= 2)
            {
                label155.Text = "Coffee Creamer Acquired!";
                label155.ForeColor = Color.Green;
                GourmetByte3 = GourmetByte3 - 2;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label155.Text = "Coffee Creamer Missing!";
                label155.ForeColor = Color.Red;
            }
            if (GourmetByte3 >= 1)
            {
                label156.Text = "Jug of Milk Acquired!";
                label156.ForeColor = Color.Green;
                GourmetByte3 = GourmetByte3 - 1;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label156.Text = "Jug of Milk Missing!";
                label156.ForeColor = Color.Red;
            }
            if (GourmetByte4 >= 128)
            {
                label157.Text = "Thawed Vegetables Acquired!";
                label157.ForeColor = Color.Green;
                GourmetByte4 = GourmetByte4 - 128;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label157.Text = "Thawed Vegetables Missing!";
                label157.ForeColor = Color.Red;
            }
            if (GourmetByte4 >= 64)
            {
                label158.Text = "Ice Pops Acquired!";
                label158.ForeColor = Color.Green;
                GourmetByte4 = GourmetByte4 - 64;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label158.Text = "Ice Pops Missing!";
                label158.ForeColor = Color.Red;
            }
            if (GourmetByte4 >= 32)
            {
                label159.Text = "Melted Ice Pops Acquired!";
                label159.ForeColor = Color.Green;
                GourmetByte4 = GourmetByte4 - 32;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label159.Text = "Melted Ice Pops Missing!";
                label159.ForeColor = Color.Red;
            }
            if (GourmetByte4 >= 16)
            {
                label160.Text = "Frozen Vegetables Acquired!";
                label160.ForeColor = Color.Green;
                GourmetByte4 = GourmetByte4 - 16;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label160.Text = "Frozen Vegatables Missing!";
                label160.ForeColor = Color.Red;
            }
            if (GourmetByte4 >= 8)
            {
                label161.Text = "Carton of Milk Acquired!";
                label161.ForeColor = Color.Green;
                GourmetByte4 = GourmetByte4 - 8;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label161.Text = "Carton of Milk Missing!";
                label161.ForeColor = Color.Red;
            }
            if (GourmetByte4 >= 4)
            {
                label162.Text = "Apple Acquired!";
                label162.ForeColor = Color.Green;
                GourmetByte4 = GourmetByte4 - 4;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label162.Text = "Apple Missing!";
                label162.ForeColor = Color.Red;
            }
            if (GourmetByte4 >= 2)
            {
                label163.Text = "Cookies Acquired!";
                label163.ForeColor = Color.Green;
                GourmetByte4 = GourmetByte4 - 2;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label163.Text = "Cookies Missing!";
                label163.ForeColor = Color.Red;
            }
            if (GourmetByte4 >= 1)
            {
                label164.Text = "Pie Acquired!";
                label164.ForeColor = Color.Green;
                GourmetByte4 = GourmetByte4 - 1;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label164.Text = "Pie Missing!";
                label164.ForeColor = Color.Red;
            }
            if (GourmetByte5 >= 64)
            {
                label165.Text = "Zombait Acquired!";
                label165.ForeColor = Color.Green;
                GourmetByte5 = GourmetByte5 - 64;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label165.Text = "Zombait Missing!";
                label165.ForeColor = Color.Red;
            }
            if (GourmetByte5 >= 32)
            {
                label166.Text = "Energizer Acquired!";
                label166.ForeColor = Color.Red;
                GourmetByte5 = GourmetByte5 - 32;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label166.Text = "Energizer Missing!";
                label166.ForeColor = Color.Red;
            }
            if (GourmetByte5 >= 16)
            {
                label167.Text = "Nectar Acquired!";
                label167.ForeColor = Color.Green;
                GourmetByte5 = GourmetByte5 - 16;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label167.Text = "Nectar Missing!";
                label167.ForeColor = Color.Red;
            }
            if (GourmetByte5 >= 8)
            {
                label168.Text = "Spitfire Acquired!";
                label168.ForeColor = Color.Green;
                GourmetByte5 = GourmetByte5 - 8;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label168.Text = "Spitfire Missing!";
                label168.ForeColor = Color.Red;
            }
            if (GourmetByte5 >= 4)
            {
                label169.Text = "Untouchable Acquired!";
                label169.ForeColor = Color.Green;
                GourmetByte5 = GourmetByte5 - 4;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label169.Text = "Untouchable Missing!";
                label169.ForeColor = Color.Red;
            }
            if (GourmetByte5 >= 2)
            {
                label170.Text = "Randomizer Acquired!";
                label170.ForeColor = Color.Green;
                GourmetByte5 = GourmetByte5 - 2;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label170.Text = "Randomizer Missing!";
                label170.ForeColor = Color.Red;
            }
            if (GourmetByte5 >= 1)
            {
                label171.Text = "Quickstep Acquired!";
                label171.ForeColor = Color.Green;
                GourmetByte5 = GourmetByte5 - 1;
                LocalGourmetCount = LocalGourmetCount + 1;
            }
            else
            {
                label171.Text = "Quickstep Missing!";
                label171.ForeColor = Color.Red;
            }
            int LocalClothesHorseCount = 0;
            int ClothesHorseByte1 = TimeSkip.ReadClothesHorseArray.ElementAt(0);
            int ClothesHorseByte2 = TimeSkip.ReadClothesHorseArray.ElementAt(1);
            int ClothesHorseByte3 = TimeSkip.ReadClothesHorseArray.ElementAt(2);
            int ClothesHorseByte4 = TimeSkip.ReadClothesHorseArray.ElementAt(3);
            int ClothesHorseByte5 = TimeSkip.ReadClothesHorseArray.ElementAt(5);
            int ClothesHorseByte6 = TimeSkip.ReadClothesHorseArray.ElementAt(6);
            int ClothesHorseByte7 = TimeSkip.ReadClothesHorseArray.ElementAt(7);
            int ClothesHorseByte8 = TimeSkip.ReadClothesHorseArray.ElementAt(8);
            int ClothesHorseByte9 = TimeSkip.ReadClothesHorseArray.ElementAt(9);
            if (ClothesHorseByte1 >= 128)
            {
                label174.Text = "Grey Suit Acquired!";
                label174.ForeColor = Color.Green;
                ClothesHorseByte1 = ClothesHorseByte1 - 128;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label174.Text = "Grey Suit Missing!";
                label174.ForeColor = Color.Red;
            }
            if (ClothesHorseByte1 >= 64)
            {
                label219.Text = "Checkered Business Suit Acquired!";
                label219.ForeColor = Color.Green;
                ClothesHorseByte1 = ClothesHorseByte1 - 64;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label219.Text = "Checkered Business Suit Missing!";
                label219.ForeColor = Color.Red;
            }
            if (ClothesHorseByte1 >= 32)
            {
                label176.Text = "White Dress Shirt Acquired!";
                label176.ForeColor = Color.Green;
                ClothesHorseByte1 = ClothesHorseByte1 - 32;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label176.Text = "White Dress Shirt Missing!";
                label176.ForeColor = Color.Red;
            }
            if (ClothesHorseByte1 >= 16)
            {
                label177.Text = "Red Sleveless Shirt Acquired!";
                label177.ForeColor = Color.Green;
                ClothesHorseByte1 = ClothesHorseByte1 - 16;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label177.Text = "Red Sleveless Shirt Missing!";
                label177.ForeColor = Color.Red;
            }
            if (ClothesHorseByte1 >= 8)
            {
                label178.Text = "Titty Shirt Acquired!";
                label178.ForeColor = Color.Green;
                ClothesHorseByte1 = ClothesHorseByte1 - 8;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label178.Text = "Titty Shirt Missing!";
                label178.ForeColor = Color.Red;
            }
            if (ClothesHorseByte1 >= 4)
            {
                label179.Text = "Brown Fur Coat Acquired!";
                label179.ForeColor = Color.Green;
                ClothesHorseByte1 = ClothesHorseByte1 - 4;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label179.Text = "Brown Fur Coat Missing!";
                label179.ForeColor = Color.Red;
            }
            if (ClothesHorseByte2 >= 64)
            {
                label180.Text = "White Strapped Dress Acquired!";
                label180.ForeColor = Color.Green;
                ClothesHorseByte2 = ClothesHorseByte2 - 64;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label180.Text = "White Strapped Dress Missing!";
                label180.ForeColor = Color.Red;
            }
            if (ClothesHorseByte2 >= 32)
            {
                label181.Text = "Purple Dress Acquired!";
                label181.ForeColor = Color.Green;
                ClothesHorseByte2 = ClothesHorseByte2 - 32;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label181.Text = "Purple Dress Missing!";
                label181.ForeColor = Color.Red;
            }
            if (ClothesHorseByte2 >= 16)
            {
                label220.Text = "Pink Skirt Acquired!";
                label220.ForeColor = Color.Green;
                ClothesHorseByte2 = ClothesHorseByte2 - 32;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label220.Text = "Pink Skirt Missing!";
                label220.ForeColor = Color.Red;
            }
            if (ClothesHorseByte2 >= 8)
            {
                label182.Text = "Black Dress Acquired!";
                label182.ForeColor = Color.Green;
                ClothesHorseByte2 = ClothesHorseByte2 - 8;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label182.Text = "Black Dress Missing!";
                label182.ForeColor = Color.Red;
            }
            if (ClothesHorseByte2 >= 4)
            {
                label183.Text = "White Business Skirt Acquired!";
                label183.ForeColor = Color.Green;
                ClothesHorseByte2 = ClothesHorseByte2 - 4;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label183.Text = "White Business Skirt Missing!";
                label183.ForeColor = Color.Red;
            }
            if (ClothesHorseByte2 >= 2)
            {
                label184.Text = "Yellow Suit Acquired!";
                label184.ForeColor = Color.Green;
                ClothesHorseByte2 = ClothesHorseByte2 - 2;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label184.Text = "Yellow Suit Missing";
                label184.ForeColor = Color.Red;
            }
            if (ClothesHorseByte2 >= 1)
            {
                label185.Text = "White Suit Acquired!";
                label185.ForeColor = Color.Green;
                ClothesHorseByte2 = ClothesHorseByte2 - 1;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label185.Text = "White Suit Missing!";
                label185.ForeColor = Color.Red;
            }
            if (ClothesHorseByte3 >= 128)
            {
                label186.Text = "USA Track Suit Acquired!";
                label186.ForeColor = Color.Green;
                ClothesHorseByte3 = ClothesHorseByte3 - 128;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label186.Text = "USA Track Suit Missing!";
                label186.ForeColor = Color.Red;
            }
            if (ClothesHorseByte3 >= 16)
            {
                label187.Text = "Red,White and Blue Kids Clothes Acquired!";
                label187.ForeColor = Color.Green;
                ClothesHorseByte3 = ClothesHorseByte3 - 16;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label187.Text = "Red,White and Blue Kids Clothes Missing!";
                label187.ForeColor = Color.Red;
            }
            if (ClothesHorseByte3 >= 8)
            {
                label188.Text = "Purple/Black Kids Clothes Acquired!";
                label188.ForeColor = Color.Green;
                ClothesHorseByte3 = ClothesHorseByte3 - 8;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label188.Text = "Purple/Black Kids Clothes Missing!";
                label188.ForeColor = Color.Red;
            }
            if (ClothesHorseByte3 >= 4)
            {
                label189.Text = "Green Ratman Shirt Acquired!";
                label189.ForeColor = Color.Green;
                ClothesHorseByte3 = ClothesHorseByte3 - 4;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label189.Text = "Green Ratman Shirt Missing!";
                label189.ForeColor = Color.Red;
            }
            if (ClothesHorseByte3 >= 2)
            {
                label190.Text = "Red Ratman Shirt Acquired!";
                label190.ForeColor = Color.Green;
                ClothesHorseByte3 = ClothesHorseByte3 - 2;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label190.Text = "Red Ratman Shirt Missing!";
                label190.ForeColor = Color.Red;
            }
            if (ClothesHorseByte3 >= 1)
            {
                label191.Text = "Blue/White Flower Dress Acquired!";
                label191.ForeColor = Color.Green;
                ClothesHorseByte3 = ClothesHorseByte3 - 1;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label191.Text = "Blue/White Flower Dress Missing!";
                label191.ForeColor = Color.Red;
            }
            if (ClothesHorseByte4 >= 4)
            {
                label192.Text = "Blue Vest & Khaki's Acquired!";
                label192.ForeColor = Color.Green;
                ClothesHorseByte4 = ClothesHorseByte4 - 4;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label192.Text = "Blue Vest & Khaki's Missing!";
                label192.ForeColor = Color.Red;
            }
            if (ClothesHorseByte4 >= 2)
            {
                label193.Text = "Camoflauge Vest Acquired!";
                label193.ForeColor = Color.Green;
                ClothesHorseByte4 = ClothesHorseByte4 - 2;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label193.Text = "Camoflauge Vest Missing!";
                label193.ForeColor = Color.Red;
            }
            if (ClothesHorseByte4 >= 1)
            {
                label194.Text = "Black/White Track Suit Acquired!";
                label194.ForeColor = Color.Green;
                ClothesHorseByte4 = ClothesHorseByte4 - 1;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label194.Text = "Black/White Track Suit Acquired!";
                label194.ForeColor = Color.Red;
            }
            if (ClothesHorseByte5 >= 128)
            {
                label197.Text = "Red/Black Tennis Shoes Acquired!";
                label197.ForeColor = Color.Green;
                ClothesHorseByte5 = ClothesHorseByte5 - 128;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label197.Text = "Red & Black Tennis Shoes Missing!";
                label197.ForeColor = Color.Red;
            }
            if (ClothesHorseByte5 >= 64)
            {
                label195.Text = "Black Dress Shoes Acquired!";
                label195.ForeColor = Color.Green;
                ClothesHorseByte5 = ClothesHorseByte5 - 64;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label195.Text = "Black Dress Shoes Missing!";
                label195.ForeColor = Color.Red;
            }
            if (ClothesHorseByte5 >= 32)
            {
                label196.Text = "White Dress Shoes Acquired!";
                label196.ForeColor = Color.Green;
                ClothesHorseByte5 = ClothesHorseByte5 - 32;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label196.Text = "White Dress Shoes Missing!";
                label196.ForeColor = Color.Red;
            }
            if (ClothesHorseByte6 >= 128)
            {
                label198.Text = "Megaman Helmet Acquired!";
                label198.ForeColor = Color.Green;
                ClothesHorseByte6 = ClothesHorseByte6 - 128;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label198.Text = "Megaman Helmet Missing!";
                label198.ForeColor = Color.Red;
            }
            if (ClothesHorseByte6 >= 32)
            {
                label199.Text = "Shaved Head Acquired!";
                label199.ForeColor = Color.Green;
                ClothesHorseByte6 = ClothesHorseByte6 - 32;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label199.Text = "Shaved Head Missing!";
                label199.ForeColor = Color.Red;
            }
            if (ClothesHorseByte6 >= 2)
            {
                label200.Text = "Orange Tennis Shoes Acquired!";
                label200.ForeColor = Color.Green;
                ClothesHorseByte6 = ClothesHorseByte6 - 2;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label200.Text = "Orange Tennis Shoes Missing!";
                label200.ForeColor = Color.Red;
            }
            if (ClothesHorseByte6 >= 1)
            {
                label201.Text = "White Tennis Shoes Acquired!";
                label201.ForeColor = Color.Green;
                ClothesHorseByte6 = ClothesHorseByte6 - 1;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label201.Text = "White Tennis Shoes Missing!";
                label201.ForeColor = Color.Red;
            }
            if (ClothesHorseByte7 >= 128)
            {
                label202.Text = "Black Fedora Acquired!";
                label202.ForeColor = Color.Green;
                ClothesHorseByte7 = ClothesHorseByte7 - 128;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label202.Text = "Black Fedora Missing!";
                label202.ForeColor = Color.Red;
            }
            if (ClothesHorseByte7 >= 64)
            {
                label203.Text = "Brown Fedora Acquired!";
                label203.ForeColor = Color.Green;
                ClothesHorseByte7 = ClothesHorseByte7 - 64;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label203.Text = "Brown Fedora Missing!";
                label203.ForeColor = Color.Red;
            }
            if (ClothesHorseByte7 >= 32)
            {
                label204.Text = "Blue Baseball Cap Acquired!";
                label204.ForeColor = Color.Green;
                ClothesHorseByte7 = ClothesHorseByte7 - 32;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label204.Text = "Blue Baseball Cap Missing!";
                label204.ForeColor = Color.Red;
            }
            if (ClothesHorseByte7 >= 16)
            {
                label205.Text = "Black Baseball Cap Acquired!";
                label205.ForeColor = Color.Green;
                ClothesHorseByte7 = ClothesHorseByte7 - 16;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label205.Text = "Black Baseball Cap Missing!";
                label205.ForeColor = Color.Red;
            }
            if (ClothesHorseByte7 >= 4)
            {
                label206.Text = "Red Hair Acquired!";
                label206.ForeColor = Color.Green;
                ClothesHorseByte7 = ClothesHorseByte7 - 4;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label206.Text = "Red Hair Missing!";
                label206.ForeColor = Color.Red;
            }
            if (ClothesHorseByte7 >= 2)
            {
                label207.Text = "Brown Hair Acquired!";
                label207.ForeColor = Color.Green;
                ClothesHorseByte7 = ClothesHorseByte7 - 2;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label207.Text = "Brown Hair Missing!";
                label207.ForeColor = Color.Red;
            }
            if (ClothesHorseByte7 >= 1)
            {
                label208.Text = "Grey Hair Acquired!";
                label208.ForeColor = Color.Green;
                ClothesHorseByte7 = ClothesHorseByte7 - 1;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label208.Text = "Grey Hair Missing!";
                label208.ForeColor = Color.Red;
            }
            if (ClothesHorseByte8 >= 64)
            {
                label209.Text = "Servbot Mask Acquired!";
                label209.ForeColor = Color.Green;
                ClothesHorseByte8 = ClothesHorseByte8 - 64;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label209.Text = "Servbot Mask Missing!";
                label209.ForeColor = Color.Red;
            }
            if (ClothesHorseByte8 >= 32)
            {
                label210.Text = "Teddy Mask Acquired!";
                label210.ForeColor = Color.Green;
                ClothesHorseByte8 = ClothesHorseByte8 - 32;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label210.Text = "Teddy Mask Missing!";
                label210.ForeColor = Color.Red;
            }
            if (ClothesHorseByte8 >= 16)
            {
                label211.Text = "Horse Mask Acquired!";
                label211.ForeColor = Color.Green;
                ClothesHorseByte8 = ClothesHorseByte8 - 16;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label211.Text = "Horse Mask Missing!";
                label211.ForeColor = Color.Red;
            }
            if (ClothesHorseByte8 >= 8)
            {
                label212.Text = "Demon Mask Acquired!";
                label212.ForeColor = Color.Green;
                ClothesHorseByte8 = ClothesHorseByte8 - 8;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label212.Text = "Demon Mask Missing!";
                label212.ForeColor = Color.Red;
            }
            if (ClothesHorseByte9 >= 128)
            {
                label213.Text = "Orange Sunglasses Acquired!";
                label213.ForeColor = Color.Green;
                ClothesHorseByte9 = ClothesHorseByte9 - 64;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label213.Text = "Orange Sunglasses Missing!";
                label213.ForeColor = Color.Red;
            }
            if (ClothesHorseByte9 >= 64)
            {
                label214.Text = "Silver Rimless Glasses Acquired!";
                label214.ForeColor = Color.Green;
                ClothesHorseByte9 = ClothesHorseByte9 - 64;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label214.Text = "Silver Rimless Glasses Missing!";
                label214.ForeColor = Color.Red;
            }
            if (ClothesHorseByte9 >= 32)
            {
                label215.Text = "Red Sunglases Acquired!";
                label215.ForeColor = Color.Green;
                ClothesHorseByte9 = ClothesHorseByte9 - 32;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label215.Text = "Red Sunglasses Missing!";
                label215.ForeColor = Color.Red;
            }
            if (ClothesHorseByte9 >= 16)
            {
                label216.Text = "Grey Rimless Glasses Acquired!";
                label216.ForeColor = Color.Green;
                ClothesHorseByte9 = ClothesHorseByte9 - 16;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label216.Text = "Grey Rimless Glasses Missing!";
                label216.ForeColor = Color.Red;
            }
            if (ClothesHorseByte9 >= 8)
            {
                label217.Text = "Silver Wireframe Glasses Acquired!";
                label217.ForeColor = Color.Green;
                ClothesHorseByte9 = ClothesHorseByte9 - 8;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label217.Text = "Silver Wireframe Glasses Missing!";
                label217.ForeColor = Color.Red;
            }
            if (ClothesHorseByte9 >= 4)
            {
                label218.Text = "Brown Sunglasses Acquired!";
                label218.ForeColor = Color.Green;
                ClothesHorseByte9 = ClothesHorseByte9 - 4;
                LocalClothesHorseCount = LocalClothesHorseCount + 1;
            }
            else
            {
                label218.Text = "Brown Sunglasses Missing!";
                label218.ForeColor = Color.Red;
            }
            string OldToolTipText = ToolTip;
            string ToolTipText = "";
            int LocalTransmissionCount = 0;
            int TransmissionaryByte1 = TimeSkip.ReadTransmissionaryArray.ElementAt(0);
            int TransmissionaryByte2 = TimeSkip.ReadTransmissionaryArray.ElementAt(4);
            int TransmissionaryByte3 = TimeSkip.ReadTransmissionaryArray.ElementAt(5);
            int TransmissionaryByte4 = TimeSkip.ReadTransmissionaryArray.ElementAt(8);
            int TransmissionaryByte5 = TimeSkip.ReadTransmissionaryArray.ElementAt(9);
            int TransmissionaryByte6 = TimeSkip.ReadTransmissionaryArray.ElementAt(10);
            if (TransmissionaryByte6 >= 32)
            {
                TransmissionaryByte6 = TransmissionaryByte6 - 32;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Jamming Device Call Missing!\r\n";
            }
            if (TransmissionaryByte6 >= 16)
            {
                TransmissionaryByte6 = TransmissionaryByte6 - 16;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Last Resort Call Missing!\r\n";
            }
            if (TransmissionaryByte6 >= 8)
            {
                TransmissionaryByte6 = TransmissionaryByte6 - 8;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Santa Cabeza Call Missing!\r\n";
            }
            if (TransmissionaryByte6 >= 4)
            {
                TransmissionaryByte6 = TransmissionaryByte6 - 4;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "A Promise To Isabella Call Missing!\r\n";
            }
            if (TransmissionaryByte6 >= 2)
            {
                TransmissionaryByte6 = TransmissionaryByte6 - 2;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Another Source Call Missing!\r\n";
            }
            if (TransmissionaryByte5 >= 128)
            {
                TransmissionaryByte5 = TransmissionaryByte5 - 128;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Image in the Monitor Call Missing!\r\n";
            }
            if (TransmissionaryByte5 >= 64)
            {
                TransmissionaryByte5 = TransmissionaryByte5 - 64;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Entrance Plaza Shutter Call Missing!\r\n";
            }
            if (TransmissionaryByte5 >= 32)
            {
                TransmissionaryByte5 = TransmissionaryByte5 - 32;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Wonderland Call Missing!\r\n";
            }
            if (TransmissionaryByte5 >= 16)
            {
                TransmissionaryByte5 = TransmissionaryByte5 - 16;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Seon's Call Missing!\r\n";
            }
            if (TransmissionaryByte5 >= 8)
            {
                TransmissionaryByte5 = TransmissionaryByte5 - 8;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Maintanence Tunnels Call Missing!\r\n";
            }
            if (TransmissionaryByte5 >= 4)
            {
                TransmissionaryByte5 = TransmissionaryByte5 - 4;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "North Plaza Call Missing!\r\n";
            }
            if (TransmissionaryByte5 >= 2)
            {
                TransmissionaryByte5 = TransmissionaryByte5 - 2;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Food Court Call Missing!\r\n";
            }
            if (TransmissionaryByte5 >= 1)
            {
                TransmissionaryByte5 = TransmissionaryByte5 - 1;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Entrance Plaza Call Missing!\r\n";
            }
            if (TransmissionaryByte4 >= 128)
            {
                TransmissionaryByte4 = TransmissionaryByte4 - 128;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Warehouse Call Missing!\r\n";
            }
            if (TransmissionaryByte4 >= 64)
            {
                TransmissionaryByte4 = TransmissionaryByte4 - 64;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Cheryl's Request Missing!\r\n";
            }
            if (TransmissionaryByte4 >= 32)
            {
                TransmissionaryByte4 = TransmissionaryByte4 - 32;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Paul's Present Missing!\r\n";
            }
            if (TransmissionaryByte4 >= 16)
            {
                TransmissionaryByte4 = TransmissionaryByte4 - 16;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Simone The Gunslinger Missing!\r\n";
            }
            if (TransmissionaryByte4 >= 8)
            {
                TransmissionaryByte4 = TransmissionaryByte4 - 8;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Floyd The Sommelier Missing!\r\n";
            }
            if (TransmissionaryByte4 >= 2)
            {
                TransmissionaryByte4 = TransmissionaryByte4 - 2;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Ronald's Appetite Missing!\r\n";
            }
            if (TransmissionaryByte4 >= 1)
            {
                TransmissionaryByte4 = TransmissionaryByte4 - 1;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Kindell's Betrayal Missing!\r\n";
            }
            if (TransmissionaryByte1 >= 128)
            {
                TransmissionaryByte1 = TransmissionaryByte1 - 128;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Long Haired Punk Missing!\r\n";
            }
            if (TransmissionaryByte1 >= 64)
            {
                TransmissionaryByte1 = TransmissionaryByte1 - 64;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Above The Law Missing!\r\n";
            }
            if (TransmissionaryByte1 >= 32)
            {
                TransmissionaryByte1 = TransmissionaryByte1 - 32;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Out of Control Missing!\r\n";
            }
            if (TransmissionaryByte1 >= 16)
            {
                TransmissionaryByte1 = TransmissionaryByte1 - 16;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "A Strange Group Missing!\r\n";
            }
            if (TransmissionaryByte1 >= 8)
            {
                TransmissionaryByte1 = TransmissionaryByte1 - 8;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Hatchet Man Missing!\r\n";
            }
            if (TransmissionaryByte1 >= 1)
            {
                TransmissionaryByte1 = TransmissionaryByte1 - 1;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Cut From The Same Cloth Missing!\r\n";
            }
            if (TransmissionaryByte2 >= 64)
            {
                TransmissionaryByte2 = TransmissionaryByte2 - 64;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "The Woman Who Didn't Make It Missing!\r\n";
            }
            if (TransmissionaryByte2 >= 32)
            {
                TransmissionaryByte2 = TransmissionaryByte2 - 32;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Barricade Pair Missing!\r\n";
            }
            if (TransmissionaryByte2 >= 16)
            {
                TransmissionaryByte2 = TransmissionaryByte2 - 16;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Antique Lover Missing!\r\n";
            }
            if (TransmissionaryByte2 >= 8)
            {
                TransmissionaryByte2 = TransmissionaryByte2 - 8;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Restaraunt Man Missing!\r\n";
            }
            if (TransmissionaryByte2 >= 4)
            {
                TransmissionaryByte2 = TransmissionaryByte2 - 4;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "The Coward Missing!\r\n";
            }
            if (TransmissionaryByte2 >= 1)
            {
                TransmissionaryByte2 = TransmissionaryByte2 - 1;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Shadow of the North Plaza Missing!\r\n";
            }
            if (TransmissionaryByte3 >= 32)
            {
                TransmissionaryByte3 = TransmissionaryByte3 - 32;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "A Woman in Despair Missing!\r\n";
            }
            if (TransmissionaryByte3 >= 16)
            {
                TransmissionaryByte3 = TransmissionaryByte3 - 16;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Lovers Missing!\r\n";
            }
            if (TransmissionaryByte3 >= 8)
            {
                TransmissionaryByte3 = TransmissionaryByte3 - 8;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "A Sick Man Missing!\r\n";
            }
            if (TransmissionaryByte3 >= 4)
            {
                TransmissionaryByte3 = TransmissionaryByte3 - 4;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Mark of the Sniper Missing!\r\n";
            }
            if (TransmissionaryByte3 >= 2)
            {
                TransmissionaryByte3 = TransmissionaryByte3 - 2;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Japanese Tourists Missing!\r\n";
            }
            if (TransmissionaryByte3 >= 1)
            {
                TransmissionaryByte3 = TransmissionaryByte3 - 1;
                LocalTransmissionCount = LocalTransmissionCount + 1;
            }
            else
            {
                ToolTipText = ToolTipText + "Mother's Lament Missing!";
            }
            ToolTip = ToolTipText;
            TransmissionCount = LocalTransmissionCount;
            ClothesHorseCount = LocalClothesHorseCount;
            GourmetCount = LocalGourmetCount;
            if (TransmissionCount >= 37)
            {
                label221.ForeColor = Color.Green;
                label221.Text = "Transmissionary Acquired!";
            }
            else
            {
                label221.ForeColor = Color.Red;
                label221.Text = $"Transmissionary = {TransmissionCount}/37";
                if (ToolTip != OldToolTipText)
                {
                    toolTip1.SetToolTip(label221, ToolTipText);
                }
            }
            if (PerfectGunner)
            {
                label123.ForeColor = Color.Green;
                label123.Text = "Perfect Gunner Acquired";
            }
            else
            {
                label123.ForeColor = Color.Red;
                label123.Text = "Perfect Gunner Missing";
            }
            if (TimeSkip.KarateChamp > 999)
            {
                label121.ForeColor = Color.Green;
                label122.ForeColor = Color.Green;
            }
            else
            {
                label121.ForeColor = Color.Red;
                label122.ForeColor = Color.Red;
            }
            if (TimeSkip.ItemSmasher > 99)
            {
                label124.ForeColor = Color.Green;
                label125.ForeColor = Color.Green;
            }
            else
            {
                label124.ForeColor = Color.Red;
                label125.ForeColor = Color.Red;
            }
            if (TimeSkip.CensusTaker > 49)
            {
                label126.ForeColor = Color.Green;
                label127.ForeColor = Color.Green;
            }
            else
            {
                label126.ForeColor = Color.Red;
                label127.ForeColor = Color.Red;
            }
            if (TimeSkip.LegendarySoldier > 9)
            {
                label128.ForeColor = Color.Green;
                label129.ForeColor = Color.Green;
            }
            else
            {
                label128.ForeColor = Color.Red;
                label129.ForeColor = Color.Red;
            }
            if (TimeSkip.cGametask == 8 || TimeSkip.cGametask == 18)
            {
                MarathonRunner = null;
            }
            if (ReducedMarathonRunner.ToString().Length < 4)
            {
                MarathonCount = ReducedMarathonRunner.ToString().Length;
                string t = $"Marathon Runner = 0.{ReducedMarathonRunner} KM";
                if (ReducedMarathonRunner.ToString().Length < 2)
                {
                    t = t.Insert(ReducedMarathonRunner.ToString().Length + 19, "0");
                }
                label130.Text = t;
            }
            if (MarathonRunner != null && MarathonRunner.Length > 3)
            {
                MarathonRunner2 = MarathonRunner.Insert(MarathonCount - 3, ".");
                label130.Text = "Marathon Runner = " + MarathonRunner2 + " KM";
            }
            if (TimeSkip.MarathonRunner > 4219499)
            {
                label130.ForeColor = Color.Green;
                MarathonRunner = ReducedMarathonRunner.ToString();
                MarathonCount = ReducedMarathonRunner.ToString().Length;
                label130.Text = "Marathon Runner = " + MarathonRunner2 + " KM";
            }
            else
            {
                label130.ForeColor = Color.Red;
                MarathonRunner = ReducedMarathonRunner.ToString();
                MarathonCount = ReducedMarathonRunner.ToString().Length;
            }
            label131.Text = $@"PP Stickers = {TimeSkip.PPStickerCount}/100";
            if (TimeSkip.PPStickerCount > 99)
            {
                label131.ForeColor = Color.Green;
            }
            else
            {
                label131.ForeColor = Color.Red;
            }
            label132.Text = $@"Bullet Point = {TimeSkip.BulletPoint}";
            if (TimeSkip.BulletPoint > 999)
            {
                label132.ForeColor = Color.Green;
            }
            else
            {
                label132.ForeColor = Color.Red;
            }
            if (GourmetCount == 39)
            {
                label134.ForeColor = Color.Green;
            }
            else
            {
                label134.ForeColor = Color.Red;
            }
            if (ClothesHorseCount == 46)
            {
                label175.ForeColor = Color.Green;
            }
            else
            {
                label175.ForeColor = Color.Red;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimeSkip.UpdateTimer.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            TimeSkip.UpdatePPStickers();
            Process[] processesByName = Process.GetProcessesByName("DeadRising");
            if (processesByName.Length == 0)
            {
                MyMessageBox.Show("The game process was not detected!\nPlease open the game.", "Error");
                return;
            }
            TimeSkip.GameProcess = processesByName[0];
            label1.Text = string.Format("Connected to PID {0}", processesByName[0].Id.ToString("X8"));
            TimeSkip.UpdateTimer.Elapsed += TimeSkip.UpdateEvent;
            TimeSkip.UpdateTimer.AutoReset = true;
            TimeSkip.UpdateTimer.Enabled = true;
            TimeSkip.form = this;
        }

        public void button2_Click(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeDisplay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label128 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label133 = new System.Windows.Forms.Label();
            this.label134 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.label145 = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.label147 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.label171 = new System.Windows.Forms.Label();
            this.label172 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label174 = new System.Windows.Forms.Label();
            this.label219 = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
            this.label178 = new System.Windows.Forms.Label();
            this.label179 = new System.Windows.Forms.Label();
            this.label180 = new System.Windows.Forms.Label();
            this.label181 = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.label184 = new System.Windows.Forms.Label();
            this.label185 = new System.Windows.Forms.Label();
            this.label186 = new System.Windows.Forms.Label();
            this.label187 = new System.Windows.Forms.Label();
            this.label188 = new System.Windows.Forms.Label();
            this.label189 = new System.Windows.Forms.Label();
            this.label190 = new System.Windows.Forms.Label();
            this.label191 = new System.Windows.Forms.Label();
            this.label192 = new System.Windows.Forms.Label();
            this.label193 = new System.Windows.Forms.Label();
            this.label194 = new System.Windows.Forms.Label();
            this.label195 = new System.Windows.Forms.Label();
            this.label196 = new System.Windows.Forms.Label();
            this.label197 = new System.Windows.Forms.Label();
            this.label198 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.label201 = new System.Windows.Forms.Label();
            this.label202 = new System.Windows.Forms.Label();
            this.label203 = new System.Windows.Forms.Label();
            this.label204 = new System.Windows.Forms.Label();
            this.label205 = new System.Windows.Forms.Label();
            this.label206 = new System.Windows.Forms.Label();
            this.label207 = new System.Windows.Forms.Label();
            this.label208 = new System.Windows.Forms.Label();
            this.label209 = new System.Windows.Forms.Label();
            this.label210 = new System.Windows.Forms.Label();
            this.label211 = new System.Windows.Forms.Label();
            this.label212 = new System.Windows.Forms.Label();
            this.label213 = new System.Windows.Forms.Label();
            this.label214 = new System.Windows.Forms.Label();
            this.label215 = new System.Windows.Forms.Label();
            this.label216 = new System.Windows.Forms.Label();
            this.label217 = new System.Windows.Forms.Label();
            this.label218 = new System.Windows.Forms.Label();
            this.label220 = new System.Windows.Forms.Label();
            this.label175 = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(260, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "The current time is:";
            // 
            // timeDisplay
            // 
            this.timeDisplay.AutoSize = true;
            this.timeDisplay.ForeColor = System.Drawing.Color.White;
            this.timeDisplay.Location = new System.Drawing.Point(284, 14);
            this.timeDisplay.Name = "timeDisplay";
            this.timeDisplay.Size = new System.Drawing.Size(53, 13);
            this.timeDisplay.TabIndex = 5;
            this.timeDisplay.Text = "<missing>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(795, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Security Room";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(825, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Rooftop";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(787, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cultist\'s Hideout";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(758, 172);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Meat Processing Area";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(7, 76);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Paradise Plaza";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 326);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Colby\'s Movieland";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(310, 68);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "North Plaza";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(449, 68);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Wonderland Plaza";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(147, 68);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Entrance Plaza";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(634, 228);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Al Fresca";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(812, 338);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Seon\'s";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(286, 228);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Food Court";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(808, 255);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Crislip\'s";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(754, 26);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 13);
            this.label17.TabIndex = 20;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(772, 68);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 13);
            this.label18.TabIndex = 21;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(746, 117);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 13);
            this.label19.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(772, 145);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 13);
            this.label20.TabIndex = 23;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(772, 200);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(0, 13);
            this.label21.TabIndex = 24;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(759, 228);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 13);
            this.label22.TabIndex = 25;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(753, 283);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 13);
            this.label23.TabIndex = 26;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(746, 310);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 13);
            this.label24.TabIndex = 27;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 89);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 13);
            this.label25.TabIndex = 28;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(7, 103);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 13);
            this.label26.TabIndex = 29;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(7, 117);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(0, 13);
            this.label27.TabIndex = 30;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(7, 131);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(0, 13);
            this.label28.TabIndex = 31;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(7, 145);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(0, 13);
            this.label29.TabIndex = 32;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(7, 158);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(0, 13);
            this.label30.TabIndex = 33;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(7, 172);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(0, 13);
            this.label31.TabIndex = 34;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(7, 186);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(0, 13);
            this.label32.TabIndex = 35;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(7, 200);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(0, 13);
            this.label33.TabIndex = 36;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(7, 214);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(0, 13);
            this.label34.TabIndex = 37;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(7, 228);
            this.label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(0, 13);
            this.label35.TabIndex = 38;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(7, 241);
            this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(0, 13);
            this.label36.TabIndex = 39;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(7, 255);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(0, 13);
            this.label37.TabIndex = 40;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(7, 269);
            this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(0, 13);
            this.label38.TabIndex = 41;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(7, 283);
            this.label39.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(0, 13);
            this.label39.TabIndex = 42;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(7, 297);
            this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(0, 13);
            this.label40.TabIndex = 43;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(7, 310);
            this.label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(0, 13);
            this.label41.TabIndex = 44;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(7, 340);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(0, 13);
            this.label42.TabIndex = 45;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(7, 354);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(0, 13);
            this.label43.TabIndex = 46;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(7, 368);
            this.label44.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(0, 13);
            this.label44.TabIndex = 47;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(7, 382);
            this.label45.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(0, 13);
            this.label45.TabIndex = 48;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(7, 396);
            this.label46.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(0, 13);
            this.label46.TabIndex = 49;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(7, 410);
            this.label47.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(0, 13);
            this.label47.TabIndex = 50;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(7, 423);
            this.label48.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(0, 13);
            this.label48.TabIndex = 51;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.ForeColor = System.Drawing.Color.White;
            this.label49.Location = new System.Drawing.Point(159, 241);
            this.label49.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(66, 13);
            this.label49.TabIndex = 52;
            this.label49.Text = "Leisure Park";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(159, 255);
            this.label50.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(0, 13);
            this.label50.TabIndex = 53;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(159, 269);
            this.label51.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(0, 13);
            this.label51.TabIndex = 54;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(159, 283);
            this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(0, 13);
            this.label52.TabIndex = 55;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(159, 297);
            this.label53.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(0, 13);
            this.label53.TabIndex = 56;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.ForeColor = System.Drawing.Color.White;
            this.label54.Location = new System.Drawing.Point(634, 68);
            this.label54.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(110, 13);
            this.label54.TabIndex = 57;
            this.label54.Text = "Maintanence Tunnels";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(634, 89);
            this.label55.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(0, 13);
            this.label55.TabIndex = 58;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(634, 103);
            this.label56.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(0, 13);
            this.label56.TabIndex = 59;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(634, 117);
            this.label57.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(0, 13);
            this.label57.TabIndex = 60;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(634, 131);
            this.label58.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(0, 13);
            this.label58.TabIndex = 61;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(634, 145);
            this.label59.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(0, 13);
            this.label59.TabIndex = 62;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(466, 89);
            this.label60.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(0, 13);
            this.label60.TabIndex = 63;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(466, 103);
            this.label61.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(0, 13);
            this.label61.TabIndex = 64;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(466, 117);
            this.label62.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(0, 13);
            this.label62.TabIndex = 65;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(466, 131);
            this.label63.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(0, 13);
            this.label63.TabIndex = 66;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(466, 145);
            this.label64.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(0, 13);
            this.label64.TabIndex = 67;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(466, 158);
            this.label65.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(0, 13);
            this.label65.TabIndex = 68;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(466, 172);
            this.label66.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(0, 13);
            this.label66.TabIndex = 69;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(466, 186);
            this.label67.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(0, 13);
            this.label67.TabIndex = 70;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(466, 200);
            this.label68.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(0, 13);
            this.label68.TabIndex = 71;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(466, 214);
            this.label69.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(0, 13);
            this.label69.TabIndex = 72;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(466, 228);
            this.label70.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(0, 13);
            this.label70.TabIndex = 73;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(466, 241);
            this.label71.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(0, 13);
            this.label71.TabIndex = 74;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(466, 255);
            this.label72.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(0, 13);
            this.label72.TabIndex = 75;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(466, 269);
            this.label73.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(0, 13);
            this.label73.TabIndex = 76;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(466, 283);
            this.label74.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(0, 13);
            this.label74.TabIndex = 77;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(319, 89);
            this.label76.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(0, 13);
            this.label76.TabIndex = 79;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(319, 103);
            this.label77.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(0, 13);
            this.label77.TabIndex = 80;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(319, 117);
            this.label78.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(0, 13);
            this.label78.TabIndex = 81;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(319, 131);
            this.label79.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(0, 13);
            this.label79.TabIndex = 82;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(319, 145);
            this.label80.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(0, 13);
            this.label80.TabIndex = 83;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(319, 158);
            this.label81.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(0, 13);
            this.label81.TabIndex = 84;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(319, 172);
            this.label82.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(0, 13);
            this.label82.TabIndex = 85;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(319, 186);
            this.label83.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(0, 13);
            this.label83.TabIndex = 86;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(759, 358);
            this.label85.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(0, 13);
            this.label85.TabIndex = 88;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(767, 379);
            this.label86.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(0, 13);
            this.label86.TabIndex = 89;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(768, 402);
            this.label87.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(0, 13);
            this.label87.TabIndex = 90;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(634, 241);
            this.label88.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(0, 13);
            this.label88.TabIndex = 91;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(634, 255);
            this.label89.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(0, 13);
            this.label89.TabIndex = 92;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(634, 269);
            this.label90.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(0, 13);
            this.label90.TabIndex = 93;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(634, 283);
            this.label91.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(0, 13);
            this.label91.TabIndex = 94;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(634, 297);
            this.label92.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(0, 13);
            this.label92.TabIndex = 95;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(596, 310);
            this.label93.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(0, 13);
            this.label93.TabIndex = 96;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(634, 324);
            this.label94.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(0, 13);
            this.label94.TabIndex = 97;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(634, 338);
            this.label95.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(0, 13);
            this.label95.TabIndex = 98;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(596, 351);
            this.label96.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(0, 13);
            this.label96.TabIndex = 99;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(634, 366);
            this.label97.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(0, 13);
            this.label97.TabIndex = 100;
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(634, 379);
            this.label98.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(0, 13);
            this.label98.TabIndex = 101;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(159, 82);
            this.label100.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(0, 13);
            this.label100.TabIndex = 103;
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(159, 96);
            this.label101.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(0, 13);
            this.label101.TabIndex = 104;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(159, 110);
            this.label102.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(0, 13);
            this.label102.TabIndex = 105;
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(159, 124);
            this.label103.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(0, 13);
            this.label103.TabIndex = 106;
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(159, 137);
            this.label104.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(0, 13);
            this.label104.TabIndex = 107;
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(159, 151);
            this.label105.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(0, 13);
            this.label105.TabIndex = 108;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(159, 165);
            this.label106.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(0, 13);
            this.label106.TabIndex = 109;
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(159, 179);
            this.label107.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(0, 13);
            this.label107.TabIndex = 110;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(159, 193);
            this.label108.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(0, 13);
            this.label108.TabIndex = 111;
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(159, 206);
            this.label109.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(0, 13);
            this.label109.TabIndex = 112;
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(286, 241);
            this.label110.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(0, 13);
            this.label110.TabIndex = 113;
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(286, 255);
            this.label111.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(0, 13);
            this.label111.TabIndex = 114;
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(286, 269);
            this.label112.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(0, 13);
            this.label112.TabIndex = 115;
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(286, 283);
            this.label113.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(0, 13);
            this.label113.TabIndex = 116;
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(286, 297);
            this.label114.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(0, 13);
            this.label114.TabIndex = 117;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(286, 310);
            this.label115.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(0, 13);
            this.label115.TabIndex = 118;
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(286, 324);
            this.label116.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(0, 13);
            this.label116.TabIndex = 119;
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(286, 340);
            this.label117.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(0, 13);
            this.label117.TabIndex = 120;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(286, 354);
            this.label118.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(0, 13);
            this.label118.TabIndex = 121;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(286, 368);
            this.label119.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(0, 13);
            this.label119.TabIndex = 122;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(286, 382);
            this.label75.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(0, 13);
            this.label75.TabIndex = 123;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(319, 200);
            this.label84.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(0, 13);
            this.label84.TabIndex = 124;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.ForeColor = System.Drawing.Color.Red;
            this.label99.Location = new System.Drawing.Point(442, 26);
            this.label99.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(0, 13);
            this.label99.TabIndex = 125;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.ForeColor = System.Drawing.Color.White;
            this.label120.Location = new System.Drawing.Point(508, 26);
            this.label120.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(0, 13);
            this.label120.TabIndex = 126;
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(7, 504);
            this.label121.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(0, 13);
            this.label121.TabIndex = 127;
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(79, 504);
            this.label122.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(0, 13);
            this.label122.TabIndex = 128;
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(759, 504);
            this.label123.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(0, 13);
            this.label123.TabIndex = 129;
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(419, 504);
            this.label124.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(0, 13);
            this.label124.TabIndex = 130;
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(496, 504);
            this.label125.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(0, 13);
            this.label125.TabIndex = 131;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(419, 423);
            this.label126.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(0, 13);
            this.label126.TabIndex = 132;
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(496, 423);
            this.label127.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(0, 13);
            this.label127.TabIndex = 133;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Red;
            this.checkBox1.Location = new System.Drawing.Point(385, -1);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(158, 17);
            this.checkBox1.TabIndex = 134;
            this.checkBox1.Text = "Enable Additional Timeskips";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkBox1_MouseDown);
            this.toolTip1.SetToolTip(this.checkBox1, $"Hotkey is: {Hotkey2}");
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(159, 423);
            this.label128.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(0, 13);
            this.label128.TabIndex = 135;
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(249, 423);
            this.label129.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(0, 13);
            this.label129.TabIndex = 136;
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(634, 423);
            this.label130.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(0, 13);
            this.label130.TabIndex = 137;
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(159, 504);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(0, 13);
            this.label131.TabIndex = 138;
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(596, 504);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(0, 13);
            this.label132.TabIndex = 139;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.Red;
            this.checkBox2.Location = new System.Drawing.Point(554, -1);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(125, 17);
            this.checkBox2.TabIndex = 140;
            this.checkBox2.Text = "Disable All Timeskips";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.ForeColor = System.Drawing.Color.White;
            this.label133.Location = new System.Drawing.Point(551, 26);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(0, 13);
            this.label133.TabIndex = 141;
            this.label133.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label133_MouseDown);
            this.toolTip1.SetToolTip(this.label133, $"Hotkey is: {Hotkey1}");
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Location = new System.Drawing.Point(419, 465);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(0, 13);
            this.label134.TabIndex = 142;
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(632, 472);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(0, 13);
            this.label135.TabIndex = 143;
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(284, 450);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(0, 13);
            this.label136.TabIndex = 144;
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(772, 423);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(0, 13);
            this.label137.TabIndex = 145;
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(518, 423);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(0, 13);
            this.label138.TabIndex = 146;
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(395, 423);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(0, 13);
            this.label139.TabIndex = 147;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(272, 423);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(0, 13);
            this.label140.TabIndex = 148;
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(147, 517);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(0, 13);
            this.label141.TabIndex = 149;
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Location = new System.Drawing.Point(147, 491);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(0, 13);
            this.label142.TabIndex = 150;
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Location = new System.Drawing.Point(147, 472);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(0, 13);
            this.label143.TabIndex = 151;
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Location = new System.Drawing.Point(147, 450);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(0, 13);
            this.label144.TabIndex = 152;
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Location = new System.Drawing.Point(5, 513);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(0, 13);
            this.label145.TabIndex = 153;
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Location = new System.Drawing.Point(5, 491);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(0, 13);
            this.label146.TabIndex = 154;
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Location = new System.Drawing.Point(5, 472);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(0, 13);
            this.label147.TabIndex = 155;
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Location = new System.Drawing.Point(5, 450);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(0, 13);
            this.label148.TabIndex = 156;
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Location = new System.Drawing.Point(147, 423);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(0, 13);
            this.label149.TabIndex = 157;
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Location = new System.Drawing.Point(632, 450);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(0, 13);
            this.label150.TabIndex = 158;
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Location = new System.Drawing.Point(5, 426);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(0, 13);
            this.label151.TabIndex = 159;
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Location = new System.Drawing.Point(518, 517);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(0, 13);
            this.label152.TabIndex = 160;
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Location = new System.Drawing.Point(5, 396);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(0, 13);
            this.label153.TabIndex = 161;
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Location = new System.Drawing.Point(518, 491);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(0, 13);
            this.label154.TabIndex = 162;
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Location = new System.Drawing.Point(286, 470);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(0, 13);
            this.label155.TabIndex = 163;
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Location = new System.Drawing.Point(518, 470);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(0, 13);
            this.label156.TabIndex = 164;
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Location = new System.Drawing.Point(395, 396);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(0, 13);
            this.label157.TabIndex = 165;
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Location = new System.Drawing.Point(518, 450);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(0, 13);
            this.label158.TabIndex = 166;
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Location = new System.Drawing.Point(395, 517);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(0, 13);
            this.label159.TabIndex = 167;
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Location = new System.Drawing.Point(632, 396);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(0, 13);
            this.label160.TabIndex = 168;
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Location = new System.Drawing.Point(758, 517);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(0, 13);
            this.label161.TabIndex = 169;
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Location = new System.Drawing.Point(758, 491);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(0, 13);
            this.label162.TabIndex = 170;
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Location = new System.Drawing.Point(758, 470);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(0, 13);
            this.label163.TabIndex = 171;
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Location = new System.Drawing.Point(758, 450);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(0, 13);
            this.label164.TabIndex = 172;
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(652, 517);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(0, 13);
            this.label165.TabIndex = 173;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(632, 491);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(0, 13);
            this.label166.TabIndex = 174;
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(395, 491);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(0, 13);
            this.label167.TabIndex = 175;
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(414, 472);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(0, 13);
            this.label168.TabIndex = 176;
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Location = new System.Drawing.Point(395, 450);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(0, 13);
            this.label169.TabIndex = 177;
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Location = new System.Drawing.Point(284, 517);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(0, 13);
            this.label170.TabIndex = 178;
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Location = new System.Drawing.Point(284, 491);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(0, 13);
            this.label171.TabIndex = 179;
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Location = new System.Drawing.Point(147, 396);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(0, 13);
            this.label172.TabIndex = 180;
            // 
            // label173
            // 
            this.label173.AutoSize = true;
            this.label173.Location = new System.Drawing.Point(632, 423);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(0, 13);
            this.label173.TabIndex = 181;
            // 
            // label174
            // 
            this.label174.AutoSize = true;
            this.label174.Location = new System.Drawing.Point(12, 144);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(0, 13);
            this.label174.TabIndex = 182;
            this.toolTip1.SetToolTip(this.label174, "Entrance: Wallington\'s");
            // 
            // label219
            // 
            this.label219.AutoSize = true;
            this.label219.Location = new System.Drawing.Point(720, 193);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(0, 13);
            this.label219.TabIndex = 227;
            this.toolTip1.SetToolTip(this.label219, "Entrance: Men\'s Storehouse");
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Location = new System.Drawing.Point(178, 48);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(0, 13);
            this.label176.TabIndex = 184;
            this.toolTip1.SetToolTip(this.label176, "Entrance: Men\'s Storehouse\nParadise: Cantonbury\'s");
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Location = new System.Drawing.Point(179, 68);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(0, 13);
            this.label177.TabIndex = 185;
            this.toolTip1.SetToolTip(this.label177, "Entrance: Space");
            // 
            // label178
            // 
            this.label178.AutoSize = true;
            this.label178.Location = new System.Drawing.Point(178, 96);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(0, 13);
            this.label178.TabIndex = 186;
            this.toolTip1.SetToolTip(this.label178, "Entrance: In The Closet\nParadise: Tucci\'s of Rome");
            // 
            // label179
            // 
            this.label179.AutoSize = true;
            this.label179.Location = new System.Drawing.Point(179, 120);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(0, 13);
            this.label179.TabIndex = 187;
            this.toolTip1.SetToolTip(this.label179, "Entrance: Distinguished Gentleman");
            // 
            // label180
            // 
            this.label180.AutoSize = true;
            this.label180.Location = new System.Drawing.Point(178, 144);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(0, 13);
            this.label180.TabIndex = 188;
            this.toolTip1.SetToolTip(this.label180, "Entrance: Fashion Fiesta");
            // 
            // label181
            // 
            this.label181.AutoSize = true;
            this.label181.Location = new System.Drawing.Point(179, 168);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(0, 13);
            this.label181.TabIndex = 189;
            this.toolTip1.SetToolTip(this.label181, "Entrance: Women\'s Lib");
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.Location = new System.Drawing.Point(179, 193);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(0, 13);
            this.label182.TabIndex = 190;
            this.toolTip1.SetToolTip(this.label182, "Entrance: Refined Class");
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.Location = new System.Drawing.Point(179, 216);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(0, 13);
            this.label183.TabIndex = 191;
            this.toolTip1.SetToolTip(this.label183, "Entrance: Gromin\'s");
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.Location = new System.Drawing.Point(179, 241);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(0, 13);
            this.label184.TabIndex = 192;
            this.toolTip1.SetToolTip(this.label184, "Wonderland: Modern Businessman");
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Location = new System.Drawing.Point(179, 269);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(0, 13);
            this.label185.TabIndex = 193;
            this.toolTip1.SetToolTip(this.label185, "Entrance: Modern Businessman");
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.Location = new System.Drawing.Point(179, 297);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(0, 13);
            this.label186.TabIndex = 194;
            this.toolTip1.SetToolTip(this.label186, "Entrance: Shootingstar Sporting Goods");
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Location = new System.Drawing.Point(348, 48);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(0, 13);
            this.label187.TabIndex = 195;
            this.toolTip1.SetToolTip(this.label187, "Wonderland: Scuffs N Scrapes");
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Location = new System.Drawing.Point(348, 68);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(0, 13);
            this.label188.TabIndex = 196;
            this.toolTip1.SetToolTip(this.label188, "Wonderland: Small Fry Duds");
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.Location = new System.Drawing.Point(348, 96);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(0, 13);
            this.label189.TabIndex = 197;
            this.toolTip1.SetToolTip(this.label189, "Entrance: Jamming Juvenile\nParadise: Tyke N Tots");
            // 
            // label190
            // 
            this.label190.AutoSize = true;
            this.label190.Location = new System.Drawing.Point(348, 120);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(0, 13);
            this.label190.TabIndex = 198;
            this.toolTip1.SetToolTip(this.label190, "Paradise: Kids Choice Clothing");
            // 
            // label191
            // 
            this.label191.AutoSize = true;
            this.label191.Location = new System.Drawing.Point(348, 145);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(0, 13);
            this.label191.TabIndex = 199;
            this.toolTip1.SetToolTip(this.label191, "Entrance: Ladies\' Space\nWonderland: Casual Gal");
            // 
            // label192
            // 
            this.label192.AutoSize = true;
            this.label192.Location = new System.Drawing.Point(348, 168);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(0, 13);
            this.label192.TabIndex = 200;
            this.toolTip1.SetToolTip(this.label192, "Wonderland: Kokonutz Sports Town");
            // 
            // label193
            // 
            this.label193.AutoSize = true;
            this.label193.Location = new System.Drawing.Point(348, 193);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(0, 13);
            this.label193.TabIndex = 201;
            this.toolTip1.SetToolTip(this.label193, "Entrance: Sports High");
            // 
            // label194
            // 
            this.label194.AutoSize = true;
            this.label194.Location = new System.Drawing.Point(348, 216);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(0, 13);
            this.label194.TabIndex = 202;
            this.toolTip1.SetToolTip(this.label194, "Wonderland: Jason Wayne\'s Sporting Goods/Homerunner\'s");
            // 
            // label195
            // 
            this.label195.AutoSize = true;
            this.label195.Location = new System.Drawing.Point(348, 241);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(0, 13);
            this.label195.TabIndex = 203;
            this.toolTip1.SetToolTip(this.label195, "Entrance: The Shoehorn/Rafael\'s Shoes\nParadise: Shoekin\'s/Cantonbury\'s");
            // 
            // label196
            // 
            this.label196.AutoSize = true;
            this.label196.Location = new System.Drawing.Point(348, 269);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(0, 13);
            this.label196.TabIndex = 204;
            this.toolTip1.SetToolTip(this.label196, "Entrance: Distinguished Gentleman/Rafael\'s Shoes\nParadise: Shoekin\'s");
            // 
            // label197
            // 
            this.label197.AutoSize = true;
            this.label197.Location = new System.Drawing.Point(348, 297);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(0, 13);
            this.label197.TabIndex = 205;
            this.toolTip1.SetToolTip(this.label197, "Entrance: Jason Wayne\'s Sporting Goods\nWonderland: Run Like The Wind");
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(537, 297);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(0, 13);
            this.label198.TabIndex = 206;
            this.toolTip1.SetToolTip(this.label198, "Colby\'s Movieland");
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(508, 269);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(0, 13);
            this.label199.TabIndex = 207;
            this.toolTip1.SetToolTip(this.label199, "North Plaza: Ripper\'s Blades");
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(508, 241);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(0, 13);
            this.label200.TabIndex = 208;
            this.toolTip1.SetToolTip(this.label200, "Entrance: Jason Wayne\'s Sporting Good\nWonderland: Run Like The Wind");
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(537, 216);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(0, 13);
            this.label201.TabIndex = 209;
            this.toolTip1.SetToolTip(this.label201, "Entrance: Jason Wayne\'s Sporting Goods\nParadise: Sportrance\nWonderland: Run Like " +
        "The Wind");
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Location = new System.Drawing.Point(508, 193);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(0, 13);
            this.label202.TabIndex = 210;
            this.toolTip1.SetToolTip(this.label202, "Entrance: Space\nParadise: Cantonbury\'s");
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.Location = new System.Drawing.Point(508, 168);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(0, 13);
            this.label203.TabIndex = 211;
            this.toolTip1.SetToolTip(this.label203, "Entrance: In The Closet\nNorth Plaza: Abandoned Store");
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Location = new System.Drawing.Point(537, 145);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(0, 13);
            this.label204.TabIndex = 212;
            this.toolTip1.SetToolTip(this.label204, "Entrance: In The Closet\nWonderland: Run Like The Wind");
            // 
            // label205
            // 
            this.label205.AutoSize = true;
            this.label205.Location = new System.Drawing.Point(508, 117);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(0, 13);
            this.label205.TabIndex = 213;
            this.toolTip1.SetToolTip(this.label205, "Paradise: Tucci\'s of Rome\nWonderland: Run Like The Wind");
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Location = new System.Drawing.Point(508, 96);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(0, 13);
            this.label206.TabIndex = 214;
            this.toolTip1.SetToolTip(this.label206, "Wonderland: Estelle\'s Fine-Lady Cosmetics");
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Location = new System.Drawing.Point(537, 72);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(0, 13);
            this.label207.TabIndex = 215;
            this.toolTip1.SetToolTip(this.label207, "Wonderland: Estelle\'s Fine-Lady Cosmetics");
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Location = new System.Drawing.Point(566, 47);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(0, 13);
            this.label208.TabIndex = 216;
            this.toolTip1.SetToolTip(this.label208, "Entrance: Estelle\'s Fine Lady Cosmetics");
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Location = new System.Drawing.Point(720, 297);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(0, 13);
            this.label209.TabIndex = 217;
            this.toolTip1.SetToolTip(this.label209, "Paradise: Child\'s Play");
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.Location = new System.Drawing.Point(720, 269);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(0, 13);
            this.label210.TabIndex = 218;
            this.toolTip1.SetToolTip(this.label210, "Paradise: Ye Olde Toybox");
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Location = new System.Drawing.Point(720, 241);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(0, 13);
            this.label211.TabIndex = 219;
            this.toolTip1.SetToolTip(this.label211, "Paradise: Kid\'s Choice Clothing");
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.Location = new System.Drawing.Point(720, 216);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(0, 13);
            this.label212.TabIndex = 220;
            this.toolTip1.SetToolTip(this.label212, "Entrance: Children\'s Castle");
            // 
            // label213
            // 
            this.label213.AutoSize = true;
            this.label213.Location = new System.Drawing.Point(720, 168);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(0, 13);
            this.label213.TabIndex = 221;
            this.toolTip1.SetToolTip(this.label213, "Paradise: Universe of Optics\nWonderland: The Lens Zen");
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Location = new System.Drawing.Point(720, 144);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(0, 13);
            this.label214.TabIndex = 222;
            this.toolTip1.SetToolTip(this.label214, "Paradise: Universe of Optics");
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Location = new System.Drawing.Point(720, 120);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(0, 13);
            this.label215.TabIndex = 223;
            this.toolTip1.SetToolTip(this.label215, "Paradise: Universe of Optic\nWonderland: The Lens Zen\nAl Fresca: Eyes Like Us");
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Location = new System.Drawing.Point(720, 96);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(0, 13);
            this.label216.TabIndex = 224;
            this.toolTip1.SetToolTip(this.label216, "Entrance: Outta Sight\nAl Fresca: Eyes Like Us");
            // 
            // label217
            // 
            this.label217.AutoSize = true;
            this.label217.Location = new System.Drawing.Point(720, 72);
            this.label217.Name = "label217";
            this.label217.Size = new System.Drawing.Size(0, 13);
            this.label217.TabIndex = 225;
            this.toolTip1.SetToolTip(this.label217, "Entrance: Outta Sight\nParadise:Universe of Optic\nAl Fresca: Eyes Like Us");
            // 
            // label218
            // 
            this.label218.AutoSize = true;
            this.label218.Location = new System.Drawing.Point(720, 47);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(0, 13);
            this.label218.TabIndex = 226;
            this.toolTip1.SetToolTip(this.label218, "Entrance: Outta Sight\nParadise: Universe of Optics\nWonderland: The Lens Zen\nAl Fr" +
        "esca: Eyes Like Us");
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(12, 214);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(0, 13);
            this.label220.TabIndex = 228;
            this.toolTip1.SetToolTip(this.label220, "Al Fresca: Brand New U");
            // 
            // label175
            // 
            this.label175.AutoSize = true;
            this.label175.Location = new System.Drawing.Point(159, 465);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(0, 13);
            this.label175.TabIndex = 183;
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Location = new System.Drawing.Point(7, 48);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(0, 13);
            this.label221.TabIndex = 229;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(882, 535);
            this.Controls.Add(this.label221);
            this.Controls.Add(this.label220);
            this.Controls.Add(this.label219);
            this.Controls.Add(this.label218);
            this.Controls.Add(this.label217);
            this.Controls.Add(this.label216);
            this.Controls.Add(this.label215);
            this.Controls.Add(this.label214);
            this.Controls.Add(this.label213);
            this.Controls.Add(this.label212);
            this.Controls.Add(this.label211);
            this.Controls.Add(this.label210);
            this.Controls.Add(this.label209);
            this.Controls.Add(this.label208);
            this.Controls.Add(this.label207);
            this.Controls.Add(this.label206);
            this.Controls.Add(this.label205);
            this.Controls.Add(this.label204);
            this.Controls.Add(this.label203);
            this.Controls.Add(this.label202);
            this.Controls.Add(this.label201);
            this.Controls.Add(this.label200);
            this.Controls.Add(this.label199);
            this.Controls.Add(this.label198);
            this.Controls.Add(this.label197);
            this.Controls.Add(this.label196);
            this.Controls.Add(this.label195);
            this.Controls.Add(this.label194);
            this.Controls.Add(this.label193);
            this.Controls.Add(this.label192);
            this.Controls.Add(this.label191);
            this.Controls.Add(this.label190);
            this.Controls.Add(this.label189);
            this.Controls.Add(this.label188);
            this.Controls.Add(this.label187);
            this.Controls.Add(this.label186);
            this.Controls.Add(this.label185);
            this.Controls.Add(this.label184);
            this.Controls.Add(this.label183);
            this.Controls.Add(this.label182);
            this.Controls.Add(this.label181);
            this.Controls.Add(this.label180);
            this.Controls.Add(this.label179);
            this.Controls.Add(this.label178);
            this.Controls.Add(this.label177);
            this.Controls.Add(this.label176);
            this.Controls.Add(this.label175);
            this.Controls.Add(this.label174);
            this.Controls.Add(this.label173);
            this.Controls.Add(this.label172);
            this.Controls.Add(this.label171);
            this.Controls.Add(this.label170);
            this.Controls.Add(this.label169);
            this.Controls.Add(this.label168);
            this.Controls.Add(this.label167);
            this.Controls.Add(this.label166);
            this.Controls.Add(this.label165);
            this.Controls.Add(this.label164);
            this.Controls.Add(this.label163);
            this.Controls.Add(this.label162);
            this.Controls.Add(this.label161);
            this.Controls.Add(this.label160);
            this.Controls.Add(this.label159);
            this.Controls.Add(this.label158);
            this.Controls.Add(this.label157);
            this.Controls.Add(this.label156);
            this.Controls.Add(this.label155);
            this.Controls.Add(this.label154);
            this.Controls.Add(this.label153);
            this.Controls.Add(this.label152);
            this.Controls.Add(this.label151);
            this.Controls.Add(this.label150);
            this.Controls.Add(this.label149);
            this.Controls.Add(this.label148);
            this.Controls.Add(this.label147);
            this.Controls.Add(this.label146);
            this.Controls.Add(this.label145);
            this.Controls.Add(this.label144);
            this.Controls.Add(this.label143);
            this.Controls.Add(this.label142);
            this.Controls.Add(this.label141);
            this.Controls.Add(this.label140);
            this.Controls.Add(this.label139);
            this.Controls.Add(this.label138);
            this.Controls.Add(this.label137);
            this.Controls.Add(this.label136);
            this.Controls.Add(this.label135);
            this.Controls.Add(this.label134);
            this.Controls.Add(this.label133);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label132);
            this.Controls.Add(this.label131);
            this.Controls.Add(this.label130);
            this.Controls.Add(this.label129);
            this.Controls.Add(this.label128);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label127);
            this.Controls.Add(this.label126);
            this.Controls.Add(this.label125);
            this.Controls.Add(this.label124);
            this.Controls.Add(this.label123);
            this.Controls.Add(this.label122);
            this.Controls.Add(this.label121);
            this.Controls.Add(this.label120);
            this.Controls.Add(this.label99);
            this.Controls.Add(this.label84);
            this.Controls.Add(this.label75);
            this.Controls.Add(this.label119);
            this.Controls.Add(this.label118);
            this.Controls.Add(this.label117);
            this.Controls.Add(this.label116);
            this.Controls.Add(this.label115);
            this.Controls.Add(this.label114);
            this.Controls.Add(this.label113);
            this.Controls.Add(this.label112);
            this.Controls.Add(this.label111);
            this.Controls.Add(this.label110);
            this.Controls.Add(this.label109);
            this.Controls.Add(this.label108);
            this.Controls.Add(this.label107);
            this.Controls.Add(this.label106);
            this.Controls.Add(this.label105);
            this.Controls.Add(this.label104);
            this.Controls.Add(this.label103);
            this.Controls.Add(this.label102);
            this.Controls.Add(this.label101);
            this.Controls.Add(this.label100);
            this.Controls.Add(this.label98);
            this.Controls.Add(this.label97);
            this.Controls.Add(this.label96);
            this.Controls.Add(this.label95);
            this.Controls.Add(this.label94);
            this.Controls.Add(this.label93);
            this.Controls.Add(this.label92);
            this.Controls.Add(this.label91);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.label89);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.label86);
            this.Controls.Add(this.label85);
            this.Controls.Add(this.label83);
            this.Controls.Add(this.label82);
            this.Controls.Add(this.label81);
            this.Controls.Add(this.label80);
            this.Controls.Add(this.label79);
            this.Controls.Add(this.label78);
            this.Controls.Add(this.label77);
            this.Controls.Add(this.label76);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeDisplay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            keyboardHook.KeyDown += KeyboardHook_KeyDown;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "100% Timeskip with PP Sticker Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void KeyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            if (Hotkey2 == key.ToString())
            {
                if (TimeSkip.EnableTimeskip == true)
                {
                    checkBox1.Checked = false;
                }
                else
                {
                    checkBox1.Checked = true;
                }
            }
            if (Hotkey1 == key.ToString())
            {
                bool a = false;
                if (CurrentScreen == "PP Collector/Miscellanous")
                {
                    a = true;
                    CurrentScreen = NextTracker;
                    NextTracker = "PP Collector/Miscellanous";
                    label133.Text = $"Click to cycle to {NextTracker}";
                    for (int i = 4; i < 135; i++)
                    {
                        string LabelI = $"label{i}";
                        Label label = this.Controls[LabelI] as Label;
                        label.Visible = false;
                    }
                    for (int i = 135; i < 222; i++)
                    {
                        string LabelI = $"label{i}";
                        Label label = this.Controls[LabelI] as Label;
                        label.Visible = true;
                    }
                }
                label175.Visible = false;
                if (CurrentScreen == "Gourmet/Clothes Horse" && a == false)
                {
                    CurrentScreen = NextTracker;
                    NextTracker = "Gourmet/Clothes Horse";
                    label133.Text = $"Click to cycle to {NextTracker}";
                    for (int i = 4; i < 135; i++)
                    {
                        string LabelI = $"label{i}";
                        Label label = this.Controls[LabelI] as Label;
                        label.Visible = true;
                    }
                    for (int i = 135; i < 222; i++)
                    {
                        string LabelI = $"label{i}";
                        Label label = this.Controls[LabelI] as Label;
                        label.Visible = false;
                    }
                    label175.Visible = true;
                }
                label133.Visible = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                TimeSkip.EnableTimeskip = true;
                checkBox1.ForeColor = Color.LawnGreen;
            }
            else
            {
                TimeSkip.EnableTimeskip = false;
                checkBox1.ForeColor = Color.Red;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                TimeSkip.DisableAllTimeskips = true;
                checkBox2.ForeColor = Color.LawnGreen;
            }
            else
            {
                TimeSkip.DisableAllTimeskips = false;
                checkBox2.ForeColor = Color.Red;
            }
        }

        private void label133_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool a = false;
                if (CurrentScreen == "PP Collector/Miscellanous")
                {
                    a = true;
                    CurrentScreen = NextTracker;
                    NextTracker = "PP Collector/Miscellanous";
                    label133.Text = $"Click to cycle to {NextTracker}";
                    for (int i = 4; i < 135; i++)
                    {
                        string LabelI = $"label{i}";
                        Label label = this.Controls[LabelI] as Label;
                        label.Visible = false;
                    }
                    for (int i = 135; i < 222; i++)
                    {
                        string LabelI = $"label{i}";
                        Label label = this.Controls[LabelI] as Label;
                        label.Visible = true;
                    }
                }
                label175.Visible = false;
                if (CurrentScreen == "Gourmet/Clothes Horse" && a == false)
                {
                    CurrentScreen = NextTracker;
                    NextTracker = "Gourmet/Clothes Horse";
                    label133.Text = $"Click to cycle to {NextTracker}";
                    for (int i = 4; i < 135; i++)
                    {
                        string LabelI = $"label{i}";
                        Label label = this.Controls[LabelI] as Label;
                        label.Visible = true;
                    }
                    for (int i = 135; i < 222; i++)
                    {
                        string LabelI = $"label{i}";
                        Label label = this.Controls[LabelI] as Label;
                        label.Visible = false;
                    }
                    label175.Visible = true;
                }
                label133.Visible = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                ActivateTextbox = true;
                MyMessageBox.Show("\n\nType chosen hotkey into the textbox and click OK to set it!");
                ActivateTextbox = false;
                if (AllowedHotkeys.Contains(TextboxText.ToUpper()))
                {
                    Hotkey1 = TextboxText.ToUpper();
                    toolTip1.SetToolTip(label133, $"Hotkey is: {Hotkey1}");
                    Tracker.Properties.Settings.Default.Hotkey1 = Hotkey1;
                }
                TextboxText = string.Empty;
            }
        }

        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ActivateTextbox = true;
                MyMessageBox.Show("\n\nType chosen hotkey into the textbox and click OK to set it!");
                ActivateTextbox = false;
                if (AllowedHotkeys.Contains(TextboxText.ToUpper()))
                {
                    Hotkey2 = TextboxText.ToUpper();
                    toolTip1.SetToolTip(checkBox1, $"Hotkey is: {Hotkey2}");
                    Tracker.Properties.Settings.Default.Hotkey1 = Hotkey2;
                }
                TextboxText = string.Empty;
            }
        }
    }
    public class MyLabel : Label
    {
        public static Label Set(string Text = "", Font Font = null, Color ForeColor = new Color(), Color BackColor = new Color())
        {
            Label l = new Label();
            l.Text = Text;
            l.Font = SystemFonts.MessageBoxFont;
            l.ForeColor = (ForeColor == new Color()) ? Color.White : ForeColor;
            l.BackColor = (BackColor == new Color()) ? Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32))))) : BackColor;
            l.AutoSize = true;
            return l;
        }
    }
    public class MyButton : Button
    {
        public static Button Set(string Text = "", int Width = 102, int Height = 30, Font Font = null, Color ForeColor = new Color(), Color BackColor = new Color())
        {
            Button b = new Button();
            b.Text = Text;
            b.Width = Width;
            b.Height = Height;
            b.Font = (Font == null) ? new Font("Calibri", 12) : Font;
            b.ForeColor = (ForeColor == new Color()) ? Color.White : ForeColor;
            b.BackColor = (BackColor == new Color()) ? Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32))))) : BackColor;
            b.UseVisualStyleBackColor = (b.BackColor == SystemColors.Control);
            return b;
        }
    }
    public partial class MyMessageBox : Form
    {
        private TextBox textbox;
        private MyMessageBox()
        {
            if (Form1.ActivateTextbox == true)
            {
                this.textbox = new TextBox();
                this.textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
                this.textbox.ForeColor = Color.White;
                this.Controls.Add(this.textbox);
                this.textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textbox_KeyPress);
            }
            this.panText = new FlowLayoutPanel();
            this.panButtons = new FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // panText
            // 
            this.panText.Parent = this;
            this.panText.AutoScroll = true;
            this.panText.AutoSize = true;
            this.panText.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panText.Location = new Point(90, 90);
            this.panText.Margin = new Padding(0);
            this.panText.MaximumSize = new Size(500, 300);
            this.panText.MinimumSize = new Size(120, 50);
            this.panText.Size = new Size(108, 50);
            // 
            // panButtons
            // 
            this.panButtons.AutoSize = true;
            this.panButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panButtons.FlowDirection = FlowDirection.RightToLeft;
            this.panButtons.Location = new Point(89, 89);
            this.panButtons.Margin = new Padding(0);
            this.panButtons.MaximumSize = new Size(580, 150);
            this.panButtons.MinimumSize = new Size(108, 0);
            this.panButtons.Size = new Size(108, 35);
            // 
            // MyMessageBox
            //
            this.BackColor = Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.AutoScaleDimensions = new SizeF(8F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(206, 133);
            this.Controls.Add(this.panButtons);
            this.Controls.Add(this.panText);
            this.Font = SystemFonts.MessageBoxFont;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Margin = new Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new Size(168, 132);
            this.Name = "MyMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
            void textbox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 13)
                {
                    Form1.TextboxText = textbox.Text;
                    Close();
                }
            }
        }
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
        public static string Show(Label Label, string Title = "", List<Button> Buttons = null, PictureBox Image = null)
        {
            List<Label> Labels = new List<Label>();
            Labels.Add(Label);
            return Show(Labels, Title, Buttons, Image);
        }
        public static string Show(string Label, string Title = "", List<Button> Buttons = null, PictureBox Image = null)
        {
            List<Label> Labels = new List<Label>();
            Labels.Add(MyLabel.Set(Label));
            return Show(Labels, Title, Buttons, Image);
        }
        public static string Show(List<Label> Labels = null, string Title = "", List<Button> Buttons = null, PictureBox Image = null)
        {
            if (Labels == null) Labels = new List<Label>();
            if (Labels.Count == 0) Labels.Add(MyLabel.Set(""));
            if (Buttons == null) Buttons = new List<Button>();
            if (Buttons.Count == 0) Buttons.Add(MyButton.Set("OK"));
            List<Button> buttons = new List<Button>(Buttons);
            buttons.Reverse();

            int ImageWidth = 0;
            int ImageHeight = 0;
            int LabelWidth = 0;
            int LabelHeight = 0;
            int ButtonWidth = 0;
            int ButtonHeight = 0;
            int TotalWidth = 0;
            int TotalHeight = 0;

            MyMessageBox mb = new MyMessageBox();

            mb.Text = Title;

            //Labels
            List<int> il = new List<int>();
            mb.panText.Location = new Point(9 + ImageWidth, 9);
            foreach (Label l in Labels)
            {
                mb.panText.Controls.Add(l);
                l.Location = new Point(200, 50);
                l.MaximumSize = new Size(480, 2000);
                il.Add(l.Width);
            }
            int mw = Labels.Max(x => x.Width);
            il.ToString();
            Labels.ForEach(l => l.MinimumSize = new Size(Labels.Max(x => x.Width), 1));
            mb.panText.Height = Labels.Sum(l => l.Height);
            mb.panText.MinimumSize = new Size(Labels.Max(x => x.Width) + mb.ScrollBarWidth(Labels), ImageHeight);
            mb.panText.MaximumSize = new Size(Labels.Max(x => x.Width) + mb.ScrollBarWidth(Labels), 300);
            LabelWidth = mb.panText.Width;
            LabelHeight = mb.panText.Height;

            //Buttons
            foreach (Button b in buttons)
            {
                mb.panButtons.Controls.Add(b);
                b.Location = new Point(3, 3);
                b.TabIndex = Buttons.FindIndex(i => i.Text == b.Text);
                b.Click += new EventHandler(mb.Button_Click);
            }
            ButtonWidth = mb.panButtons.Width;
            ButtonHeight = mb.panButtons.Height;

            //Set Widths
            if (ButtonWidth > ImageWidth + LabelWidth)
            {
                Labels.ForEach(l => l.MinimumSize = new Size(ButtonWidth - ImageWidth - mb.ScrollBarWidth(Labels), 1));
                mb.panText.Height = Labels.Sum(l => l.Height);
                mb.panText.MinimumSize = new Size(Labels.Max(x => x.Width) + mb.ScrollBarWidth(Labels), ImageHeight);
                mb.panText.MaximumSize = new Size(Labels.Max(x => x.Width) + mb.ScrollBarWidth(Labels), 300);
                LabelWidth = mb.panText.Width;
                LabelHeight = mb.panText.Height;
            }
            TotalWidth = ImageWidth + LabelWidth;

            //Set Height
            TotalHeight = LabelHeight + ButtonHeight;

            mb.panButtons.Location = new Point(TotalWidth - ButtonWidth + 9, mb.panText.Location.Y + mb.panText.Height);

            mb.Size = new Size(TotalWidth + 39, TotalHeight + 47);
            mb.ShowDialog();
            return mb.Result;
        }

        private FlowLayoutPanel panText;
        private FlowLayoutPanel panButtons;
        private int ScrollBarWidth(List<Label> Labels)
        {
            return (Labels.Sum(l => l.Height) > 300) ? 23 : 6;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (textbox.Text != null)
                {
                    Form1.TextboxText = textbox.Text;
                }
            }
            catch (NullReferenceException)
            {
                Close();
            }
            Result = ((Button)sender).Text;
            Close();
        }

        private string Result = "";
    }
}