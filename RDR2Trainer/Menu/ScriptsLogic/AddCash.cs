using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class AddCash(string caption, int value) : TriggerItem(caption)
	{
		private readonly int _value = value;
		public override void OnExecute()
		{
			MONEY_INCREMENT_CASH_BALANCE(_value, 0x2cd419dc);
		}
	}
}
