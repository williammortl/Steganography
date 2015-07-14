namespace SteganographyLibrary
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains the methods for maniuplating the content header
    /// </summary>
    public sealed class EmbeddingHeader
    {

        /// <summary>
        /// The header embedded that describes the content:
        ///     {0 - text, 1 - file}|{# of bytes}|{filename or empty string}|...
        /// </summary>
        private const String EMBEDDING_HEADER = "{0}|{1}|{2}|";

        /// <summary>
        /// This is the max path in Windows
        /// </summary>
        private const int MAX_PATH = 260;

        /// <summary>
        /// Used to seperate fields in the header
        /// </summary>
        private const char HEADER_SPLIT_CHAR = '|';

        /// <summary>
        /// This is the max size in byes of the header
        /// </summary>
        private const int MAX_HEADER = 3 + 10 + 13 + MAX_PATH;

        /// <summary>
        /// the type of content
        /// </summary>
        public ContentType TypeOfContent { get; private set; }
            
        /// <summary>
        /// the size of just the content
        /// </summary>
        public int SizeOfContent { get; private set; }
        
        /// <summary>
        /// the filename for the content
        /// </summary>
        public String Filename { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="typeOfContent">the type of content</param>
        /// <param name="sizeOfContent">the size of the content</param>
        /// <param name="filename">the filename (if the content is file)</param>
        internal EmbeddingHeader(ContentType typeOfContent, int sizeOfContent, String filename)
        {
            this.TypeOfContent = typeOfContent;
            this.SizeOfContent = sizeOfContent;
            this.Filename = filename;
        }

        /// <summary>
        /// Internal constructor that builds the object from bytes
        /// </summary>
        /// <param name="headerBytes">the bytes to search for the header within</param>
        /// <returns>the embedding header</returns>
        internal EmbeddingHeader(byte[] headerBytes)
        {
            try
            {

                // get header
                if (headerBytes.Length > MAX_HEADER)
                {
                    headerBytes = headerBytes.Take<byte>(MAX_HEADER).ToArray<byte>();
                }
                String header = System.Text.Encoding.ASCII.GetString(headerBytes).Trim();
                String[] split = header.Split(new char[1] { HEADER_SPLIT_CHAR });

                // set attributes
                this.TypeOfContent = (ContentType)Enum.Parse(typeof(ContentType), split[0].Trim());
                this.SizeOfContent = Convert.ToInt32(split[1].Trim());
                this.Filename = split[2].Trim();
            }
            catch (Exception e)
            {
                throw new SteganographyException(e.ToString());
            }
        }

        /// <summary>
        /// Internal constructor that builds the object from bytes
        /// </summary>
        /// <param name="img">the image in which to embed</param>
        /// <param name="planes">the planes to embed in</param>
        /// <param name="bitDepth">the bit depth of the embedding</param>
        /// <returns>the embedding header</returns>
        internal EmbeddingHeader(Bitmap img, EmbeddingPlane planes, int bitDepth)
        {
            try
            {

                // get header
                byte[] headerBytes = SteganographyMethods.ExtractBytes(img, planes, bitDepth, MAX_HEADER);
                String header = System.Text.Encoding.ASCII.GetString(headerBytes).Trim();
                String[] split = header.Split(new char[1] { HEADER_SPLIT_CHAR });

                // set attributes
                this.TypeOfContent = (ContentType)Enum.Parse(typeof(ContentType), split[0].Trim());
                this.SizeOfContent = Convert.ToInt32(split[1].Trim());
                this.Filename = split[2].Trim();
            }
            catch (Exception e)
            {
                throw new SteganographyException(e.ToString());
            }
        }

        /// <summary>
        /// String representation of this object
        /// </summary>
        /// <returns>the string representation of this object</returns>
        public override string ToString()
        {
            return String.Format(EMBEDDING_HEADER, this.TypeOfContent.ToString(), this.SizeOfContent.ToString(), this.Filename);
        }

        /// <summary>
        /// returns the byte representation of this object
        /// </summary>
        /// <returns>byte array of this object</returns>
        internal byte[] ToByteArray()
        {
            return Encoding.ASCII.GetBytes(this.ToString());
        }
    }
}
