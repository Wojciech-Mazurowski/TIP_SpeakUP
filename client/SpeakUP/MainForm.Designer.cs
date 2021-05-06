﻿
namespace SpeakUP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ChannelBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.RefButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.UsersBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ChannelBox
            // 
            this.ChannelBox.FormattingEnabled = true;
            this.ChannelBox.ItemHeight = 16;
            this.ChannelBox.Location = new System.Drawing.Point(12, 81);
            this.ChannelBox.Name = "ChannelBox";
            this.ChannelBox.Size = new System.Drawing.Size(172, 340);
            this.ChannelBox.TabIndex = 0;
            this.ChannelBox.Click += new System.EventHandler(this.ChannelBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(26, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Channel List:";
            // 
            // ChangeButton
            // 
            this.ChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChangeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ChangeButton.Location = new System.Drawing.Point(527, 305);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(119, 55);
            this.ChangeButton.TabIndex = 5;
            this.ChangeButton.Text = "Change Password";
            this.ChangeButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(523, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Logged In as:";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UserLabel.Location = new System.Drawing.Point(549, 118);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(77, 18);
            this.UserLabel.TabIndex = 7;
            this.UserLabel.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(201, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Active Users:";
            // 
            // LogOutButton
            // 
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LogOutButton.Location = new System.Drawing.Point(527, 366);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(119, 55);
            this.LogOutButton.TabIndex = 9;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = true;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // RefButton
            // 
            this.RefButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RefButton.BackgroundImage")));
            this.RefButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RefButton.Location = new System.Drawing.Point(12, 12);
            this.RefButton.Name = "RefButton";
            this.RefButton.Size = new System.Drawing.Size(40, 38);
            this.RefButton.TabIndex = 10;
            this.RefButton.UseVisualStyleBackColor = true;
            this.RefButton.Click += new System.EventHandler(this.RefButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddButton.Location = new System.Drawing.Point(527, 244);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(119, 55);
            this.AddButton.TabIndex = 11;
            this.AddButton.Text = "Add channel";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UsersBox
            // 
            this.UsersBox.FormattingEnabled = true;
            this.UsersBox.ItemHeight = 16;
            this.UsersBox.Location = new System.Drawing.Point(206, 81);
            this.UsersBox.Name = "UsersBox";
            this.UsersBox.Size = new System.Drawing.Size(297, 340);
            this.UsersBox.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(664, 450);
            this.Controls.Add(this.UsersBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RefButton);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChannelBox);
            this.Name = "MainForm";
            this.Text = "SpeakUP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ChannelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button RefButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox UsersBox;
    }
}