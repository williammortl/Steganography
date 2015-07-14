namespace SteganographyLibrary.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SteganographyLibrary;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Unit tests for SteganographyMethods
    /// </summary>
    [TestClass]
    public class TestMethods
    {

        /// <summary>
        /// Test bitwise operations
        /// </summary>
        [TestMethod]
        public void TestBitOperations()
        {

            // var init
            byte b = 0;

            // bad bit set parameter tests
            b = SteganographyMethods.SetBitValueInByte(byte.MaxValue, 9, 1);
            Assert.AreEqual(b, 0);
            b = SteganographyMethods.SetBitValueInByte(byte.MaxValue, 0, 1);
            Assert.AreEqual(b, 0);
            b = SteganographyMethods.SetBitValueInByte(byte.MaxValue, 1, 2);
            Assert.AreEqual(b, 0);

            // good bit set tests
            b = SteganographyMethods.SetBitValueInByte(byte.MaxValue, 1, 0);
            Assert.AreEqual(b, byte.MaxValue - 1);
            b = SteganographyMethods.SetBitValueInByte(0, 1, 1);
            Assert.AreEqual(b, 1);
            b = SteganographyMethods.SetBitValueInByte(0, 8, 1);
            Assert.AreEqual(b, Math.Pow(2.0, 7.0));
            b = SteganographyMethods.SetBitValueInByte(b, 8, 0);
            Assert.AreEqual(b, 0);

            // bad bit get tests
            b = SteganographyMethods.GetBitValueFromByte(byte.MaxValue, 9);
            Assert.AreEqual(b, 0);
            b = SteganographyMethods.GetBitValueFromByte(byte.MaxValue, 0);
            Assert.AreEqual(b, 0);

            // good bit get tests
            b = SteganographyMethods.GetBitValueFromByte(byte.MaxValue, 8);
            Assert.AreEqual(b, 1);
            b = SteganographyMethods.GetBitValueFromByte(byte.MaxValue, 1);
            Assert.AreEqual(b, 1);

            // good combo tests
            b = SteganographyMethods.SetBitValueInByte(byte.MaxValue, 2, 0);
            Assert.AreEqual(b, byte.MaxValue - 2);
            Assert.AreEqual(SteganographyMethods.GetBitValueFromByte(b, 8), 1);
            Assert.AreEqual(SteganographyMethods.GetBitValueFromByte(b, 1), 1);
            Assert.AreEqual(SteganographyMethods.GetBitValueFromByte(b, 2), 0);
        }

        /// <summary>
        /// Tests the EmbeddingContents
        /// </summary>
        [TestMethod]
        public void TestEmbeddingHeader()
        {

            // build embedding header
            String header = "File|3|smallfile.txt|";
            List<byte> headerBytes = new List<byte>(Encoding.ASCII.GetBytes(header));
            EmbeddingHeader eh = new EmbeddingHeader(headerBytes.ToArray());

            // check
            Assert.AreEqual(eh.TypeOfContent, ContentType.File);
            Assert.AreEqual(eh.Filename, "smallfile.txt");
            Assert.AreEqual(eh.SizeOfContent, 3);

            // build embedding header
            header = "Text|9999999||";
            headerBytes = new List<byte>(Encoding.ASCII.GetBytes(header));
            eh = new EmbeddingHeader(headerBytes.ToArray());

            // check
            Assert.AreEqual(eh.TypeOfContent, ContentType.Text);
            Assert.AreEqual(eh.Filename, String.Empty);
            Assert.AreEqual(eh.SizeOfContent, 9999999);

            // build embedding header ERROR
            try
            {
                eh = new EmbeddingHeader(null, EmbeddingPlane.RGB, 2);
                Assert.IsTrue(false);
            }
            catch (SteganographyException e)
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Tests the EmbeddingContents
        /// </summary>
        [TestMethod]
        public void TestEmbeddingContent()
        {

            // build embedding content
            String header = "File|4|smallfile.txt|abcd";
            List<byte> headerAndContent = new List<byte>(Encoding.ASCII.GetBytes(header));
            EmbeddingContent ec = new EmbeddingContent(headerAndContent.ToArray());

            // check
            Assert.AreEqual(ec.Header.TypeOfContent, ContentType.File);
            Assert.AreEqual(ec.Header.Filename, "smallfile.txt");
            Assert.AreEqual(ec.Header.SizeOfContent, 4);
            Assert.AreEqual(Encoding.ASCII.GetString(ec.Content), "abcd");

            // build embedding content
            header = "Text|5||abcd1";
            headerAndContent = new List<byte>(Encoding.ASCII.GetBytes(header));
            ec = new EmbeddingContent(headerAndContent.ToArray());

            // check
            Assert.AreEqual(ec.Header.TypeOfContent, ContentType.Text);
            Assert.AreEqual(ec.Header.Filename, String.Empty);
            Assert.AreEqual(ec.Header.SizeOfContent, 5);
            Assert.AreEqual(Encoding.ASCII.GetString(ec.Content), "abcd1");

            // build embedding content ERROR
            try
            {
                ec = new EmbeddingContent((byte[])null);
                Assert.IsTrue(false);
            }
            catch (SteganographyException)
            {
                Assert.IsTrue(true);
            }

            // build embedding content ERROR
            try
            {
                ec = new EmbeddingContent(new FileInfo("notafile.txt"));
                Assert.IsTrue(false);
            }
            catch (SteganographyException)
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Tests embedding and extracting a text message to bit depth 2 in RGB planes
        ///     saving as both a BMP and a PNG file
        /// </summary>
        [TestMethod]
        public void TestBMPTextEmbedDepth2RGBtoBMPandPNG()
        {

            // build content
            const String TEST_MESSAGE = "this is a test message to check to make sure it works!";
            EmbeddingContent ec = new EmbeddingContent(TEST_MESSAGE);
            EmbeddingContent recovered = null;

            // embed
            using (Bitmap img = SteganographyMethods.Embed("test.bmp", EmbeddingPlane.RGB, 2, ec))
            {
                Assert.IsNotNull(img);
                using (Bitmap png = new Bitmap(img))
                {
                    png.Save("testout.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    png.Save("testout.png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            // extract bmp
            recovered = SteganographyMethods.Extract("testout.bmp", EmbeddingPlane.RGB, 2);

            // test
            Assert.IsNotNull(recovered);
            String recoveredMessage = Encoding.ASCII.GetString(recovered.Content);
            Assert.AreEqual(recoveredMessage, TEST_MESSAGE);
            Assert.AreEqual(recovered.Header.TypeOfContent, ContentType.Text);

            // extract png
            recovered = null;
            recovered = SteganographyMethods.Extract("testout.png", EmbeddingPlane.RGB, 2);

            // test
            Assert.IsNotNull(recovered);
            recoveredMessage = Encoding.ASCII.GetString(recovered.Content);
            Assert.AreEqual(recoveredMessage, TEST_MESSAGE);
            Assert.AreEqual(recovered.Header.TypeOfContent, ContentType.Text);

            // cleanup
            File.Delete("testout.bmp");
            File.Delete("testout.png");
        }

        /// <summary>
        /// Tests embedding and extracting a file to bit depth 2 in RGB planes
        ///     saving as both a BMP and a PNG file
        /// </summary>
        [TestMethod]
        public void TestBMPFileEmbedDepth2RGBtoBMPandPNG()
        {

            // var init
            EmbeddingContent ec = new EmbeddingContent(new FileInfo("embedfile.jpg"));
            EmbeddingContent recovered = null;
            int height;
            int width;

            // get info aboud the embed file
            using (Bitmap embedfile = new Bitmap("embedfile.jpg"))
            {
                height = embedfile.Height;
                width = embedfile.Width;
            }

            // embed
            using (Bitmap img = SteganographyMethods.Embed("test.bmp", EmbeddingPlane.RGB, 2, ec))
            {
                Assert.IsNotNull(img);
                using (Bitmap png = new Bitmap(img))
                {
                    png.Save("testout.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    png.Save("testout.png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            // extract file from BMP, get info
            recovered = SteganographyMethods.Extract("testout.bmp", EmbeddingPlane.RGB, 2);
            Assert.IsNotNull(recovered);
            File.WriteAllBytes("recovered.jpg", recovered.Content);

            // test
            Assert.AreEqual(recovered.Header.TypeOfContent, ContentType.File);
            Assert.AreEqual(recovered.Content.Length, (new FileInfo("recovered.jpg")).Length);
            using (Bitmap embedfile = new Bitmap("recovered.jpg"))
            {
                Assert.AreEqual(height, embedfile.Height);
                Assert.AreEqual(width, embedfile.Width);
            }

            // cleanup
            recovered = null;
            File.Delete("recovered.jpg");

            // extract from PNG
            recovered = SteganographyMethods.Extract("testout.png", EmbeddingPlane.RGB, 2);
            Assert.IsNotNull(recovered);
            File.WriteAllBytes("recovered.jpg", recovered.Content);

            // test
            Assert.AreEqual(recovered.Header.TypeOfContent, ContentType.File);
            Assert.AreEqual(recovered.Content.Length, (new FileInfo("recovered.jpg")).Length);
            using (Bitmap embedfile = new Bitmap("recovered.jpg"))
            {
                Assert.AreEqual(height, embedfile.Height);
                Assert.AreEqual(width, embedfile.Width);
            }

            // cleanup
            File.Delete("recovered.jpg");
            File.Delete("testout.bmp");
            File.Delete("testout.png");
        }

        /// <summary>
        /// Tests embedding and extracting a text message to bit depth 1 in 
        ///     each of the RGB planes and extracting
        /// </summary>
        [TestMethod]
        public void TestPNGRandGandBDepth1()
        {

            // build content
            const String TEST_MESSAGE = "this is a test message to check to make sure it works!";
            EmbeddingContent ec = new EmbeddingContent(TEST_MESSAGE);
            EmbeddingContent recovered = null;

            // embed R
            using (Bitmap img = SteganographyMethods.Embed("test.bmp", EmbeddingPlane.R, 1, ec))
            {
                Assert.IsNotNull(img);
                using (Bitmap png = new Bitmap(img))
                {
                    png.Save("testout.png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            // extract R
            recovered = SteganographyMethods.Extract("testout.png", EmbeddingPlane.R, 1);
            Assert.IsNotNull(recovered);

            // test R
            String recoveredMessage = Encoding.ASCII.GetString(recovered.Content);
            Assert.AreEqual(recoveredMessage, TEST_MESSAGE);
            Assert.AreEqual(recovered.Header.TypeOfContent, ContentType.Text);

            // cleanup R
            recovered = null;
            File.Delete("testout.png");

            // embed G
            using (Bitmap img = SteganographyMethods.Embed("test.bmp", EmbeddingPlane.G, 1, ec))
            {
                Assert.IsNotNull(img);
                using (Bitmap png = new Bitmap(img))
                {
                    png.Save("testout.png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            // extract G
            recovered = SteganographyMethods.Extract("testout.png", EmbeddingPlane.G, 1);
            Assert.IsNotNull(recovered);

            // test G
            recoveredMessage = Encoding.ASCII.GetString(recovered.Content);
            Assert.AreEqual(recoveredMessage, TEST_MESSAGE);
            Assert.AreEqual(recovered.Header.TypeOfContent, ContentType.Text);

            // cleanup G
            recovered = null;
            File.Delete("testout.png");

            // embed B
            using (Bitmap img = SteganographyMethods.Embed("test.bmp", EmbeddingPlane.B, 1, ec))
            {
                Assert.IsNotNull(img);
                using (Bitmap png = new Bitmap(img))
                {
                    png.Save("testout.png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            // extract B
            recovered = SteganographyMethods.Extract("testout.png", EmbeddingPlane.B, 1);
            Assert.IsNotNull(recovered);

            // test B
            recoveredMessage = Encoding.ASCII.GetString(recovered.Content);
            Assert.AreEqual(recoveredMessage, TEST_MESSAGE);
            Assert.AreEqual(recovered.Header.TypeOfContent, ContentType.Text);

            // test wrong extraction from G is null (should be B)
            using (Bitmap img = new Bitmap("testout.png"))
            {
                recovered = SteganographyMethods.Extract(img, EmbeddingPlane.G, 2);
            }
            Assert.IsNull(recovered);

            // cleanup B
            File.Delete("testout.png");
        }
    }
}
