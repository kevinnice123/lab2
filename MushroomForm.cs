namespace Lab2
{
    public class MushroomForm : BaseForm
    {
        private ComboBox cmbGills, cmbForest, cmbRing, cmbCup;
        private ListBox lstMushrooms;

        // ---- Colors (change these to restyle the screen) ----
        private static readonly Color BackgroundColor = Color.FromArgb(40, 40, 40);    // dark gray
        private static readonly Color TextColor = Color.White;
        private static readonly Color ButtonColor = Color.FromArgb(90, 90, 90);    // medium gray
        private static readonly Color LogoutColor = Color.Black;
        private static readonly Color InputBackColor = Color.FromArgb(235, 235, 235); // light gray boxes

        // Facts from the lab sheet: gills, forest, ring, convex cup
        private static readonly (string Name, bool Gills, bool Forest, bool Ring, bool Cup)[] Mushrooms =
        {
            ("Agaric Jaunissant",  true,  false, true,  true),
            ("Amanite tue-mouche", true,  true,  true,  true),
            ("Cepe de Bordeaux",   false, true,  false, false),
            ("Coprin chevelu",     true,  false, true,  false),
            ("Girolle",            true,  true,  false, false),
            ("Pied bleu",          true,  true,  false, true),
        };

        public MushroomForm()
        {
            Text = "Mushroom guessing";
            ClientSize = new Size(720, 500);
            BackColor = BackgroundColor;
            ForeColor = TextColor;

            // Title and instruction
            var lblTitle = new Label
            {
                Text = "Mushroom guessing",
                Left = 0,
                Top = 20,
                Width = 720,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold)
            };
            var lblInfo = new Label
            {
                Text = "Think of one of the six mushrooms and answer the questions",
                Left = 0,
                Top = 65,
                Width = 720,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Left side: questions
            var lblQuestions = new Label
            {
                Text = "Questions",
                Left = 40,
                Top = 120,
                Width = 340,
                Height = 28,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            };

            cmbGills = AddQuestion("1. Does your mushroom have gills?", 165);
            cmbForest = AddQuestion("2. Does it grow in a forest?", 215);
            cmbRing = AddQuestion("3. Does it have a ring?", 265);
            cmbCup = AddQuestion("4. Does it have a convex cup?", 315);

            // Right side: the six mushrooms
            var lblList = new Label
            {
                Text = "The six mushrooms",
                Left = 410,
                Top = 120,
                Width = 270,
                Height = 28,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            };
            lstMushrooms = new ListBox
            {
                Left = 410,
                Top = 165,
                Width = 270,
                Height = 140,
                BackColor = InputBackColor,
                ForeColor = Color.Black
            };
            foreach (var m in Mushrooms) lstMushrooms.Items.Add(m.Name);

            // Buttons
            var btnFind = MakeButton("Find mushroom", 270, 370, 180, 40, ButtonColor);
            btnFind.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);
            btnFind.Click += BtnFind_Click;

            var btnBack = MakeButton("Back", 40, 440, 100, 38, ButtonColor);
            var btnLogout = MakeButton("Logout", 580, 440, 100, 38, LogoutColor);
            btnBack.Click += (s, e) => Nav.Go(this, new ChooseForm());
            btnLogout.Click += (s, e) => Nav.Go(this, new LoginForm());

            Controls.AddRange(new Control[]
            {
                lblTitle, lblInfo, lblQuestions, lblList, lstMushrooms,
                btnFind, btnBack, btnLogout
            });
        }

        private Button MakeButton(string text, int left, int top, int width, int height, Color back)
        {
            var btn = new Button
            {
                Text = text,
                Left = left,
                Top = top,
                Width = width,
                Height = height,
                BackColor = back,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderColor = Color.Gray;
            return btn;
        }

        // Creates one question label and its Yes/No dropdown
        private ComboBox AddQuestion(string text, int top)
        {
            var lbl = new Label { Text = text, Left = 40, Top = top + 4, Width = 230, Height = 25 };
            var cmb = new ComboBox
            {
                Left = 280,
                Top = top,
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = InputBackColor,
                ForeColor = Color.Black
            };
            cmb.Items.AddRange(new object[] { "Yes", "No" });
            Controls.Add(lbl);
            Controls.Add(cmb);
            return cmb;
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (cmbGills.SelectedIndex < 0 || cmbForest.SelectedIndex < 0 ||
                cmbRing.SelectedIndex < 0 || cmbCup.SelectedIndex < 0)
            {
                MessageBox.Show("Please answer all four questions (Yes or No).", "Missing answer",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Index 0 = Yes, index 1 = No
            bool gills = cmbGills.SelectedIndex == 0;
            bool forest = cmbForest.SelectedIndex == 0;
            bool ring = cmbRing.SelectedIndex == 0;
            bool cup = cmbCup.SelectedIndex == 0;

            foreach (var m in Mushrooms)
            {
                if (m.Gills == gills && m.Forest == forest && m.Ring == ring && m.Cup == cup)
                {
                    lstMushrooms.SelectedItem = m.Name;
                    MessageBox.Show($"Your mushroom is: {m.Name}", "Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            lstMushrooms.ClearSelected();
            MessageBox.Show("No mushroom matches these answers. Please check them and try again.",
                "No match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}