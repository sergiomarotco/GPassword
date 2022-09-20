namespace GPassword
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// Основная форма программы.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly Font bigFont = new Font("Times New Roman", 50);
        private readonly SolidBrush greenBrush = new SolidBrush(Color.GreenYellow);
        private readonly SolidBrush gainBrush = new SolidBrush(Color.Gainsboro);
        private readonly SolidBrush blackBrush = new SolidBrush(Color.Black);
        private readonly StringFormat drawFormat = new StringFormat();
        private readonly string alf0 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefjhigklmnopqrstuvwxyz{}}();:./|<>!@#$%^&*1234567890№`~?-=+¶Θ۞‡ↀ∑∭⏎☺☻✸♋♕➲♫♡©®●►▲◄▼☮☂☎☠☽☾✉✈♣♤♥♦♧☄☊☭☁ϟ┿❀✾✿✄✪♞☯абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private readonly Random rnd = new Random();
        private readonly ArrayList greenList = new ArrayList();
        private readonly Random r = new Random();
        private readonly ArrayList pxy = new ArrayList();
        private readonly Pen blackPen = new Pen(Color.Black, 1);
        private int mouseX = -40;
        private int mouseY = -40;
        private XY last = new XY(0, 0);
        private XY lastDeleted = new XY(0, 0);

        /// <summary>
        /// Коэффициент вычислений.
        /// </summary>
        private int aK = 40;
        private string[] alf2;
        private Graphics g;
        private Font drawFont = new Font("Times New Roman", 26);
        private string alf1 = string.Empty;

        /// <summary>
        /// Размер стороны сетки.
        /// </summary>
        private int a = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Основной конструктор.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            textBox4.Text = alf0;
            a = Convert.ToInt32(textBox3.Text);
            aK = 400 / a;
            GenerateALF();
        }

        private void DrawGREEN(int mouseX, int mouseY)
        {
            int num = (mouseY / aK * a) + (mouseX / aK);
            g.FillRectangle(greenBrush, mouseX + 1, mouseY + 1, aK - 1, aK - 1);
            g.DrawString(alf1[num].ToString(), drawFont, blackBrush, new Point(mouseX, mouseY), drawFormat);
        }

        private void DEdrawGREEN(int mouseX, int mouseY)
        {
            int num = (mouseY / aK * a) + (mouseX / aK);
            g.FillRectangle(gainBrush, mouseX + 1, mouseY + 1, aK - 1, aK - 1);
            g.DrawString(alf1[num].ToString(), drawFont, blackBrush, new Point(mouseX, mouseY), drawFormat);
        }

        private void DrawGRID()
        {
            g.FillRectangle(gainBrush, 0, 0, 400, 400); // drawGREEN(Mx,My);//сначала нарисовать зеленые клеточки
            for (int i = 0; i <= 400; i += aK)
            {
                g.DrawLine(blackPen, new Point(i, 0), new Point(i, 400));
                g.DrawLine(blackPen, new Point(0, i), new Point(400, i));
            }

            int y = 0;
            int num = 0;
            int x = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                pxy.Add(new XY(0, 0));
            }

            do
            {
                Thread.Sleep(1);
                g.DrawString(alf1[num].ToString(), drawFont, blackBrush, new Point(x, y), drawFormat);
                num++;
                x += aK;
                if (x >= aK * a)
                {
                    x = 0;
                    y += aK;
                } // возможно >= 400
            }
            while (num < alf1.Length);
        }

        /// <summary>
        /// Значение настоящего динамического пароля.
        /// </summary>
        private void Zapusk()
        {
            g.DrawString("Введите".ToString(), new Font("Times New Roman", 26), blackBrush, new Point(0, 10), drawFormat);
            Thread.Sleep(500);
            g.DrawString("пароль".ToString(), new Font("Times New Roman", 26), blackBrush, new Point(0, 50), drawFormat);
            Thread.Sleep(500);
        }

        private void Off()
        {
            g.DrawString("Экран".ToString(), new Font("Times New Roman", 26), blackBrush, new Point(0, 10), drawFormat);
            Thread.Sleep(500);
            g.DrawString("заблокирован".ToString(), new Font("Times New Roman", 26), blackBrush, new Point(0, 50), drawFormat);
            Thread.Sleep(500);
            g.FillRectangle(new SolidBrush(Color.SlateGray), 0, 0, 400, 400);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button1.Visible = true;
            greenList.Clear();
            button2.Visible = false;
            pictureBox1.Enabled = false;
            g.FillRectangle(new SolidBrush(Color.SlateGray), 0, 0, 400, 400);
            Off();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Войти")
            {
                textBox3.Enabled = false;
                a = Convert.ToInt32(textBox3.Text);
                aK = 400 / a;
                button1.Text = "OK";
                pictureBox1.Enabled = true;
                GenerateALF();
                Zapusk();
                DrawGRID();
                textBox2.Enabled = true;
            }
            else
            {
                if (button1.Text == "OK")
                {
                    button1.Text = "Войти";
                    textBox2.Enabled = false;
                    if (Check(textBox1.Text) == Convert.ToInt32(textBox2.Text))
                    {// пароль верен
                        button1.Visible = false;
                        g.FillRectangle(gainBrush, 0, 0, 400, 400);
                        g.DrawString("ДОСТУП", bigFont, blackBrush, new Point(50, 100), drawFormat);
                        g.DrawString("РАЗРЕШЕН", bigFont, blackBrush, new Point(15, 200), drawFormat);
                        Thread.Sleep(600);
                        g.FillRectangle(gainBrush, 0, 0, 400, 400);
                        button2.Visible = true;
                        pxy.Clear();
                    }
                    else
                    {
                        g.FillRectangle(gainBrush, 0, 0, 400, 400);
                        button1.Visible = true;
                        greenList.Clear();
                        pictureBox1.Enabled = false;
                        textBox3.Enabled = true;
                        g.DrawString("ОШИБКА", bigFont, blackBrush, new Point(50, 150), drawFormat);
                        Thread.Sleep(700);
                        g.FillRectangle(new SolidBrush(Color.SlateGray), 0, 0, 400, 400);
                    }

                    textBox2.Text = "0";
                }
            }
        }

        private int Check(string pass)
        {
            ArrayList ar = new ArrayList();

            for (int j = 0; j < pass.Length; j++)
            {// найдем номера в алфавите
                for (int i = 0; i < alf1.Length; i++)
                {
                    if (pass[j].ToString() == alf1[i].ToString())
                    {
                        ar.Add(i);
                    }
                }
            }

            int num = 0;
            for (int j = 0; j < pass.Length; j++)
            {// найдем номера в алфавите
                int x = 0, y = 0;
                num = 0;
                do
                {
                    x += aK;
                    num++;
                    if (x >= aK * a)
                    {
                        x = 0;
                        y += aK;
                    } // возможно >=400
                }
                while (num < Convert.ToInt32(ar[j]));

                pxy.Insert(j, new XY(x, y));
            }

            int result = 0;
            for (int i = 0; i < textBox1.Text.Length - 1; i++)
            {
                do
                {
                    if (((XY)pxy[i]).X < ((XY)pxy[i + 1]).X)
                    {
                        ((XY)pxy[i]).X += aK;
                        result++;
                    }
                    else
                    {
                        if (((XY)pxy[i]).X > ((XY)pxy[i + 1]).X)
                        {
                            ((XY)pxy[i]).X -= aK;
                            result++;
                        }
                    }
                }
                while (((XY)pxy[i]).X != ((XY)pxy[i + 1]).X);

                do
                {
                    if (((XY)pxy[i]).Y < ((XY)pxy[i + 1]).Y)
                    {
                        ((XY)pxy[i]).Y += aK;
                        result++;
                    }
                    else
                    {
                        if (((XY)pxy[i]).Y > ((XY)pxy[i + 1]).Y)
                        {
                            ((XY)pxy[i]).Y -= aK;
                            result++;
                        }
                    }
                }
                while (((XY)pxy[i]).Y != ((XY)pxy[i + 1]).Y);
            }

            result++;
            return result;
        }

        /// <summary>
        /// Генератор пароля, который нужно ввести.
        /// </summary>
        private void GeneratePASS()
        {
            textBox1.Text = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                textBox1.Text += alf1[r.Next(alf1.Length)];
            }
        }

        private void GenerateALF()
        {
            if (a >= 10)
            {
                drawFont = new Font("Times New Roman", aK - 10);
            }

            if (a >= 13)
            {
                drawFont = new Font("Times New Roman", aK - 8);
            }

            if (a < 10)
            {
                drawFont = new Font("Times New Roman", aK - 30);
            }

            alf1 = alf0;
            alf2 = new string[alf1.Length];
            for (int i = 0; i < alf2.Length; i++)
            {
                alf2[i] = alf1[i].ToString();
            }

            ArrayList list = new ArrayList(alf1.Length);
            for (int i = 0; i < alf2.Length; i++)
            {
                string tmp = alf1[i].ToString();
                list.Insert(rnd.Next(0, list.Count), tmp);
            }

            alf1 = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                alf1 += list[i];
            }

            alf1 = alf1.Substring(0, a * a);
            GeneratePASS();
            textBox4.Text = alf1;
        }

        /// <summary>
        /// Изменить MXMY.
        /// </summary>
        /// <param name="mouse_x">Координата мыши X.</param>
        /// <param name="mouse_y">Координата мыши Y.</param>
        private void MXMY(int mouse_x, int mouse_y)
        {
            mouseX = mouse_x;
            mouseY = mouse_y;
            if (mouseX > 400 - aK)
            {
                mouseX = 400 - aK;
            }

            if (mouseY > 400 - aK)
            {
                mouseY = 400 - aK;
            }

            if (mouseX < 0)
            {
                mouseX = 0;
            }

            if (mouseY < 0)
            {
                mouseY = 0;
            }

            int n = 0;
            for (int i = 0; i < 400; i += aK)
            {
                if (mouseX >= i && mouseX < i + aK)
                {
                    mouseX = n;
                    break;
                }

                n += aK;
            }

            n = 0;
            for (int i = 0; i < 400; i += aK)
            {
                if (mouseY >= i && mouseY < i + aK)
                {
                    mouseY = n;
                    break;
                }

                n += aK;
            }
        }

        /// <summary>
        /// Отслеживание события сдвига мышки.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">..</param>
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MXMY(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                if (greenList.Count == 0)
                {
                    greenList.Add(new XY(mouseX, mouseY));
                    textBox2.Text = greenList.Count.ToString();
                    DrawGREEN(mouseX, mouseY);
                }
                else
                {
                    if (((XY)greenList[greenList.Count - 1]).X != mouseX || ((XY)greenList[greenList.Count - 1]).Y != mouseY)
                    {
                        greenList.Add(new XY(mouseX, mouseY));
                        textBox2.Text = greenList.Count.ToString();
                    }
                }

                if (last.X != mouseX || last.Y != mouseY)
                {
                    DrawGREEN(mouseX, mouseY);
                }

                last = new XY(mouseX, mouseY);
            }

            if (e.Button == MouseButtons.Right)
            {
                if (greenList.Count != 0)
                {
                    bool can_clear = true;
                    for (int j = 0; j < greenList.Count; j++)
                    {
                        if (((XY)greenList[j]).X == mouseX && ((XY)greenList[j]).Y == mouseY)
                        {// если нашли то что можно удалить
                            if (lastDeleted.X != mouseX || lastDeleted.Y != mouseY)
                            {// не является с такими же корродинатами то что хотим удалить как и предыдущий
                                greenList.RemoveAt(j);
                                textBox2.Text = greenList.Count.ToString();
                                for (int h = 0; h < greenList.Count; h++)
                                {// нужно изменить цвет клетки только если она помечена 1 раз
                                    if (((XY)greenList[h]).X == mouseX && ((XY)greenList[h]).Y == mouseY)
                                    {// клетка помечена еще раз
                                        can_clear = false; // запретить стирать
                                    }
                                }

                                if (can_clear == true)
                                {
                                    DEdrawGREEN(mouseX, mouseY);

                                    // Удалено это!!!: can_clear = false;
                                }

                                lastDeleted = new XY(mouseX, mouseY);
                                can_clear = false;
                                break;
                            }
                        }
                    }
                }

                last = new XY(mouseX, mouseY);
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MXMY(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                greenList.Add(new XY(mouseX, mouseY));
                textBox2.Text = greenList.Count.ToString();
                DrawGREEN(mouseX, mouseY);

                last = new XY(mouseX, mouseY);
            }

            if (e.Button == MouseButtons.Right)
            {
                if (greenList.Count != 0)
                {
                    bool can_clear = true;

                    for (int i = 0; i < greenList.Count; i++)
                    {
                        if (((XY)greenList[i]).X == mouseX && ((XY)greenList[i]).Y == mouseY)
                        {// если нашли то что можно удалить
                            greenList.RemoveAt(i);
                            textBox2.Text = greenList.Count.ToString();
                            for (int j = 0; j < greenList.Count; j++)
                            {// нужно изменить цвет клетки только если она помещена 1 раз
                                if (((XY)greenList[j]).X == mouseX && ((XY)greenList[j]).Y == mouseY)
                                {// клетка помечена еще раз
                                    can_clear = false; // запретить стирать
                                }
                            }

                            if (can_clear == true)
                            {
                                DEdrawGREEN(mouseX, mouseY); // удалено это!!!: can_clear = false;
                            }

                            lastDeleted = new XY(mouseX, mouseY);
                            can_clear = false;
                            break;
                        }
                    }
                }

                last = new XY(mouseX, mouseY);
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox3.Text) * Convert.ToInt32(textBox3.Text) > alf0.Length)
            {
                textBox3.Text = "10";
            }

            if (Convert.ToInt32(textBox3.Text) <= 0)
            {
                textBox3.Text = "10";
            }
        }
    }
}