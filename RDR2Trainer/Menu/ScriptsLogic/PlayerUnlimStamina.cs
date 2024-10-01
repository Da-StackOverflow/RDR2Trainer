using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerUnlimStamina(string caption) : SwitchItem(caption)
	{
		protected override void OnUpdate()
		{
			RESTORE_PLAYER_STAMINA(PlayerID, 100.0f);
		}
	}
}
