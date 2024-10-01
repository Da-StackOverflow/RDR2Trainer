using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal unsafe class DropCurrentWeapon(string caption) : TriggerItem(caption)
	{
		public override void OnExecute()
		{
			uint unarmed = GET_HASH_KEY("WEAPON_UNARMED");
			uint cur = 0;
			if (GET_CURRENT_PED_WEAPON(PlayerPed, &cur, false, 0, false) && IS_WEAPON_VALID(cur) && cur != unarmed)
			{
				SET_PED_DROPS_INVENTORY_WEAPON(PlayerPed, cur, 0.0f, 0.0f, 0.0f, 1);
			}
		}
	}
}
