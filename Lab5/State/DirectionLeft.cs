﻿using Lab5;
using Lab5.State;
using CockroachApp.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CockroachApp.State
{
    class DirectionLeft : DirectionState, IDirection
    {
        public DirectionLeft(Bitmap image)
        {
            this.image = image;
        }
        public direction Trend => direction.Left;
        public void Step(ref int X, ref int Y)
        {
            X -= step;
        }

        IDirection IDirection.ChangeTrend(string command)
        {
            direction newtrend = Trends[command];
            switch (newtrend)
            {
                case direction.Up:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return new DirectionUp(image);
                case direction.Right:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return new DirectionRight(image);
                case direction.Down:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    return new DirectionDown(image);
                default: return new DirectionLeft(image);
            }
        }
    }
}
