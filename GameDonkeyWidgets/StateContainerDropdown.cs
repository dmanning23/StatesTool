using GameDonkeyLib;
using MenuBuddy;
using Microsoft.Xna.Framework;

namespace GameDonkeyWidgets
{
	public class StateContainerDropdown : Dropdown<IStateContainer>
	{
		public StateContainerDropdown(IScreen screen) : base(screen)
		{
			OnClick += CreateDropdownList;
		}

		/// <summary>
		/// Add all the bones in an animation container to the control.
		/// </summary>
		/// <param name="container">animation container holding all the bones</param>
		public void AddData(IStateContainer container)
		{
			if (null == container)
			{
				return;
			}

			//clear out all the current items
			Clear();

			foreach (var subContainer in container.StateContainers)
			{
				//add this dude
				var dropitem = new DropdownItem<IStateContainer>(subContainer, this)
				{
					Vertical = VerticalAlignment.Center,
					Horizontal = HorizontalAlignment.Center,
					Size = new Vector2(330f, 48f),
					Clickable = false
				};

				var label = new Label(subContainer.Name, FontSize.Small)
				{
					Vertical = VerticalAlignment.Center,
					Horizontal = HorizontalAlignment.Center
				};

				dropitem.AddItem(label);
				AddDropdownItem(dropitem);
			}
		}
	}
}
