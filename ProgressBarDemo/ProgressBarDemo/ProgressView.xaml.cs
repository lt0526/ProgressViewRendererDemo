using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgressBarDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProgressView : ContentView
	{
        public double Progress
        {
            set { SetValue(ProgressProperty, value); }
            get { return (double)GetValue(ProgressProperty); }
        }

        public readonly static BindableProperty ProgressProperty = BindableProperty.Create("Progress", typeof(double), typeof(ProgressView), 0.0);

		public ProgressView ()
		{
			InitializeComponent ();
		}
	}
}