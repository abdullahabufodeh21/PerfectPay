//using Foundation;

namespace PerfectPay;

public partial class PerfectPay : ContentPage
{
	decimal bill;
	int tip;
	int noPersons = 1;
	public PerfectPay()
	{
		InitializeComponent();
	}

	private void txtBill_Completed(object sender, EventArgs e)
	{
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();

	}
	private void CalculateTotal()
	{
		// total tip
		var totalTip = (bill * tip) / 100;
		//tip by person
		var tipByPerson = (totalTip / noPersons);
		lblTipBYPerson.Text = $"{tipByPerson:C}";
		//Subtotal
		var subtotal = (bill/ noPersons);
		lblSubTotal.Text = $"{subtotal:C}";

			//TOTAL
			var  totalByPerson = (bill+totalTip) / noPersons;
		lblTotal.Text = $"{totalByPerson:C}";

	}

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		tip = (int)sldTip.Value;
		lblTip.Text = $"Tipe: {tip}%";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (sender is Button) { 
		   var btn = (Button)sender;
			var percentage =int.Parse(btn.Text.Replace("%",""));
			sldTip.Value = percentage;
		
		}
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
		if (noPersons > 1)
		{
			noPersons--;
		}
		lblNoPersons.Text = noPersons.ToString();
		CalculateTotal();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
		noPersons++;
		lblNoPersons.Text = noPersons.ToString();
		CalculateTotal() ;
    }
}