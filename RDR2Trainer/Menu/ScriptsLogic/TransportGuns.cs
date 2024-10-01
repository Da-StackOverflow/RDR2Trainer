using System;
using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal unsafe class TransportGuns(string caption, bool isHorse, bool isBullet) : SwitchItem(caption)
	{
		bool m_isHorse = isHorse;
		bool m_isBullet = isBullet;

		long m_lastShootTime = 0;

		protected override void OnActive()
		{
			SetTips("警告: may cause ERR_GFX_STATE while breaking certain objects\n\nINSERT / NUM+", 5000);
		}

		protected override void OnUpdate()
		{
			if (!Input.IsKeyDown(KeyCode.Add) && !Input.IsKeyDown(KeyCode.Ins))
			{
				return;
			}

			if (m_lastShootTime + (m_isBullet ? 50 : 250) > Native.GetTickCount())
			{
				return;
			}

			if (!IS_PLAYER_CONTROL_ON(PlayerID))
			{
				return;
			}

			int transport;
			if (m_isHorse)
			{
				if (IS_PED_ON_MOUNT(PlayerPed))
				{
					transport = GET_MOUNT(PlayerPed);
				}
				else
				{
					return;
				}
			}

			else
			{
				if (IS_PED_IN_ANY_VEHICLE(PlayerPed, false))
				{
					transport = GET_VEHICLE_PED_IS_USING(PlayerPed);
				}
				else
				{
					return;
				}
			}

			Vector3 v0, v1;
			GET_MODEL_DIMENSIONS(GET_ENTITY_MODEL(transport), &v0, &v1);

			var modelHash = m_isBullet ? 0 : GET_HASH_KEY("S_CANNONBALL");
			var weaponHash = GET_HASH_KEY(m_isBullet ? "WEAPON_TURRET_GATLING" : "WEAPON_TURRET_REVOLVING_CANNON");

			if (modelHash != 0 && !HAS_MODEL_LOADED(modelHash))
			{
				REQUEST_MODEL(modelHash, false);
				while (!HAS_MODEL_LOADED(modelHash))
				{
					Native.Sleep(0);
				}
			}

			Vector3 coords0from = GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS(transport, -(v1.X + 0.25f), v1.Y + 1.25f, 0.1f);
			Vector3 coords1from = GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS(transport, (v1.X + 0.25f), v1.Y + 1.25f, 0.1f);
			Vector3 coords0to = GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS(transport, -v1.X, v1.Y + 100.0f, 0.1f);
			Vector3 coords1to = GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS(transport, v1.X, v1.Y + 100.0f, 0.1f);

			SHOOT_SINGLE_BULLET_BETWEEN_COORDS(coords0from.X, coords0from.Y, coords0from.X,
				coords0to.X, coords0to.Y, coords0to.Z, 250, true, weaponHash, PlayerPed, true, true, -1.0f, false);
			SHOOT_SINGLE_BULLET_BETWEEN_COORDS(coords1from.X, coords1from.Y, coords1from.Z,
				coords1to.X, coords1to.Y, coords1to.Z, 250, true, weaponHash, PlayerPed, true, true, -1.0f, false);

			if (m_isBullet)
			{
				weaponHash = GET_HASH_KEY("WEAPON_SNIPERRIFLE_CARCANO");
				SHOOT_SINGLE_BULLET_BETWEEN_COORDS(coords0from.X, coords0from.Y, coords0from.Z,
					coords0to.X, coords0to.Y, coords0to.Z, 250, true, weaponHash, PlayerPed, true, false, -1.0f, false);
				SHOOT_SINGLE_BULLET_BETWEEN_COORDS(coords1from.X, coords1from.Y, coords1from.Z,
					coords1to.X, coords1to.Y, coords1to.Z, 250, true, weaponHash, PlayerPed, true, false, -1.0f, false);
			}

			m_lastShootTime = Native.GetTickCount();
		}
	}
}
