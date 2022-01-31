using System;
using System.Collections.Generic;
using System.Text;

namespace MasterMind
{
    class Board
    {
        private readonly int maxTurns;
        private CodeRow guessUnderEvaluation;
        private List<Tuple<CodeRow,GuessCorrectness>> guesses;

        public Board(int turns)
        {
            this.maxTurns = turns;
            guesses = new List<Tuple<CodeRow, GuessCorrectness>>();
        }
        public void RecieveCodeRow(CodeRow guess)
        {
            guessUnderEvaluation = guess;
        }
        public int RecieveGuessCorrectness(GuessCorrectness correctness)
        {
            Tuple<CodeRow, GuessCorrectness> guessesRow = Tuple.Create(guessUnderEvaluation, correctness);
            guesses.Add(guessesRow);
            guessUnderEvaluation = null;
            int turnsLeft = maxTurns - guesses.Count;
            return turnsLeft;
        }
    }
}
