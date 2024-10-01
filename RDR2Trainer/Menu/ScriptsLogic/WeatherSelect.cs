using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal unsafe class WeatherSelect(string caption, ItemInfo weatherInfo) : TriggerItem(caption)
	{
		private readonly ItemInfo _weatherInfo = weatherInfo;

		public override void OnExecute()
		{
			CLEAR_OVERRIDE_WEATHER();
			var weather = GET_HASH_KEY(_weatherInfo.ModelID);
			SET_WEATHER_TYPE(weather, true, true, false, 0.0f, false);
			CLEAR_WEATHER_TYPE_PERSIST();
		}
	}
}
