class Program
{
    static void Main()
    {
        var colors = new int[] { 0, 1, 9, 3, 11, 7, 15 };
        for (double z = 1.0; true; z *= 1.1)
        {
            for (int cY = -12; cY < 12; cY++)
            {
                for (int cX = -40; cX < 40; cX++)
                {
                    double x = -0.74364388703715870 + cX / z / 3;
                    double y = 0.131825904205311970 - cY / z;
                    double r = 0, i = 0; int k = 0;
                    while (r * r + i * i < 11 && ++k < 5000) (r, i) = (r * r - i * i + x, 2 * r * i + y);
                    System.Console.BackgroundColor = (System.ConsoleColor)colors[(int)System.Math.Log2(k) % 7];
                    System.Console.Write(cX == 79 ? " \n" : " ");
                }
            }
            System.Threading.Thread.Sleep(50);
            System.Console.Clear();
        }
    }
}