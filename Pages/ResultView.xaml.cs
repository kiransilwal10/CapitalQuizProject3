﻿/*

Program Author: Kiran Silwal

USM ID: w10139554

Assignment: Capital Quiz 3

Description: This is a GUI of capital quiz project using MAUI. 

State captials based quiz game

*/

using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Project3Quiz.Classes;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Project3Quiz.Pages
{
    public partial class ResultView : ContentPage
    {

        class optionStrings { string _text = ""; public string Text { get { return _text; } set { _text = value; } } }

        public ResultView(int score,int overall,List<State> Missed)
        {
            InitializeComponent();
            ActualScore.Text = score.ToString();
            if(score == 20)
            {
                ResultLabel.Text = "You got all questions correct!";
                resultImage.IsVisible = true;
            }
            ObservableCollection<optionStrings> options_ = new ObservableCollection<optionStrings>();
            foreach (State state in Missed)
            {
                options_.Add(new optionStrings { Text = $"{state.Capital}, {state.StateName}"});
            }
            quizOptions.ItemsSource = options_;
        }

        private void NewGame_Clicked(object sender, EventArgs e)
        {
            App.newGame();
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            App.Current.Quit();
        }
    }
}
