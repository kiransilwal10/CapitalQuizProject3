/*

Program Author: Kiran Silwal

USM ID: w10139554

Assignment: Capital Quiz 3

Description: This is a GUI of capital quiz project using MAUI. 

State captials based quiz game

*/

using Project3Quiz.Classes;
using Windows.System;

namespace Project3Quiz
{
    public partial class App : Application
    {
        public static List<Classes.State> states = new List<Classes.State>();
        public App()
        {
            InitializeComponent();
            LoadStates();

            MainPage = new Pages.QuizView();
            MainPage = MainPage;
        }

        public static void newGame()
        {
            LoadStates();

            App.Current.MainPage = new Pages.QuizView();
        }
        public static void TestResult(int score, int overall, List<State> Missed)
        {
            App.Current.MainPage = new Pages.ResultView(score, overall, Missed); //new AppShell();
        }


        private static void LoadStates()
        {
            string filePath = "C:\\Users\\KIRAN SILWAL\\Downloads\\Project3Quiz\\Project3Quiz\\StateCapitals.txt"; 
            try
            {
                var file = new StreamReader(filePath);

                string? line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(" ");
                    data[0] = data[0].Replace("-", " ");
                    data[1] = data[1].Replace("-", " ");
                    Classes.State state = new Classes.State { StateName = data[0], Capital = data[1] };
                    states.Add(state);
                }

                file.Close();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Could not load file.");
            }
        }
    }
}
