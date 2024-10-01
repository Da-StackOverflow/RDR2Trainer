using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerFastHeal(string caption) : SwitchItem(caption)
	{
		protected override void OnInactive()
		{
			SET_PLAYER_HEALTH_RECHARGE_MULTIPLIER(PlayerID, 1.0f);
		}

		protected override void OnUpdate()
		{
			SET_PLAYER_HEALTH_RECHARGE_MULTIPLIER(PlayerID, 1000.0f);
		}
	}
}
