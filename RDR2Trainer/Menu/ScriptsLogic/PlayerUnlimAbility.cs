using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerUnlimAbility(string caption) : SwitchItem(caption)
	{
		protected override void OnUpdate()
		{
			SPECIAL_ABILITY_START_RESTORE(PlayerID, -1, false);
		}
	}
}
