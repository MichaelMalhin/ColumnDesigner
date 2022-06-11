using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ColumnDesign
{
    public class initMemberTable
    {
        public List<String[]> table_data = new List<string[]>();
        public int last_row_id = 0;
        public StackPanel content;

        public initMemberTable(StackPanel content) { this.content = content; }

        public void addRow()
        {
            last_row_id++;
            table_data.Add(new String[] { "5", "1.0", "1.0", "1.0", "1.0", "1.0", "1.0" });
            contentData.load_table.table_data.Add(new List<string[]> { });
            updateTableView();
        }

        public void updateTableView()
        {
            content.Children.Clear();

            for (int i = 0; i < table_data.Count; i++)
            {
                int row_index = i + 1;
                String acc_index = i.ToString();
                UniformGrid row = new UniformGrid();
                row.Rows = 1;
                row.Columns = 10;

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

                
                // H -------------------------------------------------------------
                TextBox txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][0];
                txt.Name = "MemberH_" + acc_index + "_0";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // Lcrx -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][1];
                txt.Name = "MemberLcrx_" + acc_index + "_1";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // Lcry -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][2];
                txt.Name = "MemberLcry_" + acc_index + "_2";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // Bwy -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][3];
                txt.Name = "MemberBwy_" + acc_index + "_3";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // Bwx -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][4];
                txt.Name = "MemberBwx_" + acc_index + "_4";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // Bty -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][5];
                txt.Name = "MemberBty_" + acc_index + "_5";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // Btx -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][6];
                txt.Name = "MemberBtx_" + acc_index + "_6";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // copy button -------------------------------------------------------------------------
                Button btn = new Button();
                btn.Name = "copyMemberRow_" + (row_index - 1).ToString();
                btn.Click += copyRow;
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"/img/copy.png", UriKind.Relative));
                img.Height = 16;
                StackPanel stackPnl = new StackPanel();
                stackPnl.Orientation = Orientation.Horizontal;
                stackPnl.Children.Add(img);
                btn.Content = stackPnl;
                btn.Height = 30;
                row.Children.Add(btn);

                // Delete button -------------------------------------------------------------------------
                btn = new Button();
                btn.Name = "deleteMemberRow_" + (row_index - 1).ToString();
                btn.Click += deleteRow;
                img = new Image();
                img.Source = new BitmapImage(new Uri(@"/img/delete.png", UriKind.Relative));
                img.Height = 16;
                stackPnl = new StackPanel();
                stackPnl.Orientation = Orientation.Horizontal;
                stackPnl.Children.Add(img);
                btn.Content = stackPnl;
                btn.Height = 30;
                row.Children.Add(btn);

                content.Children.Add(row);
            }

            // Update member list in load tab
            contentData.load_member.Items.Clear();
            for (int i = 0; i < table_data.Count; i++)
            {
                // item
                ComboBoxItem newitem = new ComboBoxItem();
                newitem.Content = "Member " + (i + 1);
                contentData.load_member.Items.Add(newitem);
            }
            if (table_data.Count != 0) contentData.load_member.SelectedIndex = 0;
        }


        private void changeCellValue(object sender, TextChangedEventArgs args)
        {
            TextBox input = (TextBox)sender;
            String input_name = input.Name.ToString();
            int row_id = Int32.Parse(input_name.Split('_')[1]);
            int col_id = Int32.Parse(input_name.Split('_')[2]);
            table_data[row_id][col_id] = input.Text;
        }

        private void copyRow(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String btn_name = btn.Name.ToString();
            int row_id = Int32.Parse(btn_name.Split('_')[1]);

            MessageBoxResult result = MessageBox.Show("Would you like to copy table row\ndata for all other rows?", "Column Designer", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // MessageBox.Show(btn_name);
                    for (int i = 0; i < table_data.Count; i++)
                    {
                        if (i != row_id)
                        {
                            for (int j = 0; j < table_data[i].Length; j++) table_data[i][j] = table_data[row_id][j];
                        }
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }

            // Debug.WriteLine(string.Join("/", table_data[0]));
            updateTableView();
        }

        private void deleteRow(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String btn_name = btn.Name.ToString();
            int row_id = Int32.Parse(btn_name.Split('_')[1]);

            List<String[]> temp = new List<string[]>();
            List<List<string[]>> temp_2 = new List<List<string[]>>();   
            for (int i = 0; i < table_data.Count; i++)
            {
                if (i != row_id)
                {
                    temp.Add(table_data[i]);
                    temp_2.Add(contentData.load_table.table_data[i]);
                }
            }
            table_data = temp;
            contentData.load_table.table_data = temp_2;
            last_row_id = table_data.Count;
            updateTableView();
        }

    }


    public partial class MainWindow
    {

        private void memberAddBtnFunc(object sender, RoutedEventArgs e)
        {
            contentData.member_table.addRow();
        }


    }
}
