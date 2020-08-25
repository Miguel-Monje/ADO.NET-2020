namespace WindowsForms001
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grupoOrdenar = new System.Windows.Forms.GroupBox();
            this.radioONumero = new System.Windows.Forms.RadioButton();
            this.radioOConcepto = new System.Windows.Forms.RadioButton();
            this.cajaFiltrar = new System.Windows.Forms.TextBox();
            this.botonFiltrar = new System.Windows.Forms.Button();
            this.botonRestaurar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.grupoOrdenar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(325, 176);
            this.dataGridView1.TabIndex = 0;
            // 
            // grupoOrdenar
            // 
            this.grupoOrdenar.Controls.Add(this.radioOConcepto);
            this.grupoOrdenar.Controls.Add(this.radioONumero);
            this.grupoOrdenar.Location = new System.Drawing.Point(343, 12);
            this.grupoOrdenar.Name = "grupoOrdenar";
            this.grupoOrdenar.Size = new System.Drawing.Size(170, 67);
            this.grupoOrdenar.TabIndex = 1;
            this.grupoOrdenar.TabStop = false;
            this.grupoOrdenar.Text = "Ordenacion";
            // 
            // radioONumero
            // 
            this.radioONumero.AutoSize = true;
            this.radioONumero.Location = new System.Drawing.Point(7, 20);
            this.radioONumero.Name = "radioONumero";
            this.radioONumero.Size = new System.Drawing.Size(121, 17);
            this.radioONumero.TabIndex = 0;
            this.radioONumero.TabStop = true;
            this.radioONumero.Text = "Ordenar por Numero";
            this.radioONumero.UseVisualStyleBackColor = true;
            this.radioONumero.CheckedChanged += new System.EventHandler(this.radioONumero_CheckedChanged);
            // 
            // radioOConcepto
            // 
            this.radioOConcepto.AutoSize = true;
            this.radioOConcepto.Location = new System.Drawing.Point(7, 44);
            this.radioOConcepto.Name = "radioOConcepto";
            this.radioOConcepto.Size = new System.Drawing.Size(130, 17);
            this.radioOConcepto.TabIndex = 1;
            this.radioOConcepto.TabStop = true;
            this.radioOConcepto.Text = "Ordenar por Concepto";
            this.radioOConcepto.UseVisualStyleBackColor = true;
            this.radioOConcepto.CheckedChanged += new System.EventHandler(this.radioOConcepto_CheckedChanged);
            // 
            // cajaFiltrar
            // 
            this.cajaFiltrar.Location = new System.Drawing.Point(350, 101);
            this.cajaFiltrar.Name = "cajaFiltrar";
            this.cajaFiltrar.Size = new System.Drawing.Size(100, 20);
            this.cajaFiltrar.TabIndex = 2;
            // 
            // botonFiltrar
            // 
            this.botonFiltrar.Location = new System.Drawing.Point(350, 128);
            this.botonFiltrar.Name = "botonFiltrar";
            this.botonFiltrar.Size = new System.Drawing.Size(100, 23);
            this.botonFiltrar.TabIndex = 3;
            this.botonFiltrar.Text = "Filtrar";
            this.botonFiltrar.UseVisualStyleBackColor = true;
            this.botonFiltrar.Click += new System.EventHandler(this.botonFiltrar_Click);
            // 
            // botonRestaurar
            // 
            this.botonRestaurar.Location = new System.Drawing.Point(13, 195);
            this.botonRestaurar.Name = "botonRestaurar";
            this.botonRestaurar.Size = new System.Drawing.Size(75, 23);
            this.botonRestaurar.TabIndex = 4;
            this.botonRestaurar.Text = "Restaurar";
            this.botonRestaurar.UseVisualStyleBackColor = true;
            this.botonRestaurar.Click += new System.EventHandler(this.botonRestaurar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 336);
            this.Controls.Add(this.botonRestaurar);
            this.Controls.Add(this.botonFiltrar);
            this.Controls.Add(this.cajaFiltrar);
            this.Controls.Add(this.grupoOrdenar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.grupoOrdenar.ResumeLayout(false);
            this.grupoOrdenar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.GroupBox grupoOrdenar;
        private System.Windows.Forms.RadioButton radioOConcepto;
        private System.Windows.Forms.RadioButton radioONumero;
        private System.Windows.Forms.TextBox cajaFiltrar;
        private System.Windows.Forms.Button botonFiltrar;
        private System.Windows.Forms.Button botonRestaurar;
    }
}

