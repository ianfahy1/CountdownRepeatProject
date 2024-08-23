using System.Diagnostics.Tracing;

namespace Countdown
{
    public partial class MainPage : ContentPage
    {
        private int count = 0;
        private int time = 5;
        private int p1Length = 0;
        private int p2Length = 0;

        private String temp = null;
        private String p1Word = "";
        private String p2Word = "";

        private System.Timers.Timer timer;


        public MainPage()
        {
            InitializeComponent();
            SetUpTimer();            
        }
        /*
         * Function VowelClicked
         * Initialises listOfVowels array
         * Randomises and chooses random vowel on click of
         * Vowel Button
         * 
         * Counts how many times this button has been clicked
         * and adds to counter which tracks Consonant button 
         * clicks simultaneously
         * 
         * Calls StartTimer function after global count >= 8
         */
        private void VowelClicked(object sender, EventArgs e)
        {
            char[] listOfVowels = {'A','A','A','A','A','A','A','A','A','A','A','A','A','A','A',
                               'E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E',
                               'I','I','I','I','I','I','I','I','I','I','I','I','I',
                               'O','O','O','O','O','O','O','O','O','O','O','O','O',
                               'U','U','U','U','U',};

            Random randVowel = new Random();
            int n = randVowel.Next(listOfVowels.Length);
            
            switch(count){ 
            
                case 0:
                    L0.Text = $"{listOfVowels[n]}";
                    break;

                case 1:
                    L1.Text = $"{listOfVowels[n]}";
                    break;

                case 2:
                    L2.Text = $"{listOfVowels[n]}";
                    break;

                case 3:
                    L3.Text = $"{listOfVowels[n]}";
                    break;

                case 4:
                    L4.Text = $"{listOfVowels[n]}";
                    break;

                case 5:
                    L5.Text = $"{listOfVowels[n]}";
                    break;

                case 6:
                    L6.Text = $"{listOfVowels[n]}";
                    break;

                case 7:
                    L7.Text = $"{listOfVowels[n]}";
                    break;

                case 8:
                    L8.Text = $"{listOfVowels[n]}";
                    break;

                default:
                    break;
            }
            count++;

            if (count > 8)
            {
                StartTimer();
            }
        }

        /*
         * Function ConsonantClicked
         * Initialises listOfConsonants array
         * Randomises and chooses random consonant on click of
         * Consonant Button
         * 
         * Counts how many times this button has been clicked
         * and adds to counter which tracks Vowel button 
         * clicks simultaneously
         * 
         * Calls StartTimer function after global count >= 8
         */
        private void ConsonantClicked(object sender, EventArgs e)
        {
            char[] listOfConsonants = {'B','B',
                                   'C','C','C',
                                   'D','D','D','D','D','D',
                                   'F','F',
                                   'G','G','G',
                                   'H','H',
                                   'J',
                                   'K',
                                   'L','L','L','L','L',
                                   'M','M','M','M',
                                   'N','N','N','N','N','N','N','N',
                                   'P','P','P','P',
                                   'Q',
                                   'R','R','R','R','R','R','R','R','R',
                                   'S','S','S','S','S','S','S','S','S',
                                   'T','T','T','T','T','T','T','T','T',
                                   'V',
                                   'W',
                                   'X',
                                   'Y',
                                   'Z'};

            Random randConsonant = new Random();
            int n = randConsonant.Next(listOfConsonants.Length);

            switch (count)
            {

                case 0:
                    L0.Text = $"{listOfConsonants[n]}";
                    break;

                case 1:
                    L1.Text = $"{listOfConsonants[n]}";
                    break;

                case 2:
                    L2.Text = $"{listOfConsonants[n]}";
                    break;

                case 3:
                    L3.Text = $"{listOfConsonants[n]}";
                    break;

                case 4:
                    L4.Text = $"{listOfConsonants[n]}";
                    break;

                case 5:
                    L5.Text = $"{listOfConsonants[n]}";
                    break;

                case 6:
                    L6.Text = $"{listOfConsonants[n]}";
                    break;

                case 7:
                    L7.Text = $"{listOfConsonants[n]}";
                    break;

                case 8:
                    L8.Text = $"{listOfConsonants[n]}";
                    break;

                default:
                    break;
            }
            count++;

            if(count > 8)
            {
                StartTimer();
            }
        }
        /*
         *Initialises timer and sets interval to 1 second
         */
        private void SetUpTimer()
        {
            timer = new System.Timers.Timer
            {
                Interval = 1000

            };
            timer.Elapsed += Timer_Elapsed;
        }

        /*
         *Counts down timer
         */
        private void Timer_Elapsed(object sender, EventArgs e)
        {
            Dispatcher.Dispatch(
                ()=>
                {
                    TimerFunc();
                }
                );
        }

        /*
         *Tracks timer
         *Changes text of timer_lbl to match the time 
         *elapsed in-game
         */
        private void TimerFunc()
        {
            --time;
            timer_lbl.Text = time.ToString();

            if (time == 0)
            {
                timer.Stop();
                UserInput();
            }
        }

        /*
         * Starts Timer
         */
        private void StartTimer()
        {
            timer.Start();
        }

        /*
         * Displays entry boxes for answers
         *      1.Ask player 1 length of their word
         *      2.Ask player 2 length of their word
         *      3.Ask player 1 their word
         *      4.Ask player 2 their word
         */
        private async void UserInput()
        {
            await DisplayAlert("TIME UP", "Time to guess!!", "NEXT");

            int i;
            bool valid = false;

            do
            {

                //Validating length values
                for (i = 0; i < 1;)
                {
                    if (temp != null && p1Length <= 9)
                    {
                        i = 1;
                    }
                    else if(temp == null || p1Length > 9) 
                    {
                        temp = await DisplayPromptAsync("PLAYER 1", "Please enter the length of your word\nMust 9 characters or less", "Enter");
                        //Parsing to integer value
                        p1Length = Int32.Parse(temp);
                    }
                    else
                    {
                        temp = await DisplayPromptAsync("PLAYER 1", "Please enter the length of your word\nMust 9 characters or less", "Enter");
                        //Parsing to integer value
                        p1Length = Int32.Parse(temp);
                    }

                }

                //Taking player 1s word input
                p1Word = await DisplayPromptAsync("PLAYER 1", "What is your word?", "Enter");

                for (int j = 0; j < 1;)
                {
                    if (p1Word != null && p1Word.Length >= 1)
                    {
                        j = 1;
                    }
                    else
                    {
                        p1Word = await DisplayPromptAsync("PLAYER 1", "Please enter a word", "Enter");
                    }
                }

                //Cheacking if Player 1s Word is the length they stated
                if (p1Word.Length == p1Length)
                {
                    valid = true;
                    await DisplayAlert("PLAYER 1", "Word Length and Stated Length ARE equal", "OK");
                }
                else
                {
                    valid = false;
                    await DisplayAlert("PLAYER 1", "Word Length and Stated Length NOT equal", "OK", "Re-Enter Word length");
                    i = 0;
                }

            } while (!valid);

            //Displaying player word + word length
            await DisplayAlert("Player 1s Word length is: ", temp, "OK");
            await DisplayAlert("Player 1s Word is: ", p1Word, "OK");

            valid = false;
            temp = null;

            do
            {

                //Validating length values
                for (i = 0; i < 1;)
                {
                    if (temp != null && p2Length <= 9)
                    {
                        i = 1;
                    }
                    else if (temp == null || p2Length > 9)
                    {
                        temp = await DisplayPromptAsync("PLAYER 2", "Please enter the length of your word\nMust 9 characters or less", "Enter");
                        //Parsing to integer value
                        p2Length = Int32.Parse(temp);
                    }
                    else
                    {
                        temp = await DisplayPromptAsync("PLAYER 2", "Please enter the length of your word\nMust 9 characters or less", "Enter");
                        //Parsing to integer value
                        p2Length = Int32.Parse(temp);
                    }

                }

                //Taking player 2s word input
                p2Word = await DisplayPromptAsync("PLAYER 2", "What is your word?", "Enter");

                for (int j = 0; j < 1;)
                {
                    if (p2Word != null && p2Word.Length >= 1)
                    {
                        j = 1;
                    }
                    else
                    {
                        p2Word = await DisplayPromptAsync("PLAYER 2", "Please enter a word", "Enter");
                    }
                }

                //Cheacking if Player 2s Word is the length they stated
                if (p2Word.Length == p2Length)
                {
                    valid = true;
                    await DisplayAlert("PLAYER 2", "Word Length and Stated Length ARE equal", "OK");
                }
                else
                {
                    valid = false;
                    await DisplayAlert("PLAYER 2", "Word Length and Stated Length NOT equal", "OK", "Re-Enter Word length");
                    i = 0;
                }

            } while (!valid);

            //Displaying player word + word length
            await DisplayAlert("Player 2s Word length is: ", temp, "OK");
            await DisplayAlert("Player 2s Word is :", p2Word, "OK");

        }//End of user input
    
    }//End of main

}//End of namespace