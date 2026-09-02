using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Linq;
using System.Windows.Forms;
using KonkeMunicipality.Models;
using KonkeMunicipality.Services;

namespace KonkeMunicipality
{
    public partial class ServiceRequestStatusForm : Form
    {
        private readonly IssueService issueService;
        public ServiceRequestStatusForm()
        {

            InitializeComponent();
            issueService = new IssueService();

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
