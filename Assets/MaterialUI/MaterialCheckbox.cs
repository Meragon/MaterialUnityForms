using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialUI
{
    public class MaterialCheckbox : MaterialControl
    {
        public const int DefaultHeight = 48;
        public const int DefaultWidth = 128;

        private float _imageAlpha = 0f;

        public bool Checked { get; set; }
        public Image Image { get; set; }
        public Color ImageColor { get; set; }
        public Image ImageOutline { get; set; }

        public MaterialCheckbox()
        {
            BackColor = Color.Transparent;
            Ripple = true;
            RippleColor = Color.FromArgb(64, 0, 188, 212);
            RippleSpeed = 1.4f;
            this.SetMaterialFontNormal();
            this.SetMaterialStyle();
            Size = new Size(DefaultWidth, DefaultHeight);
        }

        protected override void OnClick(EventArgs e)
        {
            Checked = !Checked;
            Ripples.Add(new MaterialRipple()
            {
                Alpha = RippleColor.A,
                MaxSize = Image.Texture.Width * 1.4f,
                Offset = new Point(12 + Image.Texture.Width / 2, 12 + Image.Texture.Height / 2),
            });
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (ImageOutline != null && ImageOutline.Texture != null)
                e.Graphics.uwfDrawImage(ImageOutline, ImageColor, 12, 12, ImageOutline.Texture.Width, ImageOutline.Texture.Height);

            if (Checked)
                _imageAlpha = MathHelper.FloatLerp(_imageAlpha, ImageColor.A, 4);
            else
                _imageAlpha = MathHelper.FloatLerp(_imageAlpha, 0, 4);

            if (Image != null && Image.Texture != null)
                e.Graphics.uwfDrawImage(Image, Color.FromArgb((int)_imageAlpha, ImageColor), 12, 12, Image.Texture.Width, Image.Texture.Height);

            int imgWidth = 0;
            if (Image != null && Image.Texture != null)
                imgWidth = Image.Texture.Width;

            e.Graphics.uwfDrawString(Text, Font, ForeColor, 12 + imgWidth + 8, 10, Width, 24);

            DrawRipples(e);
        }
    }
}
