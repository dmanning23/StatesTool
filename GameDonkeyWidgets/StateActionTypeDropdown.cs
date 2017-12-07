using GameDonkeyLib;
using MenuBuddy;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameDonkeyWidgets
{
	public class StateActionTypeDropdown : Dropdown<EActionType>
	{
		#region Properties

		#endregion //Properties

		#region Methods

		public StateActionTypeDropdown(IScreen screen) : base(screen)
		{
			var stateActionValues = Enum.GetValues(typeof(EActionType)).OfType<EActionType>().OrderBy(x => x.ToString());

			foreach (var actionType in stateActionValues)
			{
				var dropitem = new DropdownItem<EActionType>(actionType, this)
				{
					Vertical = VerticalAlignment.Center,
					Horizontal = HorizontalAlignment.Center,
					Size = new Vector2(330f, 48f)
				};

				var label = new Label(actionType.ToString(), FontSize.Small)
				{
					Vertical = VerticalAlignment.Center,
					Horizontal = HorizontalAlignment.Center
				};

				dropitem.AddItem(label);
				AddDropdownItem(dropitem);
			}
		}

		#endregion //Methods
	}
}
