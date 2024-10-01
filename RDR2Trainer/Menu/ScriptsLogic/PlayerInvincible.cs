using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerInvincible(string caption) : SwitchItem(caption)
	{
		protected override void OnInactive()
		{
			SET_PLAYER_INVINCIBLE(PlayerID, false);
		}

		protected override void OnUpdate()
		{
			SET_PLAYER_INVINCIBLE(PlayerID, true);
		}
	}
}
