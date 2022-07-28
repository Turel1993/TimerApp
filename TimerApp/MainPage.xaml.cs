namespace TimerApp;

public partial class MainPage : ContentPage
{
	int count = 0;
	

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{		
		await TimerAndroidAsync();
    }

	private async Task TimerAndroidAsync() 
	{
        var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
        CounterBtn.IsEnabled = false;

        SemanticScreenReader.Announce(CounterBtn.Text);

        while (await timer.WaitForNextTickAsync())
        {
            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            await DisplayAlert("Test", "el valor es true y se ejecuta cada 5 segundos", "Ok");
            count++;
            if (count <= 4)
			{
                timer.Dispose();
                await DisplayAlert("Test", "Saliste del timer", "Ok");
                CounterBtn.IsEnabled = true;
            }
			
        }
    }


}

