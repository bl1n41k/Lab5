using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
	public class Cockroach
	{
		
		public Bitmap Image;
		direction trend = direction.Right;
		const int step = 30;
		int x;
		int y;
		//Конструктор с параметром – изображение
		public Cockroach(Bitmap _Image)
		{
			Image = _Image;
		}
		public int X
		{
			get => x;
			set => x = value;
		}
		public int Y
		{
			get => y;
			set => y = value;
		}

		public Bitmap newImage
		{
			get => Image;
			set => Image = value;
		}

		public void Step()
		{
			switch (trend)
			{
				case direction.Right:
					{
						X += step;		
					}
					break;
				case direction.Down:
					{
						Y += step;					
					}
					break;
				case direction.Left:
					{
						X -= step;
					}
					break;
				case direction.Up:
					{
						Y -= step;
					}
					break;
			}
		}

		//Изменение направления, параметр – первая буква направления
		public void ChangeTrend(char c)
		{
			direction newtrend = trend;
			for (direction y = direction.Up; y <= direction.Left; y++)
				if (char.ToLower(c) == char.ToLower(y.ToString()[0]))
				{
					newtrend = y;
					break;
				}
			switch (trend)
			{
				case direction.Up:
					switch (newtrend)
					{
						case direction.Right: Image.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
						case direction.Down: Image.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
						case direction.Left: Image.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
					}
					break;
				case direction.Right:
					switch (newtrend)
					{
						case direction.Up: Image.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
						case direction.Down: Image.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
						case direction.Left: Image.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
					}
					break;
				case direction.Down:
					switch (newtrend)
					{
						case direction.Right: Image.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
						case direction.Up: Image.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
						case direction.Left: Image.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
					}
					break;
				case direction.Left:
					switch (newtrend)
					{
						case direction.Right: Image.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
						case direction.Down: Image.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
						case direction.Up: Image.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
					}
					break;
			}
			trend = newtrend;
		}
	} 
}
	

