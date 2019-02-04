namespace PokerLeaderBoard
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgPlayer = new System.Windows.Forms.DataGridView();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWinnings = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMedian = new System.Windows.Forms.Label();
            this.lblMean = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlAddPlayer = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblOrigWinnings = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayer)).BeginInit();
            this.pnlAddPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Median: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mean:";
            // 
            // dgPlayer
            // 
            this.dgPlayer.AllowUserToAddRows = false;
            this.dgPlayer.AllowUserToDeleteRows = false;
            this.dgPlayer.AllowUserToOrderColumns = true;
            this.dgPlayer.AllowUserToResizeColumns = false;
            this.dgPlayer.AllowUserToResizeRows = false;
            this.dgPlayer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPlayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlayer.Location = new System.Drawing.Point(44, 175);
            this.dgPlayer.Name = "dgPlayer";
            this.dgPlayer.ReadOnly = true;
            this.dgPlayer.Size = new System.Drawing.Size(701, 150);
            this.dgPlayer.TabIndex = 2;
            this.dgPlayer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPlayer_CellClick);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(40, 30);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 24);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Visible = false;
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPlayer.Location = new System.Drawing.Point(44, 346);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(114, 29);
            this.btnAddPlayer.TabIndex = 4;
            this.btnAddPlayer.Text = "Add Player";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayerName.Location = new System.Drawing.Point(107, 12);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(153, 26);
            this.txtPlayerName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Player Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(266, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Winnings";
            // 
            // txtWinnings
            // 
            this.txtWinnings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWinnings.Location = new System.Drawing.Point(346, 12);
            this.txtWinnings.Name = "txtWinnings";
            this.txtWinnings.Size = new System.Drawing.Size(100, 26);
            this.txtWinnings.TabIndex = 8;
            this.txtWinnings.Validating += new System.ComponentModel.CancelEventHandler(this.txtWinnings_Validating);
            this.txtWinnings.Validated += new System.EventHandler(this.txtWinnings_Validated);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(452, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMedian
            // 
            this.lblMedian.AutoSize = true;
            this.lblMedian.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedian.Location = new System.Drawing.Point(135, 100);
            this.lblMedian.Name = "lblMedian";
            this.lblMedian.Size = new System.Drawing.Size(123, 24);
            this.lblMedian.TabIndex = 10;
            this.lblMedian.Text = "median value";
            // 
            // lblMean
            // 
            this.lblMean.AutoSize = true;
            this.lblMean.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMean.Location = new System.Drawing.Point(135, 66);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(108, 24);
            this.lblMean.TabIndex = 11;
            this.lblMean.Text = "mean value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(44, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Poker Leader Board";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAddPlayer
            // 
            this.pnlAddPlayer.Controls.Add(this.btnCancel);
            this.pnlAddPlayer.Controls.Add(this.label3);
            this.pnlAddPlayer.Controls.Add(this.txtPlayerName);
            this.pnlAddPlayer.Controls.Add(this.label4);
            this.pnlAddPlayer.Controls.Add(this.txtWinnings);
            this.pnlAddPlayer.Controls.Add(this.btnSave);
            this.pnlAddPlayer.ForeColor = System.Drawing.SystemColors.Control;
            this.pnlAddPlayer.Location = new System.Drawing.Point(44, 381);
            this.pnlAddPlayer.Name = "pnlAddPlayer";
            this.pnlAddPlayer.Size = new System.Drawing.Size(638, 50);
            this.pnlAddPlayer.TabIndex = 14;
            this.pnlAddPlayer.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(534, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblOrigWinnings
            // 
            this.lblOrigWinnings.AutoSize = true;
            this.lblOrigWinnings.Location = new System.Drawing.Point(46, 330);
            this.lblOrigWinnings.Name = "lblOrigWinnings";
            this.lblOrigWinnings.Size = new System.Drawing.Size(68, 13);
            this.lblOrigWinnings.TabIndex = 16;
            this.lblOrigWinnings.Text = "origWinnings";
            this.lblOrigWinnings.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(662, 500);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 44);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 556);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblOrigWinnings);
            this.Controls.Add(this.pnlAddPlayer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMean);
            this.Controls.Add(this.lblMedian);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dgPlayer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Poker Leaderboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayer)).EndInit();
            this.pnlAddPlayer.ResumeLayout(false);
            this.pnlAddPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgPlayer;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWinnings;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMedian;
        private System.Windows.Forms.Label lblMean;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlAddPlayer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblOrigWinnings;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnClose;
    }
}

