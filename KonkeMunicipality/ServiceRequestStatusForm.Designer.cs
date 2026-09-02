namespace KonkeMunicipality
{
    partial class ServiceRequestStatusForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.btnCheckStatus = new System.Windows.Forms.Button();
            this.lblDetailsHeading = new System.Windows.Forms.Label();
            this.lblResultReference = new System.Windows.Forms.Label();
            this.lblResultLocation = new System.Windows.Forms.Label();
            this.lblResultCategory = new System.Windows.Forms.Label();
            this.lblResultDescription = new System.Windows.Forms.Label();
            this.lblResultDate = new System.Windows.Forms.Label();
            this.lblResultStatus = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(261, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(321, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Service Request Status";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(121, 64);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(613, 24);
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "Enter your reference number to check the status of your service request.";
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(57, 117);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(100, 13);
            this.lblReference.TabIndex = 2;
            this.lblReference.Text = "Reference Number:";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(214, 110);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(300, 20);
            this.txtReference.TabIndex = 3;
            this.txtReference.Text = "KLM-0001";
            // 
            // btnCheckStatus
            // 
            this.btnCheckStatus.Location = new System.Drawing.Point(288, 156);
            this.btnCheckStatus.Name = "btnCheckStatus";
            this.btnCheckStatus.Size = new System.Drawing.Size(130, 40);
            this.btnCheckStatus.TabIndex = 4;
            this.btnCheckStatus.Text = "Check Status";
            this.btnCheckStatus.UseVisualStyleBackColor = true;
            this.btnCheckStatus.Click += new System.EventHandler(this.btnCheckStatus_Click);
            // 
            // lblDetailsHeading
            // 
            this.lblDetailsHeading.AutoSize = true;
            this.lblDetailsHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailsHeading.Location = new System.Drawing.Point(273, 214);
            this.lblDetailsHeading.Name = "lblDetailsHeading";
            this.lblDetailsHeading.Size = new System.Drawing.Size(155, 24);
            this.lblDetailsHeading.TabIndex = 5;
            this.lblDetailsHeading.Text = "Request Details";
            // 
            // lblResultReference
            // 
            this.lblResultReference.AutoSize = true;
            this.lblResultReference.Location = new System.Drawing.Point(57, 253);
            this.lblResultReference.Name = "lblResultReference";
            this.lblResultReference.Size = new System.Drawing.Size(60, 13);
            this.lblResultReference.TabIndex = 6;
            this.lblResultReference.Text = "Reference:";
            // 
            // lblResultLocation
            // 
            this.lblResultLocation.AutoSize = true;
            this.lblResultLocation.Location = new System.Drawing.Point(58, 277);
            this.lblResultLocation.Name = "lblResultLocation";
            this.lblResultLocation.Size = new System.Drawing.Size(51, 13);
            this.lblResultLocation.TabIndex = 7;
            this.lblResultLocation.Text = "Location:";
            // 
            // lblResultCategory
            // 
            this.lblResultCategory.AutoSize = true;
            this.lblResultCategory.Location = new System.Drawing.Point(57, 300);
            this.lblResultCategory.Name = "lblResultCategory";
            this.lblResultCategory.Size = new System.Drawing.Size(52, 13);
            this.lblResultCategory.TabIndex = 8;
            this.lblResultCategory.Text = "Category:";
            // 
            // lblResultDescription
            // 
            this.lblResultDescription.AutoSize = true;
            this.lblResultDescription.Location = new System.Drawing.Point(58, 322);
            this.lblResultDescription.Name = "lblResultDescription";
            this.lblResultDescription.Size = new System.Drawing.Size(63, 13);
            this.lblResultDescription.TabIndex = 9;
            this.lblResultDescription.Text = "Description:";
            // 
            // lblResultDate
            // 
            this.lblResultDate.AutoSize = true;
            this.lblResultDate.Location = new System.Drawing.Point(58, 344);
            this.lblResultDate.Name = "lblResultDate";
            this.lblResultDate.Size = new System.Drawing.Size(80, 13);
            this.lblResultDate.TabIndex = 10;
            this.lblResultDate.Text = "Date Reported:";
            // 
            // lblResultStatus
            // 
            this.lblResultStatus.AutoSize = true;
            this.lblResultStatus.Location = new System.Drawing.Point(60, 366);
            this.lblResultStatus.Name = "lblResultStatus";
            this.lblResultStatus.Size = new System.Drawing.Size(40, 13);
            this.lblResultStatus.TabIndex = 11;
            this.lblResultStatus.Text = "Status:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(528, 387);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(166, 27);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ServiceRequestStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblResultStatus);
            this.Controls.Add(this.lblResultDate);
            this.Controls.Add(this.lblResultDescription);
            this.Controls.Add(this.lblResultCategory);
            this.Controls.Add(this.lblResultLocation);
            this.Controls.Add(this.lblResultReference);
            this.Controls.Add(this.lblDetailsHeading);
            this.Controls.Add(this.btnCheckStatus);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblTitle);
            this.Name = "ServiceRequestStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Request Status - Konke Local Municipality";
            this.Load += new System.EventHandler(this.ServiceRequestStatusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Button btnCheckStatus;
        private System.Windows.Forms.Label lblDetailsHeading;
        private System.Windows.Forms.Label lblResultReference;
        private System.Windows.Forms.Label lblResultLocation;
        private System.Windows.Forms.Label lblResultCategory;
        private System.Windows.Forms.Label lblResultDescription;
        private System.Windows.Forms.Label lblResultDate;
        private System.Windows.Forms.Label lblResultStatus;
        private System.Windows.Forms.Button btnBack;
    }
}