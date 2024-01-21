namespace Square.Utilities.Messages
{
    static class Messages
    {
        //public const string enterValue = "Enter: [wall] [Height] [Width]  or [window] [Height] [Width] [Reveal(optional)]";
        public const string revealIsNegative = "Reveal cannot be a negative number!";
        public const string heightNegative = "Height cannot be a negative number!";
        public const string widthNegative = "Width cannot be a negative number!";
        public const string invalidFigure = "Invalid figure, try again:";


        public static void IntroInfo()
        {
            //  Enter:         [              wall              ]         [              Height              ]
            Wr("Enter: "); Wr("["); Gr(); Wr("wall"); Rs(); Wr("]"); Wr(" ["); Gr(); Wr("Height"); Rs(); Wr("]");
            //   [              Width              ]         or         [              window              ]         [              Height
            Wr(" ["); Gr(); Wr("Width"); Rs(); Wr("]"); Wr(" or "); Wr("["); Cy(); Wr("window"); Rs(); Wr("]"); Wr(" ["); Cy(); Wr("Height"); Rs();
            //  ]         [              Width              ]         [              Reveal(optional)              ]         or         [      
            Wr("] "); Wr("["); Cy(); Wr("Width"); Rs(); Wr("]"); Wr(" ["); Cy(); Wr("Reveal(optional)"); Rs(); Wr("]"); Wr(" or "); Wr("[");
            //        total              ]          /        [              end              ].     
            Gr(); Wr("total"); Rs(); Wr("]"); Wr(" / "); Wr("["); Gr(); Wr("end"); Rs(); Wr("]."); Console.WriteLine();
        }

        public static void Wr(string str)
        {
            Console.Write(str);
        }
        public static void Rs()
        {
            Console.ResetColor();
        }
        public static void Gr()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void Cy()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
