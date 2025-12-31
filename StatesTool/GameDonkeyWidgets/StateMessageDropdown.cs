using MenuBuddy;
using Microsoft.Xna.Framework;
using StateMachineBuddy;

namespace StatesTool
{
    public class StateMessageDropdown : Dropdown<string>
    {
        #region Methods

        public StateMessageDropdown(HybridStateMachine stateMachine, IScreen screen) : base(screen)
        {
            OnClick += CreateDropdownList;

            foreach (var message in stateMachine.Messages)
            {
                var dropitem = new DropdownItem<string>(message, this)
                {
                    Vertical = VerticalAlignment.Center,
                    Horizontal = HorizontalAlignment.Center,
                    Size = new Vector2(330f, 48f)
                };

                var label = new Label(message, screen.Content, FontSize.Small)
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
