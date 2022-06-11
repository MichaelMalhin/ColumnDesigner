using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace ColumnDesign
{

    public class initLoadTable {

        public List<List<String[]>> table_data = new List<List<String[]>>();
        public int last_row_id = 0;
        public StackPanel content;

        public initLoadTable (StackPanel content) { this.content = content; }

        public void addRow(int member_ind)
        {
            last_row_id++;
            table_data[member_ind].Add(new String[] {"0","0", "0", "0", "0", "0",""});
            updateTableView();
        }

        public void updateTableView()
        {
    
            content.Children.Clear();
            int member_ind = contentData.load_member.SelectedIndex;

            for (int i = 0; i < table_data[member_ind].Count; i++)
            {
                int row_index = i + 1;
                String acc_index = i.ToString();
                UniformGrid row = new UniformGrid();
                row.Rows = 1;
                row.Columns = 9;

                // ID cell -------------------------------------------------------------------
                Border borderID = new Border();
                borderID.Background = new SolidColorBrush(Colors.LightGray);
                borderID.BorderBrush = new SolidColorBrush(Colors.Gray);
                borderID.BorderThickness = new Thickness(1, 1, 1, 1);
                borderID.Height = 30;
                TextBlock txtID = new TextBlock();
                txtID.HorizontalAlignment = HorizontalAlignment.Center;
                txtID.VerticalAlignment = VerticalAlignment.Center;
                txtID.Text = row_index.ToString();
                borderID.Child = txtID;
                row.Children.Add(borderID);

                // Load Type cell --------------------------------------------------------------
                ComboBox loadCase = new ComboBox();
                loadCase.Name = "loadType_" + member_ind + "_" + acc_index + "_0";
                loadCase.VerticalContentAlignment = VerticalAlignment.Center;
                // item
                ComboBoxItem newitem = new ComboBoxItem();
                newitem.Content = "DL";
                loadCase.Items.Add(newitem);
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "LL";
                loadCase.Items.Add(newitem);
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "SL";
                loadCase.Items.Add(newitem);
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "WL";
                loadCase.Items.Add(newitem);
                // Settings
                loadCase.SelectedItem = ((ComboBoxItem)loadCase.Items[Int32.Parse(table_data[member_ind][i][0])]);
                row.Children.Add(loadCase);

                // Load Way cell --------------------------------------------------------------
                ComboBox loadWay = new ComboBox();
                loadWay.Name = "loadWay_" + member_ind + "_" + acc_index + "_1";
                loadWay.VerticalContentAlignment = VerticalAlignment.Center;
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "Fz, kN";
                loadWay.Items.Add(newitem);
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "Fx, kN";
                loadWay.Items.Add(newitem);
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "Fy, kN";
                loadWay.Items.Add(newitem);
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "DLx, kN/m";
                loadWay.Items.Add(newitem);
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "DLy, kN/m";
                loadWay.Items.Add(newitem);
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "pz, kN/m2";
                loadWay.Items.Add(newitem);
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "px, kN/m2";
                loadWay.Items.Add(newitem);
                // item
                newitem = new ComboBoxItem();
                newitem.Content = "py, kN/m2";
                loadWay.Items.Add(newitem);
                // item
                /*
                newitem = new ComboBoxItem();
                newitem.Content = "SL, (EN 1-3 §5)";
                loadWay.Items.Add(newitem);
                */
                // Settings
                loadWay.SelectedItem = ((ComboBoxItem)loadWay.Items[Int32.Parse(table_data[member_ind][i][1])]);
                row.Children.Add(loadWay);

                // Load Value -------------------------------------------------------------
                TextBox txtLoadValue = new TextBox();
                txtLoadValue.HorizontalContentAlignment = HorizontalAlignment.Center;
                txtLoadValue.VerticalContentAlignment = VerticalAlignment.Center;
                txtLoadValue.Text = table_data[member_ind][i][2];
                txtLoadValue.Name = "loadValue_" + member_ind + "_" + acc_index + "_2";
                txtLoadValue.TextChanged += changeCellValue;
                row.Children.Add(txtLoadValue);

                // Load ecc x Value -------------------------------------------------------------
                TextBox txtexValue = new TextBox();
                txtexValue.HorizontalContentAlignment = HorizontalAlignment.Center;
                txtexValue.VerticalContentAlignment = VerticalAlignment.Center;
                txtexValue.Text = table_data[member_ind][i][3];
                txtexValue.Name = "loadValue_" + member_ind + "_" + acc_index + "_3";
                txtexValue.TextChanged += changeCellValue;
                row.Children.Add(txtexValue);

                // Load ecc y Value -------------------------------------------------------------
                TextBox txteyValue = new TextBox();
                txteyValue.HorizontalContentAlignment = HorizontalAlignment.Center;
                txteyValue.VerticalContentAlignment = VerticalAlignment.Center;
                txteyValue.Text = table_data[member_ind][i][4];
                txteyValue.Name = "loadValue_" + member_ind + "_" + acc_index + "_4";
                txteyValue.TextChanged += changeCellValue;
                row.Children.Add(txteyValue);

                // Load h -------------------------------------------------------------
                TextBox txthValue = new TextBox();
                txthValue.HorizontalContentAlignment = HorizontalAlignment.Center;
                txthValue.VerticalContentAlignment = VerticalAlignment.Center;
                txthValue.Text = table_data[member_ind][i][5];
                txthValue.Name = "loadValue_" + member_ind + "_" + acc_index + "_5";
                txthValue.TextChanged += changeCellValue;
                row.Children.Add(txthValue);

                // Load Value ----------------------------------------------------------------------------
                TextBox txtLoadDescription = new TextBox();
                txtLoadDescription.HorizontalContentAlignment = HorizontalAlignment.Center;
                txtLoadDescription.VerticalContentAlignment = VerticalAlignment.Center;
                txtLoadDescription.Text = table_data[member_ind][i][6];
                txtLoadDescription.Name = "loadDescription_" + member_ind + "_" + acc_index + "_6";
                txtLoadDescription.TextChanged += changeCellValue;
                row.Children.Add(txtLoadDescription);

                // Delete button -------------------------------------------------------------------------
                Button btn = new Button();
                // delete_btn.Background = new SolidColorBrush(Colors.Orange);
                // delete_btn.Content = "Delete";
                btn.Name = "delete_" + member_ind + "_" + acc_index;
                btn.Click += deleteRow;
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"/img/delete.png", UriKind.Relative));
                img.Height = 16;
                StackPanel stackPnl = new StackPanel();
                stackPnl.Orientation = Orientation.Horizontal;
                stackPnl.Children.Add(img);
                btn.Content = stackPnl;
                btn.Height = 30;
                row.Children.Add(btn);

                content.Children.Add(row);
                loadCase.SelectionChanged += comboSelection;
                loadWay.SelectionChanged += comboSelection;
            }
        }


        private void changeCellValue(object sender, TextChangedEventArgs args)
        {
            TextBox input = (TextBox)sender;
            String input_name = input.Name.ToString();
            string[] item_data = input_name.Split('_');
            int member_ind = Int32.Parse(item_data[1]);
            int row_ind = Int32.Parse(item_data[2]);
            int col_ind = Int32.Parse(item_data[3]);
            table_data[member_ind][row_ind][col_ind] = input.Text;
            // Debug.WriteLine(input.Name);
        }

        private void comboSelection(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            // ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string[] item_data = comboBox.Name.Split('_');
            int member_ind = Int32.Parse(item_data[1]);
            int row_ind = Int32.Parse(item_data[2]);
            int col_ind = Int32.Parse(item_data[3]);
            /*
            if (comboBox.SelectedIndex == 6)
            {
                Debug.WriteLine("here");
                TextBox test = (TextBox) content.FindName("loadValue_0_0_2");
                Debug.WriteLine(test.Name);
            } 
            */
            table_data[member_ind][row_ind][col_ind] = comboBox.SelectedIndex.ToString();
        }

        private void deleteRow(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String btn_name = btn.Name.ToString();
            int row_id = Int32.Parse(btn_name.Split('_')[2]);

            int member_ind = contentData.load_member.SelectedIndex;
            List<String[]> temp = new List<string[]>();

            for (int i = 0; i < table_data[member_ind].Count; i++)
            {
                if (i != row_id) temp.Add(table_data[member_ind][i]);
            }
            table_data[member_ind] = temp;
            last_row_id = table_data.Count;
            updateTableView();
            
        }

    }


    public partial class MainWindow {

        // public initLoadTable load_table;

        private void loadMemberSelection(object sender, RoutedEventArgs e)
        {
            // Debug.WriteLine(contentData.load_member.SelectedIndex);
            if (contentData.load_member.SelectedIndex < 0) return;
            contentData.load_table.updateTableView();
        }

        private void loadAddBtnFunc(object sender, RoutedEventArgs e)
        {
            if (contentData.member_table.table_data.Count != 0)
            {
                // Debug.WriteLine(contentData.load_member.SelectedItem);
                contentData.load_table.addRow(contentData.load_member.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Add new member in `Members tab`", contentData.dialog_header);
            }
        }


 


        private void loadCopyBtnFunc(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Would you like to copy table data for all other members?", "Column Designer", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // MessageBox.Show("Hello to you too!", "My App");
                    int member_ind = contentData.load_member.SelectedIndex;
                    List<String[]> data = new List<String[]>();

                    for (int i = 0; i < contentData.load_table.table_data[member_ind].Count; i++) data.Add(contentData.load_table.table_data[member_ind][i]);

                    for (int i = 0; i < contentData.load_table.table_data.Count; i++)
                    {
                        if (member_ind != i)
                        {
                            List<String[]> temp = new List<String[]>();
                            for (int j = 0; j < data.Count; j++) temp.Add(data[j]); // contentData.load_table.table_data[i].Add(data[j]);
                            contentData.load_table.table_data[i] = temp;
                        }
                    }

                    break;
                case MessageBoxResult.No:
                    // MessageBox.Show("Oh well, too bad!", "My App");
                    break;
            }
        }


    }
}
