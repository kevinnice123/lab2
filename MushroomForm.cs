namespace Lab2
{
    public class MushroomForm : BaseForm
    {
        private Label lblQuestion;
        private Button btnYes, btnNo, btnStart;
        private int questionNo;

        private enum Q { None, Ring, Forest, Cup, CupNoRing, Gills }
        private Q current = Q.None;

        public MushroomForm()
        {
            Text = "Mushroom";
            ClientSize = new Size(460, 300);

            var lblInfo = new Label
            {
                Text = "Think of one of these mushrooms:\nAgaric jaunissant, Amanite tue-mouche, Cepe de Bordeaux,\nCoprin chevelu, Girolle, Pied bleu.",
                Left = 20,
                Top = 15,
                Width = 420,
                Height = 60
            };

            btnStart = new Button { Text = "Start", Left = 20, Top = 85, Width = 420, Height = 35 };
            btnStart.Click += (s, e) => StartGame();

            lblQuestion = new Label
            {
                Text = "Press Start to begin.",
                Left = 20,
                Top = 135,
                Width = 420,
                Height = 50,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            };

            btnYes = new Button { Text = "Yes", Left = 20, Top = 190, Width = 200, Height = 35, Enabled = false };
            btnNo = new Button { Text = "No", Left = 240, Top = 190, Width = 200, Height = 35, Enabled = false };
            btnYes.Click += (s, e) => Answer(true);
            btnNo.Click += (s, e) => Answer(false);

            var btnBack = new Button { Text = "Back", Left = 20, Top = 245, Width = 200, Height = 35 };
            var btnLogout = new Button { Text = "Logout", Left = 240, Top = 245, Width = 200, Height = 35 };
            btnBack.Click += (s, e) => Nav.Go(this, new ChooseForm());
            btnLogout.Click += (s, e) => Nav.Go(this, new LoginForm());

            Controls.AddRange(new Control[] { lblInfo, btnStart, lblQuestion, btnYes, btnNo, btnBack, btnLogout });
        }

        private void StartGame()
        {
            questionNo = 0;
            btnYes.Enabled = true;
            btnNo.Enabled = true;
            btnStart.Text = "Restart";
            Ask(Q.Ring);
        }

        private void Ask(Q q)
        {
            current = q;
            questionNo++;
            string text = q switch
            {
                Q.Ring => "Does your mushroom have a ring?",
                Q.Forest => "Does your mushroom grow in a forest?",
                Q.Cup or Q.CupNoRing => "Does your mushroom have a convex cup?",
                Q.Gills => "Does your mushroom have gills?",
                _ => ""
            };
            lblQuestion.Text = $"Question {questionNo}/3:\n{text}";
        }

        // Decision tree: never more than 3 questions
        private void Answer(bool yes)
        {
            switch (current)
            {
                case Q.Ring:
                    Ask(yes ? Q.Forest : Q.CupNoRing);
                    break;
                case Q.Forest:
                    if (yes) Result("Amanite tue-mouche"); else Ask(Q.Cup);
                    break;
                case Q.Cup:
                    Result(yes ? "Agaric jaunissant" : "Coprin chevelu");
                    break;
                case Q.CupNoRing:
                    if (yes) Result("Pied bleu"); else Ask(Q.Gills);
                    break;
                case Q.Gills:
                    Result(yes ? "Girolle" : "Cepe de Bordeaux");
                    break;
            }
        }

        private void Result(string name)
        {
            current = Q.None;
            btnYes.Enabled = false;
            btnNo.Enabled = false;
            lblQuestion.Text = $"Your mushroom is: {name}";
            MessageBox.Show($"Your mushroom is: {name}", "Result",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}