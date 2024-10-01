using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal unsafe class NoReload(string caption) : SwitchItem(caption)
	{
		protected override void OnUpdate()
		{
			uint cur = 0;
			if (GET_CURRENT_PED_WEAPON(PlayerPed, &cur, false, 0, false) && IS_WEAPON_VALID(cur))
			{
				int maxAmmo;
				if (GET_MAX_AMMO(PlayerPed, &maxAmmo, cur))
				{
					SET_PED_AMMO(PlayerPed, cur, maxAmmo);
				}
				maxAmmo = GET_MAX_AMMO_IN_CLIP(PlayerPed, cur, true);
				if (maxAmmo > 0)
				{
					SET_AMMO_IN_CLIP(PlayerPed, cur, maxAmmo);
				}
			}
		}
	}
}
