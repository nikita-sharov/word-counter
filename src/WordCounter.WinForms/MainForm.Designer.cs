namespace WordCounter.WinForms
{
    partial class MainForm
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
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.parseButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.encodingLabel = new System.Windows.Forms.Label();
            this.encodingComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // fileTextBox
            // 
            this.fileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTextBox.Enabled = false;
            this.fileTextBox.Location = new System.Drawing.Point(12, 71);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.PlaceholderText = "Select the file to parse using the encoding above";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(519, 23);
            this.fileTextBox.TabIndex = 1;
            // 
            // parseButton
            // 
            this.parseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.parseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.parseButton.Location = new System.Drawing.Point(537, 70);
            this.parseButton.Name = "parseButton";
            this.parseButton.Size = new System.Drawing.Size(75, 25);
            this.parseButton.TabIndex = 1;
            this.parseButton.Text = "Parse...";
            this.parseButton.UseVisualStyleBackColor = true;
            this.parseButton.Click += new System.EventHandler(this.OnParseButtonClick);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(9, 53);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(50, 15);
            this.fileLabel.TabIndex = 3;
            this.fileLabel.Text = "Text file:";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Word";
            this.Column1.HeaderText = "Word";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Count";
            this.Column2.HeaderText = "Count";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView.Location = new System.Drawing.Point(12, 101);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(600, 328);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.Text = "dataGridView1";
            this.dataGridView.VirtualMode = true;
            this.dataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnDataGridViewCellValueNeeded);
            // 
            // encodingLabel
            // 
            this.encodingLabel.AutoSize = true;
            this.encodingLabel.Location = new System.Drawing.Point(9, 9);
            this.encodingLabel.Name = "encodingLabel";
            this.encodingLabel.Size = new System.Drawing.Size(60, 15);
            this.encodingLabel.TabIndex = 3;
            this.encodingLabel.Text = "Encoding:";
            // 
            // encodingComboBox
            // 
            this.encodingComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.encodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encodingComboBox.FormattingEnabled = true;
            this.encodingComboBox.Location = new System.Drawing.Point(12, 27);
            this.encodingComboBox.Name = "encodingComboBox";
            this.encodingComboBox.Size = new System.Drawing.Size(600, 23);
            this.encodingComboBox.Sorted = true;
            this.encodingComboBox.TabIndex = 3;
            this.encodingComboBox.SelectedValueChanged += new System.EventHandler(this.OnEncodingComboBoxSelectedValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.encodingComboBox);
            this.Controls.Add(this.encodingLabel);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.parseButton);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.dataGridView);
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Word Counter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button parseButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label encodingLabel;
        private System.Windows.Forms.ComboBox encodingComboBox;
    }
}