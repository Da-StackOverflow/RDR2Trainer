using RDR2Trainer.Menu.ScriptsLogic;

namespace RDR2Trainer.Menu
{
	internal partial class MenuController
	{
		public Menu CreateMainMenu()
		{
			Menu menu = GetMenu("内置修改器1.0 By Da");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("内置修改器1.0 By Da");
				menu.AddItem(new SubMenu("玩家系统", CreatePlayerMenu()));
				menu.AddItem(new SubMenu("动物系统", CreateAnimalSpawnerMenu()));
				menu.AddItem(new SubMenu("人物系统", CreateHumanSpawnerMenu()));
				menu.AddItem(new SubMenu("载具系统", CreateVehicleSpawnerMenu()));
				menu.AddItem(new SubMenu("武器系统", CreateWeaponMenu()));
				menu.AddItem(new SubMenu("时间系统", CreateTimeMenu()));
				menu.AddItem(new SubMenu("天气系统", CreateWeatherMenu()));
				menu.AddItem(new SubMenu("其他系统", CreateMiscMenu()));
				Register(menu);
				return menu;
			}
		}

		private Menu CreatePlayerTeleportMenu()
		{
			Menu menu = GetMenu("传送");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("传送");
				menu.AddItem(new ShowMapMarkPointValue("显示标记点值"));
				menu.AddItem(new PlayerTeleportToMarker("标记点"));
				menu.AddItem(new PlayerTeleport("马掌望台", new Vector3(-90.81644f, -4.823212f, 95f)));
				menu.AddItem(new PlayerTeleport("犁刀村", new Vector3(-1371.6590f, 2388.5073f, 307.7218f)));
				menu.AddItem(new PlayerTeleport("瓦伦丁", new Vector3(-213.152496f, 691.802979f, 112.37100f)));
				menu.AddItem(new PlayerTeleport("草莓镇", new Vector3(-1725.22143f, -418.11560f, 153.55740f)));
				menu.AddItem(new PlayerTeleport("罗兹", new Vector3(1282.707520f, -1275.7485f, 74.945099f)));
				menu.AddItem(new PlayerTeleport("圣丹尼斯", new Vector3(2336.584961f, -1106.2358f, 44.737598f)));
				menu.AddItem(new PlayerTeleport("翡翠牧场", new Vector3(1332.332642f, 300.425110f, 86.306297f)));
				menu.AddItem(new PlayerTeleport("墨西哥", new Vector3(-5311.2583f, -4612.00f, -10.63389f)));
				menu.AddItem(new PlayerTeleport("瓜玛岛", new Vector3(1315.66381f, -6815.48f, 42.377101f)));
				menu.AddItem(new PlayerTeleport("安尼斯堡", new Vector3(2898.593994f, 1239.85253f, 44.073299f)));
				menu.AddItem(new PlayerTeleport("瓦匹缇印第安人保留地", new Vector3(538.738525f, 2217.46557f, 240.23280f)));
				menu.AddItem(new PlayerTeleport("布彻河村", new Vector3(2552.203613f, 835.510010f, 81.183098f)));
				menu.AddItem(new PlayerTeleport("黑水镇", new Vector3(-798.338379f, -1238.9395f, 43.537899f)));
				menu.AddItem(new PlayerTeleport("比彻斯", new Vector3(-1653.19738f, -1448.8156f, 82.503502f)));
				menu.AddItem(new PlayerTeleport("卡利加种植园", new Vector3(1705.509888f, -1386.3237f, 42.884998f)));
				menu.AddItem(new PlayerTeleport("布雷斯韦特", new Vector3(1011.190674f, -1661.6768f, 45.918301f)));
				menu.AddItem(new PlayerTeleport("范霍恩贸易港", new Vector3(2982.234863f, 445.724915f, 51.491501f)));
				menu.AddItem(new PlayerTeleport("康尔沃煤焦油厂", new Vector3(437.7247920f, 494.582092f, 107.67649f)));
				menu.AddItem(new PlayerTeleport("叉角羚", new Vector3(-2616.57714f, 519.256775f, 144.10809f)));
				menu.AddItem(new PlayerTeleport("曼扎尼塔邮局", new Vector3(-1977.98754f, -1545.6749f, 112.87020f)));
				menu.AddItem(new PlayerTeleport("拉格拉斯", new Vector3(2111.099121f, -662.25317f, 41.259899f)));
				menu.AddItem(new PlayerTeleport("犰狳镇", new Vector3(-3622.65527f, -2586.5795f, -15.36900f)));
				menu.AddItem(new PlayerTeleport("风滚草镇", new Vector3(-5382.39453f, -2940.1596f, 1.582700f)));
				menu.AddItem(new PlayerTeleport("麦克法兰牧场", new Vector3(-2296.26318f, -2454.4101f, 60.969898f)));
				menu.AddItem(new PlayerTeleport("本尼迪克特角", new Vector3(-5269.60400f, -3411.0588f, -23.15930f)));
				Register(menu);
				return menu;
			}
		}

		private Menu CreatePlayerChangeModelMenu(string tittleName, int type)
		{
			Menu menu = GetMenu(tittleName);
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu(tittleName);

				foreach (var modelInfo in ResourcesConfig.PedInfos)
				{
					switch (type)
					{
						case 1:
							if (modelInfo.IsHorse)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 2:
							if (modelInfo.IsDog)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 3:
							if (modelInfo.IsFish)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 4:
							if (modelInfo.IsOtherAnimal)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 5:
							if (modelInfo.IsCutscenePerson)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 6:
							if (modelInfo.IsYoungMale)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 7:
							if (modelInfo.IsMiddleMale)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 8:
							if (modelInfo.IsOldMale)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 9:
							if (modelInfo.IsYoungFemale)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 10:
							if (modelInfo.IsMiddleMale)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 11:
							if (modelInfo.IsOldFemale)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
						case 12:
							if (modelInfo.IsMisc)
							{
								menu.AddItem(new ChangePlayerModel(modelInfo.Name, modelInfo));
							}
							break;
					}
				}
				Register(menu);
				return menu;
			}


		}

		private Menu CreatePlayerChangeModelAnimalMenu()
		{
			Menu menu = GetMenu("变成动物");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("变成动物");
				menu.AddItem(new SubMenu("变成马", CreatePlayerChangeModelMenu("变成马", 1)));
				menu.AddItem(new SubMenu("变成狗", CreatePlayerChangeModelMenu("变成狗", 2)));
				menu.AddItem(new SubMenu("变成鱼", CreatePlayerChangeModelMenu("变成鱼", 3)));
				menu.AddItem(new SubMenu("变成其他", CreatePlayerChangeModelMenu("变成其他", 4)));
				Register(menu);
				return menu;
			}
		}

		private Menu CreatePlayerChangeModelHumanMenu()
		{
			Menu menu = GetMenu("变成人");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("变成人");
				menu.AddItem(new SubMenu("变成剧情人物", CreatePlayerChangeModelMenu("变成CUTSCENE", 5)));
				menu.AddItem(new SubMenu("变成年轻男性", CreatePlayerChangeModelMenu("变成年轻男性", 6)));
				menu.AddItem(new SubMenu("变成中年男性", CreatePlayerChangeModelMenu("变成中年男性", 7)));
				menu.AddItem(new SubMenu("变成老年男性", CreatePlayerChangeModelMenu("变成老年男性", 8)));
				menu.AddItem(new SubMenu("变成年轻女性", CreatePlayerChangeModelMenu("变成年轻女性", 9)));
				menu.AddItem(new SubMenu("变成中年女性", CreatePlayerChangeModelMenu("变成中年女性", 10)));
				menu.AddItem(new SubMenu("变成老年女性", CreatePlayerChangeModelMenu("变成老年女性", 11)));
				menu.AddItem(new SubMenu("变成其他人", CreatePlayerChangeModelMenu("变成其他人", 12)));
				Register(menu);
				return menu;
			}
		}

		private Menu CreatePlayerChangeModelMenu()
		{
			Menu menu = GetMenu("改变自己模型");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("改变自己模型");
				menu.AddItem(new SubMenu("变成动物", CreatePlayerChangeModelAnimalMenu()));
				menu.AddItem(new SubMenu("变成人", CreatePlayerChangeModelHumanMenu()));
				Register(menu);
				return menu;
			}
		}

		private Menu CreatePlayerMenu()
		{
			Menu menu = GetMenu("玩家系统");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("玩家系统");
				menu.AddItem(new SubMenu("传送", CreatePlayerTeleportMenu()));
				menu.AddItem(new SubMenu("改变模型", CreatePlayerChangeModelMenu()));
				menu.AddItem(new PlayerHorseInvincible("马无敌"));
				menu.AddItem(new PlayerHorseUnlimStamina("马无限体力"));
				menu.AddItem(new VehicleBoost("载具加速"));
				menu.AddItem(new PlayerClearWanted("清除赏金", true, false));
				menu.AddItem(new PlayerClearWanted("取消通缉", true, true));
				menu.AddItem(new PlayerNeverWanted("永远不会被通缉"));
				menu.AddItem(new PlayerFix("重置玩家和坐骑所有状态"));
				menu.AddItem(new AddCash("增加金钱1块钱", 1 * 100));
				menu.AddItem(new AddCash("增加金钱10块钱", 10 * 100));
				menu.AddItem(new AddCash("增加金钱100块钱", 100 * 100));
				menu.AddItem(new AddCash("增加金钱1000块钱", 1000 * 100));
				menu.AddItem(new AddCash("增加金钱10000块钱", 10000 * 100));
				menu.AddItem(new PlayerFastHeal("快速恢复生命值"));
				menu.AddItem(new PlayerInvincible("无敌"));
				menu.AddItem(new PlayerUnlimStamina("无限体力"));
				menu.AddItem(new PlayerUnlimAbility("无限死亡之眼"));
				menu.AddItem(new PlayerEveryoneIgnored("所有人忽视自己"));
				menu.AddItem(new PlayerNoiseless("消音"));
				menu.AddItem(new PlayerSuperJump("超级跳"));
				menu.AddItem(new PowerfullGuns("武器爆炸伤害"));
				menu.AddItem(new PowerfullMelee("近战武器伤害增加"));
				menu.AddItem(new NoReload("不用装子弹"));
				Register(menu);
				return menu;
			}
		}

		private Menu CreatePedSpawnerMenu(string tittleName, int type)
		{
			Menu menu = GetMenu(tittleName);
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu(tittleName);
				if (type == 1)
				{
					menu.AddItem(new SpawnHorseRandom("随机产生马匹"));
				}

				foreach (var modelInfo in ResourcesConfig.PedInfos)
				{
					switch (type)
					{
						case 1:
							if (modelInfo.IsHorse)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 2:
							if (modelInfo.IsDog)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 3:
							if (modelInfo.IsFish)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 4:
							if (modelInfo.IsOtherAnimal)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 5:
							if (modelInfo.IsCutscenePerson)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 6:
							if (modelInfo.IsYoungMale)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 7:
							if (modelInfo.IsMiddleMale)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 8:
							if (modelInfo.IsOldMale)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 9:
							if (modelInfo.IsYoungFemale)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 10:
							if (modelInfo.IsMiddleFemale)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 11:
							if (modelInfo.IsOldFemale)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
						case 12:
							if (modelInfo.IsMisc)
							{
								menu.AddItem(new SpawnPed(modelInfo.Name, modelInfo));
							}
							break;
					}
				}
				Register(menu);
				return menu;
			}
		}

		private Menu CreateAnimalSpawnerMenu()
		{
			Menu menu = GetMenu("生成动物");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("生成动物");
				menu.AddItem(new SpawnAnimalRandom("随机生成动物"));
				menu.AddItem(new SubMenu("生成马", CreatePedSpawnerMenu("生成马", 1)));
				menu.AddItem(new SubMenu("生成狗", CreatePedSpawnerMenu("生成狗", 2)));
				menu.AddItem(new SubMenu("生成鱼", CreatePedSpawnerMenu("生成鱼", 3)));
				menu.AddItem(new SubMenu("生成其他动物", CreatePedSpawnerMenu("生成其他动物", 4)));
				Register(menu);
				return menu;
			}
		}

		private  Menu CreateHumanSpawnerMenu()
		{
			Menu menu = GetMenu("生成人物");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("生成人物");
				menu.AddItem(new SpawnPedRandom("随机生成人物"));
				menu.AddItem(new SubMenu("生成特殊人物", CreatePedSpawnerMenu("生成特殊人物", 5)));
				menu.AddItem(new SubMenu("生成年轻男人", CreatePedSpawnerMenu("生成年轻男人", 6)));
				menu.AddItem(new SubMenu("生成中年男人", CreatePedSpawnerMenu("生成中年男人", 7)));
				menu.AddItem(new SubMenu("生成老年男人", CreatePedSpawnerMenu("生成老年男人", 8)));
				menu.AddItem(new SubMenu("生成年轻女人", CreatePedSpawnerMenu("生成年轻女人", 9)));
				menu.AddItem(new SubMenu("生成中年女人", CreatePedSpawnerMenu("生成中年女人", 10)));
				menu.AddItem(new SubMenu("生成老年女人", CreatePedSpawnerMenu("生成老年女人", 11)));
				menu.AddItem(new SubMenu("生成其他人", CreatePedSpawnerMenu("生成其他人", 12)));
				Register(menu);
				return menu;
			}
		}

		private  VehicleType GetVehicleTypeUsingModel(ItemInfo model)
		{
			var hash = Function.GET_HASH_KEY(model.ModelID);
			if (Function.IS_THIS_MODEL_A_BOAT(hash))
			{
				return VehicleType.Boat;
			}
			if (Function.IS_THIS_MODEL_A_TRAIN(hash))
			{
				return VehicleType.TrainType;
			}
			if (model.ModelID == "gatling_gun" || model.ModelID == "gatlingMaxim02" || model.ModelID == "hotchkiss_cannon" || model.ModelID == "breach_cannon")
			{
				return VehicleType.Cannon;
			}
			if (model.ModelID == "hotAirBalloon01")
			{
				return VehicleType.Airbaloon;
			}
			return VehicleType.Wagon;
		}

		private  Menu CreateVehicleSpawnerSubMenu(string tittle, VehicleType type)
		{
			Menu menu = GetMenu(tittle);
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu(tittle);
				foreach (var model in ResourcesConfig.VehicleInfos)
				{
					var modelType = GetVehicleTypeUsingModel(model);
					if (modelType != type)
					{
						continue;
					}
					switch (type)
					{
						case VehicleType.Cannon:
							menu.AddItem(new SpawnVehicle(model.Name, model, new Vector3(0.0f, 3.0f, 0.0f), 0.0f, true));
							break;
						case VehicleType.Airbaloon:
							menu.AddItem(new SpawnVehicle(model.Name, model, new Vector3(0.0f, 5.0f, 0.0f), 0.0f, false));
							break;
						case VehicleType.Boat:
							menu.AddItem(new SpawnVehicle(model.Name, model, new Vector3(0.0f, 10.0f, 0.0f), 90.0f, false));
							break;
						case VehicleType.TrainType:
							menu.AddItem(new SpawnVehicle(model.Name, model, new Vector3(0.0f, 5.0f, -1.0f), 90.0f, false));
							break;
						case VehicleType.Wagon:
							menu.AddItem(new SpawnVehicle(model.Name, model, new Vector3(1.0f, 5.0f, 0.0f), 90.0f, true));
							break;
					}
				}
				Register(menu);
				return menu;
			}
		}

		private  Menu CreateVehicleSpawnerMenu()
		{
			Menu menu = GetMenu("生成载具");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("生成载具");
				menu.AddItem(new SubMenu("生成船", CreateVehicleSpawnerSubMenu("生成船", VehicleType.Boat)));
				menu.AddItem(new SubMenu("生成重型武器", CreateVehicleSpawnerSubMenu("生成重型武器", VehicleType.Cannon)));
				menu.AddItem(new SubMenu("生成火车", CreateVehicleSpawnerSubMenu("生成火车", VehicleType.TrainType)));
				menu.AddItem(new SubMenu("生成有马的马车", CreateVehicleSpawnerSubMenu("生成有人马车", VehicleType.Wagon)));
				menu.AddItem(new SubMenu("生成其他载具", CreateVehicleSpawnerSubMenu("生成其他载具", VehicleType.Airbaloon)));
				Register(menu);
				return menu;
			}
		}

		private  Menu CreateWeaponSelectMenu()
		{
			Menu menu = GetMenu("获得武器");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("获得武器");
				foreach (var info in ResourcesConfig.WeaponInfos)
				{
					menu.AddItem(new GiveWeapon(info.Name, info));
				}
				Register(menu);
				return menu;
			}
		}

		private  Menu CreateWeaponMenu()
		{
			Menu menu = GetMenu("武器系统");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("武器系统");
				menu.AddItem(new SubMenu("获得武器", CreateWeaponSelectMenu()));
				menu.AddItem(new DropCurrentWeapon("丢弃当前武器"));
				Register(menu);
				return menu;
			}
		}

		private  Menu CreateTimeMenu()
		{
			Menu menu = GetMenu("时间系统");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new("时间系统")
				{
					Tittle = new TimeTitle("时间系统")
				};
				menu.AddItem(new TimeAdjust("前进一小时", 1));
				menu.AddItem(new TimeAdjust("前进一小时", 1));
				menu.AddItem(new TimeAdjust("后退一小时", -1));
				menu.AddItem(new TimePause("时间暂停"));
				menu.AddItem(new TimeRealistic("相对于游戏时间的真实时间"));
				menu.AddItem(new TimeSystemSynced("相对于现实世界的真实时间"));
				Register(menu);
				return menu;
			}
		}

		private  Menu CreateWeatherMenu()
		{
			Menu menu = GetMenu("天气系统");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("天气系统");
				menu.AddItem(new WeatherFreeze("保持当前天气"));
				menu.AddItem(new WeatherWind("强风天气"));

				foreach (var weather in ResourcesConfig.WeatherInfos)
				{
					menu.AddItem(new WeatherSelect(weather.Name, weather));
				}
				Register(menu);
				return menu;
			}
		}

		private  Menu CreateMiscMenu()
		{
			Menu menu = GetMenu("其他系统");
			if (menu != null)
			{
				return menu;
			}
			else
			{
				menu = new Menu("其他系统");
				menu.AddItem(new RevealMap("地图全部可见"));
				menu.AddItem(new AddHonor("增加荣誉"));
				menu.AddItem(new HideHud("隐藏 HUD"));
				menu.AddItem(new TransportGuns("HORSE TURRETS", true, true));
				menu.AddItem(new TransportGuns("HORSE CANNONS", true, false));
				menu.AddItem(new TransportGuns("VEHICLE TURRETS", false, true));
				menu.AddItem(new TransportGuns("VEHICLE CANNONS", false, false));
				Register(menu);
				return menu;
			}
		}
	}
}
