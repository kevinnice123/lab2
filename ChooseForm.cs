namespace Lab2
{
    public class ChooseForm : BaseForm
    {
        public ChooseForm()
        {
            Text = "Choose";
            ClientSize = new Size(340, 200);

            var lblTitle = new Label
            {
                Text = "What would you like to use?",
                Left = 0,
                Top = 20,
                Width = 340,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold)
            };

            var btnBicycle = MakeButton("Bicycle", 30, 90, 130, 45);
            var btnMushroom = MakeButton("Mushroom", 180, 90, 130, 45);

            btnBicycle.Click += (s, e) => Nav.Go(this, new BicycleForm());
            btnMushroom.Click += (s, e) => Nav.Go(this, new MushroomForm());

            Controls.AddRange(new Control[] { lblTitle, btnBicycle, btnMushroom });
        }
    }
}