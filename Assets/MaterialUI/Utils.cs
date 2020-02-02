using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialUI
{
    public static class Utils
    {
        public static void SetMaterialFontNormal(this Control control)
        {
            control.Font = new Font("Roboto", 14);
        }
        public static void SetMaterialStyle(this Form form, MaterialThemes theme = MaterialThemes.None)
        {
            if (theme == MaterialThemes.None)
                theme = MaterialUISettings.Theme;

            switch (theme)
            {
                case MaterialThemes.Light:
                    form.BackColor = Color.FromArgb(238, 238, 238);
                    form.ForeColor = Color.Black;
                    break;
                case MaterialThemes.Dark:
                    form.BackColor = Color.FromArgb(51, 51, 51);
                    form.ForeColor = Color.White;
                    break;
            }

            form.uwfBorderColor = form.BackColor;
            form.uwfHeaderColor = form.BackColor;
            form.uwfHeaderTextColor = form.ForeColor;
        }
        public static void SetMaterialStyle(this MaterialFlatButton button, MaterialFlatButonStyles style, MaterialThemes theme = MaterialThemes.None)
        {
            if (theme == MaterialThemes.None)
                theme = MaterialUISettings.Theme;

            #region flat style.
            if (button.ButtonType == MaterialButtonTypes.Flat)
            {
                switch (theme)
                {
                    case MaterialThemes.Light:
                        button.HoverColor = Color.FromArgb(221, 221, 221);
                        button.PressedColor = Color.FromArgb(204, 204, 204);
                        break;
                    case MaterialThemes.Dark:
                        button.HoverColor = Color.FromArgb(74, 74, 74);
                        button.PressedColor = Color.FromArgb(89, 89, 89);
                        break;
                }

                switch (style)
                {
                    case MaterialFlatButonStyles.Default:
                        if (theme != MaterialThemes.Dark)
                            button.ForeColor = Color.FromArgb(42, 42, 42);
                        else
                            button.ForeColor = Color.White;
                        break;
                    case MaterialFlatButonStyles.Primary:
                        button.ForeColor = Color.FromArgb(255, 64, 129);
                        break;
                    case MaterialFlatButonStyles.Secondary:
                        button.ForeColor = Color.FromArgb(0, 188, 216);
                        break;
                    case MaterialFlatButonStyles.Disabled:
                        button.ForeColor = Color.FromArgb(160, 160, 160);
                        button.HoverColor = Color.Transparent;
                        button.PressedColor = Color.Transparent;
                        button.Ripple = false;
                        break;
                }

                button.BackColor = Color.FromArgb(0, button.HoverColor);
            }
            #endregion
            else
            {
                switch (theme)
                {
                    case MaterialThemes.Light:
                        button.ForeColor = Color.White;
                        button.HoverColor = Color.FromArgb(221, 221, 221);
                        button.PressedColor = Color.FromArgb(204, 204, 204);
                        break;
                    case MaterialThemes.Dark:
                        button.ForeColor = Color.FromArgb(42, 42, 42);
                        button.HoverColor = Color.FromArgb(74, 74, 74);
                        button.PressedColor = Color.FromArgb(89, 89, 89);
                        break;
                }

                button.uwfShadowBox = true;

                switch (style)
                {
                    case MaterialFlatButonStyles.Default:
                        button.BackColor = Color.White;
                        button.ForeColor = Color.FromArgb(42, 42, 42);
                        //button.HoverColor = button.BackColor - Color.FromArgb(0, 48, 48, 48);
                        //button.PressedColor = button.BackColor - Color.FromArgb(0, 72, 72, 72);
                        break;
                    case MaterialFlatButonStyles.Primary:
                        button.BackColor = Color.FromArgb(255, 64, 129);
                        //button.HoverColor = button.BackColor - Color.FromArgb(0, 48, 48, 48);
                        //button.PressedColor = button.BackColor - Color.FromArgb(0, 72, 72, 72);
                        break;
                    case MaterialFlatButonStyles.Secondary:
                        button.BackColor = Color.FromArgb(0, 188, 216);
                        //button.HoverColor = button.BackColor - Color.FromArgb(0, 48, 48, 48);
                        //button.PressedColor = button.BackColor - Color.FromArgb(0, 72, 72, 72);
                        break;
                    case MaterialFlatButonStyles.Disabled:
                        if (theme == MaterialThemes.Light)
                            button.BackColor = Color.FromArgb(229, 229, 229);
                        else
                            button.BackColor = Color.FromArgb(64, 64, 64);
                        button.ForeColor = Color.FromArgb(160, 160, 160);
                        button.HoverColor = button.BackColor;
                        button.PressedColor = button.BackColor;
                        button.Ripple = false;
                        button.uwfShadowBox = false;
                        break;
                }

                button.ForceUpdateColor();
            }
        }
        public static void SetMaterialStyle(this MaterialCheckbox checkBox, MaterialThemes theme = MaterialThemes.None)
        {
            if (theme == MaterialThemes.None)
                theme = MaterialUISettings.Theme;

            switch (theme)
            {
                case MaterialThemes.Dark:
                    checkBox.ForeColor = Color.White;
                    checkBox.ImageColor = Color.FromArgb(207, 207, 207);
                    break;
                case MaterialThemes.Light:
                    checkBox.ForeColor = Color.FromArgb(42, 42, 42);
                    checkBox.ImageColor = Color.FromArgb(0, 150, 136);
                    break;
            }

            checkBox.RippleColor = Color.FromArgb(checkBox.RippleColor.A, checkBox.ImageColor);
        }
        public static void SetMaterialStyle(this MaterialTextField field, MaterialThemes theme = MaterialThemes.None)
        {
            if (theme == MaterialThemes.None)
                theme = MaterialUISettings.Theme;

            field.BottomTextFont = new Font("Roboto", 12);
            field.LineFillColor = MaterialTextField.DefaultLineFillColor;

            switch (theme)
            {
                case MaterialThemes.Dark:
                    field.BottomTextColor = Color.FromArgb(247, 107, 107);
                    field.FloatingTextColor = field.LineFillColor;
                    field.ForeColor = Color.White;
                    field.LineColor = Color.FromArgb(64, 64, 64);
                    field.PlaceHolderColor = Color.FromArgb(185, 185, 185);
                    break;
                default:
                    field.BottomTextColor = Color.FromArgb(244, 67, 54);
                    field.FloatingTextColor = field.LineFillColor;
                    field.ForeColor = Color.FromArgb(42, 42, 42);
                    field.LineColor = Color.FromArgb(221, 221, 221);
                    field.PlaceHolderColor = Color.FromArgb(160, 160, 160);
                    break;
            }
        }
    }
}
