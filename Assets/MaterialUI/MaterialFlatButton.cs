using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialUI
{
    public class MaterialFlatButton : MaterialControl
    {
        public const int DefaultHeight = 36;
        public const int DefaultWidth = 80;

        private Color _currentBackColor = Color.FromArgb(0, 255, 255, 255);
        private Color _lerpColor = Color.FromArgb(0, 255, 255, 255);
        private float _pressTimer = 0f;

        public MaterialButtonTypes ButtonType { get; set; }
        public float ColorLerpSpeed { get; set; }
        public Image Image { get; set; }
        public Color ImageColor { get; set; }
        public Rectangle ImageRect { get; set; }
        public Color HoverColor { get; set; }
        public Color PressedColor { get; set; }
        public float PressWaitTime { get; set; }
        
        public ContentAlignment TextAlign { get; set; }

        public MaterialFlatButton()
        {
            ButtonType = MaterialButtonTypes.Flat;
            ColorLerpSpeed = 4;
            PressWaitTime = .2f;
            Ripple = true;
            RippleSpeed = 1.4f;
            this.SetMaterialFontNormal();
            this.SetMaterialStyle(MaterialFlatButonStyles.Default);
            Size = new Size(DefaultWidth, DefaultHeight);
            Text = "BUTTON";
            TextAlign = ContentAlignment.MiddleCenter;
        }

        public void ForceUpdateColor()
        {
            _currentBackColor = BackColor;
        }

        protected override void OnClick(EventArgs e)
        {
            _currentBackColor = PressedColor;
            _pressTimer = PressWaitTime;
            if (Ripple)
                Ripples.Add(new MaterialRipple() {
                    Alpha = RippleColor.A,
                    MaxSize = Width,
                    Offset = PointToClient(MousePosition)
                });
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (uwfHovered)
                _lerpColor = HoverColor;
            else
                _lerpColor = BackColor;

            if (_pressTimer > 0)
                _pressTimer -= swfHelper.GetDeltaTime();
            else
                _currentBackColor = MathHelper.ColorLerp(_currentBackColor, _lerpColor, ColorLerpSpeed);

            switch (ButtonType)
            {
                default:
                    e.Graphics.uwfFillRectangle(_currentBackColor, 0, 0, Width, Height);
                    break;
            }
            
            e.Graphics.uwfDrawString(Text, Font, ForeColor, 
                Padding.Left, 
                Padding.Top, 
                Width - Padding.Right - Padding.Left, 
                Height - Padding.Bottom - Padding.Top, 
                TextAlign);

            if (Image != null && Image.Texture != null)
                e.Graphics.uwfDrawImage(Image, ImageColor, ImageRect.X, ImageRect.Y, ImageRect.Width, ImageRect.Height);

            DrawRipples(e);
        }
    }
    
    public enum MaterialButtonTypes
    {
        Flat,
        Raised
    }
    public enum MaterialFlatButonStyles
    {
        Default,
        Primary,
        Secondary,
        Disabled,
    }
}
