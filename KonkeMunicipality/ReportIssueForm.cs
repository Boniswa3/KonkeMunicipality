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
