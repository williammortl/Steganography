namespace SteganographyLibrary
{
    using System;

    /// <summary>
    /// Exception for the Steganography Libary
    /// </summary>
    [SerializableAttribute]
    public sealed class SteganographyException : Exception
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">the message for the exception</param>
        public SteganographyException(String message) : base(message)
        {

            // do nothing! 
        }
    }
}
