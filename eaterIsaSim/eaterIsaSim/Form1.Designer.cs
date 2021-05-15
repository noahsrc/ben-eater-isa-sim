
namespace eaterIsaSim
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ControlMenu = new System.Windows.Forms.MenuStrip();
            this.FileOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.RunProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.StopProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgramData = new System.Windows.Forms.TextBox();
            this.ProgramOutput = new System.Windows.Forms.TextBox();
            this.MaxBytesTB = new System.Windows.Forms.TextBox();
            this.MaxInsnsTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputRegTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InsnDelayTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ControlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlMenu
            // 
            this.ControlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileOptions,
            this.RunProgram,
            this.StopProgram});
            this.ControlMenu.Location = new System.Drawing.Point(0, 0);
            this.ControlMenu.Name = "ControlMenu";
            this.ControlMenu.Size = new System.Drawing.Size(784, 24);
            this.ControlMenu.TabIndex = 0;
            this.ControlMenu.Text = "ControlMenu";
            // 
            // FileOptions
            // 
            this.FileOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileOpen,
            this.FileSave,
            this.FileSaveAs});
            this.FileOptions.Name = "FileOptions";
            this.FileOptions.Size = new System.Drawing.Size(37, 20);
            this.FileOptions.Text = "File";
            // 
            // FileOpen
            // 
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.Size = new System.Drawing.Size(114, 22);
            this.FileOpen.Text = "Open";
            // 
            // FileSave
            // 
            this.FileSave.Name = "FileSave";
            this.FileSave.Size = new System.Drawing.Size(114, 22);
            this.FileSave.Text = "Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(114, 22);
            this.FileSaveAs.Text = "Save As";
            // 
            // RunProgram
            // 
            this.RunProgram.Name = "RunProgram";
            this.RunProgram.Size = new System.Drawing.Size(40, 20);
            this.RunProgram.Text = "Run";
            this.RunProgram.Click += new System.EventHandler(this.RunProgram_Click);
            // 
            // StopProgram
            // 
            this.StopProgram.Name = "StopProgram";
            this.StopProgram.Size = new System.Drawing.Size(43, 20);
            this.StopProgram.Text = "Stop";
            this.StopProgram.Click += new System.EventHandler(this.StopProgram_Click);
            // 
            // ProgramData
            // 
            this.ProgramData.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProgramData.Location = new System.Drawing.Point(12, 33);
            this.ProgramData.Multiline = true;
            this.ProgramData.Name = "ProgramData";
            this.ProgramData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProgramData.Size = new System.Drawing.Size(333, 349);
            this.ProgramData.TabIndex = 1;
            this.ProgramData.Text = resources.GetString("ProgramData.Text");
            // 
            // ProgramOutput
            // 
            this.ProgramOutput.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProgramOutput.Location = new System.Drawing.Point(12, 397);
            this.ProgramOutput.Multiline = true;
            this.ProgramOutput.Name = "ProgramOutput";
            this.ProgramOutput.ReadOnly = true;
            this.ProgramOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProgramOutput.Size = new System.Drawing.Size(760, 152);
            this.ProgramOutput.TabIndex = 2;
            // 
            // MaxBytesTB
            // 
            this.MaxBytesTB.Location = new System.Drawing.Point(732, 93);
            this.MaxBytesTB.MaxLength = 20;
            this.MaxBytesTB.Name = "MaxBytesTB";
            this.MaxBytesTB.Size = new System.Drawing.Size(40, 23);
            this.MaxBytesTB.TabIndex = 3;
            this.MaxBytesTB.Text = "16";
            this.MaxBytesTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaxBytesTB.WordWrap = false;
            // 
            // MaxInsnsTB
            // 
            this.MaxInsnsTB.Location = new System.Drawing.Point(732, 122);
            this.MaxInsnsTB.MaxLength = 20;
            this.MaxInsnsTB.Name = "MaxInsnsTB";
            this.MaxInsnsTB.Size = new System.Drawing.Size(40, 23);
            this.MaxInsnsTB.TabIndex = 4;
            this.MaxInsnsTB.Text = "100";
            this.MaxInsnsTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaxInsnsTB.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(552, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Memory size in bytes (decimal):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(567, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Maximum instruction count:";
            // 
            // OutputRegTB
            // 
            this.OutputRegTB.Location = new System.Drawing.Point(732, 180);
            this.OutputRegTB.Name = "OutputRegTB";
            this.OutputRegTB.ReadOnly = true;
            this.OutputRegTB.Size = new System.Drawing.Size(40, 23);
            this.OutputRegTB.TabIndex = 7;
            this.OutputRegTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OutputRegTB.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output Register:";
            // 
            // InsnDelayTB
            // 
            this.InsnDelayTB.Location = new System.Drawing.Point(732, 151);
            this.InsnDelayTB.Name = "InsnDelayTB";
            this.InsnDelayTB.Size = new System.Drawing.Size(40, 23);
            this.InsnDelayTB.TabIndex = 9;
            this.InsnDelayTB.Text = "10";
            this.InsnDelayTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InsnDelayTB.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(601, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Instruction delay (ms):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.InsnDelayTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OutputRegTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaxInsnsTB);
            this.Controls.Add(this.MaxBytesTB);
            this.Controls.Add(this.ProgramOutput);
            this.Controls.Add(this.ProgramData);
            this.Controls.Add(this.ControlMenu);
            this.Name = "Form1";
            this.Text = "Ben Eater 8-Bit Instruction Set Simulator by Noah Miller";
            this.ControlMenu.ResumeLayout(false);
            this.ControlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ControlMenu;
        private System.Windows.Forms.ToolStripMenuItem FileOptions;
        private System.Windows.Forms.ToolStripMenuItem FileOpen;
        private System.Windows.Forms.ToolStripMenuItem FileSave;
        private System.Windows.Forms.ToolStripMenuItem FileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem RunProgram;
        private System.Windows.Forms.TextBox ProgramData;
        private System.Windows.Forms.TextBox ProgramOutput;
        private System.Windows.Forms.TextBox MaxBytesTB;
        private System.Windows.Forms.TextBox MaxInsnsTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OutputRegTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InsnDelayTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem StopProgram;
    }
}

