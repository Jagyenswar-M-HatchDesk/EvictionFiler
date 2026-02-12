using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Constants
{
    public class OpenAIPrompts
    {
        public static string OSCPrompt = "Generate ONE unified, example of an Order to Show Cause (OSC) to stay eviction. Use the uploaded document to get all the information required to generate. \n\nOutput ONLY the formatted OSC text. Do NOT include disclaimers, warnings, analysis, explanations, or multiple versions. Produce exactly one structured document with these sections:\n1. CAPTION\n2. TITLE OF MOTION\n3. INTRODUCTORY PARAGRAPH\n4. NUMBERED ORDERED CLAUSES\n5. SERVICE SECTION\n6. SIGNATURE BLOCK\n\nKeep formatting professional and concise.";
        public static string DefaultsOSC = "Generate ONE unified, example of an Order to Show Cause (OSC) to stay eviction. Use the dummy information required to generate. \n\nOutput ONLY the formatted OSC text. Do NOT include disclaimers, warnings, analysis, explanations, or multiple versions. Produce exactly one structured document with these sections:\n1. CAPTION\n2. TITLE OF MOTION\n3. INTRODUCTORY PARAGRAPH\n4. NUMBERED ORDERED CLAUSES\n5. SERVICE SECTION\n6. SIGNATURE BLOCK\n\nKeep formatting professional and concise.";
        public static string MotionPrompt = "Generate ONE unified, example of an Motion to Dismiss and Stay Eviction. Use the uploaded document to get all the information required to generate. \n\nOutput ONLY the formatted Motion text. Do NOT include disclaimers, warnings, analysis, explanations, or multiple versions. Produce exactly one structured document .\n\nKeep formatting professional and concise.";
    }
}
