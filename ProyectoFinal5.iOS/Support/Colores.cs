using System;
using UIKit;

namespace ProyectoFinal5.iOS.Support
{
    public static class Colores
    {
        const string DarkPrimaryColor = "#303F9F";
        const string LightPrimaryColor = "#C5CAE9";
        const string PrimaryColor = "#3F51B5";
        const string IconsColor = "#FFFFFF";
        const string AccentColor = "#4CAF50";
        const string TextColor = "#212121";
        const string SecondaryTextColor = "#757575";
        const string DividerColor = "#BDBDBD";

        public static UIColor DarkPrimary
        {
            get
            {
                return FromHexString(DarkPrimaryColor);
            }
        }

        public static UIColor LightPrimary
        {
            get
            {
                return FromHexString(LightPrimaryColor);
            }
        }

        public static UIColor Primary
        {
            get
            {
                return FromHexString(PrimaryColor);
            }
        }

        public static UIColor Icons
        {
            get
            {
                return FromHexString(IconsColor);
            }
        }

        public static UIColor Accent
        {
            get
            {
                return FromHexString(AccentColor);
            }
        }

        public static UIColor Text
        {
            get
            {
                return FromHexString(TextColor);
            }
        }

        public static UIColor SecondaryText
        {
            get
            {
                return FromHexString(SecondaryTextColor);
            }
        }

        public static UIColor Divider
        {
            get
            {
                return FromHexString(DividerColor);
            }
        }

        static UIColor FromHexString(string hexValue, float alpha = 1.0f)
        {
            var colorString = hexValue.Replace("#", "");

            if (alpha > 1.0f)
            {
                alpha = 1.0f;
            }
            else if (alpha < 0.0f)
            {
                alpha = 0.0f;
            }

            float red, green, blue;

            switch (colorString.Length)
            {
                case 3: // #RGB
                    {
                        red = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(0, 1)), 16) / 255f;
                        green = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(1, 1)), 16) / 255f;
                        blue = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(2, 1)), 16) / 255f;
                        return UIColor.FromRGBA(red, green, blue, alpha);
                    }
                case 6: // #RRGGBB
                    {
                        red = Convert.ToInt32(colorString.Substring(0, 2), 16) / 255f;
                        green = Convert.ToInt32(colorString.Substring(2, 2), 16) / 255f;
                        blue = Convert.ToInt32(colorString.Substring(4, 2), 16) / 255f;
                        return UIColor.FromRGBA(red, green, blue, alpha);
                    }

                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid color value {0} is invalid. It should be a hex value of the form #RBG, #RRGGBB", hexValue));

            }
        }
    }
}
