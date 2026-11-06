namespace Lab2
{
    public class ChooseForm : BaseForm
    {
        public ChooseForm()
        {
            Text = "Choose";
            ClientSize = new Size(340, 160);

            var lbl = new Label { Text = "What would you like to use?", Left = 20, Top = 20, AutoSize = true };
            var btnBicycle = new Button { Text = "Bicycle", Left = 30, Top = 70, Width = 120, Height = 40 };
            var btnMushroom = new Button { Text = "Mushroom", Left = 190, Top = 70, Width = 120, Height = 40 };

            btnBicycle.Click += (s, e) => Nav.Go(this, new BicycleForm());
            btnMushroom.Click += (s, e) => Nav.Go(this, new MushroomForm());

            Controls.AddRange(new Control[] { lbl, btnBicycle, btnMushroom });
        }
    }
}