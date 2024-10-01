using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerNeverWanted(string caption) : SwitchItem(caption)
	{
		protected override void OnInactive()
		{
			SET_WANTED_LEVEL_MULTIPLIER(1.0f);
		}

		protected override void OnUpdate()
		{
			SET_BOUNTY_HUNTER_PURSUIT_CLEARED();
			SET_BOUNTY(PlayerID, 0);
			SET_WANTED_SCORE(PlayerID, 0);
			SET_WANTED_LEVEL_MULTIPLIER(0.0f);
		}
	}
}
