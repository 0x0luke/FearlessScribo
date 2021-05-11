using System;
using System.Windows.Forms;

namespace FearlessScribo
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            String fileName = " ";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            OpenFileDialog Input = new OpenFileDialog();
            TextBox textBox1 = new TextBox();
            Input.Title = "Please select the game recording";
            Input.InitialDirectory = @"C:\Videos\";
            Input.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";
            Input.FilterIndex = 2;
            Input.RestoreDirectory = true;
            if (Input.ShowDialog() == DialogResult.OK)
            {
                fileName = Input.FileName;
            }

            Application.Run(new Scribo(fileName));



        }
    }
}
