namespace MaterialUI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class MaterialTextField : MaterialControl
    {
        public static readonly Color DefaultLineFillColor = Color.FromArgb(40, 153, 242);

        private readonly Pen penLine = new Pen(Color.Transparent);
        private readonly Pen penLineFill = new Pen(Color.Transparent);
        
        private float bottomLineYOffset = 24;
        private float coloredLineWidth;
        private Color floatingTextColor;
        private float floatingTextFontHeight = 12;
        private float floatingTextPositionY;
        private float placeholderAlpha;
        private float textBottomPadding = 8;

        public string BottomText { get; set; }
        public Color BottomTextColor { get; set; }
        public Font BottomTextFont { get; set; }
        public string FloatingText { get; set; }
        public Color FloatingTextColor { get; set; }
        public bool LineAlwaysFilled { get; set; }
        public Color LineColor { get; set; }
        public Color LineFillColor { get; set; }
        public bool Password { get; set; }
        public string PlaceHolder { get; set; }
        public Color PlaceHolderColor { get; set; }

        public MaterialTextField()
        {
            this.SetMaterialFontNormal();
            this.SetMaterialStyle();
        }

        protected override Size DefaultSize
        {
            get { return new Size(160, 64); }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (selected == false)
            {
                if (GetFieldRect().Contains(e.Location))
                    coloredLineWidth = 0;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var textRect = GetFieldRect();

            if (string.IsNullOrEmpty(Text) && (string.IsNullOrEmpty(FloatingText) || (string.IsNullOrEmpty(FloatingText) == false && selected)))
                placeholderAlpha = MathHelper.FloatLerp(placeholderAlpha, PlaceHolderColor.A, 4);
            else
                placeholderAlpha = MathHelper.FloatLerp(placeholderAlpha, 0, 4);

            if (string.IsNullOrEmpty(Text) && selected == false)
            {
                floatingTextColor = MathHelper.ColorLerp(floatingTextColor, PlaceHolderColor, 4);
                floatingTextFontHeight = MathHelper.FloatLerp(floatingTextFontHeight, Font.Size, 2);
                floatingTextPositionY = MathHelper.FloatLerp(floatingTextPositionY, textRect.Y, 4);
            }
            else
            {
                floatingTextColor = MathHelper.ColorLerp(floatingTextColor, FloatingTextColor, 4);
                floatingTextFontHeight = MathHelper.FloatLerp(floatingTextFontHeight, 10, 2);
                floatingTextPositionY = MathHelper.FloatLerp(floatingTextPositionY, 0, 4);
            }

            e.Graphics.uwfDrawString(PlaceHolder, Font, Color.FromArgb((int)placeholderAlpha, PlaceHolderColor), textRect.X + 3, textRect.Y, textRect.Width, textRect.Height, ContentAlignment.TopLeft);
            e.Graphics.uwfDrawString(FloatingText, new Font(Font.Name, floatingTextFontHeight, Font.Style), floatingTextColor, textRect.X + 3, floatingTextPositionY, textRect.Width, textRect.Height, ContentAlignment.TopLeft);

            if (selected)
            {
                if (shouldFocus)
                    e.Graphics.uwfFocusNext();
                
                var _tempText = Text;
                if (Password == false)
                    Text = e.Graphics.uwfDrawTextField(Text, Font, ForeColor, textRect.X, textRect.Y, textRect.Width, textRect.Height, HorizontalAlignment.Left);
                else
                    Text = e.Graphics.uwfDrawPasswordField(Text, Font, ForeColor, textRect.X, textRect.Y, textRect.Width, textRect.Height, HorizontalAlignment.Left);

                if (shouldFocus)
                {
                    shouldFocus = false;
                    e.Graphics.uwfFocus();
                }
                
                if (Text != _tempText)
                    OnTextChanged(EventArgs.Empty);
            }
            else if (Text != null)
            {
                string text = Text;
                if (Password) text = new string('*', text.Length);
                e.Graphics.uwfDrawString(text, Font, ForeColor, textRect.X + 3, textRect.Y, textRect.Width, textRect.Height, ContentAlignment.TopLeft);
            }


            // Bottom line.
            penLine.Color = LineColor;
            
            e.Graphics.DrawLine(penLine, 0, Height - bottomLineYOffset, Width, Height - bottomLineYOffset);

            if (LineAlwaysFilled == false)
            {
                if (selected)
                    coloredLineWidth = MathHelper.FloatLerp(coloredLineWidth, Width, 8);
                else
                    coloredLineWidth = MathHelper.FloatLerp(coloredLineWidth, 0, 8);
            }
            else
                coloredLineWidth = Width;

            if (coloredLineWidth > 1)
            {
                penLineFill.Color = LineFillColor;
                penLineFill.Width = 2;
                
                float coloredLineX = (Width - coloredLineWidth) / 2;
                e.Graphics.DrawLine(penLineFill, coloredLineX,
                    Height - bottomLineYOffset, coloredLineX + coloredLineWidth, Height - bottomLineYOffset);
            }

            // Bottom text.
            e.Graphics.uwfDrawString(BottomText, BottomTextFont, BottomTextColor, 0, Height - bottomLineYOffset, Width, 24);
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        private RectangleF GetFieldRect()
        {
            float textY = Height - bottomLineYOffset - textBottomPadding - 16;
            RectangleF textRect = new RectangleF(0, textY, Width, 24);
            return textRect;
        }
    }
}
