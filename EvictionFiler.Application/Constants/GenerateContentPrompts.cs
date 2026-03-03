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
        public static string OppositionPrompt =
                                                "Generate ONE unified, example of an Opposition to a Motion in an eviction case. Use the uploaded document to extract all necessary facts, dates, case details, and arguments.\n\n" +
                                                "Output ONLY the formatted Opposition text. Do NOT include disclaimers, warnings, analysis, explanations, or multiple versions. Produce exactly one structured document with these sections:\n" +
                                                "1. CAPTION\n" +
                                                "2. TITLE OF DOCUMENT\n" +
                                                "3. PRELIMINARY STATEMENT\n" +
                                                "4. STATEMENT OF FACTS\n" +
                                                "5. ARGUMENT (with numbered legal arguments)\n" +
                                                "6. PRAYER FOR RELIEF\n" +
                                                "7. SIGNATURE BLOCK\n\n" +
                                                "Keep formatting professional, legally structured, and concise.";

        public static string ReplyPrompt =
                                                "Generate ONE unified, example of a Reply to an Opposition in an eviction case. Use the uploaded document to extract all necessary facts, procedural history, and points raised in the Opposition.\n\n" +
                                                "Output ONLY the formatted Reply text. Do NOT include disclaimers, warnings, analysis, explanations, or multiple versions. Produce exactly one structured document with these sections:\n" +
                                                "1. CAPTION\n" +
                                                "2. TITLE OF DOCUMENT\n" +
                                                "3. INTRODUCTORY STATEMENT\n" +
                                                "4. RESPONSE TO OPPOSITION ARGUMENTS (numbered, point-by-point)\n" +
                                                "5. PRAYER FOR RELIEF\n" +
                                                "6. SIGNATURE BLOCK\n\n" +
                                                "Keep formatting professional, direct, and concise.";
    }
}
