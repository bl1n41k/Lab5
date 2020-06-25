using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
	enum direction : byte { Up, Right, Down, Left };
	public partial class Form1 : Form
	{
		int AlgStep;
		Cockroach workCockroach;//рабочий Таракан - активный Таракан, который будет выполнять алгоритм
		PictureBox workpb;//рабочее поле PictureBox - поле на котрой будет рабочий Таракан
        List<Cockroach> LC;//Список для хранения созданных Тараканов
        List<PictureBox> PB;//Список для хранения созданных объектов PictureBox
		List<Cockroach> workC;//Список для хранения рабочих Тараканов
		List<PictureBox> workP;//Список для хранения активных объектов PictureBox
		Random rand;
		public Form1()
		{
			InitializeComponent();
			rand = new Random();
			LC = new List<Cockroach>();
			PB = new List<PictureBox>();
			workP = new List<PictureBox>();
			workC = new List<Cockroach>();
		}

		private void NewBtn_Click(object sender, EventArgs e)
		{
			Cockroach cockroach = new Cockroach(new Bitmap("cockroach1.png"));
			cockroach.Image.Tag = "1";
			cockroach.X = (Field.Width/2)+ rand.Next(-200,200);
			cockroach.Y = (Field.Height/2) + rand.Next(-200,200);
			PictureBox p = new PictureBox();
			p.Location = new Point(cockroach.X, cockroach.Y);
			Show(p, Field, cockroach);
			p.MouseMove += new MouseEventHandler(IMouseMove);
			p.MouseDown += new MouseEventHandler(IMouseDown);
			PB.Add(p);
			LC.Add(cockroach);
			workCockroach = cockroach;
			workpb = p;
			workC.Clear();
			workP.Clear();
			workC.Add(workCockroach);
			workP.Add(workpb); 
		}
		private void IMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (Form.ModifierKeys != Keys.Control)
				{
					workC.Clear();
					workP.Clear();
				}
				int k = PB.IndexOf(sender as PictureBox);//запоминаем номер нажатого компонента PictureBox
				workpb = sender as PictureBox;//объявляет его рабочим
				workCockroach = LC[k];//по найденному номеру находим Таракана в списке
				if (!workP.Any())
				{
					workC.Add(workCockroach);
					workP.Add(workpb);
				}
				else if (!workP.Contains(workpb))
				{
					workC.Add(workCockroach);
					workP.Add(workpb);
				}
			}
			else if (e.Button == MouseButtons.Right)  // Изменяем образ выбранному таракану при нажатии пкм
			{
				if (e.Button == MouseButtons.Right)
				{
					int k = PB.IndexOf(sender as PictureBox);
					workpb = sender as PictureBox;
					workCockroach = LC[k];
					if ((LC[k].newImage.Tag).ToString() == "1")
					{
						LC[k] = new Cockroach(new Bitmap("cockroach2.png"));
						LC[k].newImage.Tag = "2";
					}
					else
					{
						LC[k] = new Cockroach(new Bitmap("cockroach1.png"));
						LC[k].newImage.Tag = "1";
					}
					workP.Add(workpb);
					workC.Add(workCockroach);
					RePaint(PB[k], workCockroach);
				}
			}
			
		}
		private void IMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				PictureBox picture = sender as PictureBox;
				picture.Tag = new Point(e.X, e.Y);//запоминаем координаты мыши на момент начала перетаскивания
				picture.DoDragDrop(sender, DragDropEffects.Move);//начинаем перетаскивание ЧЕГО и с КАКИМ ЭФФЕКТОМ
			}
		}

		private void Field_DragDrop(object sender, DragEventArgs e)
		{
			if (Form.ModifierKeys == Keys.Control) return;
			//извлекаем PictureBox
			PictureBox picture = (PictureBox)e.Data.GetData(typeof(PictureBox));
			Panel panel = sender as Panel;
			//получаем клиентские координаты в момент отпускания кнопки
			Point pointDrop = panel.PointToClient(new Point(e.X, e.Y));
			//извлекаем клиентские координаты мыши в момент начала перетскивания
			Point pointDrag = (Point)picture.Tag;
			//вычисляем и устанавливаем Location для PictureBox в Panel
			picture.Location = pointDrop;
			//устанавливаем координаты для X и Y для рабочего таракана
			workC[0].X = picture.Location.X;
			workC[0].Y = picture.Location.Y;
			workP[0].Location = picture.Location;
			picture.Parent = panel;
		}

		private void Field_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(PictureBox)))
			{
				e.Effect = DragDropEffects.Move;
			}
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
				timerAlgorithm.Stop(); //выключение таймера
			}
			else//выполнение команды из списка
			{
				for (int i = 0; i < workC.Count; i++)
				{
					string s = (string)Algorithm.Items[AlgStep];
					Algorithm.SetSelected(AlgStep, true);
					if (s == "Step") workC[i].Step();
					else workC[i].ChangeTrend(s[0]);
					RePaint(workP[i], workC[i]);
				}
				AlgStep++;
			}
		}

		private void RunBtn_Click(object sender, EventArgs e)
		{
			AlgStep = 0;
			timerAlgorithm.Start();
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
			if (workpb != null) workpb.Dispose();
			workC.Clear();
			workP.Clear();
		}

		//Изображение объекта Таракан в PictureBox используется при изменении направления Таракана
		public void RePaint(PictureBox p, Cockroach c)
		{
			p.Bounds = new Rectangle(c.X, c.Y, c.Image.Width, c.Image.Height);//создание новых границ изображения для PictureBox
			p.Image = c.Image;
		}

		//Изображение Таракана на поле
		public void Show(PictureBox p, Panel owner, Cockroach c)
		{
			RePaint(p,c);
			owner.Controls.Add(p);// добавляем PictureBox к элементу Panel
		}
	}
}
