using static RDR2Trainer.Native;

namespace RDR2Trainer
{
	internal unsafe static class Function
	{
		public static float Random(float min = 0.0f, float max = 1.0f)
		{
			return Invoke<float>(0xE29F927A961F8AAA, V(min), V(max));
		}

		public static int Random(int min, int max)
		{
			return Invoke<int>(0xD53343AA4FB7DD28, V(min), V(max));
		}

		public static float Sin(float value)
		{
			return Invoke<float>(0x0BADBFA3B172435F, V(value));
		}

		public static float Cos(float value)
		{
			return Invoke<float>(0xD0FFB162F40A139C, V(value));
		}

		public static float Tan(float value)
		{
			return Invoke<float>(0x8C13DB96497B7ABF, V(value));
		}

		public static float ArcSin(float value)
		{
			return Invoke<float>(0x6E3C15D296C15583, V(value));
		}

		public static float ArcCos(float value)
		{
			return Invoke<float>(0x586690F0176DC575, V(value));
		}

		public static float ArcTan(float value)
		{
			return Invoke<float>(0x503054DED0B78027, V(value));
		}

		public static float ArcTan2(float value1, float value2)
		{
			return Invoke<float>(0x965B220A066E3F07, V(value1), V(value2));
		}

		public static float Sqrt(float value)
		{
			return Invoke<float>(0x71D93B57D07F9804, V(value));
		}

		public enum TweenType
		{
			TYPE_LINEAR,
		 	TYPE_QUADRATIC_IN,
		 	TYPE_QUADRATIC_OUT,
		 	TYPE_QUADRATIC_INOUT,
		 	TYPE_CUBIC_IN,
		 	TYPE_CUBIC_OUT,
		 	TYPE_CUBIC_INOUT,
		 	TYPE_QUARTIC_IN,
		 	TYPE_QUARTIC_OUT,
		 	TYPE_QUARTIC_INOUT,
		 	TYPE_QUINTIC_IN,
		 	TYPE_QUINTIC_OUT,
		 	TYPE_QUINTIC_INOUT,
		 	TYPE_EXPONENTIAL_IN,
		 	TYPE_EXPONENTIAL_OUT,
		 	TYPE_EXPONENTIAL_INOUT,
		 	TYPE_SINE_IN,
		 	TYPE_SINE_OUT,
		 	TYPE_SINE_INOUT,
		 	TYPE_CIRCULAR_IN,
		 	TYPE_CIRCULAR_OUT,
		 	TYPE_CIRCULAR_INOUT,
		 	TYPE_BOUNCE_IN,
		 	TYPE_BOUNCE_OUT,
		 	TYPE_BOUNCE_INOUT,
		 	TYPE_CUSTOM
		}
		public static float Tween(float t, float b, float d, TweenType easingCurveType)
		{
			return Invoke<float>(0xEF50E344A8F93784, V(t), V(b), V(d), V((int)easingCurveType));
		}


		public static void DrawText(string text, Vector2 position, Vector2 scale, Color color)
		{
			BG_SET_TEXT_SCALE(scale.X, scale.Y);
			BG_SET_TEXT_COLOR(color.R, color.G, color.B, color.A);
			BG_DISPLAY_TEXT(text, position.X, position.Y);
		}

		public static void DrawText(string text, float positionX, float positionY, float scaleX, float scaleY, Color color)
		{
			BG_SET_TEXT_SCALE(scaleX, scaleY);
			BG_SET_TEXT_COLOR(color.R, color.G, color.B, color.A);
			BG_DISPLAY_TEXT(text, positionX, positionY);
		}

		public static void DrawBackground(Vector2 position, float width, float height, Color color)
		{
			DRAW_RECT(position.X, position.Y, width, height, color.R, color.G, color.B, color.A, 1, 1);
		}

		// Draws a rectangle on the screen.
		// -x: The relative X point of the center of the rectangle. (0.0-1.0, 0.0 is the left edge of the screen, 1.0 is the right edge of the screen)
		// -y: The relative Y point of the center of the rectangle. (0.0-1.0, 0.0 is the top edge of the screen, 1.0 is the bottom edge of the screen)
		// -width: The relative width of the rectangle. (0.0-1.0, 1.0 means the whole screen width)
		// -height: The relative height of the rectangle. (0.0-1.0, 1.0 means the whole screen height)
		// -R: Red part of the color. (0-255)
		// -G: Green part of the color. (0-255)
		// -B: Blue part of the color. (0-255)
		// -A: Alpha part of the color. (0-255, 0 means totally transparent, 255 means totally opaque)
		public static void DRAW_RECT(float x, float y, float width, float height, int red, int green, int blue, int alpha, int p8, int p9) { Invoke(0x405224591DF02025, V(x), V(y), V(width), V(height), V(red), V(green), V(blue), V(alpha), V(p8), V(p9)); }

		// Note: you must use VAR_STRING
		public static void BG_DISPLAY_TEXT(string text, float x, float y)
		{
			Invoke(0x16794E044C9EFB58, V(text, true), V(x), V(y));
		}

		public static void BG_SET_TEXT_SCALE(float scaleX, float scaleY) { Invoke(0xA1253A3C870B6843, V(scaleX), V(scaleY)); }

		// https://github.com/femga/rdr3_discoveries/tree/master/useful_info_from_rpfs/colours
		public static void BG_SET_TEXT_COLOR(int red, int green, int blue, int alpha) { Invoke(0x16FA5CE47F184F1E, V(red), V(green), V(blue), V(alpha)); }

		// This returns YOUR 'identity' as a Player type.
		// Always returns 0 in story mode.
		public static int PLAYER_ID() { return Invoke<int>(0x217E9DC48139933D); }

		// Returns current player ped
		public static int PLAYER_PED_ID() { return Invoke<int>(0x096275889B8E0EE0); }

		public static bool MONEY_INCREMENT_CASH_BALANCE(int amount, uint addReason) { return Invoke<bool>(0xBC3422DC91667621, V(amount), V(addReason)); }
		public static void SET_SUPER_JUMP_THIS_FRAME(int player) { Invoke(0xB3E9BE963F10C445, V(player)); }

		public static bool IS_WAYPOINT_ACTIVE() { return Invoke<bool>(0x202B1BBFC6AB5EE4); }

		public static Vector3 GET_WAYPOINT_COORDS() { return Invoke<Vector3>(0x29B30D07C3F7873B); }

		public static bool IS_PED_ON_MOUNT(int ped) { return Invoke<bool>(0x460BC76A0E10655E, V(ped)); }

		public static int GET_MOUNT(int ped) { return Invoke<int>(0xE7E11B8DCBED1058, V(ped)); }
		// Gets a value indicating whether the specified ped is in any vehicle.
		public static bool IS_PED_IN_ANY_VEHICLE(int ped, bool atGetIn) { return Invoke<bool>(0x997ABD671D25CA0B, V(ped), V(atGetIn)); }

		public static int GET_VEHICLE_PED_IS_USING(int ped) { return Invoke<int>(0x6094AD011A2EA87D, V(ped)); }

		public static bool GET_GROUND_Z_FOR_3D_COORD(float x, float y, float z, float* groundZ, bool p4) { return Invoke<bool>(0x24FA4267BB8D2431, V(x), V(y), V(z), V(groundZ), V(p4)); }

		public static void SET_ENTITY_COORDS_NO_OFFSET(int entity, float xPos, float yPos, float zPos, bool xAxis, bool yAxis, bool zAxis) { Invoke(0x239A3351AC1DA385, V(entity), V(xPos), V(yPos), V(zPos), V(xAxis), V(yAxis), V(zAxis)); }

		public static void SET_ENTITY_COORDS(int entity, float xPos, float yPos, float zPos, bool xAxis, bool yAxis, bool zAxis, bool clearArea) { Invoke(0x06843DA7060A026B, V(entity), V(xPos), V(yPos), V(zPos), V(xAxis), V(yAxis), V(zAxis), V(clearArea)); }

		// Computes a hash for the given string. It is hashed using Jenkins' One-at-a-Time hash algorithm (https://en.wikipedia.org/wiki/Jenkins_hash_function)
		// Note: this implementation is case-insensitive.
		public static uint GET_HASH_KEY(string model) { return Invoke<uint>(0xFD340785ADF8CFB7, V(model)); }

		// Returns whether the specified model exists in the game.
		public static bool IS_MODEL_IN_CDIMAGE(uint model) { return Invoke<bool>(0xD6F3B6D7716CFF8E, V(model)); }

		// Returns whether the specified model is valid
		public static bool IS_MODEL_VALID(uint model) { return Invoke<bool>(0x392C8D8E07B70EFC, V(model)); }

		// Request a model to be loaded into memory.
		public static void REQUEST_MODEL(uint model, bool p1) { Invoke(0xFA28FE3A6246FC30, V(model), V(p1)); }

		// Checks if the specified model has loaded into memory.
		public static bool HAS_MODEL_LOADED(uint model) { return Invoke<bool>(0x1283B8B89DD5D1B6, V(model)); }

		// Offset values are relative to the entity.
		//
		// x = left/right
		// y = forward/backward
		// z = up/down
		public static Vector3 GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS(int entity, float offsetX, float offsetY, float offsetZ) { return Invoke<Vector3>(0x1899F328B0E12848, V(entity), V(offsetX), V(offsetY), V(offsetZ)); }

		public static int CREATE_PED(uint modeluint, float x, float y, float z, float heading, bool isNetwork, bool bScriptHostint, bool p7, bool p8) { return Invoke<int>(0xD49F9B0955C367DE, V(modeluint), V(x), V(y), V(z), V(heading), V(isNetwork), V(bScriptHostint), V(p7), V(p8)); }

		public static void SET_RANDOM_OUTFIT_VARIATION(int ped, bool p1) { Invoke(0x283978A15512B2FE, V(ped), V(p1)); }

		// This is an alias of SET_ENTITY_AS_NO_LONGER_NEEDED.
		public static void SET_PED_AS_NO_LONGER_NEEDED(int* ped) { Invoke(0x2595DD4236549CE3, V(ped)); }

		// Marks the model as no longer needed.
		public static void SET_MODEL_AS_NO_LONGER_NEEDED(uint model) { Invoke(0x4AD96EF928BD4F9A, V(model)); }

		public static void SET_PLAYER_HEALTH_RECHARGE_MULTIPLIER(int player, float regenRate) { Invoke(0x8899C244EBCF70DE, V(player), V(regenRate)); }

		// Sets the entity's health. healthAmount sets the health value to that, and sets the maximum health core value. Setting healthAmount to 0 will kill the entity. entityKilledBy parameter can also be 0
		public static void SET_ENTITY_HEALTH(int entity, int healthAmount, int entityKilledBy) { Invoke(0xAC2767ED8BDFAB15, V(entity), V(healthAmount), V(entityKilledBy)); }

		public static int GET_ENTITY_MAX_HEALTH(int entity, bool p1) { return Invoke<int>(0x15D757606D170C3C, V(entity), V(p1)); }

		// It clears the wetness of the selected Ped/Player. Clothes have to be wet to notice the difference.
		public static void CLEAR_PED_WETNESS(int ped) { Invoke(0x9C720776DAA43E7E, V(ped)); }

		public static void RESTORE_PLAYER_STAMINA(int player, float p1) { Invoke(0xC41F4B6E23FE6A4A, V(player), V(p1)); }

		// Params: p1 = -1 in R* Scripts
		public static void SPECIAL_ABILITY_START_RESTORE(int player, int p1, bool p2) { Invoke(0x1D77B47AFA584E90, V(player), V(p1), V(p2)); }

		// 0.0 <= stamina <= 100.0
		public static void RESTORE_PED_STAMINA(int ped, float stamina) { Invoke(0x675680D089BFA21F, V(ped), V(stamina)); }

		// Returns the model hash from the entity
		public static uint GET_ENTITY_MODEL(int entity) { return Invoke<uint>(0xDA76A9F39210D365, V(entity)); }

		public static bool IS_THIS_MODEL_A_TRAIN(uint model) { return Invoke<bool>(0xFC08C8F8C1EDF174, V(model)); }

		public static void SET_TRAIN_SPEED(int train, float speed) { Invoke(0xDFBA6BBFF7CCAFBB, V(train), V(speed)); }

		public static void SET_TRAIN_CRUISE_SPEED(int train, float speed) { Invoke(0x01021EB2E96B793C, V(train), V(speed)); }

		// Result is in meters per second (m/s)
		public static float GET_ENTITY_SPEED(int entity) { return Invoke<float>(0xFB6BA510A533DF81, V(entity)); }

		public static void SET_VEHICLE_FORWARD_SPEED(int vehicle, float speed) { Invoke(0xF9F92AF49F12F6E7, V(vehicle), V(speed)); }

		public static bool IS_ENTITY_IN_AIR(int entity, uint p1) { return Invoke<bool>(0x886E37EC497200B6, V(entity), V(p1)); }

		// Simply sets you as invincible (Health will not deplete).
		public static void SET_PLAYER_INVINCIBLE(int player, bool toggle) { Invoke(0xFEBEEBC9CBDF4B12, V(player), V(toggle)); }

		// Sets a ped or an object totally invincible. It doesn't take any kind of damage. Peds will not ragdoll on explosions.
		public static void SET_ENTITY_INVINCIBLE(int entity, bool toggle) { Invoke(0xA5C38736C426FCB8, V(entity), V(toggle)); }

		public static void SET_PLAYER_NOISE_MULTIPLIER(int player, float multiplier) { Invoke(0xB5EC6BDAEBCA454C, V(player), V(multiplier)); }

		public static void SET_PLAYER_SNEAKING_NOISE_MULTIPLIER(int player, float multiplier) { Invoke(0x4DE44FA389DCA565, V(player), V(multiplier)); }

		public static void SET_EVERYONE_IGNORE_PLAYER(int player, bool toggle) { Invoke(0x34630A768925B852, V(player), V(toggle)); }

		public static void SET_BOUNTY(int player, int amount) { Invoke(0x093A9D1F72DF0D19, V(player), V(amount)); }

		// Force clears local player's wanted level
		public static void SET_BOUNTY_HUNTER_PURSUIT_CLEARED() { Invoke(0x55F37F5F3F2475E1); }

		public static void SET_WANTED_SCORE(int player, int intensity) { Invoke(0xA80FF73F772ACF6A, V(player), V(intensity)); }

		public static int GET_BOUNTY(int player) { return Invoke<int>(0x54310AAB97B92816, V(player)); }

		public static int GET_WANTED_SCORE(int player) { return Invoke<int>(0xDD5FD601481F648B, V(player)); }

		public static void SET_WANTED_LEVEL_MULTIPLIER(float multiplier) { Invoke(0xD7FA719CB54866C2, V(multiplier)); }

		// Returns the heading of the entity in degrees. Also know as the "Yaw" of an entity.
		public static float GET_ENTITY_HEADING(int entity) { return Invoke<float>(0xC230DD956E2F5507, V(entity)); }

		public static int CREATE_VEHICLE(uint modeluint, float x, float y, float z, float heading, bool isNetwork, bool bScriptHostVeh, bool bDontAutoCreateDraftAnimals, bool p8) { return Invoke<int>(0xAF35D0D2583051B0, V(modeluint), V(x), V(y), V(z), V(heading), V(isNetwork), V(bScriptHostVeh), V(bDontAutoCreateDraftAnimals), V(p8)); }

		// This function sets metadata of type bool to specified entity.
		public static bool DECOR_SET_BOOL(int entity, string propertyName, bool value)
		{
			return Invoke<bool>(0xFE26E4609B1C3772, V(entity), V(propertyName), V(value));
		}

		public static bool SET_VEHICLE_ON_GROUND_PROPERLY(int vehicle, bool p1) { return Invoke<bool>(0x7263332501E07F52, V(vehicle), V(p1)); }

		public static void SET_ENTITY_HEADING(int entity, float heading) { Invoke(0xCF2B9C0645C4651B, V(entity), V(heading)); }

		// Ped: The ped to warp.
		// vehicle: The vehicle to warp the ped into.
		// seatIndex: see CREATE_PED_INSIDE_VEHICLE
		public static void SET_PED_INTO_VEHICLE(int ped, int vehicle, int seatIndex) { Invoke(0xF75B0D629E1C063D, V(ped), V(vehicle), V(seatIndex)); }

		// This is an alias of SET_ENTITY_AS_NO_LONGER_NEEDED.
		public static void SET_VEHICLE_AS_NO_LONGER_NEEDED(int* vehicle) { Invoke(0x629BFA74418D6239, V(vehicle)); }

		// addReason: see _ADD_AMMO_TO_PED
		public static void GIVE_DELAYED_WEAPON_TO_PED(int ped, uint weaponuint, int ammoCount, bool p3, uint addReason) { Invoke(0xB282DC6EBD803C75, V(ped), V(weaponuint), V(ammoCount), V(p3), V(addReason)); }

		public static void SET_PED_AMMO(int ped, uint weaponuint, int ammo) { Invoke(0x14E56BC5B5DB6A19, V(ped), V(weaponuint), V(ammo)); }

		//attachPoint:
		public enum WeaponAttachPoint
		{
			Invalid = -1,  //无效
			FirstHand = 0, //右手
			SecondHand = 1, //左手
			PistolRight = 2, //右手手枪
			MaxHand = 2,	//全部手枪
			PistolLeft = 3, //左手手枪
			Kinfe = 4,     //刀
			Lasso = 5,   //绳套
			Thrower = 6,  //投掷物
			Bow = 7,	//弓
			BowAlternate = 8,  //弓的候补
			Rifle = 9,  //刀
			RifleAlternate = 10,  //刀的候补
			Lantern = 11,  //手提灯
			TempLantern = 12,  //手提灯的候补
			Melee = 13,  //混乱
			MaxSynced = 13,  //最大同步
			Hip = 14,  //臀部
			Boot = 15,  //靴子
			Back = 16,  //后面
			Front = 17,  //前面
			ShouldersLing = 18,  //肩膀
			LeftBreast = 19,  //左胸
			RightBreast = 20,  //右胸
			LeftArmpit = 21, //左腋窝
			RightArmpit = 22, //右腋窝
			LeftArmpitRifle = 23, //左肩的步枪
			Satchel = 24, //包
			LeftArmpitBow = 25, //左肩的弓
			RightHandExtra = 26, //右边
			LeftHandExtra = 27, //左边
			RightHandAux = 28, //右手辅助
			Max = 29 //最大
		}
		public static void SET_CURRENT_PED_WEAPON(int ped, uint weaponuint, bool equipNow, WeaponAttachPoint attachPoint, bool p4, bool p5) { Invoke(0xADF692B254977C0C, V(ped), V(weaponuint), V(equipNow), V((int)attachPoint), V(p4), V(p5)); }

		// This modifies the damage value of your weapon. Whether it is a multiplier or base damage is unknown.
		public static void SET_PLAYER_WEAPON_DAMAGE_MODIFIER(int player, float modifier) { Invoke(0x94D529F7B73D7A85, V(player), V(modifier)); }

		public static void SET_PLAYER_MELEE_WEAPON_DAMAGE_MODIFIER(int player, float modifier) { Invoke(0xE4CB5A3F18170381, V(player), V(modifier)); }

		// attachPoint: see SET_CURRENT_PED_WEAPON
		public static bool GET_CURRENT_PED_WEAPON(int ped, uint* weaponuint, bool p2, int attachPoint, bool p4) { return Invoke<bool>(0x3A87E44BB9A01D54, V(ped), V(weaponuint), V(p2), V(attachPoint), V(p4)); }

		public static bool IS_WEAPON_VALID(uint weaponuint) { return Invoke<bool>(0x937C71165CF334B3, V(weaponuint)); }

		public static bool GET_MAX_AMMO(int ped, int* ammo, uint weaponuint) { return Invoke<bool>(0xDC16122C7A20C933, V(ped), V(ammo), V(weaponuint)); }

		public static int GET_MAX_AMMO_IN_CLIP(int ped, uint weaponuint, bool p2) { return Invoke<int>(0xA38DCFFCEA8962FA, V(ped), V(weaponuint), V(p2)); }

		public static bool SET_AMMO_IN_CLIP(int ped, uint weaponuint, int ammo) { return Invoke<bool>(0xDCD2A934D65CB497, V(ped), V(weaponuint), V(ammo)); }

		public static void SET_PED_DROPS_INVENTORY_WEAPON(int ped, uint weaponuint, float xOffset, float yOffset, float zOffset, int ammoCount) { Invoke(0x208A1888007FC0E6, V(ped), V(weaponuint), V(xOffset), V(yOffset), V(zOffset), V(ammoCount)); }

		public static void ADD_TO_CLOCK_TIME(int hours, int minutes, int seconds) { Invoke(0xAB7C251C7701D336, V(hours), V(minutes), V(seconds)); }

		public static void PAUSE_CLOCK(bool toggle, uint unused) { Invoke(0x4D1A590C92BF377E, V(toggle), V(unused)); }

		// Gets the current ingame hour, expressed without zeros. (09:34 will be represented as 9)
		public static int GET_CLOCK_HOURS() { return Invoke<int>(0xC82CF208C2B19199); }

		// Gets the current ingame clock minute.
		public static int GET_CLOCK_MINUTES() { return Invoke<int>(0x4E162231B823DBBF); }

		// Gets the current ingame clock second. Note that ingame clock seconds change really fast since a day in RDR is only 48 minutes in real life.
		public static int GET_CLOCK_SECONDS() { return Invoke<int>(0xB6101ABE62B5F080); }

		// SET_CLOCK_TIME(12, 34, 56);
		public static void SET_CLOCK_TIME(int hour, int minute, int second) { Invoke(0x3A52C59FFB2DEED8, V(hour), V(minute), V(second)); }

		public static void SET_WEATHER_TYPE_FROZEN(bool toggle) { Invoke(0xD74ACDF7DB8114AF, V(toggle)); }

		public static void SET_WIND_SPEED(float speed) { Invoke(0xD00C2D82DC04A99F, V(speed)); }

		public static void SET_WIND_DIRECTION(float direction) { Invoke(0xB56C4F5F57A45600, V(direction)); }

		public static void CLEAR_OVERRIDE_WEATHER() { Invoke(0x80A398F16FFE3CC3); }

		// https://github.com/femga/rdr3_discoveries/blob/master/weather/weather_types.lua
		public static void SET_WEATHER_TYPE(uint weatherType, bool p1, bool p2, bool transition, float transitionTime, bool p5) { Invoke(0x59174F1AFE095B5A, V(weatherType), V(p1), V(p2), V(transition), V(transitionTime), V(p5)); }

		public static void CLEAR_WEATHER_TYPE_PERSIST() { Invoke(0xD85DFE5C131E4AE9); }

		public static void HIDE_HUD_AND_RADAR_THIS_FRAME() { Invoke(0x36CDD81627A6FCD2); }

		// Sets property to int.
		public static bool DECOR_SET_INT(int entity, string propertyName, int value) { return Invoke<bool>(0xE88F4D7F52A6090F, V(entity), V(propertyName), V(value)); }

		public static void TASK_COMBAT_PED(int ped, int targetint, int p2, int p3) { Invoke(0xF166E48407BAC484, V(ped), V(targetint), V(p2), V(p3)); }

		// Reveals the entire minimap (FOW = Fog of War)
		public static void SET_MINIMAP_HIDE_FOW(bool toggle) { Invoke(0x4B8F743A4A6D2FF8, V(toggle)); }

		public static void RESET_MINIMAP_FOW(uint hash) { Invoke(0xEB3CB3386C775D72, V(hash)); }

		public static void REVEAL_MINIMAP_FOW(uint hash) { Invoke(0xF8096DF9B87246E3, V(hash)); }

		// Returns whether the player can control himself.
		public static bool IS_PLAYER_CONTROL_ON(int player) { return Invoke<bool>(0x7964097FCE4C244B, V(player)); }

		public static void GET_MODEL_DIMENSIONS(uint modeluint, Vector3* minimum, Vector3* maximum) { Invoke(0xDCB8DDD5D054A7E7, V(modeluint), V(minimum), V(maximum)); }

		public static void SHOOT_SINGLE_BULLET_BETWEEN_COORDS(float x1, float y1, float z1, float x2, float y2, float z2, int damage, bool p7, uint weaponuint, int ownerint, bool isAudible, bool isInvisible, float speed, bool p13) { Invoke(0x867654CBC7606F2C, V(x1), V(y1), V(z1), V(x2), V(y2), V(z2), V(damage), V(p7), V(weaponuint), V(ownerint), V(isAudible), V(isInvisible), V(speed), V(p13)); }

		public static bool IS_THIS_MODEL_A_BOAT(uint model) { return Invoke<bool>(0x799CFC7C5B743B15, V(model)); }
	}
}
