using FFMpegCore;
using FFMpegCore.Enums;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FearlessScribo
{
    public partial class Scribo : Form
    {

        String output = "PlayerReport.mp4";
        public Scribo(String fileName)
        {
            InitializeComponent();
            GlobalFFOptions.Configure(new FFOptions { BinaryFolder = "./bin", TemporaryFilesFolder = "./tmp" });
            SetText(fileName);
            String file = fileName;

            button1.Click += delegate (object sender, EventArgs e) { button_Click(sender, e, file); };

        }


        private void button_Click(object sender, EventArgs e, String file)
        {
            ProcessVideo(file, output);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void SetText(string fileName)
        {
            textBox1.Text = fileName;
        }
        public void ProcessVideo(String input, String output)
        {

            // Debug.Write("Our file name is:" + input);
            FFMpegArguments
                .FromFileInput(input)
                .OutputToFile(output, false, options => options
                    .WithVideoCodec(VideoCodec.LibX264)
                    .WithConstantRateFactor(21)
                    .WithAudioCodec(AudioCodec.Aac)
                    .OverwriteExisting()
                    .WithVariableBitrate(4)
                    .UsingMultithreading(true)
                    .UsingThreads(Environment.ProcessorCount)
                    .WithVideoFilters(filterOptions => filterOptions
                        .Scale(VideoSize.Hd))
                    .WithFastStart())
                .ProcessSynchronously();
            if(Process.GetProcessesByName("ffmpeg").Length == 0)
            {
                Finished();
            }
            
        }

        private void Finished()
        {
            DialogResult result;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            result = MessageBox.Show("Finished!", "Status", buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}

