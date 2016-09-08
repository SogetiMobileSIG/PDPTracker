using System;
using System.Collections.Generic;
using Hackathon.Spade.Model;
using Xamarin.Forms;

namespace PDPTracker
{
    public partial class ActivityPage : ContentPage
    {
        readonly ActivityViewModel _vm;

        public ActivityPage ()
        {
            InitializeComponent ();
            _vm = new ActivityViewModel (this);
            BindingContext = _vm;

            DescriptionLabel.IsVisible = false;
            DateLabel.IsVisible = false;

            DescriptionEntry.IsVisible = true;
            DescriptionEntry.Placeholder = "Enter description";
            DescriptionEntry.Focus ();

            AddToolbarButtons ("Save");
        }

        public ActivityPage(int actId)
        {
            InitializeComponent ();
            _vm = new ActivityViewModel (this, actId);
            BindingContext = _vm;
            AddToolbarButtons ();
        }

        private void AddToolbarButtons(string name = "Edit")
        {
            var editButton = new ToolbarItem
            {
                Text = name,
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };

            editButton.Clicked += (sender, args) =>
            {
                var button = sender as ToolbarItem;

                if (button == null) return;

                if (string.Equals(button.Text, "Edit"))
                {
                    button.Text = "Save";
                    DescriptionLabel.IsVisible = false;
                    DescriptionEntry.IsVisible = true;
                    DescriptionEntry.Focus();
                }
                else
                {
                    button.Text = "Edit";
                    DescriptionEntry.IsVisible = false;
                    DescriptionLabel.IsVisible = true;
                    DescriptionLabel.Focus();
                    OnSave ();
                }
            };

            ToolbarItems.Add(editButton);
        }

        private void OnSave ()
        {
            _vm.OnSave ();

            DateLabel.IsVisible = true;
        }
    }
}

