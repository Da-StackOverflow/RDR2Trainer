using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class VehicleBoost(string caption) : SwitchItem(caption)
	{
		protected override void OnActive()
		{
			SetTips("按住 UP / NUM9 加速 \n Down / NUM6 减速");
		}

		protected override void OnUpdate()
		{
			if (!IS_PED_IN_ANY_VEHICLE(PlayerPed, false))
			{
				return;
			}

			var veh = GET_VEHICLE_PED_IS_USING(PlayerPed);
			var model = GET_ENTITY_MODEL(veh);
			var bTrain = IS_THIS_MODEL_A_TRAIN(model);

			bool bUp = Input.IsUp();
			bool bDown = Input.IsDown();

			if (!bUp && !bDown)
			{
				return;
			}
			float speed;
			if (bTrain)
			{
				speed = bUp ? 30.0f : 0.0f;
				SET_TRAIN_SPEED(veh, speed);
				SET_TRAIN_CRUISE_SPEED(veh, speed);
				return;
			}

			speed = GET_ENTITY_SPEED(veh);
			if (bUp)
			{
				if (speed < 3.0f)
					speed = 3.0f;
				speed += speed * 0.03f;
				SET_VEHICLE_FORWARD_SPEED(veh, speed);
			}
			else
			if (IS_ENTITY_IN_AIR(veh, 0) || speed > 5.0)
			{
				SET_VEHICLE_FORWARD_SPEED(veh, 0.0f);
			}
		}
	}
}
