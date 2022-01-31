using System;
using System.Collections.Generic;
using System.Text;

namespace MasterMind
{
    public class GuessCorrectness
    {
        public readonly int correctPegs;
        public readonly int correctColourPegs;

        public GuessCorrectness(int correct, int correctColour)
        {
            this.correctPegs = correct;
            this.correctColourPegs = correctColour;
        }
    }
}
