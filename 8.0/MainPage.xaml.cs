#if WINDOWS
using Common.Windows;
#endif

namespace UsedToWork;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void OnTestBtnClicked(object sender, EventArgs e)
    {
        string message = "Applicable to Windows Only";
        try
        {

#if WINDOWS
			var isDeclared = PackageHelpers.IsUriProtocolDeclared("myapp");
			message= "Windows success";
#endif
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        TestBtn.Text = message;
    }
}

