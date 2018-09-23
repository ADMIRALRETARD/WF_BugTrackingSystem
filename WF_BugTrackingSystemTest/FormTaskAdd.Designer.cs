namespace WF_BugTrackingSystemTest
{
    partial class FormTaskAdd
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
            this.tbTheme = new System.Windows.Forms.TextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.tbPriority = new System.Windows.Forms.TextBox();
            this.tbDescrition = new System.Windows.Forms.TextBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblTheme = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblExecutor = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cbProjects = new System.Windows.Forms.ComboBox();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbTheme
            // 
            this.tbTheme.Location = new System.Drawing.Point(92, 59);
            this.tbTheme.Name = "tbTheme";
            this.tbTheme.Size = new System.Drawing.Size(169, 20);
            this.tbTheme.TabIndex = 0;
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(92, 89);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(100, 20);
            this.tbType.TabIndex = 1;
            // 
            // tbPriority
            // 
            this.tbPriority.Location = new System.Drawing.Point(92, 119);
            this.tbPriority.Name = "tbPriority";
            this.tbPriority.Size = new System.Drawing.Size(100, 20);
            this.tbPriority.TabIndex = 2;
            // 
            // tbDescrition
            // 
            this.tbDescrition.Location = new System.Drawing.Point(92, 196);
            this.tbDescrition.Multiline = true;
            this.tbDescrition.Name = "tbDescrition";
            this.tbDescrition.Size = new System.Drawing.Size(281, 20);
            this.tbDescrition.TabIndex = 3;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(12, 29);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(44, 13);
            this.lblProject.TabIndex = 4;
            this.lblProject.Text = "Проект";
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(12, 59);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(57, 13);
            this.lblTheme.TabIndex = 5;
            this.lblTheme.Text = "Название";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(12, 89);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(26, 13);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Тип";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(12, 119);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(61, 13);
            this.lblPriority.TabIndex = 7;
            this.lblPriority.Text = "Приоритет";
            // 
            // lblExecutor
            // 
            this.lblExecutor.AutoSize = true;
            this.lblExecutor.Location = new System.Drawing.Point(12, 156);
            this.lblExecutor.Name = "lblExecutor";
            this.lblExecutor.Size = new System.Drawing.Size(74, 13);
            this.lblExecutor.TabIndex = 8;
            this.lblExecutor.Text = "Исполнитель";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 199);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(57, 13);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Описание";
            // 
            // cbProjects
            // 
            this.cbProjects.FormattingEnabled = true;
            this.cbProjects.Location = new System.Drawing.Point(92, 29);
            this.cbProjects.Name = "cbProjects";
            this.cbProjects.Size = new System.Drawing.Size(121, 21);
            this.cbProjects.TabIndex = 10;
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(92, 156);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(121, 21);
            this.cbUsers.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(298, 255);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FormTaskAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 306);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.cbProjects);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblExecutor);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.tbDescrition);
            this.Controls.Add(this.tbPriority);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.tbTheme);
            this.Name = "FormTaskAdd";
            this.Text = "Добавить задачу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTheme;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.TextBox tbPriority;
        private System.Windows.Forms.TextBox tbDescrition;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblExecutor;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cbProjects;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Button btnAdd;
    }
}