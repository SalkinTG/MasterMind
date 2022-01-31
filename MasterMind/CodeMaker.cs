using System;
using System.Collections.Generic;
using System.Text;

namespace MasterMind
{
    class CodeMaker
    {
        private readonly CodeRow solution;

        public CodeMaker()
        {
            CodePegColour slot0Colour = CodePegColour.Blank;
            CodePegColour slot1Colour = CodePegColour.Blank;
            CodePegColour slot2Colour = CodePegColour.Blank;
            CodePegColour slot3Colour = CodePegColour.Blank;

            // Some logic to generate four random colours

            solution = new CodeRow(slot0Colour, slot1Colour, slot2Colour, slot3Colour);
        }

        public GuessCorrectness ScoreCodeGuess(CodeRow guess)
        {
            (int correctPegs, bool[] scoringTracker) = FullyCorrectPegs(guess);
            int correctColourPegs = CorrectColourPegs(guess, scoringTracker);

            GuessCorrectness correctness = new GuessCorrectness(correctPegs, correctColourPegs);
            return correctness;
        }

        private (int, bool[]) FullyCorrectPegs(CodeRow guess)
        {
            int correctPegs = 0;
            int numberOfSlots = guess.pegSlots.Length;
            bool[] scoringTracker = new bool[numberOfSlots];
            for (int i = 0; i < numberOfSlots; i++)
            {
                CodePegColour solutionColour = solution.CheckSlotColour(i);
                CodePegColour guessColour = guess.CheckSlotColour(i);

                if (guessColour == solutionColour)
                {
                    correctPegs++;
                    scoringTracker[i] = false;
                }
                else
                {
                    scoringTracker[i] = true;
                }
            }

            return (correctPegs, scoringTracker);
        }
        private int CorrectColourPegs(CodeRow guess, bool[] scoringTracker) 
        {
            int correctColourPegs = 0;
            int numberOfSlots = guess.pegSlots.Length;
            bool[] solutionTracker = scoringTracker;
            for (int i = 0; i < numberOfSlots; i++)
            {
                if (scoringTracker[i])
                {
                    for (int j = 0; j < numberOfSlots; j++)
                    {
                        if (solutionTracker[j])
                        {
                            CodePegColour solutionColour = solution.CheckSlotColour(j);
                            CodePegColour guessColour = guess.CheckSlotColour(i);

                            if (guessColour == solutionColour)
                            {
                                correctColourPegs++;
                                solutionTracker[j] = false;
                            }
                        }
                    }
                }
            }
            return correctColourPegs;
        }
    }
}
