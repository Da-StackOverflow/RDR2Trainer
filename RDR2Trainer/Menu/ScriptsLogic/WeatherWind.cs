using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class WeatherWind(string caption) : SwitchItem(caption)
	{
		protected override void OnActive()
		{
			SET_WIND_SPEED(50.0f);
			SET_WIND_DIRECTION(GET_ENTITY_HEADING(PlayerPed));
		}

		protected override void OnInactive()
		{
			SET_WIND_SPEED(0.0f);
		}

		protected override void OnUpdate()
		{
			
		}
	}
}
