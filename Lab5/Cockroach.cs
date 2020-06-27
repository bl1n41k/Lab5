using Lab5.State;
using CockroachApp.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace Lab5
{
    public class Cockroach
    {
        public Bitmap image;
        int x;
        int y;
        IDirection direction;
        public Cockroach(Bitmap _image)
        {
            image = _image;
            direction = new DirectionUp(image);
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
        public Bitmap Image
        {
            get => image;
            set => image = value;
        }
        public void Step()
        {
            direction.Step(ref x, ref y);
        }

        public void ChangeTrend(string s)
        {
            direction = direction.ChangeTrend(s);
        }
    }
}

