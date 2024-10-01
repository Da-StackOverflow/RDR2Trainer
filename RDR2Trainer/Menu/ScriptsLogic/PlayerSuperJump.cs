using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerSuperJump(string caption) : SwitchItem(caption)
	{
		protected override void OnUpdate()
		{
			SET_SUPER_JUMP_THIS_FRAME(PlayerID);
		}
	}
}
