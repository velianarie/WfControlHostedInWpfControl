namespace WfControlHostedInWpfControl
{
    using System;
    using System.Windows.Forms;

    public partial class WindowsFormControl : UserControl
    {
        public WindowsFormControl()
        {
            InitializeComponent();
        }

        public void WorkYourMagic(Person person)
        {
            TextBoxName.Text = person.Name;
            TextBoxAge.Text = Convert.ToString(person.Age);

        }
    }
}
