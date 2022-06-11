using System;
using System.Collections.Generic;
using System.IO;
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
    public class initDesignTable
    {
        public List<String[]> table_data = new List<string[]>();
        public int last_row_id = 0;
        public StackPanel content;

        public initDesignTable(StackPanel content) { 
            this.content = content;
            table_data.Add(new String[] { "1", "Fault", "125.2", "56.1", "50", "NG" });
            table_data.Add(new String[] { "2", "RHS 250x10", "80.2", "56.1", "50", "OK" });
            table_data.Add(new String[] { "3", "RHS 250x10", "80.2", "56.1", "50", "OK" });
            table_data.Add(new String[] { "4", "RHS 250x10", "80.2", "56.1", "50", "OK" });
            updateTableView();
        }

        public void addRow()
        {
            // last_row_id++;
            
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
                row.Columns = 8;

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

                //  -------------------------------------------------------------
                TextBox txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][0];
                // txt.Name = "MemberH_" + acc_index;
                row.Children.Add(txt);

                //  -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][1];
                // txt.Name = "MemberH_" + acc_index;
                row.Children.Add(txt);

                //  -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][2];
                // txt.Name = "MemberLcrx_" + acc_index;
                row.Children.Add(txt);

                //  -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][3];
                // txt.Name = "MemberLcrx_" + acc_index;
                row.Children.Add(txt);

                //  -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][4];
                // txt.Name = "MemberLcrx_" + acc_index;
                row.Children.Add(txt);

                //  -------------------------------------------------------------
                txt = new TextBox();
                txt.HorizontalContentAlignment = HorizontalAlignment.Center;
                txt.VerticalContentAlignment = VerticalAlignment.Center;
                txt.Text = table_data[i][5];
                // txt.Name = "MemberLcrx_" + acc_index;
                row.Children.Add(txt);



                // copy button -------------------------------------------------------------------------
                Button btn = new Button();
                // delete_btn.Background = new SolidColorBrush(Colors.Orange);
                // delete_btn.Content = "Delete";
                btn.Name = "copyMemberRow_" + (row_index - 1).ToString();
                // btn.Click += tableMembersDeleteRow;
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"/img/report.png", UriKind.Relative));
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

    }


    public partial class MainWindow
    {

        // public initDesignTable design_table;

        private void memberDesignBtnFunc(object sender, RoutedEventArgs e)
        {


            if (contentData.member_table.table_data.Count == 0)
            {
                MessageBox.Show("Members are not defined!","Warning!");
                return;
            }

            if (contentData.load_combos.table_data.Count == 0)
            {
                MessageBox.Show("Load Combinations are not defined!", "Warning!");
                return;
            }


            Dictionary<string, string> load_case_conv = new Dictionary<string, string>();
            load_case_conv["0"] = "DL";
            load_case_conv["1"] = "LL";
            load_case_conv["2"] = "SL";
            load_case_conv["3"] = "WL";


            // design_table.addRow();
            string selected_db = ((ComboBoxItem)profile_database.SelectedItem).Content.ToString();

            string json_content = ""; 

            json_content += "{\"profileDatabase\": \"" + selected_db + "\",\n";

            json_content += "\"optimizationCriteria\":{\n";
            json_content += "\"MinSectionWidth\": \""+ opt_min_sec_w.Text + "\",\n";
            json_content += "\"MaxSectionWidth\": \"" + opt_max_sec_w.Text + "\",\n";
            json_content += "\"MinSectionHeight\": \"" + opt_min_sec_h.Text + "\",\n";
            json_content += "\"MaxSectionHeight\": \"" + opt_max_sec_h.Text + "\",\n";
            json_content += "\"MaxSectionWeight\": \"" + opt_max_wm.Text + "\"\n";
            json_content += "},\n";

            json_content += "\"designFactors\":{\n";
            json_content += "\"gammaM0\": \"" + gamma_m0.Text + "\",\n";
            json_content += "\"gammaM1\": \"" + gamma_m1.Text + "\",\n";
            json_content += "\"DiflectionLimit\": \"" + H_lim.Text + "\",\n";
            json_content += "\"AllowedUtilization\": \"" + min_unility.Text + "\"\n";
            json_content += "},\n";

            json_content += "\"material\":{\n";
            json_content += "\"SteelGrade\": \"" + ((ComboBoxItem)materialGrade.SelectedItem).Content.ToString() + "\",\n";
            json_content += "\"ModulusE\": \"" + "210000" + "\",\n";
            json_content += "\"ModulusG\": \"" + "81000" + "\",\n";
            json_content += "\"Density\": \"" + "76.98" + "\"\n";
            json_content += "},\n";

            json_content += "\"members\":[\n";
            // Member i
            for (int i = 0; i < contentData.member_table.table_data.Count; i++)
            {
                string[] member_row = contentData.member_table.table_data[i];
                List<string[]> loads = contentData.load_table.table_data[i];

                if (loads.Count == 0)
                {
                    MessageBox.Show("Member " + (i + 1) + " doesn't have defined loads!", "Warning!");
                    return;
                }

                json_content += "{\n";
                json_content += "\"Height\": " + member_row[0] + ",\n";
                json_content += "\"Ky\": " + member_row[1] + ",\n";
                json_content += "\"Kz\": " + member_row[2] + ",\n";
                json_content += "\"Loads\": {\n";

                Boolean isWz = false;
                Boolean isWy = false;
                List<string> point_load_arr = new List<string>();
                List<string> distributed_load_arr = new List<string>();

                for (int j = 0; j < loads.Count; j++)
                {

                    // string load_way = ((ComboBoxItem)materialGrade.SelectedItem).Content.ToString() loads[j][1]
                    string load_case = load_case_conv[loads[j][0]];

                    if (loads[j][1] == "0" || loads[j][1] == "5")
                    {
                        string point_load_collection = "";
                        point_load_collection += "{\n";
                        point_load_collection += "\"loadCase\": \"" + load_case + "\",\n";
                        point_load_collection += "\"direction\": \"x\",\n";
                        if (loads[j][1] == "0") point_load_collection += "\"magnitude\": " + loads[j][2] + ",\n";
                        else if (loads[j][1] == "5")
                        {
                            double pz = Double.Parse(loads[j][2]);
                            double Btx = Double.Parse(member_row[5]);
                            double Bty = Double.Parse(member_row[6]);
                            double Fz = pz * Btx * Bty;
                            point_load_collection += "\"magnitude\": " + Fz + ",\n";
                        }
                        point_load_collection += "\"position\": " + member_row[0] + ",\n";
                        point_load_collection += "\"eccentricZ\": "+loads[j][3]+",\n";
                        point_load_collection += "\"eccentricY\": " + loads[j][4] + "\n";
                        point_load_collection += "}\n";
                        point_load_arr.Add(point_load_collection);
                    }
                    else if (loads[j][1] == "1" || loads[j][1] == "2")
                    {
                        string point_load_collection = "";
                        point_load_collection += "{\n";
                        if (load_case == "WL" && loads[j][1] == "1") point_load_collection += "\"loadCase\": \"WLz\",\n";
                        else if (load_case == "WL" && loads[j][1] == "2") point_load_collection += "\"loadCase\": \"WLy\",\n";
                        else point_load_collection += "\"loadCase\": \"" + load_case + "\",\n";

                        if (loads[j][1] == "1") point_load_collection += "\"direction\": \"z\",\n";
                        else if (loads[j][1] == "2") point_load_collection += "\"direction\": \"y\",\n";
                        
                        if (Double.Parse(loads[j][5]) > Double.Parse(member_row[0]))
                        {
                            MessageBox.Show("In Member " + (i + 1) + ", Load row " + (j + 1) + " h value exceeds column height", "Warning!");
                            return;
                        }

                        point_load_collection += "\"magnitude\": " + loads[j][2] + ",\n";
                        point_load_collection += "\"position\": " + loads[j][5] + ",\n";
                        point_load_collection += "}\n";
                        point_load_arr.Add(point_load_collection);
                    }
                    else if (loads[j][1] == "3" || loads[j][1] == "4")
                    {
                        string distributed_load_collection = "";
                        distributed_load_collection += "{\n";
                        if (load_case == "WL" && loads[j][1] == "3") distributed_load_collection += "\"loadCase\": \"WLz\",\n";
                        else if (load_case == "WL" && loads[j][1] == "4") distributed_load_collection += "\"loadCase\": \"WLy\",\n";
                        else distributed_load_collection += "\"loadCase\": \"" + load_case + "\",\n";

                        if (loads[j][1] == "3") distributed_load_collection += "\"direction\": \"z\",\n";
                        else if (loads[j][1] == "4") distributed_load_collection += "\"direction\": \"y\",\n";

                        distributed_load_collection += "\"magnitude\": " + loads[j][2] + ",\n";
                        distributed_load_collection += "\"position\": " + loads[j][5] + ",\n";
                        distributed_load_collection += "\"length\": " + member_row[0] + ",\n";
                        distributed_load_collection += "}\n";
                        distributed_load_arr.Add(distributed_load_collection);
                    }
                    else if (loads[j][1] == "6" || loads[j][1] == "7")
                    {
                        string distributed_load_collection = "";
                        distributed_load_collection += "{\n";
                        if (load_case == "WL" && loads[j][1] == "6") distributed_load_collection += "\"loadCase\": \"WLz\",\n";
                        else if (load_case == "WL" && loads[j][1] == "7") distributed_load_collection += "\"loadCase\": \"WLy\",\n";
                        else distributed_load_collection += "\"loadCase\": \"" + load_case + "\",\n";

                        if (loads[j][1] == "6") distributed_load_collection += "\"direction\": \"z\",\n";
                        else if (loads[j][1] == "7") distributed_load_collection += "\"direction\": \"y\",\n";

                        if (loads[j][1] == "6")
                        {
                            double px = Double.Parse(loads[j][2]);
                            double Bwy = Double.Parse(member_row[3]);
                            double H = Double.Parse(member_row[0]);
                            double Fx = px * H * Bwy;
                            distributed_load_collection += "\"magnitude\": " + Fx/H + ",\n";
                        }
                        else
                        {
                            double py = Double.Parse(loads[j][2]);
                            double Bwx = Double.Parse(member_row[4]);
                            double H = Double.Parse(member_row[0]);
                            double Fy = py * H * Bwx;
                            distributed_load_collection += "\"magnitude\": " + Fy / H + ",\n";
                        }

                        distributed_load_collection += "\"position\": " + loads[j][5] + ",\n";
                        distributed_load_collection += "\"length\": " + member_row[0] + ",\n";
                        distributed_load_collection += "}\n";
                        distributed_load_arr.Add(distributed_load_collection);
                    }

                    // json_content += "}\n";
                }

                if (point_load_arr.Count != 0)
                {
                    json_content += "\"PointLoads\":[\n" + String.Join(",", point_load_arr) + " \n],\n";
                }
                if (distributed_load_arr.Count != 0)
                {
                    json_content += "\"DistributedLoads\":[\n" + String.Join(",", distributed_load_arr) + " \n],\n";
                }

                json_content += "\"LoadCombinations\":[\n";

                for (int c = 0; c < contentData.load_combos.table_data.Count; c++)
                {
                    string[] load_combo = contentData.load_combos.table_data[c];

                    json_content += "{\n";
                    if (load_combo[4] != "") json_content += "\"name\": \"" + load_combo[4] + "\",\n";
                    else json_content += "\"name\": \"LC" + (c+1) + "\",\n";
                    json_content += "\"DL\": \"" + load_combo[0] + "\",\n";
                    json_content += "\"LL\": \"" + load_combo[1] + "\",\n";
                    json_content += "\"WLz\": \"" + load_combo[2] + "\",\n";
                    json_content += "\"WLy\": \"" + load_combo[2] + "\",\n";
                    json_content += "\"SL\": \"" + load_combo[3] + "\"\n";
                    if (c == contentData.load_combos.table_data.Count - 1) json_content += "}\n";
                    else json_content += "},\n";
                }
                json_content += "]\n";

                json_content += "}\n";
                // if (i == loads.Count - 1) json_content += "}\n";
                // else json_content += "},\n";

                if (i == contentData.member_table.table_data.Count - 1) json_content += "}\n";
                else json_content += "},\n";
            }

            json_content += "]\n";
            json_content += "}\n";

            using (StreamWriter writer = new StreamWriter("test.json", false))
            {
                writer.WriteLine(json_content);
            }

        }



    }
}
