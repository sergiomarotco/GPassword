using System;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        readonly string alf0 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefjhigklmnopqrstuvwxyz{}}();:./|<>!@#$%^&*1234567890№`~?-=+¶Θ۞‡ↀ∑∭⏎☺☻✸♋♕➲♫♡©®●►▲◄▼☮☂☎☠☽☾✉✈♣♤♥♦♧☄☊☭☁ϟ┿❀✾✿✄✪♞☯абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string alf1 = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            textBox4.Text = alf0;
            a = Convert.ToInt32(textBox3.Text);
            a_k = 400 / a;
            GenerateALF();
        }

        /// <summary>
        /// Размер стороны сетки
        /// </summary>
        private int a = 10;

        /// <summary>
        /// Коэффициент вычислений
        /// </summary>
        private int a_k = 40;
        string[] alf2;
        private readonly Random rnd = new Random();
        private Graphics g;
        readonly Pen blackPen = new Pen(Color.Black, 1);
        private Font drawFont = new Font("Times New Roman", 26);
        readonly Font BigFont = new Font("Times New Roman", 50);
        readonly SolidBrush GreenBrush = new SolidBrush(Color.GreenYellow);
        readonly SolidBrush GainBrush = new SolidBrush(Color.Gainsboro);
        readonly SolidBrush BlackBrush = new SolidBrush(Color.Black);
        readonly StringFormat drawFormat = new StringFormat();

        private void DrawGREEN(int Mx, int My)
        {
            int num = -a_k;
            g.FillRectangle(GreenBrush, Mx + 1, My + 1, a_k - 1, a_k - 1);
            if (My == 0)
            {
                num = My / a_k * a + Mx / a_k;
            }
            else
            {
                num = My / a_k * a + Mx / a_k;
            }
            g.DrawString(alf1[num].ToString(), drawFont, BlackBrush, new Point(Mx, My), drawFormat);
        }
        private void DEdrawGREEN(int Mx, int My)
        {
            int num = Mx / a_k * a + My / a_k;
            g.FillRectangle(GreenBrush, Mx + 1, My + 1, a_k - 1, a_k - 1);
            if (My == 0)
            {
                num = My / a_k * a + Mx / a_k;
            }
            else
            {
                num = My / a_k * a + Mx / a_k;
            }
            g.FillRectangle(GainBrush, Mx + 1, My + 1, a_k - 1, a_k - 1);
            g.DrawString(alf1[num].ToString(), drawFont, BlackBrush, new Point(Mx, My), drawFormat);
        }
        private void DrawGRID()
        {
            g.FillRectangle(GainBrush, 0, 0, 400, 400);
            //drawGREEN(Mx,My);//сначала нарисовать зеленые клеточки            
            for (int i = 0; i <= 400; i += a_k)
            {
                g.DrawLine(blackPen, new Point(i, 0), new Point(i, 400));
                g.DrawLine(blackPen, new Point(0, i), new Point(400, i));
            }
            int y = 0;
            int num = 0;
            int x = 0; for (int i = 0; i < textBox1.Text.Length; i++)
            {
                Pxy.Add(new XY(0, 0));
            }
            do
            {
                Thread.Sleep(1);
                g.DrawString(alf1[num].ToString(), drawFont, BlackBrush, new Point(x, y), drawFormat);
                num++;
                x += a_k;
                if (x >= a_k * a) { x = 0; y += a_k; }//возможно >= 400
            } while (num < alf1.Length);
        }

        private readonly ArrayList Pxy = new ArrayList();
        /// <summary>
        /// Значение настоящего динамического пароля
        /// </summary>
        private void Zapusk()
        {
            g.DrawString("Введите".ToString(), new Font("Times New Roman", 26), BlackBrush, new Point(0, 10), drawFormat);
            Thread.Sleep(500);
            g.DrawString("пароль".ToString(), new Font("Times New Roman", 26), BlackBrush, new Point(0, 50), drawFormat);
            Thread.Sleep(500);
        }
        private void Off()
        {
            g.DrawString("Экран".ToString(), new Font("Times New Roman", 26), BlackBrush, new Point(0, 10), drawFormat);
            Thread.Sleep(500);
            g.DrawString("заблокирован".ToString(), new Font("Times New Roman", 26), BlackBrush, new Point(0, 50), drawFormat);
            Thread.Sleep(500);
            g.FillRectangle(new SolidBrush(Color.SlateGray), 0, 0, 400, 400);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button1.Visible = true;
            GREEN.Clear();
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
                a_k = 400 / a;
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
                    if (Check(textBox1.Text) == Convert.ToInt32(textBox2.Text))//пароль верен
                    {
                        button1.Visible = false;
                        g.FillRectangle(GainBrush, 0, 0, 400, 400);
                        g.DrawString("ДОСТУП", BigFont, BlackBrush, new Point(50, 100), drawFormat);
                        g.DrawString("РАЗРЕШЕН", BigFont, BlackBrush, new Point(15, 200), drawFormat);
                        Thread.Sleep(600);
                        g.FillRectangle(GainBrush, 0, 0, 400, 400);
                        button2.Visible = true;
                        Pxy.Clear();
                    }
                    else
                    {
                        g.FillRectangle(GainBrush, 0, 0, 400, 400);
                        button1.Visible = true;
                        GREEN.Clear();
                        pictureBox1.Enabled = false;
                        textBox3.Enabled = true;
                        g.DrawString("ОШИБКА", BigFont, BlackBrush, new Point(50, 150), drawFormat);
                        Thread.Sleep(700);
                        g.FillRectangle(new SolidBrush(Color.SlateGray), 0, 0, 400, 400);
                    }
                    textBox2.Text = "0";
                }
            }
        }
        int Mx = -40; int My = -40;
        XY Last = new XY(0, 0);
        readonly ArrayList GREEN = new ArrayList();
        private int Check(string Pass)
        {
            ArrayList Ar = new ArrayList();

            for (int j = 0; j < Pass.Length; j++)//найдем номера в алфавите
            {
                for (int i = 0; i < alf1.Length; i++)
                {
                    if (Pass[j].ToString() == alf1[i].ToString())
                    {
                        Ar.Add(i);
                    }
                }
            }
            int num = 0;
            for (int j = 0; j < Pass.Length; j++)//найдем номера в алфавите
            {
                int x = 0, y = 0; num = 0;
                do
                {
                    x += a_k;
                    num++;
                    if (x >= a_k * a) { x = 0; y += a_k; }//возможно >=400
                } while (num < Convert.ToInt32(Ar[j]));

                Pxy.Insert(j, new XY(x, y));
            }
            int result = 0;
            for (int i = 0; i < textBox1.Text.Length - 1; i++)
            {
                do
                {
                    if (((XY)Pxy[i]).X < ((XY)Pxy[i + 1]).X)
                    {
                        ((XY)Pxy[i]).X += a_k; result++;
                    }
                    else
                    {
                        if (((XY)Pxy[i]).X > ((XY)Pxy[i + 1]).X)
                        {
                            ((XY)Pxy[i]).X -= a_k; result++;
                        }
                    }
                } while (((XY)Pxy[i]).X != ((XY)Pxy[i + 1]).X);
                do
                {
                    if (((XY)Pxy[i]).Y < ((XY)Pxy[i + 1]).Y)
                    {
                        ((XY)Pxy[i]).Y += a_k; result++;
                    }
                    else
                    {
                        if (((XY)Pxy[i]).Y > ((XY)Pxy[i + 1]).Y)
                        {
                            ((XY)Pxy[i]).Y -= a_k; result++;
                        }
                    }
                } while (((XY)Pxy[i]).Y != ((XY)Pxy[i + 1]).Y);
            }
            result++;
            return result;
        }

        readonly Random r = new Random();
        /// <summary>
        /// Генератор пароля, который нужно ввести
        /// </summary>
        private void GeneratePASS()
        {
            textBox1.Text = "";
            for (int i = 0; i < 6; i++)
                textBox1.Text += alf1[r.Next(alf1.Length)];
        }
        private void GenerateALF()
        {
            if (a >= 10)
                drawFont = new Font("Times New Roman", a_k - 10);
            if (a >= 13)
                drawFont = new Font("Times New Roman", a_k - 8);
            if (a < 10)
                drawFont = new Font("Times New Roman", a_k - 30);

            alf1 = alf0;
            alf2 = new string[alf1.Length];
            for (int i = 0; i < alf2.Length; i++)
            {
                alf2[i] = alf1[i].ToString();
            }
            ArrayList L = new ArrayList(alf1.Length);
            for (int i = 0; i < alf2.Length; i++)
            {
                string tmp = alf1[i].ToString();
                L.Insert(rnd.Next(0, L.Count), tmp);
            }
            alf1 = "";
            for (int i = 0; i < L.Count; i++)
            {
                alf1 += L[i];
            }
            alf1 = alf1.Substring(0, a * a);
            GeneratePASS();
            textBox4.Text = alf1;   }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="Mx">(Ex - координата Х мыши)</param>
        /// <param name="My"></param>
        void MXMY(int Ex, int Ey)
        {
            Mx = Ex; My = Ey;
            if (Mx > 400 - a_k) Mx = (400 - a_k);
            if (My > 400 - a_k) My = (400 - a_k);
            if (Mx < 0) Mx = 0; if (My < 0) My = 0;
            int n = 0;
            for (int i = 0; i < 400; i += a_k)
            {
                if (Mx >= i && Mx < i + a_k)
                {
                    Mx = n;
                    break;
                }
                n += a_k;
            }
            n = 0;
            for (int i = 0; i < 400; i += a_k)
            {
                if (My >= i && My < i + a_k)
                {
                    My = n;
                    break;
                }
                n += a_k;
            }
        }
        /// <summary>
        /// Отслеживание события сдвига мышки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MXMY(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                if (GREEN.Count == 0)
                {
                    GREEN.Add(new XY(Mx, My));
                    textBox2.Text = GREEN.Count.ToString();
                    DrawGREEN(Mx, My);
                }
                else
                {
                    if (((XY)GREEN[GREEN.Count - 1]).X != Mx || ((XY)GREEN[GREEN.Count - 1]).Y != My)
                    {
                        GREEN.Add(new XY(Mx, My)); textBox2.Text = GREEN.Count.ToString();
                    }
                }
                if (Last.X != Mx || Last.Y != My)
                    DrawGREEN(Mx, My);
                Last = new XY(Mx, My);
            }
            if (e.Button == MouseButtons.Right)
            {
                if (GREEN.Count != 0)
                {
                    bool can_clear = true;
                    for (int i = 0; i < GREEN.Count; i++)//при удалении размер изменится
                    {
                        for (int j = 0; j < GREEN.Count; j++)
                        {
                            if (((XY)GREEN[j]).X == Mx && ((XY)GREEN[j]).Y == My)//если нашли то что можно удалить
                            {
                                if (LastDeleted.X != Mx || LastDeleted.Y != My)//не является с такими же корродинатами то что хотим удалить каки предыдущий
                                {
                                    GREEN.RemoveAt(j);
                                    textBox2.Text = GREEN.Count.ToString();
                                    for (int h = 0; h < GREEN.Count; h++)//нужно изменить цвет клетки только если она помещена 1 раз
                                    {
                                        if (((XY)GREEN[h]).X == Mx && ((XY)GREEN[h]).Y == My)//клетка помечена еще раз
                                        {
                                            can_clear = false;//запретить стирать
                                        }
                                    }
                                    if (can_clear == true)
                                    {
                                        DEdrawGREEN(Mx, My); can_clear = false;
                                    }
                                    LastDeleted = new XY(Mx, My);
                                    can_clear = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                Last = new XY(Mx, My);
            }
        }
        XY LastDeleted = new XY(0, 0);
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MXMY(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                GREEN.Add(new XY(Mx, My));
                textBox2.Text = GREEN.Count.ToString();
                DrawGREEN(Mx, My);

                Last = new XY(Mx, My);
            }
            if (e.Button == MouseButtons.Right)
            {
                if (GREEN.Count != 0)
                {
                    bool can_clear = true;

                    for (int j = 0; j < GREEN.Count; j++)
                    {
                        if (((XY)GREEN[j]).X == Mx && ((XY)GREEN[j]).Y == My)//если нашли то что можно удалить
                        {
                            GREEN.RemoveAt(j);
                            textBox2.Text = GREEN.Count.ToString();
                            for (int h = 0; h < GREEN.Count; h++)//нужно изменить цвет клетки только если она помещена 1 раз
                            {
                                if (((XY)GREEN[h]).X == Mx && ((XY)GREEN[h]).Y == My)//клетка помечена еще раз
                                {
                                    can_clear = false;//запретить стирать
                                }
                            }
                            if (can_clear == true)
                            {
                                DEdrawGREEN(Mx, My); can_clear = false;
                            }
                            LastDeleted = new XY(Mx, My);
                            can_clear = false; break;
                        }
                    }
                }
                Last = new XY(Mx, My);
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox3.Text) * Convert.ToInt32(textBox3.Text) > alf0.Length) textBox3.Text = "10";
            if (Convert.ToInt32(textBox3.Text) <= 0) textBox3.Text = "10";
        }
    }
}

/// <summary>
/// Класс координат клеток
/// </summary>
class XY
{
    public XY(int X, int Y)
    {
        this.X = X; this.Y = Y;
    }
    public int X = 0;
    public int Y = 0;
}
