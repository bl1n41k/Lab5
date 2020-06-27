using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using Lab5;

namespace CockroachApp.State
{
    class DirectionState
    {
        protected Dictionary<string, direction> Trends = new Dictionary<string, direction>()
        {
            {"Up", direction.Up },
            {"Down", direction.Down },
            {"Left", direction.Left },
            {"Right", direction.Right}
        };
        protected Bitmap image;
        protected const int step = 30;
    }
}