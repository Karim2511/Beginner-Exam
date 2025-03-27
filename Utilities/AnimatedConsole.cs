namespace OOP_Exam.Utilities
{
    public static class AnimatedConsole
    {
        // this animation will be for Console.Write() 
        public static void WriteAnimated(string text, int delay = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        // this animation will be for Console.WriteLine() 
        public static void WriteLineAnimated(string text, int delay = 30)
        {
            WriteAnimated(text, delay);
            Console.WriteLine();
        }
    }
}