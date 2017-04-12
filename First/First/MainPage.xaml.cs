using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

// WinPhone

namespace First
{
	public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        #region properties

        public event PropertyChangedEventHandler PropertyChanged;

        private string _czWord { get; set; }
        private string _enWord { get; set; }
        private bool _iKnowButtonVisible { get; set; }
        private bool _iDontKnowButtonVisible { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string CzWord
        {
            get { return _czWord; }
            set
            {
                if (value != _czWord)
                {
                    _czWord = value;
                    OnPropertyChanged("CzWord");
                }
            }
        }

        public string EnWord
        {
            get { return _enWord; }
            set
            {
                if (value != _enWord)
                {
                    _enWord = value;
                    OnPropertyChanged("EnWord");
                }
            }
        }

        public bool IKnowButtonVisible
        {
            get { return _iKnowButtonVisible; }
            set
            {
                if (value != _iKnowButtonVisible)
                {
                    _iKnowButtonVisible = value;
                    OnPropertyChanged("IKnowButtonVisible");
                }
            }
        }

        public bool IDontKnowButtonVisible
        {
            get { return _iDontKnowButtonVisible; }
            set
            {
                if (value != _iDontKnowButtonVisible)
                {
                    _iDontKnowButtonVisible = value;
                    OnPropertyChanged("IDontKnowButtonVisible");
                }
            }
        }

        public bool TranslationFromCzToEn;
        public Words Words;
        private Word Word;

        #endregion properties

        public MainPage()
		{
			InitializeComponent();

            TranslationFromCzToEn = true;
            IKnowButtonVisible = true;
            IDontKnowButtonVisible = false;
            DB.PrepareDB();
            Words = new Words();
            BindingContext = this;
        }

        // button I know
        private void Button_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            if (b.Text == "Start")
            {
                b.Text = "I know";
                IDontKnowButtonVisible = true;
                Word = Words.GetRandom();
                CzWord = Word.WordCZ;
                EnWord = "";
                TranslationFromCzToEn = true;
                return;
            }

            if (TranslationFromCzToEn)
            {
                b.Text = "Next";
                ShowAnswer();
                IDontKnowButtonVisible = false;
                TranslationFromCzToEn = false;

                // update database and Words
                Words.SetLessWeight(Word);
            }
            else
            {
                Word = Words.GetRandom();
                CzWord = Word.WordCZ;
                EnWord = "";
                b.Text = "I know";
                TranslationFromCzToEn = true;
                IDontKnowButtonVisible = true;
            }
        }

        // button I dont know
        private void ButtonIDK_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            if (TranslationFromCzToEn)
            {
                b.Text = "Next";
                ShowAnswer();
                IKnowButtonVisible = false;
                TranslationFromCzToEn = false;

                // update database and Words
                Words.SetMoreWeight(Word);
            }
            else
            {
                Word = Words.GetRandom();
                CzWord = Word.WordCZ;
                EnWord = "";
                b.Text = "I dont know";
                TranslationFromCzToEn = true;
                IKnowButtonVisible = true;
            }
        }

        private void ShowAnswer()
        {
            EnWord = Word.WordEN;
            CzWord = "(" + Word.WordCZ + ")";
        }

    }
}
