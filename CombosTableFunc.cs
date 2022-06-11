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
    public class initCombosTable
    {
        public List<String[]> table_data = new List<string[]>();
        public int last_row_id = 0;
        public StackPanel content;

        public initCombosTable(StackPanel content) { 
            this.content = content;
            table_data.Add(new String[] { "1.35", "0.0", "0.0", "0.0", "1.35DL" });
            table_data.Add(new String[] { "1.35", "1.5", "0.0", "0.0", "1.35DL+1.5LL" });
            table_data.Add(new String[] { "1.0", "0.0", "1.5", "0.0", "1.0DL+1.5WL" });
            table_data.Add(new String[] { "1.35", "0.0", "1.5", "0.0", "1.35DL+1.5WL" });
            table_data.Add(new String[] { "1.35", "1.5", "0.9", "0.0", "1.35DL+1.5LL+0.9WL" });
            table_data.Add(new String[] { "1.35", "1.05", "1.5", "0.0", "1.35DL+1.05LL+1.5WL" });
            updateTableView();
        }

        public void addRow()
        {
            last_row_id++;
            table_data.Add(new String[] { "0.0", "0.0", "0.0", "0.0", "" });
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
                row.Columns = 7;

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


                // -------------------------------------------------------------
                TextBox txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][0];
                txt.Name = "comboDL_" + acc_index + "_0";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][1];
                txt.Name = "comboLL_" + acc_index + "_1";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][2];
                txt.Name = "comboWL_" + acc_index + "_2";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][3];
                txt.Name = "comboSL_" + acc_index + "_3";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                // -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][4];
                txt.Name = "comboDescription_" + acc_index + "_4";
                txt.TextChanged += changeCellValue;
                row.Children.Add(txt);

                ToolTip toolTip = new ToolTip();
                StackPanel toolTipPanel = new StackPanel();
                toolTipPanel.Children.Add(new TextBlock { Text = txt.Text, FontSize = 14 });
                toolTip.Content = toolTipPanel;
                txt.ToolTip = toolTip;


                // Delete button -------------------------------------------------------------------------
                Button btn = new Button();
                btn.Name = "deleteMemberRow_" + (row_index - 1).ToString();
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
            }

        }


        private void changeCellValue(object sender, TextChangedEventArgs args)
        {
            TextBox input = (TextBox)sender;
            String input_name = input.Name.ToString();
            int row_id = Int32.Parse(input_name.Split('_')[1]);
            int col_id = Int32.Parse(input_name.Split('_')[2]);
            table_data[row_id][col_id] = input.Text;
        }

        
        private void deleteRow(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String btn_name = btn.Name.ToString();
            int row_id = Int32.Parse(btn_name.Split('_')[1]);

            List<String[]> temp = new List<string[]>();
            for (int i = 0; i < table_data.Count; i++)
            {
                if (i != row_id) temp.Add(table_data[i]);
            }
            table_data = temp;
            last_row_id = table_data.Count;
            updateTableView();
        }

    }


    public partial class MainWindow
    {

        private void comboAddBtnFunc(object sender, RoutedEventArgs e)
        {
            contentData.load_combos.addRow();
        }


    }
}
