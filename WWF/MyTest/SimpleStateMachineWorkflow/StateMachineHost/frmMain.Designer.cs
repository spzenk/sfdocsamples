﻿using System.Windows.Forms;
namespace StateMachineHost
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.itemsList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.itemQuantity = new System.Windows.Forms.NumericUpDown();
            this.submitButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.orderStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ordersIdList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemQuantity)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item";
            // 
            // itemsList
            // 
            this.itemsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemsList.FormattingEnabled = true;
            this.itemsList.Items.AddRange(new object[] {
            "Apple",
            "Orange",
            "Banana",
            "Pear",
            "Watermelon",
            "Grapes"});
            this.itemsList.Location = new System.Drawing.Point(13, 26);
            this.itemsList.Name = "itemsList";
            this.itemsList.Size = new System.Drawing.Size(161, 21);
            this.itemsList.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantity";
            // 
            // itemQuantity
            // 
            this.itemQuantity.Location = new System.Drawing.Point(13, 67);
            this.itemQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemQuantity.Name = "itemQuantity";
            this.itemQuantity.Size = new System.Drawing.Size(80, 20);
            this.itemQuantity.TabIndex = 1;
            this.itemQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(99, 64);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 23);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit Order";
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.orderStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ordersIdList);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(13, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 193);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Status";
            // 
            // orderStatus
            // 
            this.orderStatus.Location = new System.Drawing.Point(7, 82);
            this.orderStatus.Multiline = true;
            this.orderStatus.Name = "orderStatus";
            this.orderStatus.ReadOnly = true;
            this.orderStatus.Size = new System.Drawing.Size(230, 105);
            this.orderStatus.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "History";
            // 
            // ordersIdList
            // 
            this.ordersIdList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ordersIdList.FormattingEnabled = true;
            this.ordersIdList.Location = new System.Drawing.Point(7, 37);
            this.ordersIdList.Name = "ordersIdList";
            this.ordersIdList.Size = new System.Drawing.Size(230, 21);
            this.ordersIdList.TabIndex = 0;
            this.ordersIdList.SelectedIndexChanged += new System.EventHandler(this.ordersIdList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Order Id";
            // 
            // frmMain
            // 
            this.AcceptButton = this.submitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 298);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.itemQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemsList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Simple Order Form";
            ((System.ComponentModel.ISupportInitialize)(this.itemQuantity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox itemsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown itemQuantity;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ordersIdList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox orderStatus;
        private System.Windows.Forms.Label label4;

    }
}

