using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ConfigFromAnywhere.Configuration
{
    internal class ImageConfigurationParser
    {
        public IDictionary<string, string> Parse(Stream stream, ICollection<ImageConfigurationRegion> regions)
        {
            var result = new Dictionary<string, string>();
            var pureWhite = 255 * 3;

            using (var configImage = new Bitmap(stream))
            {
                foreach (var region in regions)
                {
                    var key = region.PropertyName;
                    var detected = false;

                    for (int x = region.TopLeft.X; x < region.TopLeft.X + region.Dimension; x++)
                    {
                        for (int y = region.TopLeft.Y; y < region.TopLeft.Y + region.Dimension; y++)
                        {
                            var pixelColor = configImage.GetPixel(x, y);
                            var totalDelta = pureWhite - (pixelColor.R + pixelColor.G + pixelColor.B);
                            if (totalDelta > 15)
                            {
                                detected = true;
                            }
                        }
                    }
                    result.Add(key, detected.ToString());
                }
            }

            return result;
        }

        private bool ImageHasBoxChecked(string rootPath, string configImage, Point topCorner, int boxSize)
        {
            var configFilepath = $"{rootPath}\\Config\\{configImage}";
            var result = false;

            using (var myBitmap = new Bitmap(configFilepath))
            {
                var pureWhite = 255 * 3;
                for (int x = topCorner.X; x < topCorner.X + boxSize; x++)
                {
                    for (int y = topCorner.Y; y < topCorner.Y + boxSize; y++)
                    {
                        var pixelColor = myBitmap.GetPixel(x, y);
                        var totalDelta = pureWhite - (pixelColor.R + pixelColor.G + pixelColor.B);
                        if (totalDelta > 15)
                            result = true;
                    }
                }
            }

            return result;
        }

    }
}