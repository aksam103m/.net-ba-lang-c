namespace ado.net
{
    partial class kategori
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.kuzeyYeliDataSet = new ado.net.KuzeyYeliDataSet();
            this.kategorilerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kategorilerTableAdapter = new ado.net.KuzeyYeliDataSetTableAdapters.KategorilerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.kuzeyYeliDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kategorilerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.kategorilerBindingSource;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(33, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(540, 355);
            this.listBox1.TabIndex = 0;
            // 
            // kuzeyYeliDataSet
            // 
            this.kuzeyYeliDataSet.DataSetName = "KuzeyYeliDataSet";
            this.kuzeyYeliDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kategorilerBindingSource
            // 
            this.kategorilerBindingSource.DataMember = "Kategoriler";
            this.kategorilerBindingSource.DataSource = this.kuzeyYeliDataSet;
            // 
            // kategorilerTableAdapter
            // 
            this.kategorilerTableAdapter.ClearBeforeFill = true;
            // 
            // kategori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Name = "kategori";
            this.Text = "kategori";
            this.Load += new System.EventHandler(this.kategori_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kuzeyYeliDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kategorilerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private KuzeyYeliDataSet kuzeyYeliDataSet;
        private System.Windows.Forms.BindingSource kategorilerBindingSource;
        private KuzeyYeliDataSetTableAdapters.KategorilerTableAdapter kategorilerTableAdapter;
    }
}