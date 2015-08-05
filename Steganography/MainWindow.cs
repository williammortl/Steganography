namespace Steganography
{
    using SteganographyLibrary;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    
    /// <summary>
    /// Event handler for the main window
    /// </summary>
    public partial class MainWindow : Form
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Main Window load event
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void MainWindow_Load(object sender, EventArgs e)
        {

            // initialize drop downs
            this.embedContentType.SelectedIndex = 0;
            this.embedPlane.SelectedIndex = 0;
            this.embedBitDepth.SelectedIndex = 0;
            this.extractPlane.SelectedIndex = 0;
            this.extractBitDepth.SelectedIndex = 0;
            this.destFileType.SelectedIndex = 0;

            // set initial tab
            this.mainTab.SelectedIndex = 0;
        }

        /// <summary>
        /// Select a file
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void selectSourceFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Bitmap Files (.bmp)|*.bmp|PNG Files (*.png)|*.png";
                dlg.FilterIndex = 0;
                dlg.Multiselect = false;
                dlg.InitialDirectory = (this.sourceFile.Text.Trim() == String.Empty) ? Environment.CurrentDirectory : Path.GetDirectoryName(this.sourceFile.Text);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.sourceFile.Text = dlg.FileName;
                }
            }
        }

        /// <summary>
        /// Embed content
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void embedButton_Click(object sender, EventArgs e)
        {

            // var init
            Boolean success = false;

            // show an error if nothing to embed
            if (this.destFile.Text.Trim() == String.Empty)
            {
                MessageBox.Show("You must supply a destination file in which to embed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((ContentType)Enum.Parse(typeof(ContentType), this.embedContentType.SelectedItem.ToString()) == ContentType.Text)
            {
                if (this.embedText.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must supply text to embed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    EmbeddingContent content = new EmbeddingContent(this.embedText.Text);
                    EmbeddingPlane planes = (EmbeddingPlane)Enum.Parse(typeof(EmbeddingPlane), this.embedPlane.SelectedItem.ToString());
                    byte bitDepth = Convert.ToByte(this.embedBitDepth.SelectedItem.ToString());
                    using (Bitmap img = SteganographyMethods.Embed(this.sourceFile.Text.Trim(), planes, bitDepth, content))
                    {
                        ImageFormat format = (this.destFileType.SelectedItem.ToString() == "Bmp") ? ImageFormat.Bmp : ImageFormat.Png;
                        success = MainWindow.SaveImgToFile(img, this.destFile.Text.Trim(), format);
                    }
                }
            }
            else if ((ContentType)Enum.Parse(typeof(ContentType), this.embedContentType.SelectedItem.ToString()) == ContentType.File)
            {
                if (this.embedFile.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("You must supply a file to embed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    EmbeddingContent content = new EmbeddingContent(new FileInfo(this.embedFile.Text.Trim()));
                    EmbeddingPlane planes = (EmbeddingPlane)Enum.Parse(typeof(EmbeddingPlane), this.embedPlane.SelectedItem.ToString());
                    byte bitDepth = Convert.ToByte(this.embedBitDepth.SelectedItem.ToString());
                    using (Bitmap img = SteganographyMethods.Embed(this.sourceFile.Text.Trim(), planes, bitDepth, content))
                    {
                        ImageFormat format = (this.destFileType.SelectedItem.ToString() == "Bmp") ? ImageFormat.Bmp : ImageFormat.Png;
                        success = MainWindow.SaveImgToFile(img, this.destFile.Text.Trim(), format);
                    }
                }
            }

            // notify if the operation is successful
            if (success == true)
            {
                MessageBox.Show("The operation was completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Extract content
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void extractButton_Click(object sender, EventArgs e)
        {

            // clear the extracted text box
            this.extractedText.Text = String.Empty;

            // extract!
            EmbeddingPlane planes = (EmbeddingPlane)Enum.Parse(typeof(EmbeddingPlane), this.extractPlane.SelectedItem.ToString());
            byte bitDepth = Convert.ToByte(this.extractBitDepth.SelectedItem.ToString());
            EmbeddingContent content = SteganographyMethods.Extract(this.sourceFile.Text.Trim(), planes, bitDepth);
            if (content == null)
            {

                // nothing was extracted, show an error message box
                MessageBox.Show("An error occurred while extracting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (content.Header.TypeOfContent == ContentType.Text)
                {

                    // text was extracted, put in extracted text box
                    this.extractedText.Text = Encoding.ASCII.GetString(content.Content);
                }
                else
                {

                    // write to file
                    String newFilename = String.Format("extracted_{0}", content.Header.Filename);
                    String newPathAndFilename = Path.Combine(Path.GetDirectoryName(this.sourceFile.Text), newFilename);
                    File.WriteAllBytes(newPathAndFilename, content.Content);

                    // extraction mesage
                    String extractionMessage = String.Format("Successfully extracted file: {0}", newFilename); 

                    // notify that a file was extracted
                    this.extractedText.Text = extractionMessage;
                    MessageBox.Show(extractionMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Check for file existence when the source file changes
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void sourceFile_TextChanged(object sender, EventArgs e)
        {
            this.mainTab.Enabled = (File.Exists(this.sourceFile.Text) == true);
            if (this.destFile.Text == String.Empty)
            {
                this.destFile.Text = Path.Combine(Path.GetDirectoryName(this.sourceFile.Text), Path.GetFileNameWithoutExtension(this.sourceFile.Text) + "_out." + this.destFileType.SelectedItem.ToString().ToLower());
            }
            this.UpdateBytesAvailable();
        }

        /// <summary>
        /// If either of the embedding parameters in combo boxes changes, execute this same method
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void inputEmbeddingChanged_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateBytesAvailable();
        }

        /// <summary>
        /// When the destination file type changes
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void destFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.sourceFile.Text != String.Empty) && (this.destFile.Text != String.Empty))
            {
                this.destFile.Text = Path.Combine(Path.GetDirectoryName(this.destFile.Text), Path.GetFileNameWithoutExtension(this.destFile.Text) + "." + this.destFileType.SelectedItem.ToString().ToLower());
            }
        }

        /// <summary>
        /// Event for when the content type changes
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void embedContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ContentType)Enum.Parse(typeof(ContentType), this.embedContentType.SelectedItem.ToString()) == ContentType.Text)
            {
                this.embedText.Enabled = true;
                this.embedFile.Text = String.Empty;
                this.embedFile.Enabled = false;
                this.selectFileEmbed.Enabled = false;
            }
            else
            {
                this.embedText.Enabled = false;
                this.embedText.Text = String.Empty;
                this.embedFile.Enabled = true;
                this.selectFileEmbed.Enabled = true;
            }
        }

        /// <summary>
        /// Browses for a file to embed
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void selectFileEmbed_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "All files (.*)|*.*";
                dlg.FilterIndex = 0;
                dlg.Multiselect = false;
                dlg.InitialDirectory = Path.GetDirectoryName(this.sourceFile.Text);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.embedFile.Text = dlg.FileName;
                }
            }
        }

        /// <summary>
        /// Updates the bytes available on the embed tab
        /// </summary>
        private void UpdateBytesAvailable()
        {

            // try to figure out how many bytes are available in the file
            try
            {
                using (Bitmap img = new Bitmap(this.sourceFile.Text))
                {
                    int bitDepth = Convert.ToInt32(this.embedBitDepth.SelectedItem.ToString());
                    EmbeddingPlane planes = (EmbeddingPlane)Enum.Parse(typeof(EmbeddingPlane), this.embedPlane.SelectedItem.ToString());
                    this.bytesInPicture.Text = SteganographyMethods.MaxBytesInImage(img, planes, bitDepth).ToString();
                }
            }
            catch
            {
                this.bytesInPicture.Text = "N/A";
            }
        }

        /// <summary>
        /// Saves an image to file
        /// </summary>
        /// <param name="img">the image to save</param>
        /// <param name="filename">the file to save the image to</param>
        /// <param name="format">the format to save</param>
        /// <returns>true if successful</returns>
        private static Boolean SaveImgToFile(Bitmap img, String filename, ImageFormat format)
        {

            // var init
            Boolean retVal = true;

            try
            {
                img.Save(filename, format);
            }
            catch
            {
                retVal = false;
                MessageBox.Show("There was an error saving the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }
    }
}
