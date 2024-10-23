using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Reflection;
using System.Drawing.Text;
using System.Linq.Expressions;

namespace Clock
{
	public partial class ChooseFont : Form
	{
		public Font ChosenFont { get; private set; }
		public string FontFile { get; private set; }
		public ChooseFont()
		{
			InitializeComponent();
			LoadFonts();
		}
		public ChooseFont(string fontFile) : base()
		{
			SetFontFile(fontFile);
		}
		public Font SetFontFile(string fontFile)
		{
			FontFile = fontFile;
			comboBoxFonts.SelectedIndex = comboBoxFonts.Items.IndexOf(fontFile);
			PrivateFontCollection pfc = new PrivateFontCollection();
			pfc.AddFontFile(FontFile);
			return new Font(pfc.Families[0], 36);
		}
		//private void SetFontDirectory()
		//{
		//	string location = Assembly.GetEntryAssembly().Location; //получаем полный адрес .exe
		//															//MessageBox.Show(location);
		//	string path = Path.GetDirectoryName(location); //из адреса извлекаем путь к файлу
		//	MessageBox.Show(Directory.GetCurrentDirectory()); //System.IO
		//													  //Directory.SetCurrentDirectory($"{Assembly.GetEntryAssembly().Location}\\..\\..\\..\\fonts");
		//	Directory.SetCurrentDirectory($"{path}\\..\\..\\fonts");// \\.. - переход на уровень выше
		//	MessageBox.Show(Directory.GetCurrentDirectory()); //System.IO
		//}
		void LoadFonts()
		{
			//SetFontDirectory();

			string[] fonts = Directory.EnumerateFiles(Directory.GetCurrentDirectory()).ToArray();
			//string[] fonts = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.ttf").ToArray();
			//fonts = fonts.Where < i >= i = i.Split('\\').Last() >;
			for (int i = 0; i < fonts.Length; i++) 
			{
				fonts[i] = fonts[i].Split('\\').Last();
			}
			comboBoxFonts.Items.AddRange(fonts);
			comboBoxFonts.SelectedIndex = 1;
		}
		

		private void comboBoxFonts_Click(object sender, EventArgs e)
		{
			//comboBoxFonts.Items[comboBoxFonts.SelectedIndex]
		}

		private void comboBoxFonts_SelectedValueChanged(object sender, EventArgs e)
		{
			FontFile = $"{Directory.GetCurrentDirectory()}\\{comboBoxFonts.SelectedItem.ToString()}";
			//string fontFile = $"{Directory.GetCurrentDirectory()}\\{comboBoxFonts.SelectedValue.ToString()}";
			//MessageBox.Show(fontFile);
			//PrivateFontCollection pfc = new PrivateFontCollection();
			//pfc.AddFontFile(fontFile);
			//Font font = new Font(pfc.Families[0], 12);
			//labelExample.Font = font;

			PrivateFontCollection pfc = new PrivateFontCollection();
			pfc.AddFontFile(FontFile);
			//Font font = new Font(pfc.Families[0], 36);
			labelExample.Font = new Font(pfc.Families[0], 36);
			//comboBoxFonts.Font = new Font(pfc.Families[0], 12);
		}
		private void buttonOkay_Click(object sender, EventArgs e)
		{
			ChosenFont = new Font(labelExample.Font.FontFamily, labelExample.Font.Size); //ChooseFont и label1Font - две ссылки на один объект
		}
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
