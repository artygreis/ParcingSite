namespace ParserSite
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.btnParser = new System.Windows.Forms.Button();
            this.btnLoadFromDb = new System.Windows.Forms.Button();
            this.dgvDataPages = new System.Windows.Forms.DataGridView();
            this.grpDataPages = new System.Windows.Forms.GroupBox();
            this.txtFindPage = new System.Windows.Forms.TextBox();
            this.btnFindPage = new System.Windows.Forms.Button();
            this.btnShowHtml = new System.Windows.Forms.Button();
            this.btnShowArticle = new System.Windows.Forms.Button();
            this.btnOpenUrl = new System.Windows.Forms.Button();
            this.btnClearDb = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.numPagesToCrawl = new System.Windows.Forms.NumericUpDown();
            this.lblPagesToCrawl = new System.Windows.Forms.Label();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPages)).BeginInit();
            this.grpDataPages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPagesToCrawl)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.txtLog);
            this.grpLog.Location = new System.Drawing.Point(11, 351);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(515, 183);
            this.grpLog.TabIndex = 1;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Лог";
            // 
            // btnParser
            // 
            this.btnParser.Location = new System.Drawing.Point(51, 49);
            this.btnParser.Name = "btnParser";
            this.btnParser.Size = new System.Drawing.Size(114, 32);
            this.btnParser.TabIndex = 0;
            this.btnParser.Text = "Сканировать";
            this.btnParser.UseVisualStyleBackColor = true;
            this.btnParser.Click += new System.EventHandler(this.btnParser_Click);
            // 
            // btnLoadFromDb
            // 
            this.btnLoadFromDb.Location = new System.Drawing.Point(233, 7);
            this.btnLoadFromDb.Name = "btnLoadFromDb";
            this.btnLoadFromDb.Size = new System.Drawing.Size(114, 34);
            this.btnLoadFromDb.TabIndex = 1;
            this.btnLoadFromDb.Text = "Загрузить из БД";
            this.btnLoadFromDb.UseVisualStyleBackColor = true;
            this.btnLoadFromDb.Click += new System.EventHandler(this.btnLoadFromDb_Click);
            // 
            // dgvDataPages
            // 
            this.dgvDataPages.AllowUserToAddRows = false;
            this.dgvDataPages.AllowUserToDeleteRows = false;
            this.dgvDataPages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataPages.Location = new System.Drawing.Point(6, 19);
            this.dgvDataPages.Name = "dgvDataPages";
            this.dgvDataPages.ReadOnly = true;
            this.dgvDataPages.Size = new System.Drawing.Size(503, 199);
            this.dgvDataPages.TabIndex = 2;
            // 
            // grpDataPages
            // 
            this.grpDataPages.Controls.Add(this.dgvDataPages);
            this.grpDataPages.Location = new System.Drawing.Point(11, 87);
            this.grpDataPages.Name = "grpDataPages";
            this.grpDataPages.Size = new System.Drawing.Size(515, 224);
            this.grpDataPages.TabIndex = 3;
            this.grpDataPages.TabStop = false;
            this.grpDataPages.Text = "База данных";
            // 
            // txtFindPage
            // 
            this.txtFindPage.Location = new System.Drawing.Point(378, 18);
            this.txtFindPage.Name = "txtFindPage";
            this.txtFindPage.Size = new System.Drawing.Size(142, 20);
            this.txtFindPage.TabIndex = 4;
            // 
            // btnFindPage
            // 
            this.btnFindPage.Location = new System.Drawing.Point(378, 49);
            this.btnFindPage.Name = "btnFindPage";
            this.btnFindPage.Size = new System.Drawing.Size(142, 34);
            this.btnFindPage.TabIndex = 5;
            this.btnFindPage.Text = "Найти статьи";
            this.btnFindPage.UseVisualStyleBackColor = true;
            this.btnFindPage.Click += new System.EventHandler(this.btnFindPage_Click);
            // 
            // btnShowHtml
            // 
            this.btnShowHtml.Location = new System.Drawing.Point(406, 317);
            this.btnShowHtml.Name = "btnShowHtml";
            this.btnShowHtml.Size = new System.Drawing.Size(114, 34);
            this.btnShowHtml.TabIndex = 7;
            this.btnShowHtml.Text = "Показать HTML";
            this.btnShowHtml.UseVisualStyleBackColor = true;
            this.btnShowHtml.Click += new System.EventHandler(this.btnShowHtml_Click);
            // 
            // btnShowArticle
            // 
            this.btnShowArticle.Location = new System.Drawing.Point(286, 317);
            this.btnShowArticle.Name = "btnShowArticle";
            this.btnShowArticle.Size = new System.Drawing.Size(114, 34);
            this.btnShowArticle.TabIndex = 8;
            this.btnShowArticle.Text = "Показать статью";
            this.btnShowArticle.UseVisualStyleBackColor = true;
            this.btnShowArticle.Click += new System.EventHandler(this.btnShowArticle_Click);
            // 
            // btnOpenUrl
            // 
            this.btnOpenUrl.Location = new System.Drawing.Point(166, 317);
            this.btnOpenUrl.Name = "btnOpenUrl";
            this.btnOpenUrl.Size = new System.Drawing.Size(114, 34);
            this.btnOpenUrl.TabIndex = 9;
            this.btnOpenUrl.Text = "Открыть ссылку";
            this.btnOpenUrl.UseVisualStyleBackColor = true;
            this.btnOpenUrl.Click += new System.EventHandler(this.btnOpenUrl_Click);
            // 
            // btnClearDb
            // 
            this.btnClearDb.Location = new System.Drawing.Point(233, 49);
            this.btnClearDb.Name = "btnClearDb";
            this.btnClearDb.Size = new System.Drawing.Size(114, 34);
            this.btnClearDb.TabIndex = 10;
            this.btnClearDb.Text = "Очистить БД";
            this.btnClearDb.UseVisualStyleBackColor = true;
            this.btnClearDb.Click += new System.EventHandler(this.btnClearDb_Click);
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Location = new System.Drawing.Point(6, 19);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(503, 158);
            this.txtLog.TabIndex = 1;
            // 
            // numPagesToCrawl
            // 
            this.numPagesToCrawl.Location = new System.Drawing.Point(51, 23);
            this.numPagesToCrawl.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPagesToCrawl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPagesToCrawl.Name = "numPagesToCrawl";
            this.numPagesToCrawl.Size = new System.Drawing.Size(114, 20);
            this.numPagesToCrawl.TabIndex = 11;
            this.numPagesToCrawl.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblPagesToCrawl
            // 
            this.lblPagesToCrawl.AutoSize = true;
            this.lblPagesToCrawl.Location = new System.Drawing.Point(14, 6);
            this.lblPagesToCrawl.Name = "lblPagesToCrawl";
            this.lblPagesToCrawl.Size = new System.Drawing.Size(195, 13);
            this.lblPagesToCrawl.TabIndex = 12;
            this.lblPagesToCrawl.Text = "Укажите страниц для сканирования:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 541);
            this.Controls.Add(this.lblPagesToCrawl);
            this.Controls.Add(this.numPagesToCrawl);
            this.Controls.Add(this.btnClearDb);
            this.Controls.Add(this.btnOpenUrl);
            this.Controls.Add(this.btnShowArticle);
            this.Controls.Add(this.btnShowHtml);
            this.Controls.Add(this.btnFindPage);
            this.Controls.Add(this.txtFindPage);
            this.Controls.Add(this.grpDataPages);
            this.Controls.Add(this.btnLoadFromDb);
            this.Controls.Add(this.btnParser);
            this.Controls.Add(this.grpLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "https://belaruspartisan.by";
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPages)).EndInit();
            this.grpDataPages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPagesToCrawl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.Button btnParser;
        private System.Windows.Forms.Button btnLoadFromDb;
        private System.Windows.Forms.DataGridView dgvDataPages;
        private System.Windows.Forms.GroupBox grpDataPages;
        private System.Windows.Forms.TextBox txtFindPage;
        private System.Windows.Forms.Button btnFindPage;
        private System.Windows.Forms.Button btnShowHtml;
        private System.Windows.Forms.Button btnShowArticle;
        private System.Windows.Forms.Button btnOpenUrl;
        private System.Windows.Forms.Button btnClearDb;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.NumericUpDown numPagesToCrawl;
        private System.Windows.Forms.Label lblPagesToCrawl;
    }
}

