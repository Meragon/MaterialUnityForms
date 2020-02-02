namespace MaterialUI
{
    using System.Drawing;
    using System.Windows.Forms;

    using Properties;

    public class FormMaterial : Form
    {
        public FormMaterial()
        {
            BackColor = Color.White;
            ControlBox = false;
            this.SetMaterialFontNormal();
            this.SetMaterialStyle();
            Size = new Size(720, 360);
            Text = ("Material UI - " + ((MaterialThemes)(MaterialUISettings.Theme)).ToString()).ToUpper();
            
            uwfHeaderFont = Font;
            innerBorderPen.Color = Color.Transparent;

            for (int i = 0; i < 4; i++)
            {
                MaterialFlatButton flatButton = new MaterialFlatButton();
                flatButton.Location = new Point(16 + i * 128, 32);
                flatButton.SetMaterialStyle((MaterialFlatButonStyles)i);
                flatButton.Text = ((MaterialFlatButonStyles)i).ToString().ToUpper();
                flatButton.Size = new Size(12 * flatButton.Text.Length, MaterialFlatButton.DefaultHeight);
                Controls.Add(flatButton);
            }

            MaterialFlatButton flatButtonWImage = new MaterialFlatButton();
            flatButtonWImage.Location = new Point(16, 32 + 40);
            flatButtonWImage.SetMaterialStyle(MaterialFlatButonStyles.Primary);
            flatButtonWImage.Text = "WITH IMAGE";
            flatButtonWImage.Size = new Size(128, flatButtonWImage.Height);
            flatButtonWImage.Image = ResourceManager.Images.SafeGet(ImageNames.imageMaterial_Android);
            flatButtonWImage.ImageColor = flatButtonWImage.ForeColor;
            flatButtonWImage.ImageRect = new Rectangle(8, 8, flatButtonWImage.Height - 16, flatButtonWImage.Height - 16);
            flatButtonWImage.Padding = new Padding(flatButtonWImage.ImageRect.X + flatButtonWImage.ImageRect.Width, 0, flatButtonWImage.ImageRect.X, 0);
            Controls.Add(flatButtonWImage);

            MaterialFlatButton flatButtonNoRipple = new MaterialFlatButton();
            flatButtonNoRipple.Location = new Point(flatButtonWImage.Location.X + flatButtonWImage.Width + 16, flatButtonWImage.Location.Y);
            flatButtonNoRipple.Ripple = false;
            flatButtonNoRipple.SetMaterialStyle(MaterialFlatButonStyles.Secondary);
            flatButtonNoRipple.Size = new Size(128, flatButtonNoRipple.Height);
            flatButtonNoRipple.Text = "NO RIPPLE";
            Controls.Add(flatButtonNoRipple);

            for (int i = 0; i < 4; i++)
            {
                MaterialRaisedButton raisedButton = new MaterialRaisedButton();
                raisedButton.Location = new Point(16 + i * 128, 32 + 80);
                raisedButton.SetMaterialStyle((MaterialFlatButonStyles)i);
                raisedButton.Text = ((MaterialFlatButonStyles)i).ToString().ToUpper();
                raisedButton.Size = new Size(12 * raisedButton.Text.Length, MaterialFlatButton.DefaultHeight);
                Controls.Add(raisedButton);
            }

            MaterialTextField textField1 = new MaterialTextField();
            textField1.Location = new Point(16, 32 + 124);
            Controls.Add(textField1);

            MaterialTextField textField2 = new MaterialTextField();
            textField2.Location = new Point(textField1.Location.X + textField1.Width + 16, 32 + 124);
            textField2.Password = true;
            textField2.PlaceHolder = "Password hint";
            Controls.Add(textField2);

            MaterialTextField textField3 = new MaterialTextField();
            textField3.FloatingText = "Floating text";
            textField3.Location = new Point(textField2.Location.X + textField2.Width + 16, 32 + 124);
            textField3.PlaceHolder = "Hint here";
            Controls.Add(textField3);

            MaterialTextField textField4 = new MaterialTextField();
            textField4.BottomText = "Error here";
            textField4.LineAlwaysFilled = true;
            textField4.LineFillColor = textField4.BottomTextColor;
            textField4.Location = new Point(textField3.Location.X + textField3.Width + 16, 32 + 124);
            textField4.PlaceHolder = "";
            Controls.Add(textField4);

            MaterialCheckbox checkBox = new MaterialCheckbox();
            checkBox.Image = ResourceManager.Images.SafeGet(ImageNames.imageMaterial_Checkbox);
            checkBox.ImageOutline = ResourceManager.Images.SafeGet(ImageNames.imageMaterial_CheckboxOutline);
            checkBox.Location = new Point(16, 212);
            checkBox.Text = "CheckBox";
            Controls.Add(checkBox);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == Keys.Escape || (e.Control && e.KeyCode == Keys.W))
                Close();
        }
    }
}
