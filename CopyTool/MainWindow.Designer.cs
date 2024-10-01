namespace CopyTool
{
	partial class MainWindow
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.CopyAll = new System.Windows.Forms.Label();
			this.CopyDll = new System.Windows.Forms.Label();
			this.DirInput = new System.Windows.Forms.TextBox();
			this.DirDesc = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// CopyAll
			// 
			this.CopyAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.CopyAll.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.CopyAll.Location = new System.Drawing.Point(4, 57);
			this.CopyAll.Name = "CopyAll";
			this.CopyAll.Size = new System.Drawing.Size(415, 117);
			this.CopyAll.TabIndex = 0;
			this.CopyAll.Text = "复制所有";
			this.CopyAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CopyAll.Click += new System.EventHandler(this.CopyAll_Click);
			// 
			// CopyDll
			// 
			this.CopyDll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.CopyDll.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.CopyDll.Location = new System.Drawing.Point(425, 57);
			this.CopyDll.Name = "CopyDll";
			this.CopyDll.Size = new System.Drawing.Size(386, 117);
			this.CopyDll.TabIndex = 1;
			this.CopyDll.Text = "复制DLL";
			this.CopyDll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CopyDll.Click += new System.EventHandler(this.CopyDll_Click);
			// 
			// DirInput
			// 
			this.DirInput.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.DirInput.Location = new System.Drawing.Point(104, 9);
			this.DirInput.Name = "DirInput";
			this.DirInput.Size = new System.Drawing.Size(707, 29);
			this.DirInput.TabIndex = 2;
			// 
			// DirDesc
			// 
			this.DirDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.DirDesc.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.DirDesc.Location = new System.Drawing.Point(3, 9);
			this.DirDesc.Name = "DirDesc";
			this.DirDesc.Size = new System.Drawing.Size(95, 29);
			this.DirDesc.TabIndex = 3;
			this.DirDesc.Text = "Rdr2路径";
			this.DirDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 183);
			this.Controls.Add(this.DirDesc);
			this.Controls.Add(this.DirInput);
			this.Controls.Add(this.CopyDll);
			this.Controls.Add(this.CopyAll);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "复制工具";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label CopyAll;
		private System.Windows.Forms.Label CopyDll;
		private System.Windows.Forms.TextBox DirInput;
		private System.Windows.Forms.Label DirDesc;
	}
}

