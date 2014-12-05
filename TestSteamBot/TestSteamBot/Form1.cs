using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TestSteamBot
{
    public partial class Form1 : Form
    {

        string tempPrice;
        string tempName;
        string tempCurrency;
        OpenFileDialog openFile = new OpenFileDialog();
        SaveFileDialog saveFile = new SaveFileDialog();
        Regex loadNameExp;
        Match match;
        List<string> toLoad = new List<string>();
        List<string> toSave = new List<string>();
        List<TFItem> Items = new List<TFItem>();
        private readonly BackgroundWorker worker = new BackgroundWorker();
        decimal KeyConvert;

        public Form1()
        {
            Config.IsLoading = false;
            worker.RunWorkerCompleted += updateList;
            InitializeComponent();
        }

        private void updateList(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lstItems.Items.Clear(); // clear the items in the listbox
            this.lstItems.Columns.Clear(); // clear columns in the listbox

            lstItems.Columns.Add("Name"); // add columns
            lstItems.Columns.Add("Price");

            foreach (TFItem x in Items)
            {
                var item = new ListViewItem(new[] { x.Name, x.Price });
                lstItems.Items.Add(item);
            }

        }



        private void btnLoadtxt_Click(object sender, EventArgs a)
        {
            KeyConvert = Convert.ToDecimal(txtKeyValue.Text);

            

            Console.WriteLine("Loading file!");

            loadNameExp = new Regex(@".* \(");
            toLoad = new List<string>();
            openFile = new OpenFileDialog();

            openFile.Title = "Open Order File"; // title of the dialog box
            openFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // filter the dialog box
            if (openFile.ShowDialog() == DialogResult.OK) // if the pressed OK
            {
                worker.DoWork += (obj, e) => work(openFile);
                worker.RunWorkerAsync(openFile);
            }
        }

        public void work(OpenFileDialog openFile)
        {
            Config.IsLoading = true;
                foreach (var i in File.ReadAllLines(openFile.FileName)) // read all the lines in the file
                {
                    toLoad.Add(i); // add them to the list
                }



                foreach (var i in toLoad.ToArray()) // for each item in the list
                {
                    match = loadNameExp.Match(i); // apply regular expression to string
                    if (match.Success) // if found a match
                    {

                        tempName = i.Substring(0, i.IndexOf("(") - 1);
                        tempPrice = i.Substring(i.IndexOf("(") + 1);
                        tempCurrency = "ref";

                        if (tempName.Contains("#26"))
                            Console.WriteLine();

                        if (tempPrice.Contains("$"))
                        {
                            tempCurrency = "$";
                        }
                        else if (tempPrice.ToLower().Contains("key"))
                        {
                            tempCurrency = "keys";
                        }



                        if (tempPrice.Contains("-"))
                        {
                            Console.WriteLine("Contains -:" + tempPrice + ". New price: " + tempPrice.Substring(0, tempPrice.IndexOf("-")));
                            tempPrice = tempPrice.Substring(0, tempPrice.IndexOf("-"));

                        }
                        if (tempPrice.Contains("–"))
                            tempPrice = tempPrice.Substring(0, tempPrice.IndexOf("–"));
                        if (tempPrice.Contains("�"))
                            tempPrice = tempPrice.Substring(0, 3);

                        if (tempCurrency == "$")
                            tempPrice = "1 ref";


                        if (tempCurrency == "keys")
                        {
                            if (tempPrice.Contains(")"))
                                tempPrice = tempPrice.Substring(0, tempPrice.IndexOf(")"));

                            Console.WriteLine(tempName + " is in keys (" + tempPrice + ")... converting to ref with ration 1:" + KeyConvert);


                            if (tempPrice.Contains("k"))
                                tempPrice = tempPrice.Substring(0, tempPrice.IndexOf("k") - 1);

                            Console.WriteLine("after substring: " + tempPrice);

                            try
                            {
                                tempPrice = (Decimal.Multiply(Convert.ToDecimal(tempPrice), KeyConvert)).ToString();
                            }
                            catch (System.FormatException)
                            {
                                MessageBox.Show(string.Format("The item {0}, containts an invalid character in its price. It will be ignored!", tempName), "Invalid Character", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                continue;
                            }
                            Console.WriteLine(tempPrice + "Is new price");
                        }

                        if (tempPrice.Contains(")"))
                        {
                            tempPrice = tempPrice.Substring(0, tempPrice.IndexOf(")"));
                        }

                        /*if (tempPrice.Contains("r"))
                            tempPrice = tempPrice.Substring(0, tempPrice.IndexOf("r")-1);//*/
                        if (!(tempPrice.Contains("r")) && !(tempCurrency == "ref"))
                            tempPrice += " ref";

                        if (tempCurrency == "$")
                            tempPrice += " (converted from USD)";
                        else if (tempCurrency == "keys")
                            tempPrice += " (converted from Key)";

                        Console.WriteLine("Name \"{0}\", Price: \"{1}\"", tempName, tempPrice);
                        Items.Add(new TFItem(tempName, tempPrice));

                    }
                }
                Config.IsLoading = false;
            }

        

        private void txtKeyValue_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                lblInfo.Text = "Decimal: " + Convert.ToDecimal(txtKeyValue.Text).ToString() + ". Total: " + Convert.ToDecimal(txtKeyValue.Text) * (decimal)2.3;
            }
            catch (InvalidCastException)
            {
                lblInfo.Text = "Deciaml: ";
            }//*/
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFile = new SaveFileDialog(); // create saveFileDialog instance
            toSave = new List<string>(); // list of lines to save to file

            saveFile.FileName = "Vending Order.txt"; // defualt file name
            saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // filter for save file dialog

            if (saveFile.ShowDialog() == DialogResult.OK) // prompt user for save location, if they press OK then
            {
                foreach (var i in Items) // for each of the items bought
                {
                    toSave.Add(i.Name + ": " + i.Price); // add it to the list of lines to be wrote to file
                }

                File.WriteAllLines(saveFile.FileName, toSave.ToArray()); // write all lines to file
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Config.IsLoading)
            {
                lblInfo.Text = "Loading File...";
            }
            else
            {
                lblInfo.Text = "Ready.";
            }
        }
    }
}
