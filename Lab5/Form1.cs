using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab5
{
    enum direction : byte { Up, Right, Down, Left };
    public partial class Form1 : Form
    {
        int AlgStep, x, y;
        bool newImage = false;
        Cockroach cockroachStyle;
        Cockroach workCockroach;//рабочий Таракан - активный Таракан, который будет выполнять алгоритм
        PictureBox workpb;//рабочее поле PictureBox - поле на котрой будет рабочий Таракан
        List<Cockroach> LC;//Список для хранения созданных Тараканов
        List<PictureBox> PB;//Список для хранения созданных объектов PictureBox
        List<Cockroach> workС;//Список для хранения рабочих Тараканов
        List<PictureBox> workP;//Список для хранения активных объектов PictureBox
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            LC = new List<Cockroach>();
            PB = new List<PictureBox>();
            workP = new List<PictureBox>();
            workС = new List<Cockroach>();
        }
        public void RePaint(Cockroach c, PictureBox p)
        {
            if (newImage == false)
            {
                c.X = x;
                c.Y = y;
                p.Bounds = new Rectangle(x, y, c.Image.Width, c.Image.Height);//создание новых границ изображения для PictureBox
               
            }
            p.Bounds = new Rectangle(c.X, c.Y, c.Image.Width, c.Image.Height);
            
            p.Image = c.Image;
        }

        public void Show(Cockroach c, PictureBox p, Panel owner)
        {
            newImage = true;
            RePaint(c, p);
            owner.Controls.Add(p);//добавляем PictureBox к элементу Panel
        }

        private void IMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Form.ModifierKeys != Keys.Control)
                {
                    ClearWorkItems();
                }
                int k = PB.IndexOf(sender as PictureBox);//запоминаем номер нажатого компонента PictureBox
                workpb = sender as PictureBox;//объявляем его рабочим  
                workCockroach = LC[k];//по найденному номеру находим Таракана в списке
                if (!workP.Any())
                {
                    workС.Add(workCockroach);
                    workP.Add(workpb);
                }
                else if (!workP.Contains(workpb))
                {
                    workС.Add(workCockroach);
                    workP.Add(workpb);
                }
            }
            else if (e.Button == MouseButtons.Right)//cмена образа таракана нажатием ПКМ
            {
                ClearWorkItems();
                int k = PB.IndexOf(sender as PictureBox);
                workpb = sender as PictureBox;
               
                if ((LC[k].Image.Tag).ToString() == "2")
                {
                    x = workpb.Location.X;
                    y = workpb.Location.Y;
                    LC[k] = new Cockroach(new Bitmap("Cockroach1.png"));
                    LC[k].Image.Tag = "1";
                    workpb.Location = new Point(x, y);
                }
                else
                {
                    x = workpb.Location.X;
                    y = workpb.Location.Y;
                    LC[k] = new Cockroach(new Bitmap("Cockroach2.png"));
                    LC[k].Image.Tag = "2";
                    workpb.Location = new Point(x, y);
                }
                newImage = false;
                workP.Add(workpb);
                workС.Add(LC[k]);
                RePaint(LC[k], PB[k]);
            }
        }

        private void IMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox picture = sender as PictureBox;
                picture.Tag = new Point(picture.Location.X , picture.Location.Y );//запоминаем координаты мыши на момент начала перетаскивания
                picture.DoDragDrop(sender, DragDropEffects.Move);//начинаем перетаскивание ЧЕГО и с КАКИМ ЭФФЕКТОМ
            }
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            cockroachStyle = new Cockroach(new Bitmap("Cockroach1.png"));
            cockroachStyle.Image.Tag = "1";
            cockroachStyle.X = rand.Next(Field.Width - 100);
            cockroachStyle.Y = rand.Next(Field.Height - 100);
            PictureBox p = new PictureBox();
            p.Location = new Point(cockroachStyle.X, cockroachStyle.Y);
            Show(cockroachStyle, p, Field);
            p.MouseMove += new MouseEventHandler(IMouseMove);
            p.MouseDown += new MouseEventHandler(IMouseDown);
            PB.Add(p);
            LC.Add(cockroachStyle);
            workCockroach = cockroachStyle;
            workpb = p;
            ClearWorkItems();
            workP.Add(workpb);
            workС.Add(workCockroach);
        }

        private void Field_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void Field_DragDrop(object sender, DragEventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                return;
            }
            //извлекаем PictureBox
            PictureBox picture = (PictureBox)e.Data.GetData(typeof(PictureBox));
            Panel panel = sender as Panel;
            //получаем клиентские координаты в момент отпускания кнопки
            Point pointDrop = panel.PointToClient(new Point(e.X, e.Y));
            //извлекаем клиентские координаты мыши в момент начала перетаскивания
            Point pointDrag = (Point)picture.Tag;
            //вычисляем и устанавливаем Location для PictureBox в Panel
            picture.Location = new Point(pointDrop.X - pointDrag.X + picture.Location.X, pointDrop.Y - pointDrag.Y + picture.Location.Y);
            workС[0].X = picture.Location.X;
            workС[0].Y = picture.Location.Y;
            workP[0].Location = picture.Location;
            picture.Parent = panel;
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }

        private void DownBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }

        private void StepBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Add((sender as Button).Text);
        }

        private void timerAlgorithm_Tick(object sender, EventArgs e)
        {
            if (AlgStep == Algorithm.Items.Count) //конец алгоритма
            {
                timerAlgorithm.Enabled = false; //выключение таймера
            }
            else//выполнение команды из списка
            {
                for (int i = 0; i < workС.Count; ++i)
                {
                    string s = (string)Algorithm.Items[AlgStep];
                    Algorithm.SetSelected(AlgStep, true);
                    if (s == "Step")
                        workС[i].Step();
                    if (s == "Up")
                        workС[i].ChangeTrend(s);
                    if (s == "Left")
                        workС[i].ChangeTrend(s);
                    if (s == "Right")
                        workС[i].ChangeTrend(s);
                    if (s == "Down")
                        workС[i].ChangeTrend(s);
                    newImage = true;
                    RePaint(workС[i], workP[i]);
                }
                AlgStep++;
            }
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            timerAlgorithm.Enabled = true;
            AlgStep = 0;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Algorithm.Items.Clear();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            while (workP.Count > 0)
            {
                workP[0].Dispose();
                workP.RemoveAt(0);
            }
            if (workpb != null)
                workpb.Dispose();
            ClearWorkItems();
        }

        private void ClearWorkItems()
        {
            workС.Clear();
            workP.Clear();
        }
    }
}
