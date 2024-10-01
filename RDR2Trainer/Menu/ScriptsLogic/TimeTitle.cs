using System;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class TimeTitle(string caption) : TitleItem(caption)
	{
		public override string Text
		{
			get
			{
				return $"{base.Text} {DateTime.Now}";
			}
		}
	}
}
