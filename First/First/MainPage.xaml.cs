using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

// WinPhone

namespace First
{
	public partial class MainPage : ContentPage
	{

        public string CzWord { get; set; }
        public string EnWord { get; set; }
        public Words Words;

		public MainPage()
		{
			InitializeComponent();

            DB.PrepareDB();
            Words = new Words();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            if (b.Text == "Start")
            {
                b.Text = "I know";
            }
            


            Word word = Words.GetRandom();
            CzWord = word.WordCZ;
            EnWord = word.WordEN;
        }

        private void ButtonIDK_Clicked(object sender, EventArgs e)
        {

        }

    }
}
