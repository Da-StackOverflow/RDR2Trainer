using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerTeleportToMarker(string caption) : TriggerItem(caption)
	{
		private static readonly float[] groundCheckHeight = [0.0f, 50.0f, 100.0f, 150.0f, 200.0f, 250.0f, 300.0f, 350.0f, 400.0f, 450.0f, 500.0f, 550.0f, 600.0f, 650.0f, 700.0f, 750.0f, 800.0f];

		public unsafe override void OnExecute()
		{
			if (!IS_WAYPOINT_ACTIVE())
			{
				SetTips("地图没有标记点!");
				return;
			}

			Vector3 coords = GET_WAYPOINT_COORDS();

			int e = PlayerPed;
			if (IS_PED_ON_MOUNT(e))
			{
				e = GET_MOUNT(e);
			}
			else if (IS_PED_IN_ANY_VEHICLE(e, false))
			{
				e = GET_VEHICLE_PED_IS_USING(e);
			}

			if (!GET_GROUND_Z_FOR_3D_COORD(coords.X, coords.Y, 100.0f, &coords.Z, false))
			{

				foreach (float height in groundCheckHeight)
				{
					SET_ENTITY_COORDS_NO_OFFSET(e, coords.X, coords.Y, height, false, false, true);
					WaitAndDraw(100);
					if (GET_GROUND_Z_FOR_3D_COORD(coords.X, coords.Y, height, &coords.Z, false))
					{
						coords.Z += 3.0f;
						break;
					}
				}
			}

			SET_ENTITY_COORDS(e, coords.X, coords.Y, coords.Z, false, false, true, false);
		}
	}
}
