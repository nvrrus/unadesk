namespace TriangleLibrary
{
    public static class TriangleHelper
    {
        const double ErrorLimit = 1E-13;
        const double MaxValue = 1E16;

        /// <summary>
        /// По трем сторонам треугольника определяет, 
        /// является ли он остроугольным, прямоугольным или тупоугольным
        /// </summary>
        /// <param name="a">Длина первой стороны треугольника</param>
        /// <param name="b">Длина второй стороны треугольника</param>
        /// <param name="c">Длина третьей стороны треугольника</param>
        /// <returns>Тип треугольника <see cref="TriangleAngleTypeEnum"/></returns>
        public static TriangleAngleTypeEnum GetAngleType(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Допустимы только положительные длины сторон");
            }

            MoveMaxSideIntoFirst(ref a, ref b, ref c);
            if (a >= b + c)
            {
                throw new ArgumentException($"Невозможно построить треугольник по сторонам: {a}, {b}, {c}");
            }

            var maxSideSquared = Math.Pow(a, 2);
            var otherSidesSumSquared = Math.Pow(b, 2) + Math.Pow(c, 2);
            if (maxSideSquared >= MaxValue || otherSidesSumSquared >= MaxValue)
            {
                throw new ArgumentOutOfRangeException("Превышена допустимая длина стороны треугольника");
            }

            var delta = maxSideSquared - otherSidesSumSquared;

            if (Math.Abs(delta) <= ErrorLimit)
            {
                return TriangleAngleTypeEnum.Right;
            }

            return delta < 0
                ? TriangleAngleTypeEnum.Acture
                : TriangleAngleTypeEnum.Obtuse;
        }

        private static void MoveMaxSideIntoFirst(ref double a, ref double b, ref double c)
        {
            var oldA = a;
            if (b > a && b > c)
            {
                a = b;
                b = oldA;
                return;
            }
            
            if (c > a)
            {
                a = c;
                c = oldA;
            }
        }
    }
}