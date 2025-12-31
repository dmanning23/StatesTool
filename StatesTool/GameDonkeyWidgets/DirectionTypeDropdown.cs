using GameDonkeyLib;
using MenuBuddy;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace StatesTool
{
    public class DirectionTypeDropdown : Dropdown<EDirectionType>
    {
        #region Properties

        #endregion //Properties

        #region Methods

        public DirectionTypeDropdown(IScreen screen) : base(screen)
        {
            OnClick += CreateDropdownList;
            var stateActionValues = Enum.GetValues(typeof(EDirectionType)).OfType<EDirectionType>().OrderBy(x => x.ToString());

            foreach (var actionType in stateActionValues)
            {
                var dropitem = new DropdownItem<EDirectionType>(actionType, this)
                {
                    Vertical = VerticalAlignment.Center,
                    Horizontal = HorizontalAlignment.Center,
                    Size = new Vector2(330f, 48f)
                };

                var label = new Label(actionType.ToString(), screen.Content, FontSize.Small)
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
