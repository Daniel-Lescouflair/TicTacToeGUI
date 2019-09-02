
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToeWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// HOlds the current results of cells in the active game.
        /// </summary>
        private SymbolType[] sResults;

        /// <summary>
        /// True if it is player 1's turn (X) or player 2's turn (0)
        /// </summary>
        private bool sPlayer1Turn;

        /// <summary>
        /// True if the game has ended. 
        /// </summary>
        private bool sEndGame;

        #endregion


        #region Constructor

        /// <summary>
        /// Default_Constructor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion

        /// <summary>
        /// Starts a new game and clears all values back to the original.
        /// </summary>
        private void NewGame()
        {
            //Create a new blank array of Empty cells.
            sResults = new SymbolType[9];

            for (var i = 0; i < sResults.Length; i++)
            {
                sResults[i] = SymbolType.Empty;
            }

            //Making sure Player 1 starts the game.
            sPlayer1Turn = true;

            // Set every button on the grid..
            Field.Children.Cast<Button>().ToList().ForEach(button =>
            {

                //Changing bakground, foreground, and content to default values.
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            //Make sure the game hasn't fnished
            sEndGame = false;
        }

        /// <summary>
        /// Handles each time a button is clicked. 
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Start a new game on the click after it finished.
            if (sEndGame)
            {
                NewGame();
                return;
            }

            // Cast the sender to a button
            var button = (Button)sender;

            // Find the buttons positions in the array.
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);

            // Don't do anything if the cell has a value in it.
            if (sResults[index] != SymbolType.Empty)
                return;

            // Set the cell value based on which player turn it is.
            if (sPlayer1Turn)
            {
                sResults[index] = SymbolType.Cross;
            }

            else
            {
                sResults[index] = SymbolType.Circle;
            }

            // Set button text to the result.
            button.Content = sPlayer1Turn ? "X" : "O";

            // Change Circle's to green.
            if (!sPlayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }

            if (sPlayer1Turn)
            {
                sPlayer1Turn = false;
            }
            else
            {
                sPlayer1Turn = true;
            }

            //Checking for a winner
            CheckForWinner();


        }

        /// <summary>
        /// Checks if there is a winner of a 3 line straight.
        /// </summary>
        private void CheckForWinner()
        {
            #region Horizontal Wins
            //Check for Horizontal Wins

            //
            // - Row 0 
            //

            if (sResults[0] != SymbolType.Empty && (sResults[0] & sResults[1] & sResults[2]) == sResults[0])
            {
                // Game Ends
                sEndGame = true;

                // Highlight the winners.
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            //
            // - Row 1 
            //

            if (sResults[3] != SymbolType.Empty && (sResults[3] & sResults[4] & sResults[5]) == sResults[3])
            {
                // Game Ends
                sEndGame = true;

                // Highlight the winners.
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            //
            // - Row 2 
            //

            if (sResults[6] != SymbolType.Empty && (sResults[6] & sResults[7] & sResults[8]) == sResults[6])
            {
                // Game Ends
                sEndGame = true;

                // Highlight the winners.
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion


            #region Vertical Wins
            //Check for Vertical Wins

            //
            // - Column 0 
            //

            if (sResults[0] != SymbolType.Empty && (sResults[0] & sResults[3] & sResults[6]) == sResults[0])
            {
                // Game Ends
                sEndGame = true;

                // Highlight the winners.
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            //
            // - Column 1 
            //

            if (sResults[1] != SymbolType.Empty && (sResults[1] & sResults[4] & sResults[7]) == sResults[1])
            {
                // Game Ends
                sEndGame = true;

                // Highlight the winners.
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            //
            // - Column 2 
            //

            if (sResults[2] != SymbolType.Empty && (sResults[2] & sResults[5] & sResults[8]) == sResults[2])
            {
                // Game Ends
                sEndGame = true;

                // Highlight the winners.
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion


            #region Diagonal Wins
            //Check for Diagonals Wins

            //
            // - Top Left, Bottom Right.
            //

            if (sResults[0] != SymbolType.Empty && (sResults[0] & sResults[4] & sResults[8]) == sResults[0])
            {
                // Game Ends
                sEndGame = true;

                // Highlight the winners.
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            //
            // - Top Right, Bottom Left.
            //

            if (sResults[2] != SymbolType.Empty && (sResults[2] & sResults[4] & sResults[6]) == sResults[2])
            {
                // Game Ends
                sEndGame = true;

                // Highlight the winners.
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }


            #endregion



            #region No Winners
            // CHecking for no winner and the cells are filled.
            if (!sResults.Any(result => result == SymbolType.Empty))
            {
                //Game ended
                sEndGame = true;

                //Turn all cells orange.
                Field.Children.Cast<Button>().ToList().ForEach(button =>
                {

                    button.Background = Brushes.Orange;

                });

                #endregion
            }
        }
    }
}
