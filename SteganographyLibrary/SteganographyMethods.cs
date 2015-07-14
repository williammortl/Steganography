namespace SteganographyLibrary
{
    using System;
    using System.Drawing;

    /// <summary>
    /// Contains functions for embedding information in images
    /// </summary>
    public static class SteganographyMethods
    {

        /// <summary>
        /// Calculates the maximum number of bytes which can be stored
        /// </summary>
        /// <param name="img">the image to determine the max amount of bytes whithin</param>
        /// <param name="planes">which planes to embed in</param>
        /// <param name="bitDepth">the number of bits to embed [1, 8]</param>
        /// <returns>the number of bytes, 0 on error</returns>
        public static int MaxBytesInImage(Bitmap img, EmbeddingPlane planes, int bitDepth)
        {

            // short circuit
            if ((img == null) || (bitDepth < 1) || (bitDepth > 8))
            {
                return 0;
            }

            // calculate the maximum number of bytes
            int bitsAvailable = img.Height * img.Width * bitDepth;
            int bytesAvailable = Convert.ToInt32(Math.Floor(bitsAvailable / 8.0));
            if (planes == EmbeddingPlane.RGB)
            {
                bytesAvailable = bytesAvailable * 3;
            }

            return bytesAvailable;
        }

        /// <summary>
        /// Extracts the content from the image
        /// </summary>
        /// <param name="img">the image from which to extract</param>
        /// <param name="planes">the planes to embed in</param>
        /// <param name="bitDepth">the bit depth of the embedding</param>
        /// <returns>the embedded content, null if a problem occurs</returns>
        public static EmbeddingContent Extract(Bitmap img, EmbeddingPlane planes, int bitDepth)
        {

            // short circuit
            if ((img == null) || (bitDepth < 1) || (bitDepth > 8))
            {
                return null;
            }

            // var declatation
            EmbeddingContent retVal = null;

            try
            {

                // get the header to determine what to extract
                EmbeddingHeader eh = new EmbeddingHeader(img, planes, bitDepth);

                // read the bytes
                int totalBytesToExtract = eh.ToString().Length + eh.SizeOfContent;
                retVal = new EmbeddingContent(SteganographyMethods.ExtractBytes(img, planes, bitDepth, totalBytesToExtract));
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }

        /// Extracts the content from the image
        /// </summary>
        /// <param name="imageFile">the image file from which to extract</param>
        /// <param name="planes">the planes to embed in</param>
        /// <param name="bitDepth">the bit depth of the embedding</param>
        /// <returns>the embedded content, null if a problem occurs</returns>
        public static EmbeddingContent Extract(String imageFile, EmbeddingPlane planes, int bitDepth)
        {

            // var init
            EmbeddingContent retVal = null;

            // wrap call
            try
            {
                using (Bitmap img = new Bitmap(imageFile))
                {
                    retVal = SteganographyMethods.Extract(img, planes, bitDepth);
                }
            }
            catch
            {
                retVal = null;
            }

            return retVal; ;
        }

        /// <summary>
        /// Embeds content in the image
        /// </summary>
        /// <param name="img">the image in which to embed</param>
        /// <param name="planes">the planes to embed in</param>
        /// <param name="bitDepth">the bit depth of the embedding</param>
        /// <param name="content">the content to embed</param>
        /// <returns>true if successful</returns>
        public static Boolean Embed(Bitmap img, EmbeddingPlane planes, int bitDepth, EmbeddingContent content)
        {

            // short circuit
            if ((img == null) || (bitDepth < 1) || (bitDepth > 8) || (content == null) || (content.HeaderAndContent.Length > SteganographyMethods.MaxBytesInImage(img, planes, bitDepth)))
            {
                return false;
            }
            
            // var init
            Boolean retVal = true;
            int currentByteIndex = 0;
            byte currentBitIndex = 1;

            try
            {

                // loop through the x and y pixels of the image, as well as the correct bit depths
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        for (byte embedBit = 1; embedBit <= bitDepth; embedBit++)
                        {

                            // embed in R
                            if ((planes == EmbeddingPlane.R) || (planes == EmbeddingPlane.RGB))
                            {
                                Color rgb = img.GetPixel(x, y);
                                byte r = SteganographyMethods.SetBitValueInByte(rgb.R, embedBit, SteganographyMethods.GetBitValueFromByte(content.HeaderAndContent[currentByteIndex], currentBitIndex));
                                img.SetPixel(x, y, Color.FromArgb(r, rgb.G, rgb.B));

                                // enumerate bit/byte counter
                                currentBitIndex++;
                                if (currentBitIndex > 8)
                                {
                                    currentBitIndex = 1;
                                    currentByteIndex++;
                                }
                                if (currentByteIndex >= content.HeaderAndContent.Length)
                                {
                                    x = img.Width;
                                    y = img.Height;
                                    break;
                                }
                            }

                            // embed in G
                            if ((planes == EmbeddingPlane.G) || (planes == EmbeddingPlane.RGB))
                            {
                                Color rgb = img.GetPixel(x, y);
                                byte g = SteganographyMethods.SetBitValueInByte(rgb.G, embedBit, SteganographyMethods.GetBitValueFromByte(content.HeaderAndContent[currentByteIndex], currentBitIndex));
                                img.SetPixel(x, y, Color.FromArgb(rgb.R, g, rgb.B));

                                // enumerate bit/byte counter
                                currentBitIndex++;
                                if (currentBitIndex > 8)
                                {
                                    currentBitIndex = 1;
                                    currentByteIndex++;
                                }
                                if (currentByteIndex >= content.HeaderAndContent.Length)
                                {
                                    x = img.Width;
                                    y = img.Height;
                                    break;
                                }
                            }

                            // embed in B
                            if ((planes == EmbeddingPlane.B) || (planes == EmbeddingPlane.RGB))
                            {
                                Color rgb = img.GetPixel(x, y);
                                byte b = SteganographyMethods.SetBitValueInByte(rgb.B, embedBit, SteganographyMethods.GetBitValueFromByte(content.HeaderAndContent[currentByteIndex], currentBitIndex));
                                img.SetPixel(x, y, Color.FromArgb(rgb.R, rgb.G, b));

                                // enumerate bit/byte counter
                                currentBitIndex++;
                                if (currentBitIndex > 8)
                                {
                                    currentBitIndex = 1;
                                    currentByteIndex++;
                                }
                                if (currentByteIndex >= content.HeaderAndContent.Length)
                                {
                                    x = img.Width;
                                    y = img.Height;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        /// <summary>
        /// Embeds content in the image
        /// </summary>
        /// <param name="imageFile">the image file in which to embed</param>
        /// <param name="planes">the planes to embed in</param>
        /// <param name="bitDepth">the bit depth of the embedding</param>
        /// <param name="content">the content to embed</param>
        /// <returns>the image with the data embedded if successful, otherwise null</returns>
        public static Bitmap Embed(String imageFile, EmbeddingPlane planes, int bitDepth, EmbeddingContent content)
        {

            // var init
            Bitmap retVal = null;

            // wrap call
            try
            {
                retVal = new Bitmap(imageFile);
                if (SteganographyMethods.Embed(retVal, planes, bitDepth, content) == false)
                {
                    throw new SteganographyException(String.Empty);
                }
            }
            catch
            {
                if (retVal != null)
                {
                    retVal.Dispose();
                }
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// Gets the bit from the byte at a position
        /// </summary>
        /// <param name="value">value to get the bit from</param>
        /// <param name="bitNumber">what bit, [1, 8]</param>
        /// <returns>return 1 or 0</returns>
        internal static byte GetBitValueFromByte(byte value, byte bitNumber)
        {

            // var declaration
            byte retVal = 0;

            // get value
            if ((bitNumber > 0) && (bitNumber <= 8))
            {
                byte mask = System.Convert.ToByte(Math.Pow(2, bitNumber - 1));
                retVal = System.Convert.ToByte(((mask & value) == 0) ? 0 : 1);
            }

            return retVal;
        }

        /// <summary>
        /// Sets the bit from the byte at a position
        /// </summary>
        /// <param name="value">value to get the bit from</param>
        /// <param name="bitNumber">what bit [1, 8]</param>
        /// <param name="bitValue">the value to set, 1 or 0</param>
        /// <returns>adjusted value</returns>
        internal static byte SetBitValueInByte(byte value, byte bitNumber, byte bitValue)
        {

            // var declaration
            byte retVal = value;

            // change value
            if ((bitNumber > 0) && (bitNumber <= 8) && (bitValue >= 0) && (bitValue <= 1))
            {
                if (GetBitValueFromByte(value, bitNumber) != bitValue)
                {
                    byte mask = System.Convert.ToByte(Math.Pow(2, bitNumber - 1));
                    if (bitValue == 1)
                    {
                        retVal += mask;
                    }
                    else
                    {
                        retVal -= mask;
                    }
                }
            }
            else
            {
                retVal = 0;
            }

            return retVal;
        }

        /// <summary>
        /// Get bytes hidden in a picture's plane
        /// </summary>
        /// <param name="img">the picture to extract data from</param>
        /// <param name="planes">what pleanes to extract from</param>
        /// <param name="bitDepth">the bit depth to extract [1, 8]</param>
        /// <param name="bytesToGet">the number of bytes to retrieve</param>
        /// <returns>a byte array of data, null if there is a problem</returns>
        internal static byte[] ExtractBytes(Bitmap img, EmbeddingPlane planes, int bitDepth, int bytesToGet)
        {

            // var declatation
            byte[] retVal = new Byte[bytesToGet];
            int currentByteIndex = 0;
            byte currentBitIndex = 1;

            try
            {

                // loop through the x and y pixels of the image, as well as the correct bit depths
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        for (byte extractBit = 1; extractBit <= bitDepth; extractBit++)
                        {

                            // extract from R
                            if ((planes == EmbeddingPlane.R) || (planes == EmbeddingPlane.RGB))
                            {
                                Color rgb = img.GetPixel(x, y);
                                byte r = SteganographyMethods.GetBitValueFromByte(rgb.R, extractBit);
                                retVal[currentByteIndex] = SteganographyMethods.SetBitValueInByte(retVal[currentByteIndex], currentBitIndex, r);

                                // enumerate bit/byte counter
                                currentBitIndex++;
                                if (currentBitIndex > 8)
                                {
                                    currentBitIndex = 1;
                                    currentByteIndex++;
                                }
                                if (currentByteIndex >= bytesToGet)
                                {
                                    x = img.Width;
                                    y = img.Height;
                                    break;
                                }
                            }

                            // extract from G
                            if ((planes == EmbeddingPlane.G) || (planes == EmbeddingPlane.RGB))
                            {
                                Color rgb = img.GetPixel(x, y);
                                byte g = SteganographyMethods.GetBitValueFromByte(rgb.G, extractBit);
                                retVal[currentByteIndex] = SteganographyMethods.SetBitValueInByte(retVal[currentByteIndex], currentBitIndex, g);

                                // enumerate bit/byte counter
                                currentBitIndex++;
                                if (currentBitIndex > 8)
                                {
                                    currentBitIndex = 1;
                                    currentByteIndex++;
                                }
                                if (currentByteIndex >= bytesToGet)
                                {
                                    x = img.Width;
                                    y = img.Height;
                                    break;
                                }
                            }

                            // extract from B
                            if ((planes == EmbeddingPlane.B) || (planes == EmbeddingPlane.RGB))
                            {
                                Color rgb = img.GetPixel(x, y);
                                byte b = SteganographyMethods.GetBitValueFromByte(rgb.B, extractBit);
                                retVal[currentByteIndex] = SteganographyMethods.SetBitValueInByte(retVal[currentByteIndex], currentBitIndex, b);

                                // enumerate bit/byte counter
                                currentBitIndex++;
                                if (currentBitIndex > 8)
                                {
                                    currentBitIndex = 1;
                                    currentByteIndex++;
                                }
                                if (currentByteIndex >= bytesToGet)
                                {
                                    x = img.Width;
                                    y = img.Height;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                retVal = null;
            }

           return retVal;
        }
    }
}
