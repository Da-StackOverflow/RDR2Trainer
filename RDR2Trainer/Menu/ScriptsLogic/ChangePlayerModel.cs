using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal unsafe class ChangePlayerModel(string caption, PedInfo info) : TriggerItem(caption)
	{
		private readonly PedInfo _info = info;

		public override void OnExecute()
		{
			var model = GET_HASH_KEY(_info.ModelID);
			if (IS_MODEL_IN_CDIMAGE(model) && IS_MODEL_VALID(model))
			{
				ulong* ptr1 = Native.GetGlobalPtr(0x28) + 0x27;
				ulong* ptr2 = Native.GetGlobalPtr((7 << 18) | 0x1890C) + 2;
				ulong bcp1 = *ptr1;
				ulong bcp2 = *ptr2;
				*ptr1 = *ptr2 = model;
				WaitAndDraw(1000);
				SET_RANDOM_OUTFIT_VARIATION(PlayerPed, true);
				if (GET_ENTITY_MODEL(PlayerPed) != model)
				{
					*ptr1 = bcp1;
					*ptr2 = bcp2;
				}
			}
		}
	}
}
