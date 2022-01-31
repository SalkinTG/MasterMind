using System;
using System.Collections.Generic;
using System.Text;

namespace MasterMind
{
    class GameHandler
    {
        CodeMaker codeMaker;
        Board gameBoard;

        public GameHandler(int maxTurns)
        {
            codeMaker = new CodeMaker();
            gameBoard = new Board(maxTurns);
        }
        public void NewGame(int maxTurns)
        {
            codeMaker = new CodeMaker();
            gameBoard = new Board(maxTurns);
        }
        public Outcomes MakeGuess(CodeRow guess) 
        {
            gameBoard.RecieveCodeRow(guess); // This could be done in the nex step, making the called method obsolete
                                             // Iv'e chosen to do this as I like to keep the board up to date. Especially in the case where a human code maker is implemented.
            GuessCorrectness correctness = codeMaker.ScoreCodeGuess(guess);
            if (correctness.correctPegs == guess.pegSlots.Length)
            {
                return Outcomes.breakerWin;
            }
            int turnsLeft = gameBoard.RecieveGuessCorrectness(correctness);
            if (turnsLeft > 0)
            {
                return Outcomes.success;
            }
            else // no more turns left
            {
                return Outcomes.breakerLoose;
            }
        }
    }
}
