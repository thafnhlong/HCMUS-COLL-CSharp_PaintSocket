﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_3.Custom
{
    public class LineDraw : BasicDraw
    {
        public LineDraw() { TypeOf = Form1.DrawMode.line; }
        public LineDraw(Point p1, Point p2, Pen penCur)
        {
            TypeOf = Form1.DrawMode.line;
            Vertices.Add(new Vertex { X = p1.X, Y = p1.Y });
            Vertices.Add(new Vertex { X = p2.X, Y = p2.Y });

            pen = penCur.Clone() as Pen;

            UpdateBounds();
        }

        protected override void GetPathContent(ref GraphicsPath gp)
        {
            if (gp != null) gp.Dispose();
            gp = new GraphicsPath();
            gp.AddLine(Vertices[0].X, Vertices[0].Y, Vertices[1].X, Vertices[1].Y);
        }
        public override BasicDraw clone()
        {
            var temp = (LineDraw)base.clone();
            temp.UpdateBounds();
            return temp;
        }
        protected override BasicDraw CreateInstanceForClone()
        {
            return new LineDraw();
        }
        protected override void UpdateBounds()
        {
            Left = Math.Min(Vertices[0].X, Vertices[1].X);
            Top = Math.Min(Vertices[0].Y, Vertices[1].Y);
            Width = Math.Abs(Vertices[0].X - Vertices[1].X);
            Height = Math.Abs(Vertices[0].Y - Vertices[1].Y);
        }
    }
}
