
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KonkeMunicipality.Models;
using KonkeMunicipality.Services;

namespace KonkeMunicipality
{
    public partial class LocalEventsForm : Form
    {
        private readonly MunicipalEventService eventService;
        private List<MunicipalEvent> allItems;

        private ComboBox cmbType;
        private TextBox txtSearch;
        private DataGridView dgvItems;
        private Label lblInformation;

        public LocalEventsForm()
        {
            InitializeComponent();

            eventService = new MunicipalEventService();

            BuildInterface();
            LoadItems();
        }

       


private void BuildInterface()
        {
            Color navy = Color.FromArgb(20, 43, 74);
            Color blue = Color.FromArgb(37, 86, 166);
            Color pageBackground = Color.FromArgb(243, 246, 250);
            Color mutedText = Color.FromArgb(91, 105, 123);

            Text = "Konke Local Municipality | Events and Announcements";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(900, 610);
            MinimumSize = new Size(820, 550);
            BackColor = pageBackground;
            Font = new Font("Segoe UI", 9.5F);

            // Header
            Panel header = new Panel
            {
                BackColor = navy,
                Location = new Point(0, 0),
                Size = new Size(900, 105),
                Anchor = AnchorStyles.Top | AnchorStyles.Left |
                         AnchorStyles.Right
            };
            Controls.Add(header);

            Label lblTitle = new Label
            {
                Text = "Local Events and Announcements",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 12),
                Size = new Size(860, 45),
                Anchor = AnchorStyles.Top | AnchorStyles.Left |
                         AnchorStyles.Right
            };
            header.Controls.Add(lblTitle);

            Label lblSubtitle = new Label
            {
                Text = "Stay informed about community events and municipal notices.",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(220, 229, 240),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 59),
                Size = new Size(860, 27),
                Anchor = AnchorStyles.Top | AnchorStyles.Left |
                         AnchorStyles.Right
            };
            header.Controls.Add(lblSubtitle);

            // Search and filter section
            Panel filterPanel = new Panel
            {
                BackColor = Color.White,
                Location = new Point(25, 125),
                Size = new Size(850, 75),
                Anchor = AnchorStyles.Top | AnchorStyles.Left |
                         AnchorStyles.Right
            };
            Controls.Add(filterPanel);

            Label lblType = new Label
            {
                Text = "Filter by type",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = navy,
                Location = new Point(18, 8),
                AutoSize = true
            };
            filterPanel.Controls.Add(lblType);

            cmbType = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(18, 32),
                Size = new Size(190, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            cmbType.Items.AddRange(new object[]
            {
        "All",
        "Events",
        "Announcements"
            });
            cmbType.SelectedIndex = 0;
            cmbType.SelectedIndexChanged += FilterItems;
            filterPanel.Controls.Add(cmbType);

            Label lblSearch = new Label
            {
                Text = "Search by title, location or keyword",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = navy,
                Location = new Point(235, 8),
                AutoSize = true
            };
            filterPanel.Controls.Add(lblSearch);

            txtSearch = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                Location = new Point(235, 32),
                Size = new Size(580, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Left |
                         AnchorStyles.Right
            };
            txtSearch.TextChanged += FilterItems;
            filterPanel.Controls.Add(txtSearch);

            // Events and announcements table
            dgvItems = new DataGridView
            {
                Location = new Point(25, 215),
                Size = new Size(850, 310),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                         AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(225, 231, 239),
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 42,
                RowTemplate = { Height = 38 }
            };

            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvItems.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvItems.ColumnHeadersDefaultCellStyle.SelectionBackColor = navy;
            dgvItems.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dgvItems.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvItems.DefaultCellStyle.ForeColor = navy;
            dgvItems.DefaultCellStyle.BackColor = Color.White;
            dgvItems.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 232, 250);
            dgvItems.DefaultCellStyle.SelectionForeColor = navy;
            dgvItems.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(247, 249, 252);

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Reference",
                DataPropertyName = "EventId",
                FillWeight = 75
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Type",
                DataPropertyName = "Type",
                FillWeight = 85
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Title",
                DataPropertyName = "Title",
                FillWeight = 140
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Date",
                DataPropertyName = "EventDate",
                FillWeight = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd MMM yyyy"
                }
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Location",
                DataPropertyName = "Location",
                FillWeight = 120
            });

            dgvItems.CellDoubleClick += DgvItems_CellDoubleClick;
            Controls.Add(dgvItems);

            // Information footer
            lblInformation = new Label
            {
                Text = "Double-click an item to view its details.",
                Location = new Point(28, 540),
                Size = new Size(590, 25),
                Font = new Font("Segoe UI", 9F),
                ForeColor = mutedText,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            Controls.Add(lblInformation);

            Button btnBack = new Button
            {
                Text = "Back to Main Menu",
                Size = new Size(190, 40),
                Location = new Point(685, 535),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                BackColor = blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                UseVisualStyleBackColor = false
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += BtnBack_Click;
            Controls.Add(btnBack);
        }

        

        private void LoadItems()
        {
            allItems = eventService.GetAllItems();
            FilterItems(this, EventArgs.Empty);
        }

        private void FilterItems(object sender, EventArgs e)
        {
            if (allItems == null)
            {
                return;
            }

            string selectedType =
                cmbType.SelectedItem == null
                    ? "All"
                    : cmbType.SelectedItem.ToString();

            string searchText =
                txtSearch == null
                    ? string.Empty
                    : txtSearch.Text.Trim();

            IEnumerable<MunicipalEvent> filtered =
                allItems;

            if (selectedType == "Events")
            {
                filtered = filtered.Where(
                    item => item.Type == "Event");
            }
            else if (selectedType == "Announcements")
            {
                filtered = filtered.Where(
                    item => item.Type == "Announcement");
            }

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filtered = filtered.Where(item =>
                    item.Title.IndexOf(
                        searchText,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    ||
                    item.Description.IndexOf(
                        searchText,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    ||
                    item.Location.IndexOf(
                        searchText,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    ||
                    item.Category.IndexOf(
                        searchText,
                        StringComparison.OrdinalIgnoreCase) >= 0);
            }

            dgvItems.DataSource = null;
            dgvItems.DataSource = filtered.ToList();

            lblInformation.Text =
                filtered.Count() + " item(s) displayed. " +
                "Demonstration data: verify official details.";
        }

        private void DgvItems_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            MunicipalEvent selected =
                dgvItems.Rows[e.RowIndex].DataBoundItem
                as MunicipalEvent;

            if (selected == null)
            {
                return;
            }

            string details =
                "Reference: " + selected.EventId +
                Environment.NewLine +
                "Type: " + selected.Type +
                Environment.NewLine +
                "Title: " + selected.Title +
                Environment.NewLine +
                "Date: " +
                    selected.EventDate.ToString("dd MMMM yyyy") +
                Environment.NewLine +
                "Location: " + selected.Location +
                Environment.NewLine +
                "Category: " + selected.Category +
                Environment.NewLine +
                Environment.NewLine +
                selected.Description;

            MessageBox.Show(
                details,
                selected.Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

