/*
 * Created by SharpDevelop.
 * User: vche
 * Date: 11/9/2018
 * Time: 12:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;


namespace winapp1
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		const string pattern = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?valcode=&&date=&&json";
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			string date = dateTimePicker1.Text.Replace(".", "");
			linkLabel1.Text = pattern;
			linkLabel1.Text = linkLabel1.Text.Replace("valcode=", "valcode=" + comboBox1.Text);
			linkLabel1.Text = linkLabel1.Text.Replace("date=", "date=" + date);
		}
		void DateTimePicker1ValueChanged(object sender, EventArgs e)
		{
			string currency = comboBox1.Text;
			string date = dateTimePicker1.Text.Replace(".", "");
			linkLabel1.Text = pattern;
			linkLabel1.Text = linkLabel1.Text.Replace("valcode=", "valcode=" + currency);
			linkLabel1.Text = linkLabel1.Text.Replace("date=", "date=" + date);
		}
		void Button1Click(object sender, EventArgs e)
		{
			string html = Utility.ReadResponse(linkLabel1.Text);
			richTextBox1.Text = html;
			label1.Text = Utility.JsonParse(html);
			linkLabel1.Text = pattern;
		}
	}
}
