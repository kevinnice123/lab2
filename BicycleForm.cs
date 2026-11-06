namespace Lab2
{
    public class BicycleForm : BaseForm
    {
        private TextBox txtStart, txtEnd, txtTotal;

        public BicycleForm()
        {
            Text = "Bicycle Rental";
            ClientSize = new Size(380, 340);

            var lblTitle = new Label
            {
                Text = "Bicycle Rental",
                Left = 0,
                Top = 15,
                Width = 380,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold)
            };

            var lblStart = new Label { Text = "Start hour (0 - 23):", Left = 20, Top = 75, AutoSize = true };
            txtStart = MakeTextBox(220, 72, 130);
            var lblEnd = new Label { Text = "End hour (1 - 24):", Left = 20, Top = 120, AutoSize = true };
            txtEnd = MakeTextBox(220, 117, 130);

            var btnCalc = MakeButton("Calculate", 20, 165, 330, 38);
            btnCalc.Click += BtnCalc_Click;

            var lblTotal = new Label { Text = "Total (RWF):", Left = 20, Top = 225, AutoSize = true };
            txtTotal = MakeTextBox(220, 222, 130);
            txtTotal.ReadOnly = true;

            var btnBack = MakeButton("Back", 20, 280, 150, 38);
            var btnLogout = MakeButton("Logout", 200, 280, 150, 38, dark: true);
            btnBack.Click += (s, e) => Nav.Go(this, new ChooseForm());
            btnLogout.Click += (s, e) => Nav.Go(this, new LoginForm());

            Controls.AddRange(new Control[] { lblTitle, lblStart, txtStart, lblEnd, txtEnd, btnCalc,
                                              lblTotal, txtTotal, btnBack, btnLogout });
            AcceptButton = btnCalc;
        }

        // Price of the one-hour slot that starts at hour h
        private static int RateForHour(int h)
        {
            if (h >= 14 && h < 19) return 1500;
            if ((h >= 7 && h < 14) || (h >= 19 && h < 21)) return 1000;
            return 500;   // 0-7 and 21-24
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            txtTotal.Clear();

            if (!int.TryParse(txtStart.Text.Trim(), out int start) ||
                !int.TryParse(txtEnd.Text.Trim(), out int end))
            {
                Warn("Please enter whole numbers only (no decimals or letters).");
                return;
            }
            if (start < 0 || start > 23) { Warn("The start time must be between 0 and 23."); return; }
            if (end < 1 || end > 24) { Warn("The end time must be between 1 and 24."); return; }
            if (start >= end) { Warn("The start time must be less than the end time."); return; }

            int total = 0;
            for (int hour = start; hour < end; hour++)
                total += RateForHour(hour);

            txtTotal.Text = total.ToString();
            MessageBox.Show($"Rental from {start}h to {end}h.\nTotal to pay: {total} RWF",
                "Rental price", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Warn(string msg) =>
            MessageBox.Show(msg, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}