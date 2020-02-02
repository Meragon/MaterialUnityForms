using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialUI
{
    public class MaterialRipple
    {
        public float Alpha { get; set; }
        public float MaxSize { get; set; }
        public Point Offset { get; set; }
        public float Size { get; private set; }

        public MaterialRipple()
        {
            MaxSize = 255;
        }

        public bool Step(float speed)
        {
            Size = MathHelper.FloatLerp(Size, MaxSize * 2, speed);
            if (Size > MaxSize)
            {
                if (Alpha <= 0)
                    return false;

                Alpha -= speed;
            }

            return true;
        }
    }
}
