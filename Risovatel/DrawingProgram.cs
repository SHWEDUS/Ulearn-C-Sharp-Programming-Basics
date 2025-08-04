using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Drawer
    {
        static float x, y;
        static IGraphics _graphics;

        public static void StartInitialization(IGraphics newGraphics)
        {
            _graphics = newGraphics;
            _graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }
        
        /// <summary>
        /// Функция рисования траектории
        /// </summary>
        /// <param name="pen">Ручка</param>
        /// <param name="width">Шаг</param>
        /// <param name="angle">Угол</param>
        public static void DrawLine(Pen pen, double width, double angle)
        {
            var x1 = (float)(x + width * Math.Cos(angle));
            var y1 = (float)(y + width * Math.Sin(angle));
            _graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Turn(double width, double angle)
        {
            x = (float)(x + width * Math.Cos(angle));
            y = (float)(y + width * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double angle, IGraphics graphics)
        {
            Drawer.StartInitialization(graphics);

            var size = Math.Min(width, height);
            var pen = new Pen(Brushes.Yellow);
            
            var diagonalLength = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Drawer.SetPosition(x0, y0);
            
            DrawFirstLine(pen, size);
            DrawSecondLine(pen, size);
            DrawThirdLine(pen, size);
            DrawFourthLine(pen, size);
        }

        private static void DrawFourthLine(Pen pen, int size)
        {
            Drawer.DrawLine(pen, size * 0.375f, Math.PI / 2);
            Drawer.DrawLine(pen, size * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            Drawer.DrawLine(pen, size * 0.375f, Math.PI / 2 + Math.PI);
            Drawer.DrawLine(pen, size * 0.375f - size * 0.04f, Math.PI / 2 + Math.PI / 2);

            Drawer.Turn(size * 0.04f, Math.PI / 2 - Math.PI);
            Drawer.Turn(size * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }

        private static void DrawThirdLine(Pen pen, int size)
        {
            Drawer.DrawLine(pen, size * 0.375f, Math.PI);
            Drawer.DrawLine(pen, size * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
            Drawer.DrawLine(pen, size * 0.375f, Math.PI + Math.PI);
            Drawer.DrawLine(pen, size * 0.375f - size * 0.04f, Math.PI + Math.PI / 2);

            Drawer.Turn(size * 0.04f, Math.PI - Math.PI);
            Drawer.Turn(size * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);
        }

        private static void DrawSecondLine(Pen pen, int size)
        {
            Drawer.DrawLine(pen, size * 0.375f, -Math.PI / 2);
            Drawer.DrawLine(pen, size * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
            Drawer.DrawLine(pen, size * 0.375f, -Math.PI / 2 + Math.PI);
            Drawer.DrawLine(pen, size * 0.375f - size * 0.04f, -Math.PI / 2 + Math.PI / 2);

            Drawer.Turn(size * 0.04f, -Math.PI / 2 - Math.PI);
            Drawer.Turn(size * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);
        }

        private static void DrawFirstLine(Pen pen, int size)
        {
            Drawer.DrawLine(pen, size * 0.375f, 0);
            Drawer.DrawLine(pen, size * 0.04f * Math.Sqrt(2), Math.PI / 4);
            Drawer.DrawLine(pen, size * 0.375f, Math.PI);
            Drawer.DrawLine(pen, size * 0.375f - size * 0.04f, Math.PI / 2);

            Drawer.Turn(size * 0.04f, -Math.PI);
            Drawer.Turn(size * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);
        }
    }
}