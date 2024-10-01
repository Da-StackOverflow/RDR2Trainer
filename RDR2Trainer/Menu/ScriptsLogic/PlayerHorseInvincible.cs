using static RDR2Trainer.Function;
namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerHorseInvincible(string caption) : SwitchItem(caption)
	{
		private void SetPlayerHorseInvincible(bool set)
		{
			if (IS_PED_ON_MOUNT(PlayerPed))
			{
				var horse = GET_MOUNT(PlayerPed);
				SET_ENTITY_INVINCIBLE(horse, set);
			}
		}

		protected override void OnInactive()
		{
			SetPlayerHorseInvincible(false);
		}

		protected override void OnUpdate()
		{
			SetPlayerHorseInvincible(true);
		}
	}
}
