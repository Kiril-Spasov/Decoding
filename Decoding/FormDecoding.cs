using System;
using System.IO;
using System.Windows.Forms;

namespace Decoding
{
    public partial class FormDecoding : Form
    {
        public FormDecoding()
        {
            InitializeComponent();
        }

        private void BtnDecode_Click(object sender, EventArgs e)
        {
            string line = "";
            
            string path = Application.StartupPath + @"/decode.txt";
            StreamReader streamReader = new StreamReader(path);

            int lineCount = Convert.ToInt32(streamReader.ReadLine());

            for (int i = 1; i <= lineCount; i++)
            {
                line = streamReader.ReadLine();
                TxtResult.Text += Decode(line) + Environment.NewLine;
            }
        }

        private string Decode(string word)
        {
            string[] letters = new string[] { "a", "b", "d", "e", "h", "l", "o", "r", "w" };

            string result = "";
            string digit = "";
            int zerosCount = 0;

            for (int i = 0; i < word.Length; i++)
            {
                digit = word.Substring(i, 1);

                if (digit == "1")
                {
                    result += letters[zerosCount];
                    zerosCount = 0;
                }
                else
                {
                    zerosCount++;
                }
            }
            return result;
        }
    }
}
