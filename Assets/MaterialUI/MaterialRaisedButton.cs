using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaterialUI
{
    public class MaterialRaisedButton : MaterialFlatButton
    {
        public MaterialRaisedButton()
        {
            ButtonType = MaterialButtonTypes.Raised;
            this.SetMaterialStyle(MaterialFlatButonStyles.Default);
        }
    }
}
