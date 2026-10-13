using KonkeMunicipality.Models;
using KonkeMunicipality.Services;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KonkeMunicipality
{
    public partial class ServiceRequestStatusForm : Form
    {
        private readonly IssueService issueService;
        public ServiceRequestStatusForm()
        {
            InitializeComponent();
            issueService = new IssueService();
            ApplyProfessionalDesign();

        }



        private void ApplyProfessionalDesign()
        {
            Color navy = Color.FromArgb(20, 43, 74);
            Color blue = Color.FromArgb(37, 86, 166);
            Color pageBackground = Color.FromArgb(243, 246, 250);
            Color mutedText = Color.FromArgb(91, 105, 123);

            Text = "Konke Local Municipality | Service Request Status";
            BackColor = pageBackground;
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(850, 620);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            // Header panel
            Panel header = new Panel
            {
                BackColor = navy,
                Location = new Point(0, 0),
                Size = new Size(850, 112)
            };
            Controls.Add(header);
            header.SendToBack();

            // Title
            Controls.Remove(lblTitle);
            lblTitle.AutoSize = false;
            lblTitle.Text = "Service Request Status";
            lblTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(20, 12);
            lblTitle.Size = new Size(810, 48);
            lblTitle.BackColor = Color.Transparent;
            header.Controls.Add(lblTitle);

            // Subtitle
            Controls.Remove(lblInstruction);
            lblInstruction.AutoSize = false;
            lblInstruction.Text =
                "Enter your reference number to check your reported issue.";
            lblInstruction.Font = new Font("Segoe UI", 10F);
            lblInstruction.ForeColor = Color.FromArgb(220, 229, 240);
            lblInstruction.TextAlign = ContentAlignment.MiddleCenter;
            lblInstruction.Location = new Point(20, 62);
            lblInstruction.Size = new Size(810, 28);
            lblInstruction.BackColor = Color.Transparent;
            header.Controls.Add(lblInstruction);

            // Reference number section
            lblReference.Text = "Reference Number";
            lblReference.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReference.ForeColor = navy;
            lblReference.Location = new Point(45, 145);
            lblReference.AutoSize = true;

            txtReference.Font = new Font("Segoe UI", 11F);
            txtReference.Location = new Point(45, 174);
            txtReference.Size = new Size(490, 32);
            txtReference.BorderStyle = BorderStyle.FixedSingle;

            btnCheckStatus.Text = "Check Status";
            btnCheckStatus.Location = new Point(555, 171);
            btnCheckStatus.Size = new Size(245, 38);
            btnCheckStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckStatus.BackColor = blue;
            btnCheckStatus.ForeColor = Color.White;
            btnCheckStatus.FlatStyle = FlatStyle.Flat;
            btnCheckStatus.FlatAppearance.BorderSize = 0;
            btnCheckStatus.Cursor = Cursors.Hand;
            btnCheckStatus.UseVisualStyleBackColor = false;

            // Request details panel
            Panel resultsPanel = new Panel
            {
                BackColor = Color.White,
                Location = new Point(35, 230),
                Size = new Size(780, 290),
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(resultsPanel);

            Controls.Remove(lblDetailsHeading);
            lblDetailsHeading.AutoSize = false;
            lblDetailsHeading.Text = "Request Details";
            lblDetailsHeading.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDetailsHeading.ForeColor = navy;
            lblDetailsHeading.Location = new Point(20, 12);
            lblDetailsHeading.Size = new Size(730, 30);
            resultsPanel.Controls.Add(lblDetailsHeading);

            Label[] resultLabels =
            {
        lblResultReference,
        lblResultLocation,
        lblResultCategory,
        lblResultDescription,
        lblResultDate,
        lblResultStatus
    };

            int[] resultYPositions = { 52, 87, 122, 157, 207, 247 };

            for (int i = 0; i < resultLabels.Length; i++)
            {
                Controls.Remove(resultLabels[i]);

                resultLabels[i].AutoSize = false;
                resultLabels[i].Font = new Font("Segoe UI", 10F);
                resultLabels[i].ForeColor = navy;
                resultLabels[i].Location =
                    new Point(20, resultYPositions[i]);
                resultLabels[i].Size = new Size(730, 30);
                resultLabels[i].TextAlign = ContentAlignment.MiddleLeft;

                resultsPanel.Controls.Add(resultLabels[i]);
            }

            lblResultDescription.Size = new Size(730, 45);
            lblResultDescription.AutoEllipsis = true;

            lblResultStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResultStatus.ForeColor = blue;

            // Guidance text
            Label lblHelp = new Label
            {
                Text = "Tip: Use the reference number provided when you submitted your issue.",
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = mutedText,
                Location = new Point(35, 530),
                Size = new Size(780, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(lblHelp);

            // Back button
            btnBack.Text = "Back to Main Menu";
            btnBack.Location = new Point(325, 568);
            btnBack.Size = new Size(200, 40);
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.BackColor = Color.White;
            btnBack.ForeColor = navy;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderColor =
                Color.FromArgb(190, 201, 216);
            btnBack.Cursor = Cursors.Hand;
            btnBack.UseVisualStyleBackColor = false;
        }



        private void ServiceRequestStatusForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            string referenceNumber = txtReference.Text.Trim();

            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                MessageBox.Show(
                    "Please enter your reference number.",
                    "Reference Number Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtReference.Focus();
                return;
            }

            Issue issue = issueService
                .GetIssues()
                .FirstOrDefault(i =>
                    i.IssueId.Equals(
                        referenceNumber,
                        StringComparison.OrdinalIgnoreCase));

            if (issue == null)
            {
                MessageBox.Show(
                    "No service request was found with reference number: "
                    + referenceNumber,
                    "Request Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearResults();
                return;
            }

            lblResultReference.Text =
                "Reference: " + issue.IssueId;

            lblResultLocation.Text =
                "Location: " + issue.Location;

            lblResultCategory.Text =
                "Category: " + issue.Category;

            lblResultDescription.Text =
                "Description: " + issue.Description;

            lblResultDate.Text =
                "Date Reported: " +
                issue.DateReported.ToString("dd/MM/yyyy HH:mm");

            lblResultStatus.Text =
                "Status: " + issue.Status;
        }

        private void ClearResults()
        {
            lblResultReference.Text = "Reference: -";
            lblResultLocation.Text = "Location: -";
            lblResultCategory.Text = "Category: -";
            lblResultDescription.Text = "Description: -";
            lblResultDate.Text = "Date Reported: -";
            lblResultStatus.Text = "Status: -";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
