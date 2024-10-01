using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerNoiseless(string caption) : SwitchItem(caption)
	{
		protected override void OnInactive()
		{
			SET_PLAYER_NOISE_MULTIPLIER(PlayerID, 1.0f);
			SET_PLAYER_SNEAKING_NOISE_MULTIPLIER(PlayerID, 1.0f);
		}

		protected override void OnUpdate()
		{
			SET_PLAYER_NOISE_MULTIPLIER(PlayerID, 0.0f);
			SET_PLAYER_SNEAKING_NOISE_MULTIPLIER(PlayerID, 0.0f);
		}
	}
}
