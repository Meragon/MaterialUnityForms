namespace MaterialUI
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class MaterialControl : Control
    {
        internal readonly List<MaterialRipple> Ripples = new List<MaterialRipple>();

        public bool Ripple { get; set; }
        public bool RippleCentered { get; set; }
        public Color RippleColor { get; set; }
        public Bitmap RippleImage { get; set; }
        public float RippleSpeed { get; set; }

        public MaterialControl()
        {
            Ripple = false;
            RippleCentered = false;
            RippleColor = Color.FromArgb(64, Color.White);
            RippleImage = ApplicationResources.Images.Circle;
            RippleSpeed = 1f;
        }

        public void DrawRipples(PaintEventArgs e)
        {
            ProccessRipples();

            for (int i = 0; i < Ripples.Count; i++)
            {
                if (RippleCentered)
                    e.Graphics.uwfDrawImage(RippleImage,
                        Color.FromArgb((int)(Ripples[i].Alpha), RippleColor),
                        (Width - Ripples[i].Size) / 2,
                        (Height - Ripples[i].Size) / 2,
                        Ripples[i].Size,
                        Ripples[i].Size);
                else
                    e.Graphics.uwfDrawImage(RippleImage,
                        Color.FromArgb((int)(Ripples[i].Alpha), RippleColor),
                        (Ripples[i].Offset.X - Ripples[i].Size / 2),
                        (Ripples[i].Offset.Y - Ripples[i].Size / 2),
                        Ripples[i].Size,
                        Ripples[i].Size);
            }
        }

        private void ProccessRipples()
        {
            if (Ripple)
            {
                for (int i = 0; i < Ripples.Count; i++)
                {
                    if (Ripples[i].Step(RippleSpeed) == false)
                    {
                        Ripples.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }
}
