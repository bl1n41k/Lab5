﻿namespace Lab5
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.Field = new System.Windows.Forms.Panel();
			this.Group = new System.Windows.Forms.Panel();
			this.DeleteBtn = new System.Windows.Forms.Button();
			this.ClearBtn = new System.Windows.Forms.Button();
			this.RunBtn = new System.Windows.Forms.Button();
			this.NewBtn = new System.Windows.Forms.Button();
			this.StepBtn = new System.Windows.Forms.Button();
			this.LeftBtn = new System.Windows.Forms.Button();
			this.DownBtn = new System.Windows.Forms.Button();
			this.RightBtn = new System.Windows.Forms.Button();
			this.UpBtn = new System.Windows.Forms.Button();
			this.Algorithm = new System.Windows.Forms.ListBox();
			this.timerAlgorithm = new System.Windows.Forms.Timer(this.components);
			this.Group.SuspendLayout();
			this.SuspendLayout();
			// 
			// Field
			// 
			this.Field.AllowDrop = true;
			this.Field.AutoSize = true;
			this.Field.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Field.Location = new System.Drawing.Point(13, 13);
			this.Field.Name = "Field";
			this.Field.Size = new System.Drawing.Size(705, 502);
			this.Field.TabIndex = 0;
			this.Field.DragDrop += new System.Windows.Forms.DragEventHandler(this.Field_DragDrop);
			this.Field.DragEnter += new System.Windows.Forms.DragEventHandler(this.Field_DragEnter);
			// 
			// Group
			// 
			this.Group.Controls.Add(this.DeleteBtn);
			this.Group.Controls.Add(this.ClearBtn);
			this.Group.Controls.Add(this.RunBtn);
			this.Group.Controls.Add(this.NewBtn);
			this.Group.Controls.Add(this.StepBtn);
			this.Group.Controls.Add(this.LeftBtn);
			this.Group.Controls.Add(this.DownBtn);
			this.Group.Controls.Add(this.RightBtn);
			this.Group.Controls.Add(this.UpBtn);
			this.Group.Location = new System.Drawing.Point(724, 13);
			this.Group.Name = "Group";
			this.Group.Size = new System.Drawing.Size(107, 502);
			this.Group.TabIndex = 1;
			// 
			// DeleteBtn
			// 
			this.DeleteBtn.Location = new System.Drawing.Point(14, 462);
			this.DeleteBtn.Name = "DeleteBtn";
			this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
			this.DeleteBtn.TabIndex = 8;
			this.DeleteBtn.Text = "Delete";
			this.DeleteBtn.UseVisualStyleBackColor = true;
			this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
			// 
			// ClearBtn
			// 
			this.ClearBtn.Location = new System.Drawing.Point(14, 432);
			this.ClearBtn.Name = "ClearBtn";
			this.ClearBtn.Size = new System.Drawing.Size(75, 23);
			this.ClearBtn.TabIndex = 7;
			this.ClearBtn.Text = "Clear";
			this.ClearBtn.UseVisualStyleBackColor = true;
			this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
			// 
			// RunBtn
			// 
			this.RunBtn.Location = new System.Drawing.Point(14, 402);
			this.RunBtn.Name = "RunBtn";
			this.RunBtn.Size = new System.Drawing.Size(75, 23);
			this.RunBtn.TabIndex = 6;
			this.RunBtn.Text = "Run";
			this.RunBtn.UseVisualStyleBackColor = true;
			this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
			// 
			// NewBtn
			// 
			this.NewBtn.Location = new System.Drawing.Point(14, 373);
			this.NewBtn.Name = "NewBtn";
			this.NewBtn.Size = new System.Drawing.Size(75, 23);
			this.NewBtn.TabIndex = 5;
			this.NewBtn.Text = "New Hero";
			this.NewBtn.UseVisualStyleBackColor = true;
			this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
			// 
			// StepBtn
			// 
			this.StepBtn.Location = new System.Drawing.Point(14, 133);
			this.StepBtn.Name = "StepBtn";
			this.StepBtn.Size = new System.Drawing.Size(75, 23);
			this.StepBtn.TabIndex = 4;
			this.StepBtn.Text = "Step";
			this.StepBtn.UseVisualStyleBackColor = true;
			this.StepBtn.Click += new System.EventHandler(this.StepBtn_Click);
			// 
			// LeftBtn
			// 
			this.LeftBtn.Location = new System.Drawing.Point(14, 103);
			this.LeftBtn.Name = "LeftBtn";
			this.LeftBtn.Size = new System.Drawing.Size(75, 23);
			this.LeftBtn.TabIndex = 3;
			this.LeftBtn.Text = "Left";
			this.LeftBtn.UseVisualStyleBackColor = true;
			this.LeftBtn.Click += new System.EventHandler(this.LeftBtn_Click);
			// 
			// DownBtn
			// 
			this.DownBtn.Location = new System.Drawing.Point(14, 73);
			this.DownBtn.Name = "DownBtn";
			this.DownBtn.Size = new System.Drawing.Size(75, 23);
			this.DownBtn.TabIndex = 2;
			this.DownBtn.Text = "Down";
			this.DownBtn.UseVisualStyleBackColor = true;
			this.DownBtn.Click += new System.EventHandler(this.DownBtn_Click);
			// 
			// RightBtn
			// 
			this.RightBtn.Location = new System.Drawing.Point(14, 43);
			this.RightBtn.Name = "RightBtn";
			this.RightBtn.Size = new System.Drawing.Size(75, 23);
			this.RightBtn.TabIndex = 1;
			this.RightBtn.Text = "Right";
			this.RightBtn.UseVisualStyleBackColor = true;
			this.RightBtn.Click += new System.EventHandler(this.RightBtn_Click);
			// 
			// UpBtn
			// 
			this.UpBtn.Location = new System.Drawing.Point(14, 14);
			this.UpBtn.Name = "UpBtn";
			this.UpBtn.Size = new System.Drawing.Size(75, 23);
			this.UpBtn.TabIndex = 0;
			this.UpBtn.Text = "Up";
			this.UpBtn.UseVisualStyleBackColor = true;
			this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
			// 
			// Algorithm
			// 
			this.Algorithm.FormattingEnabled = true;
			this.Algorithm.Location = new System.Drawing.Point(837, 13);
			this.Algorithm.Name = "Algorithm";
			this.Algorithm.Size = new System.Drawing.Size(183, 498);
			this.Algorithm.TabIndex = 2;
			// 
			// timerAlgorithm
			// 
			this.timerAlgorithm.Tick += new System.EventHandler(this.timerAlgorithm_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1034, 521);
			this.Controls.Add(this.Algorithm);
			this.Controls.Add(this.Group);
			this.Controls.Add(this.Field);
			this.MaximumSize = new System.Drawing.Size(1050, 560);
			this.MinimumSize = new System.Drawing.Size(1050, 560);
			this.Name = "Form1";
			this.Text = "Робот-Таракан";
			this.Group.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel Field;
		private System.Windows.Forms.Panel Group;
		private System.Windows.Forms.Button ClearBtn;
		private System.Windows.Forms.Button RunBtn;
		private System.Windows.Forms.Button NewBtn;
		private System.Windows.Forms.Button StepBtn;
		private System.Windows.Forms.Button LeftBtn;
		private System.Windows.Forms.Button DownBtn;
		private System.Windows.Forms.Button RightBtn;
		private System.Windows.Forms.Button UpBtn;
		private System.Windows.Forms.ListBox Algorithm;
		private System.Windows.Forms.Timer timerAlgorithm;
		private System.Windows.Forms.Button DeleteBtn;
	}
}

