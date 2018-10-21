namespace WfControlHostedInWpfControl
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms.Integration;

    /// <summary>
    /// Interaction logic for WpfControl.xaml
    /// </summary>
    public partial class WpfControl : UserControl
    {
        public static readonly DependencyProperty ComplexPocoProperty = DependencyProperty.Register(
            "ComplexPoco",
            typeof(Person),
            typeof(WpfControl),
            new FrameworkPropertyMetadata(
                default(Person),
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnPropertyChanged));
        
        public WpfControl()
        {
            InitializeComponent();
        }

        public Person ComplexPoco
        {
            get { return (Person)GetValue(ComplexPocoProperty); }
            set { SetValue(ComplexPocoProperty, value); }
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WpfControl thisControl = (WpfControl)d;
            WindowsFormsHost wfHost = thisControl.MyHost;
            WindowsFormControl wf = (WindowsFormControl)wfHost.Child;
            wf.WorkYourMagic((Person)e.NewValue);
        }
    }
}
