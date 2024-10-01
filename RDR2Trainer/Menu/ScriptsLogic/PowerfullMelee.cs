using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PowerfullMelee(string caption) : SwitchItem(caption)
	{
		protected override void OnInactive()
		{
			SET_PLAYER_MELEE_WEAPON_DAMAGE_MODIFIER(PlayerID, 1.0f);
		}

		protected override void OnUpdate()
		{
			SET_PLAYER_MELEE_WEAPON_DAMAGE_MODIFIER(PlayerID, 100.0f);
		}
	}
}
