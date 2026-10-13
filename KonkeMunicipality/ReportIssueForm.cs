using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KonkeMunicipality.Models;
using KonkeMunicipality.Services;

namespace KonkeMunicipality
{
    public partial class ReportIssueForm : Form
    {
        private readonly IssueService issueService;
        private string selectedAttachmentPath = string.Empty;
        public ReportIssueForm()
        {
            InitializeComponent();
            issueService = new IssueService();
            LoadCategories();
            ApplyProfessionalDesign();

        }


        private void ApplyProfessionalDesign()
        {
            Color navy = Color.FromArgb(20, 43, 74);
            Color blue = Color.FromArgb(37, 86, 166);
            Color pageBackground = Color.FromArgb(243, 246, 250);
            Color mutedText = Color.FromArgb(91, 105, 123);

            // Main window
            Text = "Konke Local Municipality | Report an Issue";
            BackColor = pageBackground;
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(884, 650);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            // Navy header
            Panel header = new Panel
            {
                BackColor = navy,
                Location = new Point(0, 0),
                Size = new Size(884, 112)
            };
            Controls.Add(header);
            header.SendToBack();

            // Heading
            lblTitle.AutoSize = false;
            lblTitle.Text = "Report a Municipal Issue";
            lblTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(20, 12);
            lblTitle.Size = new Size(844, 48);
            lblTitle.BackColor = Color.Transparent;
            header.Controls.Add(lblTitle);

            // Instruction beneath the heading
            lblInstruction.AutoSize = false;
            lblInstruction.Text =
                "Provide the details below so the municipality can assist you.";
            lblInstruction.Font = new Font("Segoe UI", 10F);
            lblInstruction.ForeColor = Color.FromArgb(220, 229, 240);
            lblInstruction.TextAlign = ContentAlignment.MiddleCenter;
            lblInstruction.Location = new Point(20, 62);
            lblInstruction.Size = new Size(844, 28);
            lblInstruction.BackColor = Color.Transparent;
            header.Controls.Add(lblInstruction);

            // Field labels
            Label[] fieldLabels =
            {
        lblLocation,
        lblCategory,
        lblDescription,
        lblAttachment
    };

            foreach (Label label in fieldLabels)
            {
                label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                label.ForeColor = navy;
            }

            // Input controls
            txtLocation.Font = new Font("Segoe UI", 10F);
            txtLocation.BackColor = Color.White;
            txtLocation.BorderStyle = BorderStyle.FixedSingle;
            txtLocation.Location = new Point(171, 145);
            txtLocation.Size = new Size(600, 28);

            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.BackColor = Color.White;
            cmbCategory.Location = new Point(171, 201);
            cmbCategory.Size = new Size(300, 28);

            rtbDescription.Font = new Font("Segoe UI", 10F);
            rtbDescription.BackColor = Color.White;
            rtbDescription.BorderStyle = BorderStyle.FixedSingle;
            rtbDescription.Location = new Point(171, 257);
            rtbDescription.Size = new Size(600, 120);

            // Field positions
            lblLocation.Location = new Point(52, 149);
            lblCategory.Location = new Point(52, 205);
            lblDescription.Location = new Point(52, 261);
            lblAttachment.Location = new Point(52, 416);

            // Character counter
            lblDescriptionCount.Font = new Font("Segoe UI", 8.5F);
            lblDescriptionCount.ForeColor = mutedText;
            lblDescriptionCount.Location = new Point(600, 382);
            lblDescriptionCount.Size = new Size(171, 20);
            lblDescriptionCount.TextAlign = ContentAlignment.MiddleRight;

            // Attachment controls
            btnAttach.Location = new Point(224, 411);
            btnAttach.Size = new Size(130, 34);
            btnAttach.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAttach.BackColor = Color.White;
            btnAttach.ForeColor = navy;
            btnAttach.FlatStyle = FlatStyle.Flat;
            btnAttach.FlatAppearance.BorderColor =
                Color.FromArgb(190, 201, 216);
            btnAttach.Cursor = Cursors.Hand;
            btnAttach.UseVisualStyleBackColor = false;

            lblAttachmentPath.Location = new Point(224, 451);
            lblAttachmentPath.Size = new Size(547, 24);
            lblAttachmentPath.AutoSize = false;
            lblAttachmentPath.Font = new Font("Segoe UI", 9F);
            lblAttachmentPath.ForeColor = mutedText;
            lblAttachmentPath.AutoEllipsis = true;

            // Progress section
            lblProgress.Location = new Point(52, 493);
            lblProgress.Size = new Size(140, 24);
            lblProgress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProgress.ForeColor = navy;
            lblProgress.TextAlign = ContentAlignment.MiddleLeft;

            progressReport.Location = new Point(200, 496);
            progressReport.Size = new Size(571, 20);
            progressReport.Style = ProgressBarStyle.Continuous;

            lblEngagement.AutoSize = false;
            lblEngagement.Location = new Point(52, 527);
            lblEngagement.Size = new Size(719, 24);
            lblEngagement.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblEngagement.ForeColor = mutedText;
            lblEngagement.TextAlign = ContentAlignment.MiddleCenter;

            // Submit button
            btnSubmit.Location = new Point(171, 566);
            btnSubmit.Size = new Size(200, 44);
            btnSubmit.Text = "Submit Issue";
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.BackColor = blue;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.UseVisualStyleBackColor = false;

            // Back button
            btnBack.Location = new Point(471, 566);
            btnBack.Size = new Size(200, 44);
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.BackColor = Color.White;
            btnBack.ForeColor = navy;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderColor =
                Color.FromArgb(190, 201, 216);
            btnBack.FlatAppearance.BorderSize = 1;
            btnBack.Cursor = Cursors.Hand;
            btnBack.UseVisualStyleBackColor = false;

            // Keep the existing input controls above the header background.
            lblTitle.BringToFront();
            lblInstruction.BringToFront();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Add("Roads and Potholes");
            cmbCategory.Items.Add("Water and Sanitation");
            cmbCategory.Items.Add("Electricity");
            cmbCategory.Items.Add("Waste Management");
            cmbCategory.Items.Add("Street Lights");
            cmbCategory.Items.Add("Public Safety");
            cmbCategory.Items.Add("Other");

            cmbCategory.SelectedIndex = -1;

        }
        private void UpdateProgress()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                progress += 30;
            }

            if (cmbCategory.SelectedIndex >= 0)
            {
                progress += 30;
            }

            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                progress += 40;
            }

            progressReport.Value = progress;

            lblProgress.Text =
                "Report Progress: " +
                progress +
                "%";

            if (progress == 0)
            {
                lblEngagement.Text =
                    "Let's get your issue reported!";
            }
            else if (progress == 30)
            {
                lblEngagement.Text =
                    "Good start! Keep going.";
            }
            else if (progress == 60)
            {
                lblEngagement.Text =
                    "Great! You're making good progress.";
            }
            else if (progress == 100)
            {
                lblEngagement.Text =
                    "Excellent! Your report is ready to submit.";
            }
        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image or Document";

                openFileDialog.Filter =
                    "Images and Documents|*.jpg;*.jpeg;*.png;*.gif;*.pdf;*.doc;*.docx|" +
                    "Images|*.jpg;*.jpeg;*.png;*.gif|" +
                    "Documents|*.pdf;*.doc;*.docx|" +
                    "All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedAttachmentPath = openFileDialog.FileName;

                    lblAttachmentPath.Text = "Selected: " + System.IO.Path.GetFileName(openFileDialog.FileName);

                    UpdateProgress();
                }
            }
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            int characterCount = rtbDescription.Text.Length;

            lblDescriptionCount.Text =
                "Characters: " +
                characterCount +
                " / 1000";

            UpdateProgress();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the reported issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLocation.Focus();
                return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select an issue category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a description of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                rtbDescription.Focus();
                return;
            }

            if (rtbDescription.Text.Trim().Length < 10)
            {
                MessageBox.Show(
                    "Please provide a more detailed description of the issue.",
                    "Description Too Short",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                rtbDescription.Focus();
                return;
            }

            string issueId = issueService.GenerateIssueId();

            string savedAttachmentPath =
                issueService.SaveAttachment(
                    selectedAttachmentPath,
                    issueId);

            Issue newIssue = new Issue
            {
                IssueId = issueId,
                Location = txtLocation.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString(),
                Description = rtbDescription.Text.Trim(),
                AttachmentPath = savedAttachmentPath,
                DateReported = DateTime.Now,
                Status = "Submitted"
            };

            issueService.SaveIssue(newIssue);

            MessageBox.Show(
                "Your issue has been successfully submitted.\n\n" +
                "Reference Number: " + newIssue.IssueId,
                "Issue Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearForm();
        }

        private void ClearForm()
        {
            txtLocation.Clear();

            cmbCategory.SelectedIndex = -1;

            rtbDescription.Clear();

            selectedAttachmentPath = string.Empty;

            lblAttachmentPath.Text = "No file selected";

            progressReport.Value = 0;

            lblProgress.Text = "Report Progress: 0%";

            lblEngagement.Text = "Let's get your issue reported!";

            txtLocation.Focus();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
