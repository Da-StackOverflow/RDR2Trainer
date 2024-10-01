using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerEveryoneIgnored(string caption) : SwitchItem(caption)
	{
		protected override void OnInactive()
		{
			SET_EVERYONE_IGNORE_PLAYER(PlayerID, false);
		}

		protected override void OnUpdate()
		{
			SET_EVERYONE_IGNORE_PLAYER(PlayerID, true);
		}
	}
}
