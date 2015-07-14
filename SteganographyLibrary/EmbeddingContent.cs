namespace SteganographyLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The content to embed / or was extracted
    /// </summary>
    public sealed class EmbeddingContent
    {

        /// <summary>
        /// The header for the content
        /// </summary>
        public EmbeddingHeader Header { get; private set; }

        /// <summary>
        /// The header and content as a byte array
        /// </summary>
        public byte[] HeaderAndContent { get; private set; }

        /// <summary>
        /// Just the content as a byte array
        /// </summary>
        public byte[] Content 
        { 
            get
            {
                return this.HeaderAndContent.Skip<byte>(this.Header.ToString().Length).ToArray<byte>();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="typeOfContent">the type of content</param>
        /// <param name="filename">the filename (if the content is file)</param>
        /// <param name="content">byte array of content</param>
        public EmbeddingContent(ContentType typeOfContent, String filename, byte[] content)
        {

            // short circuit
            if ((content == null) || (content.Length < 1))
            {
                throw new SteganographyException("Incorrect parameters for EmbeddingContent");
            }

            this.Header = new EmbeddingHeader(typeOfContent, content.Length, filename);
            this.HeaderAndContent = EmbeddingContent.MergeHeaderAndContent(this.Header, content);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="content">the text content</param>
        public EmbeddingContent(String content)
        {

            // short circuit
            content = content.Trim();
            if (content.Length < 1)
            {
                throw new SteganographyException("Incorrect parameters for EmbeddingContent");
            }

            this.Header = new EmbeddingHeader(ContentType.Text, content.Length, String.Empty);
            this.HeaderAndContent = EmbeddingContent.MergeHeaderAndContent(this.Header, Encoding.ASCII.GetBytes(content));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="content">the file to embed</param>
        public EmbeddingContent(FileInfo content)
        {

            // short circuit
            if ((content == null) || (content.Exists == false))
            {
                throw new SteganographyException("Incorrect parameters for EmbeddingContent");
            }

            this.Header = new EmbeddingHeader(ContentType.File, Convert.ToInt32(content.Length), content.Name);
            this.HeaderAndContent = EmbeddingContent.MergeHeaderAndContent(this.Header, File.ReadAllBytes(content.FullName));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="headerAndContent">the header and content in a byte array</param>
        internal EmbeddingContent(byte[] headerAndContent)
        {

            // short circuit
            if ((headerAndContent == null) || (headerAndContent.Length < 1))
            {
                throw new SteganographyException("Incorrect parameters for EmbeddingContent");
            }

            this.Header = new EmbeddingHeader(headerAndContent);
            this.HeaderAndContent = headerAndContent;
        }

        /// <summary>
        /// Combines a header and a byte array of content
        /// </summary>
        /// <param name="eh">header</param>
        /// <param name="content">content</param>
        /// <returns>merged byte array</returns>
        private static byte[] MergeHeaderAndContent(EmbeddingHeader header, byte[] content)
        {
            List<byte> retVal = new List<byte>(header.ToByteArray());
            retVal.AddRange(content);
            return retVal.ToArray<byte>();
        }
    }
}
