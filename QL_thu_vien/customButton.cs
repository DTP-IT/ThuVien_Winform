using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace QL_thu_vien
{
    public class customButton : Button
    {
        //fields
        private int boderSize = 0;
        private int boderRadius = 40;
        private Color boderColor = Color.PaleVioletRed;
        //Properties
        [Category("Custom Button")]
        public int BoderSize 
        {
            get 
            { 
               return boderSize; 
            } 
            set 
            {
                boderSize = value;
                this.Invalidate();
            } 
        }
        [Category("Custom Button")]
        public int BoderRadius { 
            get => boderRadius;
            set 
            { 
                boderRadius = value;
                this.Invalidate();
            } 
        }
        [Category("Custom Button")]
        public Color BoderColor 
        { 
            get => boderColor;
            set 
            { 
                boderColor = value;
                this.Invalidate();
            }  
        }
        [Category("Custom Button")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }
        [Category("Custom Button")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }
        //contructor
        public customButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
        }

        //Methods
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width-radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height-radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (boderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, boderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, boderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBoder= new Pen(boderColor, boderSize))
                {
                    penBoder.Alignment = PenAlignment.Inset;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface boder for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button boder
                    if (boderSize >=1)
                    {
                        //Draw control border
                        pevent.Graphics.DrawPath(penBoder, pathBorder);
                    }
                }
            }
            else
            {
                //Button surface
                this.Region = new Region(rectSurface);
                //Button border
                if (boderSize >=1)
                {
                    using (Pen penBorder = new Pen(boderColor, boderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);

        }
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }
    }
}
