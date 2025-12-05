using DotNetLab4_FileEncryptor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetLab4
{
    public partial class Form1 : Form
    {
        private readonly FileEncryptor _encryptor = new FileEncryptor();
        private Stopwatch _stopwatch;
        private string _inputPath;
        private string _outputPath;
        private string _key;

        public Form1()
        {
            InitializeComponent();

            // Підписуємося на події
            btnBrowse.Click += btnBrowse_Click;
            btnEncrypt.Click += btnEncrypt_Click;
            btnDecrypt.Click += btnDecrypt_Click;

            bgWorker.WorkerReportsProgress = true;
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;

            timer1.Tick += Timer1_Tick;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName;
                }
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            StartEncryptDecrypt(isEncrypt: true);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            StartEncryptDecrypt(isEncrypt: false);
        }

        private void StartEncryptDecrypt(bool isEncrypt)
        {
            try
            {
                _inputPath = txtFilePath.Text;
                _key = txtKey.Text;

                if (string.IsNullOrWhiteSpace(_inputPath) || !File.Exists(_inputPath))
                {
                    MessageBox.Show("Оберіть коректний файл");
                    return;
                }

                if (string.IsNullOrWhiteSpace(_key))
                {
                    MessageBox.Show("Введіть ключ");
                    return;
                }

                using (var sfd = new SaveFileDialog())
                {
                    sfd.FileName = Path.GetFileNameWithoutExtension(_inputPath) +
                                   (isEncrypt ? "_encrypted" : "_decrypted") +
                                   Path.GetExtension(_inputPath);

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    _outputPath = sfd.FileName;
                }

                progressBar.Value = 0;
                lblStatus.Text = "Початок обробки...";
                _stopwatch = Stopwatch.StartNew();
                timer1.Start();

                btnEncrypt.Enabled = false;
                btnDecrypt.Enabled = false;
                btnBrowse.Enabled = false;

                bgWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;

            var progress = new Progress<int>(percent =>
            {
                worker.ReportProgress(percent);
            });

            _encryptor.EncryptFile(_inputPath, _outputPath, _key, progress);
        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            lblStatus.Text = $"Прогрес: {e.ProgressPercentage}%";
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Stop();
            _stopwatch?.Stop();

            btnEncrypt.Enabled = true;
            btnDecrypt.Enabled = true;
            btnBrowse.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show("Помилка під час шифрування: " + e.Error.Message);
                return;
            }

            var fi = new FileInfo(_outputPath);
            string msg = $"Операцію завершено успішно.\n" +
                         $"Файл: {fi.Name}\n" +
                         $"Розмір: {fi.Length} байт\n" +
                         $"Час: {_stopwatch.Elapsed}";
            MessageBox.Show(msg, "Готово");

            lblStatus.Text = "Готово";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (_stopwatch != null)
            {
                lblTime.Text = "Час: " + _stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
