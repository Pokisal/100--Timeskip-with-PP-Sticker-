using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Timers;
using ReadWriteMemory;

namespace DR_RTM
{

	public static class TimeSkip
	{
		public static double TimerInterval = 16.666666666666668;

		public static Timer UpdateTimer = new Timer(TimerInterval);

		public static Process GameProcess;

		public static Form1 form;

		private static ReadWriteMemory.ProcessMemory gameMemory;

		public static uint CensusTaker = 0u;

		private static IntPtr gameTimePtr;

		private static IntPtr cGametaskPtr;

		private static IntPtr PhotoStatsPtr;

		private static IntPtr TransmissionaryPtr;

		public static int[] ReadPPArray = new int[100];

		public static int[] ReadCensusArray = new int[75];

		public static byte[] ReadGourmetArray = new byte[5];

		public static byte[] ReadClothesHorseArray = new byte[10];

		public static byte[] ReadTransmissionaryArray = new byte[11];

		private const int gameTimeOffset = 408;

		private static uint gameTime;

		private static uint campaignProgress;

		public static uint KarateChamp;

		public static uint ItemSmasher;

		public static uint PerfectGunner;

		public static uint BulletPoint;

		public static uint LegendarySoldier;

		public static uint MarathonRunner;

		private static bool inCutsceneOrLoad;

		private static int loadingRoomId;

		private static byte caseMenuState;

		public static byte cGametask;

		private static dynamic old = new ExpandoObject();

		public static uint PPStickerCount;

		public static bool EnableTimeskip = false;

		public static bool DisableAllTimeskips = false;

		public static void Init()
		{
		}

		public static string StringTime(uint time)
		{
			uint num = time / 108000u % 24u;
			uint num2 = time / 1800u % 60u;
			uint num3 = time / 30u % 60u;
			string text = "AM";
			if (num >= 12)
			{
				text = "PM";
				num %= 12u;
			}
			if (num == 0)
			{
				num = 12u;
			}
			return string.Format("{0}:{1}:{2} {3}", num.ToString("D2"), num2.ToString("D2"), num3.ToString("D2"), text);
		}

		public static void UpdatePPStickers()
		{
			if (ReadPPArray.ElementAt(98) > 0)
			{
				Form1.SecurityBench = "Security Bench Acquired";
			}
			else
			{
				Form1.SecurityBench = "Security Bench Missing";
			}
			if (ReadPPArray.ElementAt(46) > 0)
			{
				Form1.VentPhoto = "Vent Photo Acquired";
			}
			else
			{
				Form1.VentPhoto = "Vent Photo Missing";
			}
			if (ReadPPArray.ElementAt(99) > 0)
			{
				Form1.CultistsTrueEye = "True Eye Sticker Acquired";
			}
			else
			{
				Form1.CultistsTrueEye = "True Eye Sticker Missing";
			}
			if (ReadPPArray.ElementAt(96) > 0)
			{
				Form1.CultistsFoxPoster = "Cultists Fox Acquired";
			}
			else
			{
				Form1.CultistsFoxPoster = "Cultists Fox Missing";
			}
			if (ReadPPArray.ElementAt(79) > 0)
			{
				Form1.CowPoster = "Cow Poster Acquired";
			}
			else
			{
				Form1.CowPoster = "Cow Poster Missing";
			}
			if (ReadPPArray.ElementAt(80) > 0)
			{
				Form1.ConveyorBelt = "Conveyor Belt Acquired";
			}
			else
			{
				Form1.ConveyorBelt = "Conveyor Belt Missing";
			}
			if (ReadPPArray.ElementAt(64) > 0)
			{
				Form1.CrislipsLifestyleSign = "Lifestyle Poster Acquired";
			}
			else
			{
				Form1.CrislipsLifestyleSign = "Lifestyle Poster Missing";
			}
			if (ReadPPArray.ElementAt(65) > 0)
			{
				Form1.CrislipsGardeningSign = "Gardening Poster Acquired";
			}
			else
			{
				Form1.CrislipsGardeningSign = "Gardening Poster Missing";
			}
			if (ReadPPArray.ElementAt(4) > 0)
			{
				Form1.PharmacySign = "Pharmacy Sign Acquired";
			}
			else
			{
				Form1.PharmacySign = "Pharmacy Sign Missing";
			}
			if (ReadPPArray.ElementAt(54) > 0)
			{
				Form1.Seafood = "Seafood Sign Acquired";
			}
			else
			{
				Form1.Seafood = "Seafood Sign Missing";
			}
			if (ReadPPArray.ElementAt(53) > 0)
			{
				Form1.SeonsMeatsSign = "Meats Sign Acquired";
			}
			else
			{
				Form1.SeonsMeatsSign = "Meats Sign Missing";
			}
			if (ReadPPArray.ElementAt(15) > 0)
			{
				Form1.BirdClock = "Bird Clock Acquired";
			}
			else
			{
				Form1.BirdClock = "Bird Clock Missing";
			}
			if (ReadPPArray.ElementAt(40) > 0)
			{
				Form1.ServbotMask = "Servbot Mask Acquired";
			}
			else
			{
				Form1.ServbotMask = "Servbot Mask Missing";
			}
			if (ReadPPArray.ElementAt(39) > 0)
			{
				Form1.ParadiseCDShopPoster = "Wendy Poster Acquired";
			}
			else
			{
				Form1.ParadiseCDShopPoster = "Wendy Poster Missing";
			}
			if (ReadPPArray.ElementAt(56) > 0)
			{
				Form1.KidsChoiceSign = "Kids Choice Sign Acquired";
			}
			else
			{
				Form1.KidsChoiceSign = "Kids Choice Sign Missing";
			}
			if (ReadPPArray.ElementAt(17) > 0)
			{
				Form1.GlassesStoreClock = "Glasses Store Clock Acquired";
			}
			else
			{
				Form1.GlassesStoreClock = "Glasses Store Clock Missing";
			}
			if (ReadPPArray.ElementAt(26) > 0)
			{
				Form1.SkateshopHoop = "Skate Shop Hoop Acquired";
			}
			else
			{
				Form1.SkateshopHoop = "Skate Shop Hoop Missing";
			}
			if (ReadPPArray.ElementAt(55) > 0)
			{
				Form1.ParadiseStaircasePoster = "Staircase Poster Acquired";
			}
			else
			{
				Form1.ParadiseStaircasePoster = "Staircase Poster Missing";
			}
			if (ReadPPArray.ElementAt(0) > 0)
			{
				Form1.ParadiseGreenVase = "Green Vase Acquired";
			}
			else
			{
				Form1.ParadiseGreenVase = "Green Vase Missing";
			}
			if (ReadPPArray.ElementAt(25) > 0)
			{
				Form1.ParadiseRoastmastersSign = "Colombian Sign Acquired";
			}
			else
			{
				Form1.ParadiseRoastmastersSign = "Colombian Sign Missing";
			}
			if (ReadPPArray.ElementAt(34) > 0)
			{
				Form1.ParadiseGreenShirt = "Megaman Shirt Acquired";
			}
			else
			{
				Form1.ParadiseGreenShirt = "Megaman Shirt Missing";
			}
			if (ReadPPArray.ElementAt(16) > 0)
			{
				Form1.ParadiseTeddyBear = "Teddy Bear Acquired";
			}
			else
			{
				Form1.ParadiseTeddyBear = "Teddy Bear Missing";
			}
			if (ReadPPArray.ElementAt(37) > 0)
			{
				Form1.TykeNTotsSign = "TykeNTots Acquired";
			}
			else
			{
				Form1.TykeNTotsSign = "TykeNTots Missing";
			}
			if (ReadPPArray.ElementAt(35) > 0)
			{
				Form1.TunemakersSign = "Tunemakers Acquired";
			}
			else
			{
				Form1.TunemakersSign = "Tunemakers Missing";
			}
			if (ReadPPArray.ElementAt(36) > 0)
			{
				Form1.JillsSandwichesSign = "Jills Sandwiches Acquired";
			}
			else
			{
				Form1.JillsSandwichesSign = "Jills Sandwiches Missing";
			}
			if (ReadPPArray.ElementAt(3) > 0)
			{
				Form1.ColbysSign = "Colbys Sign Acquired";
			}
			else
			{
				Form1.ColbysSign = "Colbys Sign Missing";
			}
			if (ReadPPArray.ElementAt(67) > 0)
			{
				Form1.RatmanPoster = "Ratman Poster Acquired";
			}
			else
			{
				Form1.RatmanPoster = "Ratman Poster Missing";
			}
			if (ReadPPArray.ElementAt(66) > 0)
			{
				Form1.MegamanPoster = "Megaman Poster Acquired";
			}
			else
			{
				Form1.MegamanPoster = "Megaman Poster Missing";
			}
			if (ReadPPArray.ElementAt(70) > 0)
			{
				Form1.MoviePoster1 = "Poster 1 Acquired";
			}
			else
			{
				Form1.MoviePoster1 = "Poster 1 Missing";
			}
			if (ReadPPArray.ElementAt(71) > 0)
			{
				Form1.MoviePoster2 = "Poster 2 Acquired";
			}
			else
			{
				Form1.MoviePoster2 = "Poster 2 Missing";
			}
			if (ReadPPArray.ElementAt(72) > 0)
			{
				Form1.MoviePoster3 = "Poster 3 Acquired";
			}
			else
			{
				Form1.MoviePoster3 = "Poster 3 Missing";
			}
			if (ReadPPArray.ElementAt(73) > 0)
			{
				Form1.MoviePoster4 = "Poster 4 Acquired";
			}
			else
			{
				Form1.MoviePoster4 = "Poster 4 Missing";
			}
			if (ReadPPArray.ElementAt(69) > 0)
			{
				Form1.ColbysFoxPoster1 = "Fox Poster 1 Acquired";
			}
			else
			{
				Form1.ColbysFoxPoster1 = "Fox Poster 1 Missing";
			}
			if (ReadPPArray.ElementAt(68) > 0)
			{
				Form1.ColbysFoxPoster2 = "Fox Poster 2 Acquired";
			}
			else
			{
				Form1.ColbysFoxPoster2 = "Fox Poster 2 Missing";
			}
			if (ReadPPArray.ElementAt(2) > 0)
			{
				Form1.ColbysRatman = "Ratman Acquired";
			}
			else
			{
				Form1.ColbysRatman = "Ratman Missing";
			}
			if (ReadPPArray.ElementAt(33) > 0)
			{
				Form1.NorthClock = "North Face Acquired";
			}
			else
			{
				Form1.NorthClock = "North Face Missing";
			}
			if (ReadPPArray.ElementAt(82) > 0)
			{
				Form1.SouthClock = "South Face Acquired";
			}
			else
			{
				Form1.SouthClock = "South Face Missing";
			}
			if (ReadPPArray.ElementAt(81) > 0)
			{
				Form1.EastClock = "East Face Acquired";
			}
			else
			{
				Form1.EastClock = "East Face Missing";
			}
			if (ReadPPArray.ElementAt(83) > 0)
			{
				Form1.TunnelSign = "Tunnel Sign Acquired";
			}
			else
			{
				Form1.TunnelSign = "Tunnel Sign Missing";
			}
			if (ReadPPArray.ElementAt(78) > 0)
			{
				Form1.Bomb1 = "Bomb 1 Acquired";
			}
			else
			{
				Form1.Bomb1 = "Bomb 1 Missing";
			}
			if (ReadPPArray.ElementAt(75) > 0)
			{
				Form1.Bomb2 = "Bomb 2 Acquired";
			}
			else
			{
				Form1.Bomb2 = "Bomb 2 Missing";
			}
			if (ReadPPArray.ElementAt(74) > 0)
			{
				Form1.Bomb3 = "Bomb 3 Acquired";
			}
			else
			{
				Form1.Bomb3 = "Bomb 3 Missing";
			}
			if (ReadPPArray.ElementAt(76) > 0)
			{
				Form1.Bomb4 = "Bomb 4 Acquired";
			}
			else
			{
				Form1.Bomb4 = "Bomb 4 Missing";
			}
			if (ReadPPArray.ElementAt(77) > 0)
			{
				Form1.Bomb5 = "Bomb 5 Acquired";
			}
			else
			{
				Form1.Bomb5 = "Bomb 5 Missing";
			}
			if (ReadPPArray.ElementAt(8) > 0)
			{
				Form1.BookStoreSign = "Bookstore Sign Acquired";
			}
			else
			{
				Form1.BookStoreSign = "Bookstore Sign Missing";
			}
			if (ReadPPArray.ElementAt(49) > 0)
			{
				Form1.WonderlandNorthPlazaEndRedHouse = "NP End House Acquired";
			}
			else
			{
				Form1.WonderlandNorthPlazaEndRedHouse = "NP End House Missing";
			}
			if (ReadPPArray.ElementAt(50) > 0)
			{
				Form1.BaseballStorePhoto = "Baseball Photo Acquired";
			}
			else
			{
				Form1.BaseballStorePhoto = "Baseball Photo Missing";
			}
			if (ReadPPArray.ElementAt(45) > 0)
			{
				Form1.ScuffsNScrapesShirt = "Kids Shirt Acquired";
			}
			else
			{
				Form1.ScuffsNScrapesShirt = "Kids Shirt Missing";
			}
			if (ReadPPArray.ElementAt(22) > 0)
			{
				Form1.WonderlandWindmill = "Windmill Acquired";
			}
			else
			{
				Form1.WonderlandWindmill = "Windmill Missing";
			}
			if (ReadPPArray.ElementAt(48) > 0)
			{
				Form1.WonderlandFoodCourtEndRedHouse = "FC End House Acquired";
			}
			else
			{
				Form1.WonderlandFoodCourtEndRedHouse = "FC End House Missing";
			}
			if (ReadPPArray.ElementAt(7) > 0)
			{
				Form1.WonderlandFoodCourtEndBunny = "FC End Bunny Acquired";
			}
			else
			{
				Form1.WonderlandFoodCourtEndBunny = "FC End Bunny Missing";
			}
			if (ReadPPArray.ElementAt(60) > 0)
			{
				Form1.SpaceRiderJoSideRocket = "Jo Side Astronaut Acquired";
			}
			else
			{
				Form1.SpaceRiderJoSideRocket = "Jo Side Astronaut Missing";
			}
			if (ReadPPArray.ElementAt(6) > 0)
			{
				Form1.WonderlandGreenBalloon = "Balloon Acquired";
			}
			else
			{
				Form1.WonderlandGreenBalloon = "Balloon Missing";
			}
			if (ReadPPArray.ElementAt(32) > 0)
			{
				Form1.SmallFryDudsPoster = "Duds Poster Acquired";
			}
			else
			{
				Form1.SmallFryDudsPoster = "Duds Poster Missing";
			}
			if (ReadPPArray.ElementAt(57) > 0)
			{
				Form1.KokonutzSign = "Kokonutz Acquired";
			}
			else
			{
				Form1.KokonutzSign = "Kokonutz Missing";
			}
			if (ReadPPArray.ElementAt(61) > 0)
			{
				Form1.SpaceRiderAlien = "Alien Acquired";
			}
			else
			{
				Form1.SpaceRiderAlien = "Alien Missing";
			}
			if (ReadPPArray.ElementAt(59) > 0)
			{
				Form1.SpaceRiderSign = "Space Rider Sign Acquired";
			}
			else
			{
				Form1.SpaceRiderSign = "Space Rider Sign Missing";
			}
			if (ReadPPArray.ElementAt(58) > 0)
			{
				Form1.SpaceRiderRocket = "Adam Side Rocket Acquired";
			}
			else
			{
				Form1.SpaceRiderRocket = "Adam Side Rocket Missing";
			}
			if (ReadPPArray.ElementAt(47) > 0)
			{
				Form1.WonderlandNorthPlazaEndBunny = "NP End Bunny Acquired";
			}
			else
			{
				Form1.WonderlandNorthPlazaEndBunny = "NP End Bunny Missing";
			}
			if (ReadPPArray.ElementAt(28) > 0)
			{
				Form1.ShieldRack = "Shield Rack Acquired";
			}
			else
			{
				Form1.ShieldRack = "Shield Rack Missing";
			}
			if (ReadPPArray.ElementAt(27) > 0)
			{
				Form1.SwordRack = "Sword Rack Acquired";
			}
			else
			{
				Form1.SwordRack = "Sword Rack Missing";
			}
			if (ReadPPArray.ElementAt(23) > 0)
			{
				Form1.SeonsSign = "Seons Sign Acquired";
			}
			else
			{
				Form1.SeonsSign = "Seons Sign Missing";
			}
			if (ReadPPArray.ElementAt(51) > 0)
			{
				Form1.GunstoreShotguns = "Flag Acquired";
			}
			else
			{
				Form1.GunstoreShotguns = "Flag Missing";
			}
			if (ReadPPArray.ElementAt(52) > 0)
			{
				Form1.GunstoreHunter = "Hunter Acquired";
			}
			else
			{
				Form1.GunstoreHunter = "Hunter Missing";
			}
			if (ReadPPArray.ElementAt(29) > 0)
			{
				Form1.GunstoreMoose1 = "Moose 1 Acquired";
			}
			else
			{
				Form1.GunstoreMoose1 = "Moose 1 Missing";
			}
			if (ReadPPArray.ElementAt(30) > 0)
			{
				Form1.GunstoreMoose2 = "Moose 2 Acquired";
			}
			else
			{
				Form1.GunstoreMoose2 = "Moose 2 Missing";
			}
			if (ReadPPArray.ElementAt(5) > 0)
			{
				Form1.NorthPlazaCupid = "Cupid Acquired";
			}
			else
			{
				Form1.NorthPlazaCupid = "Cupid Missing";
			}
			if (ReadPPArray.ElementAt(24) > 0)
			{
				Form1.CrislipsSign = "Crislips Sign Acquired";
			}
			else
			{
				Form1.CrislipsSign = "Crislips Sign Missing";
			}
			if (ReadPPArray.ElementAt(12) > 0)
			{
				Form1.FoodCourtChrisSign = "Main Chris Acquired";
			}
			else
			{
				Form1.FoodCourtChrisSign = "Main Chris Missing";
			}
			if (ReadPPArray.ElementAt(18) > 0)
			{
				Form1.FoodCourtChrisDishes = "Dishes Chris Acquired";
			}
			else
			{
				Form1.FoodCourtChrisDishes = "Dishes Chris Missing";
			}
			if (ReadPPArray.ElementAt(21) > 0)
			{
				Form1.FoodCourtCowboy = "Cowboy Acquired";
			}
			else
			{
				Form1.FoodCourtCowboy = "Cowboy Missing";
			}
			if (ReadPPArray.ElementAt(13) > 0)
			{
				Form1.FoodCourtWillabee = "FC Sign Acquired";
			}
			else
			{
				Form1.FoodCourtWillabee = "FC Sign Missing";
			}
			if (ReadPPArray.ElementAt(14) > 0)
			{
				Form1.FoodCourtBull = "Bull Acquired";
			}
			else
			{
				Form1.FoodCourtBull = "Bull Missing";
			}
			if (ReadPPArray.ElementAt(92) > 0)
			{
				Form1.CentralTacos = "Central Tacos Acquired";
			}
			else
			{
				Form1.CentralTacos = "Central Tacos Missing";
			}
			if (ReadPPArray.ElementAt(93) > 0)
			{
				Form1.TheDarkBean = "Dark Bean Acquired";
			}
			else
			{
				Form1.TheDarkBean = "Dark Bean Missing";
			}
			if (ReadPPArray.ElementAt(19) > 0)
			{
				Form1.MeatyBurger = "Meaty Burger Acquired";
			}
			else
			{
				Form1.MeatyBurger = "Meaty Burger Missing";
			}
			if (ReadPPArray.ElementAt(20) > 0)
			{
				Form1.FrozenDream = "Frozen Dream Acquired";
			}
			else
			{
				Form1.FrozenDream = "Frozen Dream Missing";
			}
			if (ReadPPArray.ElementAt(1) > 0)
			{
				Form1.JadeParadise = "Jade Paradise Acquired";
			}
			else
			{
				Form1.JadeParadise = "Jade Paradise Missing";
			}
			if (ReadPPArray.ElementAt(94) > 0)
			{
				Form1.TeresasOven = "Teresas Oven Acquired";
			}
			else
			{
				Form1.TeresasOven = "Teresas Oven Missing";
			}
			if (ReadPPArray.ElementAt(11) > 0)
			{
				Form1.AlFrescaFoodCourtSign = "FC Sign Acquired";
			}
			else
			{
				Form1.AlFrescaFoodCourtSign = "FC Sign Missing";
			}
			if (ReadPPArray.ElementAt(87) > 0)
			{
				Form1.FlexinBuffPoster = "Buff Poster Acquired";
			}
			else
			{
				Form1.FlexinBuffPoster = "Buff Poster Missing";
			}
			if (ReadPPArray.ElementAt(88) > 0)
			{
				Form1.FlexinSign = "Flexin Sign Acquired";
			}
			else
			{
				Form1.FlexinSign = "Flexin Sign Missing";
			}
			if (ReadPPArray.ElementAt(89) > 0)
			{
				Form1.FlexinTreadmill = "Treadmill Acquired";
			}
			else
			{
				Form1.FlexinTreadmill = "Treadmill Missing";
			}
			if (ReadPPArray.ElementAt(84) > 0)
			{
				Form1.FlexinExerciseBike = "Bike Acquired";
			}
			else
			{
				Form1.FlexinExerciseBike = "Bike Missing";
			}
			if (ReadPPArray.ElementAt(86) > 0)
			{
				Form1.FlexinWeightMachine = "Weight Machine Acquired";
			}
			else
			{
				Form1.FlexinWeightMachine = "Weight Machine Missing";
			}
			if (ReadPPArray.ElementAt(85) > 0)
			{
				Form1.FlexinBehindCounterPosters = "4 Posters Acquired";
			}
			else
			{
				Form1.FlexinBehindCounterPosters = "4 Posters Missing";
			}
			if (ReadPPArray.ElementAt(90) > 0)
			{
				Form1.AlFrescaBrandNewUShoes = "BrandNewU Shoes Acquired";
			}
			else
			{
				Form1.AlFrescaBrandNewUShoes = "BrandNewU Shoes Missing";
			}
			if (ReadPPArray.ElementAt(91) > 0)
			{
				Form1.EyesLikeUsPoster = "Glasses Poster Acquired";
			}
			else
			{
				Form1.EyesLikeUsPoster = "Glasses Poster Missing";
			}
			if (ReadPPArray.ElementAt(9) > 0)
			{
				Form1.AlFrescaRoastmastersSign = "AF Colombian Acquired";
			}
			else
			{
				Form1.AlFrescaRoastmastersSign = "AF Colombian Missing";
			}
			if (ReadPPArray.ElementAt(10) > 0)
			{
				Form1.HamburgerFiefdomPrices = "Fiefdom Prices Acquired";
			}
			else
			{
				Form1.HamburgerFiefdomPrices = "Fiefdom Prices Missing";
			}
			if (ReadPPArray.ElementAt(95) > 0)
			{
				Form1.FrontDoor = "Front Door Acquired";
			}
			else
			{
				Form1.FrontDoor = "Front Door Missing";
			}
			if (ReadPPArray.ElementAt(97) > 0)
			{
				Form1.CampingTent = "Tent Acquired";
			}
			else
			{
				Form1.CampingTent = "Tent Missing";
			}
			if (ReadPPArray.ElementAt(41) > 0)
			{
				Form1.ChildrensCastleBear = "Bears Acquired";
			}
			else
			{
				Form1.ChildrensCastleBear = "Bears Missing";
			}
			if (ReadPPArray.ElementAt(31) > 0)
			{
				Form1.RefinedClassDisplay = "Refined Class Acquired";
			}
			else
			{
				Form1.RefinedClassDisplay = "Refined Class Missing";
			}
			if (ReadPPArray.ElementAt(38) > 0)
			{
				Form1.MrWillabeeClock = "Bee Clock Acquired";
			}
			else
			{
				Form1.MrWillabeeClock = "Bee Clock Missing";
			}
			if (ReadPPArray.ElementAt(62) > 0)
			{
				Form1.EntranceCDShopPoster = "Wendy Poster Acquired";
			}
			else
			{
				Form1.EntranceCDShopPoster = "Wendy Poster Missing";
			}
			if (ReadPPArray.ElementAt(63) > 0)
			{
				Form1.EntranceFoxPoster = "Fox Poster Acquired";
			}
			else
			{
				Form1.EntranceFoxPoster = "Fox Poster Missing";
			}
			if (ReadPPArray.ElementAt(43) > 0)
			{
				Form1.KnickknackeryCrown = "Crown Acquired";
			}
			else
			{
				Form1.KnickknackeryCrown = "Crown Missing";
			}
			if (ReadPPArray.ElementAt(42) > 0)
			{
				Form1.EntranceGreenVase = "Vase Acquired";
			}
			else
			{
				Form1.EntranceGreenVase = "Vase Missing";
			}
			if (ReadPPArray.ElementAt(44) > 0)
			{
				Form1.EntrancePerfumeShopPoster = "Perfume Poster Acquired";
			}
			else
			{
				Form1.EntrancePerfumeShopPoster = "Perfume Poster Missing";
			}
			if (PerfectGunner == 150)
			{
				Form1.PerfectGunner = true;
			}
			if (ReadCensusArray != null)
			{
				uint count = 0;
				for (int i = 0; i < ReadCensusArray.Length; i++)
				{
					if (ReadCensusArray.ElementAt(i) != 0)
					{
						count++;
					}
				}
				CensusTaker = count;
			}
			if (ReadPPArray != null)
			{
				uint count = 0;
				for (int i = 0; i < ReadPPArray.Length; i++)
				{
					if (ReadPPArray.ElementAt(i) != 0)
					{
						count++;
					}
				}
				PPStickerCount = count;
            }
		}

		public static void UpdateEvent(object source, ElapsedEventArgs e)
		{
			if (gameMemory != null && !gameMemory.CheckProcess())
			{
				gameMemory = null;
				UpdateTimer.Enabled = false;
				return;
			}
			if (gameMemory == null)
			{
				gameMemory = new ReadWriteMemory.ProcessMemory(GameProcess);
			}
			if (!gameMemory.IsProcessStarted())
			{
				gameMemory.StartProcess();
			}
			gameTimePtr = gameMemory.Pointer("DeadRising.exe", 26496472, 134592);
			if (gameTimePtr == IntPtr.Zero)
			{
				if (!form.IsDisposed)
				{
					form.TimeDisplayUpdate("<missing>");
				}
				return;
			}
			old.gameTime = gameTime;
			old.campaignProgress = campaignProgress;
			old.inCutsceneOrLoad = inCutsceneOrLoad;
			old.loadingRoomId = loadingRoomId;
			old.caseMenuState = caseMenuState;
			gameTime = gameMemory.ReadUInt(IntPtr.Add(gameTimePtr, 408));
			cGametaskPtr = gameMemory.Pointer("DeadRising.exe", 26496472, 134592);
			PhotoStatsPtr = gameMemory.Pointer("DeadRising.exe", 0x1CF3128, 0x40);
			TransmissionaryPtr = gameMemory.Pointer("DeadRising.exe", 0x1944DD8);
			cGametask = gameMemory.ReadByte(IntPtr.Add(cGametaskPtr, 56));
			ReadPPArray = new int[100].Select((_, i) => gameMemory.ReadInt((IntPtr)(PhotoStatsPtr + 0x6E8 + 4 * i))).ToArray();
			ReadCensusArray = new int[69].Select((_, i) => gameMemory.ReadInt((IntPtr)(PhotoStatsPtr + 0x4ED + 4 * i))).ToArray();
			ReadTransmissionaryArray = new byte[11].Select((_, i) => gameMemory.ReadByte((IntPtr)(TransmissionaryPtr + 0x20F6C + i))).ToArray();
			ReadClothesHorseArray = new byte[10].Select((_, i) => gameMemory.ReadByte((IntPtr)(PhotoStatsPtr + 0x4B4 + i))).ToArray();
			ReadGourmetArray = new byte[5].Select((_, i) => gameMemory.ReadByte((IntPtr)(PhotoStatsPtr + 0x694C + i))).ToArray();
			BulletPoint = gameMemory.ReadUInt(IntPtr.Add(gameMemory.Pointer("DeadRising.exe", 30355752, 64), 26856));
			MarathonRunner = gameMemory.ReadUInt(IntPtr.Add(gameMemory.Pointer("DeadRising.exe", 30355752, 64), 1196));
			KarateChamp = gameMemory.ReadUInt(IntPtr.Add(gameMemory.Pointer("DeadRising.exe", 26582688), 948));
			PerfectGunner = gameMemory.ReadUInt(IntPtr.Add(gameMemory.Pointer("DeadRising.exe", 26503504), -68));
			ItemSmasher = gameMemory.ReadUInt(IntPtr.Add(gameMemory.Pointer("DeadRising.exe", 30355752, 64), 1136));
			LegendarySoldier = gameMemory.ReadUInt(IntPtr.Add(gameMemory.Pointer("DeadRising.exe", 30355752, 64), 26844));
			campaignProgress = gameMemory.ReadUInt(IntPtr.Add(gameMemory.Pointer("DeadRising.exe", 26496472, 134592), 336));
			inCutsceneOrLoad = (gameMemory.ReadByte(IntPtr.Add(gameMemory.Pointer("DeadRising.exe", 26500976), 112)) & 1) == 1;
			loadingRoomId = gameMemory.ReadInt(IntPtr.Add(gameMemory.Pointer("DeadRising.exe", 26500976), 72));
			caseMenuState = gameMemory.ReadByte(IntPtr.Add(gameMemory.Pointer("DeadRising.exe", 26505152, 192600), 386));

			form.TimeDisplayUpdate(StringTime(gameTime));
			if (DisableAllTimeskips != true)
			{
				if (loadingRoomId == 1025 && campaignProgress >= 400 && campaignProgress < 410 && EnableTimeskip == true && old.inCutsceneOrLoad && !inCutsceneOrLoad && gameTime < 10368000)
                {
					gameMemory.WriteUInt(IntPtr.Add(gameTimePtr, 408), 10368001u);
				}
				if (campaignProgress == 340 && EnableTimeskip && gameTime < 9612000 || campaignProgress == 345 && EnableTimeskip && gameTime < 9612000)
				{
					gameMemory.WriteUInt(IntPtr.Add(gameTimePtr, 408), 9612001u);
				}
				if (campaignProgress == 370 && EnableTimeskip && gameTime < 9936000)
				{
					gameMemory.WriteUInt(IntPtr.Add(gameTimePtr, 408), 9936001u);
				}
				if (campaignProgress == 390 && EnableTimeskip && gameTime < 10152000)
				{
					gameMemory.WriteUInt(IntPtr.Add(gameTimePtr, 408), 10152001u);
				}
				if (campaignProgress == 400 && EnableTimeskip && loadingRoomId == 1025 && old.inCutsceneOrLoad && !inCutsceneOrLoad)
				{
					gameMemory.WriteUInt(IntPtr.Add(gameTimePtr, 408), 10260000u);
				}
				if (campaignProgress == 402 && old.inCutsceneOrLoad && !inCutsceneOrLoad && EnableTimeskip)
				{
					gameMemory.WriteUInt(IntPtr.Add(gameTimePtr, 408), gameTime + 18000 + 1);
				}
				if (campaignProgress == 404 && old.inCutsceneOrLoad && !inCutsceneOrLoad && EnableTimeskip)
				{
					gameMemory.WriteUInt(IntPtr.Add(gameTimePtr, 408), 10368001u);
				}
				if ((campaignProgress == 406 && EnableTimeskip) || (campaignProgress == 410 && EnableTimeskip) || (campaignProgress == 415 && EnableTimeskip))
				{
					gameMemory.WriteUInt(IntPtr.Add(gameTimePtr, 408), gameMemory.ReadUInt(IntPtr.Add(gameTimePtr, 408)) + 1);
				}
				if (campaignProgress == 415 && loadingRoomId == 1025 && gameTime > 10368000 && old.inCutsceneOrLoad && !inCutsceneOrLoad)
				{
					gameMemory.WriteUInt(IntPtr.Add(gameTimePtr, 408), 11448000u);
				}
				if (campaignProgress == 420 && loadingRoomId == 288 && old.inCutsceneOrLoad && !inCutsceneOrLoad)
				{
					gameMemory.WriteUInt(IntPtr.Add(gameTimePtr, 408), 11664501u);
				}
			}
		}
	}
}