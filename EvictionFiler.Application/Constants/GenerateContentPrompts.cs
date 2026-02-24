using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Constants
{
    public class GenerateContentPrompts
    {
        public static string OSCPrompt = "Generate ONE unified, example of an Order to Show Cause (OSC) to stay eviction. Use the uploaded document to get all the information required to generate. \n\nOutput ONLY the formatted OSC text. Do NOT include disclaimers, warnings, analysis, explanations, or multiple versions. Produce exactly one structured document with these sections:\n1. CAPTION\n2. TITLE OF MOTION\n3. INTRODUCTORY PARAGRAPH\n4. NUMBERED ORDERED CLAUSES\n5. SERVICE SECTION\n6. SIGNATURE BLOCK\n\nKeep formatting professional and concise.";
        public static string DefaultsOSC = "Generate ONE unified, example of an Order to Show Cause (OSC) to stay eviction. Use the dummy information required to generate. \n\nOutput ONLY the formatted OSC text. Do NOT include disclaimers, warnings, analysis, explanations, or multiple versions. Produce exactly one structured document with these sections:\n1. CAPTION\n2. TITLE OF MOTION\n3. INTRODUCTORY PARAGRAPH\n4. NUMBERED ORDERED CLAUSES\n5. SERVICE SECTION\n6. SIGNATURE BLOCK\n\nKeep formatting professional and concise.";
        public static string DefaultsOpposition = "Generate ONE unified, example of an Opposition. Use the dummy information required to generate. \n\nOutput ONLY the formatted Opposition text. Do NOT include disclaimers, warnings, analysis, explanations, or multiple versions. Produce exactly one structured document with these sections:\n1. CAPTION\n2. Introduction / Summary\n3. Procedural History\n4. Counterstatement of Facts\n5. Legal Arguments\n6. Conclusion\n\nKeep formatting professional and concise.";
        public static string DefaultsReply = "Generate ONE unified, example of an Reply. Use the dummy information required to generate. \n\nOutput ONLY the formatted Reply text. Do NOT include disclaimers, warnings, analysis, explanations, or multiple versions. Produce exactly one structured document with these sections:\n1. CAPTION\n2. Introduction \n3. Reply to Opposition Arguments\n4. Reinforce the Original Motion\n5. Conclusion\n\nKeep formatting professional and concise.";
        public static string MotionPrompt = "Generate ONE unified, example of an Motion to Dismiss and Stay Eviction. Use the uploaded document to get all the information required to generate. \n\nOutput ONLY the formatted Motion text. Do NOT include disclaimers, warnings, analysis, explanations, or multiple versions. Produce exactly one structured document .\n\nKeep formatting professional and concise.";
    }
}
