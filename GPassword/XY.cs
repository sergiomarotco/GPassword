namespace GPassword
{
    /// <summary>
    /// Класс координат клеток.
    /// </summary>
    internal class XY
    {
        /// <summary>
        /// Координата X.
        /// </summary>
        internal int X = 0;

        /// <summary>
        /// Координата Y.
        /// </summary>
        internal int Y = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="XY"/> class.
        /// Конструктор.
        /// </summary>
        /// <param name="x">Значение координаты X.</param>
        /// <param name="y">Значение координаты Y.</param>
        public XY(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}