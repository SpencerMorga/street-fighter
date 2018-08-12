﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skywalker
{
    public class Animation : Sprite
    {
        TimeSpan elaspedtime;
        public TimeSpan waitingtime = new TimeSpan(0, 0, 0, 0, 70);
        public List<Frame> frames;
        public int currentframeIndex = 0;

        public Animation (Texture2D image, Vector2 position, Color color, List<Frame> frames)
            : base (image, position, color)
        {
            this.image = image;
            this.position = position;
            this.color = color;
            this.frames = frames;
            waitingtime = TimeSpan.Zero;
        }

        public void Update (GameTime gtime)
        {
            elaspedtime += gtime.ElapsedGameTime;

            if (elaspedtime > waitingtime)
            {
                currentframeIndex++;
                if (currentframeIndex >= frames.Count)
                {
                    currentframeIndex = 0;
                }
                elaspedtime = TimeSpan.Zero;
            }
            sourceRectangle = frames[currentframeIndex].frame;
        }
    }
}