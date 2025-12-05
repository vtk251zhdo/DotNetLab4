namespace DotNetLab4_ProcessManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnKill = new System.Windows.Forms.Button();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.btnSetPriority = new System.Windows.Forms.Button();
            this.btnStartCalc = new System.Windows.Forms.Button();
            this.btnStartWord = new System.Windows.Forms.Button();
            this.btnStartApp1 = new System.Windows.Forms.Button();
            this.btnStartApp2 = new System.Windows.Forms.Button();
            this.btnStartApp3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProcesses
            // 
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.Location = new System.Drawing.Point(12, 12);
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.Size = new System.Drawing.Size(498, 322);
            this.dgvProcesses.TabIndex = 0;
            this.dgvProcesses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProcesses_CellContentClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefresh.Location = new System.Drawing.Point(382, 398);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnKill
            // 
            this.btnKill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKill.Location = new System.Drawing.Point(588, 398);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(200, 40);
            this.btnKill.TabIndex = 2;
            this.btnKill.Text = "Завершити процес";
            this.btnKill.UseVisualStyleBackColor = true;
            // 
            // cmbPriority
            // 
            this.cmbPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(12, 360);
            this.cmbPriority.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(200, 32);
            this.cmbPriority.TabIndex = 3;
            // 
            // btnSetPriority
            // 
            this.btnSetPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetPriority.Location = new System.Drawing.Point(12, 398);
            this.btnSetPriority.Name = "btnSetPriority";
            this.btnSetPriority.Size = new System.Drawing.Size(200, 40);
            this.btnSetPriority.TabIndex = 4;
            this.btnSetPriority.Text = "Змінити пріоритет";
            this.btnSetPriority.UseVisualStyleBackColor = true;
            // 
            // btnStartCalc
            // 
            this.btnStartCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartCalc.Location = new System.Drawing.Point(588, 23);
            this.btnStartCalc.Name = "btnStartCalc";
            this.btnStartCalc.Size = new System.Drawing.Size(200, 40);
            this.btnStartCalc.TabIndex = 5;
            this.btnStartCalc.Text = "Calc";
            this.btnStartCalc.UseVisualStyleBackColor = true;
            // 
            // btnStartWord
            // 
            this.btnStartWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartWord.Location = new System.Drawing.Point(588, 76);
            this.btnStartWord.Name = "btnStartWord";
            this.btnStartWord.Size = new System.Drawing.Size(200, 40);
            this.btnStartWord.TabIndex = 6;
            this.btnStartWord.Text = "Word";
            this.btnStartWord.UseVisualStyleBackColor = true;
            // 
            // btnStartApp1
            // 
            this.btnStartApp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartApp1.Location = new System.Drawing.Point(588, 129);
            this.btnStartApp1.Name = "btnStartApp1";
            this.btnStartApp1.Size = new System.Drawing.Size(200, 40);
            this.btnStartApp1.TabIndex = 7;
            this.btnStartApp1.Text = "Excel";
            this.btnStartApp1.UseVisualStyleBackColor = true;
            // 
            // btnStartApp2
            // 
            this.btnStartApp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartApp2.Location = new System.Drawing.Point(588, 182);
            this.btnStartApp2.Name = "btnStartApp2";
            this.btnStartApp2.Size = new System.Drawing.Size(200, 40);
            this.btnStartApp2.TabIndex = 8;
            this.btnStartApp2.Text = "VS Code";
            this.btnStartApp2.UseVisualStyleBackColor = true;
            // 
            // btnStartApp3
            // 
            this.btnStartApp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartApp3.Location = new System.Drawing.Point(588, 235);
            this.btnStartApp3.Name = "btnStartApp3";
            this.btnStartApp3.Size = new System.Drawing.Size(200, 40);
            this.btnStartApp3.TabIndex = 9;
            this.btnStartApp3.Text = "Canva";
            this.btnStartApp3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStartApp3);
            this.Controls.Add(this.btnStartApp2);
            this.Controls.Add(this.btnStartApp1);
            this.Controls.Add(this.btnStartWord);
            this.Controls.Add(this.btnStartCalc);
            this.Controls.Add(this.btnSetPriority);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvProcesses);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Button btnSetPriority;
        private System.Windows.Forms.Button btnStartCalc;
        private System.Windows.Forms.Button btnStartWord;
        private System.Windows.Forms.Button btnStartApp1;
        private System.Windows.Forms.Button btnStartApp2;
        private System.Windows.Forms.Button btnStartApp3;
    }
}

