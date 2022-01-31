using System;
using System.Collections.Generic;
using System.Text;

namespace MasterMind
{
    public class CodeRow
    {
        public readonly CodePegColour[] pegSlots;

        public CodeRow(CodePegColour slot0Colour, CodePegColour slot1Colour, CodePegColour slot2Colour, CodePegColour slot3Colour)
        {
            pegSlots = new CodePegColour[] { slot0Colour, slot1Colour, slot2Colour, slot3Colour};
        }
        public CodePegColour CheckSlotColour(int slotNumber) // Should also handle out of scope slotNumbers
        {
            CodePegColour colour = pegSlots[slotNumber]; 
            return colour;
        }
    }
}
