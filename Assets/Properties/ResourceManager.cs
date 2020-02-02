namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public static class ResourceManager
    {
        public const string ImagesFolder = "Images";
        
        public static ResourceCollection<ImageNames, Bitmap> Images
        {
            get { return images; }
        }

        private static readonly ResourceCollection<ImageNames, Bitmap> images = new ResourceCollection<ImageNames, Bitmap>();
        
        public static Dictionary<string, TEnum> GetEnumData<TEnum>()
        {
            var dic = new Dictionary<string, TEnum>(); 
            var type = typeof(TEnum);

            var fields = type.GetFields(
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static);

            var fieldsLength = fields.Length;
            for (int i = 0; i < fieldsLength; i++)
            {
                var field = fields[i];

                dic.Add(field.Name, (TEnum)field.GetRawConstantValue());
            }

            return dic;
        }
        public static void LoadImages()
        {
            var uImages = UnityEngine.Resources.LoadAll<UnityEngine.Texture2D>(ImagesFolder);
            var dicImages = GetEnumData<ImageNames>();
            
            for (int i = 0; i < uImages.Length; i++)
            {
                var ui = uImages[i];
                var uiName = ui.name;
                
                if (dicImages.ContainsKey(uiName))
                {
                    Images.SafeAdd(dicImages[uiName], Unity.API.UnityGdiHelper.ToBitmap(ui));
                    continue;
                }
            }
        }
    }
}