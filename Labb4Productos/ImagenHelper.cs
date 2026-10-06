using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Labb4Productos
{
    public static class ImagenHelper
    {
        // Convierte un objeto Image de C# a un arreglo de bytes para MySQL (LONGBLOB)
        public static byte[] ImageToByteArray(Image? image)
        {
            if (image == null) return null; // Evaluación de nulabilidad estricta
            using (MemoryStream mMemoryStream = new MemoryStream())
            {
                image.Save(mMemoryStream, ImageFormat.Png);
                return mMemoryStream.ToArray();
            }
        }

        // Convierte un arreglo de bytes proveniente de MySQL a un objeto Bitmap seguro para la interfaz
        public static Image ByteArrayToImage(byte[]? bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (Bitmap bmp = new Bitmap(ms))
                {
                    return new Bitmap(bmp); // Clonación indispensable para desvincular el flujo de RAM
                }
            }
        }
    }
}
