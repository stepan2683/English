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

        public string CzWord;
        public Words Words;
        public Word Word;

		public MainPage()
		{
			InitializeComponent();

            DB.PrepareDB();
            Words = new Words();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Word = Words.GetRandom();
        }
    }
}
