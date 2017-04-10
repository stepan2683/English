using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace First
{
    class ContentPageExample : ContentPage
    {

        private Words PairAct;
        private Words Words;
        private bool CzWord;
        private Label TextPlace;
        private Label CzTextPlace;
        private Button IDontKnow;
        private Button IKnow;

        public ContentPageExample()
        {

            CzWord = true;
            Words = new Words();

            Label Signature = new Label
            {
                Text = "Pro mojí lásku od Štěpána",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
                TextColor = Color.Gray
            };

            Label Signature2 = new Label
            {
                Text = "stepan2683@gmail.com",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
                TextColor = Color.Gray
            };

            TextPlace = new Label
            {
                Text = "",
                FontSize = 46,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                Margin = new Thickness(0, 20, 0, 0)
            };

            CzTextPlace = new Label
            {
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Gray
            };

            IKnow = new Button
            {
                Text = "Start0",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Fill,
                BorderColor = Color.Black,
                TextColor = Color.Green,
                Margin = new Thickness(0, 30, 0, 0),
                WidthRequest = 200,
                HeightRequest = 80
            };

            IKnow.Clicked += OnClickOnButton;

            IDontKnow = new Button
            {
                Text = "I don't know",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Fill,
                BorderColor = Color.Black,
                TextColor = Color.Red,
                Margin = new Thickness(0, 30, 0, 60),
                WidthRequest = 200,
                HeightRequest = 80,
                IsVisible = false
            };

            IDontKnow.Clicked += IDontKnow_Clicked;

            // add all to StackLayout

            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    TextPlace,
                    CzTextPlace,
                    IKnow,
                    IDontKnow,
                    Signature,
                    Signature2
                }
                //HeightRequest = 1500,
                //BackgroundColor = Color.White
            };

            this.Content = stackLayout;

            this.BackgroundColor = Color.White;



        }

        private void IDontKnow_Clicked(object sender, EventArgs e)
        {
            //TextPlace.Text = PairAct.En;
            //CzTextPlace.Text = "(" + PairAct.Cz + ")";
            //IKnow.Text = "Next one";
            //CzWord = true;
            //IDontKnow.IsVisible = false;
        }

        private void OnClickOnButton(object sender, EventArgs e)
        {        

            //if (CzWord)
            //{
            //    PairAct = Words.GetRandom();
            //    TextPlace.Text = PairAct.Cz;
            //    CzTextPlace.Text = "";
            //    CzWord = false;
            //    IKnow.Text = "I know";
            //    IDontKnow.Text = "I don't know";
            //    IDontKnow.IsVisible = true;
            //}
            //else
            //{
            //    TextPlace.Text = PairAct.En;
            //    CzTextPlace.Text = "(" + PairAct.Cz + ")";
            //    IKnow.Text = "Next one";
            //    CzWord = true;
            //    IDontKnow.IsVisible = false;
            //}
        }
    }
}
