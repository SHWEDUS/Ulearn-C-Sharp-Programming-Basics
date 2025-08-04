namespace StyleErrors
{
    class Program
    {
        static int A;
        static int upperBound;
        
        static void Main()
        {
            upperBound = 100;
        }

        static string Decode(string str)
        {
            return (int.Parse(str.Replace(".", "")) % 1024).ToString();
        }
    }
}