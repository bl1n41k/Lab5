﻿using Lab5;
using Lab5.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CockroachApp.State
{
    class DirectionUp : DirectionState, IDirection
    {
        public DirectionUp(Bitmap image)
        {
            this.image = image;
        }
        public direction Trend => direction.Up;

        public void Step(ref int X, ref int Y)
        {
            Y -= step;
        }
        IDirection IDirection.ChangeTrend(string command)
        {
            direction newtrend = Trends[command];
            switch (newtrend)
            {
                case direction.Right:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return new DirectionRight(image);
                case direction.Down:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return new DirectionDown(image);
                case direction.Left:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    return new DirectionLeft(image);
                default: return new DirectionUp(image);
            }
        }
    }
}