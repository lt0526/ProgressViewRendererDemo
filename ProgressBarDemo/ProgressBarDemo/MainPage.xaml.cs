using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgressBarDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            MyBtn.Clicked += MyBtn_Clicked;
        }

        private void MyBtn_Clicked(object sender, EventArgs e)
        {
            MyProgress.Progress = 0.5;
        }
    }
}
