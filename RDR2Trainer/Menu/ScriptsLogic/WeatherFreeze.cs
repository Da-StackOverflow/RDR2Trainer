using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class WeatherFreeze(string caption) : SwitchItem(caption)
	{
		protected override void OnActive()
		{
			SET_WEATHER_TYPE_FROZEN(true);
		}

		protected override void OnInactive()
		{
			SET_WEATHER_TYPE_FROZEN(false);
		}

		protected override void OnUpdate()
		{
			
		}
	}
}
