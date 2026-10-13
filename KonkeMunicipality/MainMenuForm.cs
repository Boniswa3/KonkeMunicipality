
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KonkeMunicipality
{
    public partial class MainMenuForm : Form
    {
        private readonly Color navy = Color.FromArgb(20, 43, 74);
        private readonly Color blue = Color.FromArgb(37, 86, 166);
        private readonly Color background = Color.FromArgb(243, 246, 250);
        private readonly Color mutedText = Color.FromArgb(91, 105, 123);

        public MainMenuForm()
        {
            InitializeComponent();
            ApplyProfessionalDesign();
        }

        private void ApplyProfessionalDesign()
        {
            // Main window
            Text = "Konke Local Municipality | Citizen Portal";
            Size = new Size(1000, 720);
            MinimumSize = new Size(1000, 720);
            MaximumSize = new Size(1000, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = background;
            Font = new Font("Segoe UI", 10F);

            // Header panel
            Panel header = new Panel();
            header.BackColor = navy;
            header.Location = new Point(0, 0);
            header.Size = new Size(984, 190);
            Controls.Add(header);

            // Move the existing labels into the header.
            Controls.Remove(lblTitle);
            Controls.Remove(lblSubtitle);
            Controls.Remove(lblInstruction);

            lblTitle.AutoSize = false;
            lblTitle.Text = "Konke Local Municipality";
            lblTitle.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(20, 25);
            lblTitle.Size = new Size(944, 48);
            header.Controls.Add(lblTitle);

            lblSubtitle.AutoSize = false;
            lblSubtitle.Text = "MUNICIPAL SERVICES PORTAL";
            lblSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblSubtitle.ForeColor = Color.FromArgb(211, 222, 237);
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtitle.Location = new Point(20, 78);
            lblSubtitle.Size = new Size(944, 30);
            header.Controls.Add(lblSubtitle);

            lblInstruction.AutoSize = false;
            lblInstruction.Text =
                "Welcome. Select a service below to get started.";
            lblInstruction.Font = new Font("Segoe UI", 10F);
            lblInstruction.ForeColor = Color.WhiteSmoke;
            lblInstruction.TextAlign = ContentAlignment.MiddleCenter;
            lblInstruction.Location = new Point(20, 125);
            lblInstruction.Size = new Size(944, 25);
            header.Controls.Add(lblInstruction);

            // Service card panels
            Panel reportCard = CreateServiceCard(
                new Point(35, 235));

            Panel eventsCard = CreateServiceCard(
                new Point(357, 235));

            Panel statusCard = CreateServiceCard(
                new Point(679, 235));

            Controls.Add(reportCard);
            Controls.Add(eventsCard);
            Controls.Add(statusCard);

            // Add descriptions to the cards.
            AddCardDescription(
                reportCard,
                "Report Issues",
                "Report problems involving roads, water, electricity and other municipal services.");

            AddCardDescription(
                eventsCard,
                "Events & Announcements",
                "Stay informed about community events, public notices and municipal updates.");

            AddCardDescription(
                statusCard,
                "Service Request Status",
                "View the status of a service request you have submitted.");

            // Reuse the existing buttons and preserve their click handlers.
            MoveButtonToCard(
                btnReportIssues, reportCard, "Open Service");

            MoveButtonToCard(
                btnEventsAnnouncements, eventsCard, "View Events");

            MoveButtonToCard(
                btnServiceStatus, statusCard, "Check Status");

            // Style the existing Exit button.
            btnExit.Location = new Point(415, 585);
            btnExit.Size = new Size(150, 42);
            btnExit.Text = "Exit Portal";
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExit.BackColor = Color.White;
            btnExit.ForeColor = navy;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderColor =
                Color.FromArgb(190, 201, 216);
            btnExit.FlatAppearance.BorderSize = 1;
            btnExit.Cursor = Cursors.Hand;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.BringToFront();
        }

        private Panel CreateServiceCard(Point location)
        {
            Panel card = new Panel();
            card.Location = location;
            card.Size = new Size(270, 285);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            return card;
        }

        private void AddCardDescription(
            Panel card, string heading, string description)
        {
            Label title = new Label();
            title.Text = heading;
            title.Location = new Point(15, 20);
            title.Size = new Size(238, 45);
            title.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            title.ForeColor = navy;
            title.TextAlign = ContentAlignment.MiddleCenter;
            card.Controls.Add(title);

            Label detail = new Label();
            detail.Text = description;
            detail.Location = new Point(20, 78);
            detail.Size = new Size(228, 90);
            detail.Font = new Font("Segoe UI", 9.5F);
            detail.ForeColor = mutedText;
            detail.TextAlign = ContentAlignment.TopCenter;
            card.Controls.Add(detail);
        }

        private void MoveButtonToCard(
            Button button, Panel card, string buttonText)
        {
            // Removing and reparenting the existing button does not
            // remove its Click event handler.
            Controls.Remove(button);

            button.Text = buttonText;
            button.Location = new Point(15, 205);
            button.Size = new Size(238, 48);
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.BackColor = blue;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;

            card.Controls.Add(button);
            button.BringToFront();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssueForm reportForm = new ReportIssueForm();
            reportForm.ShowDialog();
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            ServiceRequestStatusForm statusForm =
                new ServiceRequestStatusForm();

            statusForm.ShowDialog();
        }

        private void btnEventsAnnouncements_Click(object sender, EventArgs e)
        {
            using (LocalEventsForm eventsForm = new LocalEventsForm())
            {
                eventsForm.ShowDialog(this);
            }
        }
    }
}

