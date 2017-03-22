using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
	public class Form1 : Form
	{
		private IContainer components = null;

		private Label labelTitle;

		private bool startGame = false;

		private gameActions game = new gameActions();

		private int win = 0;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.labelTitle = new Label();
			base.SuspendLayout();
			this.labelTitle.AutoSize = true;
			this.labelTitle.ForeColor = Color.White;
			this.labelTitle.Location = new Point(0, -1);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new Size(74, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "GameWindow";
			this.labelTitle.Click += new EventHandler(this.labelTitle_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.Black;
			base.ClientSize = new Size(492, 470);
			base.Controls.Add(this.labelTitle);
			base.Name = "Form1";
			this.Text = "Game";
			base.Load += new EventHandler(this.Form1_Load);
			base.Resize += new EventHandler(this.Form1_reSize);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		protected override bool IsInputKey(Keys keyData)
		{
			return true;
		}

		public Form1()
		{
			this.InitializeComponent();
			this.game.showForm(this, base.Size);
		}

		public void GameLoop()
		{
			this.game.createBox();
			this.game.InitializeGraphics(this);
			while (base.Created)
			{
				this.GameLogic();
				this.game.Render();
				Application.DoEvents();
				Application.AddMessageFilter(this.game);
			}
		}

		private void GameLogic()
		{
			this.game.moveBox();
			this.labelTitle.Text = this.game.calculateScore();
		}

		private void Form1_reSize(object sender, EventArgs e)
		{
			this.game.showForm(this, base.Size);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void labelTitle_Click(object sender, EventArgs e)
		{
		}
	}
}
