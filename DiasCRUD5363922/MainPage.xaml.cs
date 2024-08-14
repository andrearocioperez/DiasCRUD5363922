namespace DiasCRUD5363922
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDBService _dbService;
        private int _editRespuestaId;
        public MainPage(LocalDBService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listview.ItemsSource = await _dbService.GetCalculoD());
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
        }

        private async void resultButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(DiasEntry.Text, out int dias))
            {
                var segundos = dias * 24 * 60 * 60;

                labelresult.Text = $"{dias} días son {segundos} segundos.";


                if (_editRespuestaId == 0)
                {
                    await _dbService.Create(new CalculoD
                    {
                        Dias = DiasEntry.Text,
                        ReSegundos = labelresult.Text,
                    });
                }
                else
                {
                    await _dbService.Update(new CalculoD
                    {
                        Id = _editRespuestaId,
                        Dias = DiasEntry.Text,
                        ReSegundos = labelresult.Text
                    });
                    _editRespuestaId = 0;
                }
                DiasEntry.Text = string.Empty;
                labelresult.Text = string.Empty;

                listview.ItemsSource = await _dbService.GetCalculoD();
            }
            else
            {
                labelresult.Text = "Por favor, introduce un número de dias válido.";
            }
        }

        private async void Listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var calculo = (CalculoD)e.Item;
            var action = await DisplayActionSheet("Selecciona", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    _editRespuestaId = calculo.Id;
                    DiasEntry.Text = calculo.Dias;
                    labelresult.Text = calculo.ReSegundos;
                    break;

                case "Delete":
                    await _dbService.Delete(calculo);
                    listview.ItemsSource = await _dbService.GetCalculoD();
                    break;
            }
        }
    }

}
