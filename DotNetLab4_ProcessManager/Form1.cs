using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetLab4_ProcessManager
{
    public partial class Form1 : Form
    {
        private readonly ProcessService _service = new ProcessService();
        private BindingList<ProcessInfoDto> _bindingList;

        public Form1()
        {
            InitializeComponent();

            btnRefresh.Click += btnRefresh_Click;
            btnKill.Click += btnKill_Click;
            btnSetPriority.Click += btnSetPriority_Click;

            btnStartCalc.Click += btnStartCalc_Click;
            btnStartWord.Click += btnStartWord_Click;
            btnStartApp1.Click += btnStartApp1_Click;
            btnStartApp2.Click += btnStartApp2_Click;
            btnStartApp3.Click += btnStartApp3_Click;

            InitPriorityCombo();
            LoadProcesses();
        }

        private void InitPriorityCombo()
        {
            cmbPriority.DataSource = Enum.GetValues(typeof(ProcessPriorityClass));
        }

        private void LoadProcesses()
        {
            var processes = _service.GetProcesses()
                .OrderBy(p => p.Name)
                .ToList();

            _bindingList = new BindingList<ProcessInfoDto>(processes);
            dgvProcesses.DataSource = _bindingList;

            dgvProcesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private ProcessInfoDto GetSelectedProcess()
        {
            if (dgvProcesses.CurrentRow == null)
                return null;

            return dgvProcesses.CurrentRow.DataBoundItem as ProcessInfoDto;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            var p = GetSelectedProcess();
            if (p == null) return;

            if (MessageBox.Show($"Завершити процес {p.Name} ({p.Id})?",
                                "Підтвердження",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _service.KillProcess(p.Id);
                    LoadProcesses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при завершенні процесу: " + ex.Message);
                }
            }
        }

        private void btnSetPriority_Click(object sender, EventArgs e)
        {
            var p = GetSelectedProcess();
            if (p == null) return;

            var priority = (ProcessPriorityClass)cmbPriority.SelectedItem;

            try
            {
                _service.SetPriority(p.Id, priority);
                LoadProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при зміні пріоритету: " + ex.Message);
            }
        }

        private void btnStartCalc_Click(object sender, EventArgs e)
        {
            try
            {
                _service.StartCalculator();
                LoadProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалось запустити калькулятор: " + ex.Message);
            }
        }

        private void btnStartWord_Click(object sender, EventArgs e)
        {
            try
            {
                _service.StartWord();
                LoadProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалось запустити Word: " + ex.Message);
            }
        }

        private void btnStartApp1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("excel.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалося запустити Excel: " + ex.Message);
            }
        }

        private void btnStartApp2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("code");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалося запустити VS Code: " + ex.Message);
            }
        }

        private void btnStartApp3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.canva.com",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалося відкрити Canva: " + ex.Message);
            }
        }

        private void StartCustomApp()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "EXE files|*.exe";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _service.StartApp(ofd.FileName);
                        LoadProcesses();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка запуску: " + ex.Message);
                    }
                }
            }
        }

    }
}
