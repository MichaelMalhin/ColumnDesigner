using System;
using System.Collections.Generic;
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


    public class contentData
    {
        public static string dialog_header = "Column designer";

        public static initMemberTable member_table;
        public static initLoadTable load_table;
        public static initCombosTable load_combos;
        public static initDesignTable design_table;
        public static ComboBox load_member;
    }


    public partial class MainWindow
    {

        private ToolTip tableHeaderTooltip (string header, string img, int tooltip_fontsize)
        {

            ToolTip toolTip = new ToolTip();
            StackPanel toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = header, FontSize = tooltip_fontsize });
            
            if (img != "")
            {
                toolTip.Background = new SolidColorBrush(Colors.White);
                toolTip.Width = 200;
                toolTip.Height = 220;
                Image tooltip_img = new Image();
                tooltip_img.Width = 180;
                tooltip_img.Height = 180;
                // tooltip_img.Margin = new Thickness(5);
                tooltip_img.Source = new BitmapImage(new Uri(@"/" + img, UriKind.Relative));
                toolTipPanel.Children.Add(tooltip_img);
            }
            
            toolTip.Content = toolTipPanel;
            return toolTip;
        } 

        private void initDefaultSettings()
        {
            ToolTip toolTip;
            Image tooltip_img;
            StackPanel toolTipPanel;
            int tooltip_fontsize = 14;
            int tooltip_subfontsize = 12;

      
            // Materials tab ----------------------------------------------------------------------------------------------------------------------------------
            materialGrade.SelectedIndex = 2;


            // Design factors ----------------------------------------------------------------------------------------------------------------------------------

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Partial factor for resistance of\ncross-sections whatever the class is", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            gamma_m0.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Partial factor for resistance of members\nto instability assessed by member checks", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            gamma_m1.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTip.Width = 245;
            toolTip.Height = 292;
            toolTipPanel = new StackPanel();
            tooltip_img = new Image();
            tooltip_img.Source = new BitmapImage(new Uri(@"/img/lim_H.jpg", UriKind.Relative));
            toolTipPanel.Children.Add(tooltip_img);
            toolTip.Content = toolTipPanel;
            H_lim.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Minimum allowed utilization will\nbe used in all design checks", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            min_unility.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Minimum allowed section width\nduring profile optimization process", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            opt_min_sec_w.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Maximum allowed section width\nduring profile optimization process", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            opt_max_sec_w.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Minimum allowed section height\nduring profile optimization process", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            opt_min_sec_h.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Maximum allowed section height\nduring profile optimization process", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            opt_max_sec_h.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Maximum allowed weight of column per length\nduring profile optimization process", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            opt_max_wm.ToolTip = toolTip;

            // Members Tab ------------------------------------------------------------------------------------------------------------------------------------

            profile_database.SelectedIndex = 0;
            contentData.member_table = new initMemberTable(table_members_content);

            member_table_H.ToolTip = tableHeaderTooltip("Column height", "", tooltip_fontsize);
            member_table_Lcrx.ToolTip = tableHeaderTooltip("Nominal buckling length factor for flexure about y axis", "", tooltip_fontsize);
            member_table_Lcry.ToolTip = tableHeaderTooltip("Nominal buckling length factor for flexure about x axis", "", tooltip_fontsize);
            member_table_Bwy.ToolTip = tableHeaderTooltip("Side width along y axis for\ndistributed load", "img/Bwy_guide.jpg", tooltip_fontsize);
            member_table_Bwx.ToolTip = tableHeaderTooltip("Side width along x axis for\ndistributed load", "img/Bwx_guide.jpg", tooltip_fontsize);
            member_table_Bty.ToolTip = tableHeaderTooltip("Top loading area side\nalong y axis", "img/Bty_guide.png", tooltip_fontsize);
            member_table_Btx.ToolTip = tableHeaderTooltip("Top loading area side\nalong x axis", "img/Btx_guide.jpg", tooltip_fontsize);
            member_table_copy.ToolTip = tableHeaderTooltip("Duplicate row properties for all other rows", "", tooltip_fontsize);
            member_table_delete.ToolTip = tableHeaderTooltip("Delete table row", "", tooltip_fontsize);

            // Loads Tab ------------------------------------------------------------------------------------------------------------------------------------
            contentData.load_member = load_member;
            contentData.load_table = new initLoadTable(table_loads_content);

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Identificator for Load Combinations:", FontSize = tooltip_fontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "DL - Dead Load", FontSize = tooltip_subfontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "LL - Live Load", FontSize = tooltip_subfontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "SL - Snow Load", FontSize = tooltip_subfontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "WL - Wind Load", FontSize = tooltip_subfontsize });
            toolTip.Content = toolTipPanel;
            load_table_header_load_type.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Load applied to column", FontSize = tooltip_fontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "Fz - Vertical concentrated load", FontSize = tooltip_subfontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "Fx - Horizontal concentrated load along x axis", FontSize = tooltip_subfontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "Fy - Horizontal concentrated load along y axis", FontSize = tooltip_subfontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "DLx - Distributed load on column side along x axis", FontSize = tooltip_subfontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "DLy - Distributed load on column side along y axis", FontSize = tooltip_subfontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "pz - Pressure load on the top loading area", FontSize = tooltip_subfontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "px - Pressure load on the side loading area along x axis", FontSize = tooltip_subfontsize });
            toolTipPanel.Children.Add(new TextBlock { Text = "py - Pressure load on the side loading area along y axis", FontSize = tooltip_subfontsize });
            toolTip.Content = toolTipPanel;
            load_table_header_load_way.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Load value for selected load way", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            load_table_header_load_value.ToolTip = toolTip;

            load_table_header_load_ex.ToolTip = tableHeaderTooltip("Eccentricity along x axis\nfor vertical load Fz", "img/ex_guide.jpg", tooltip_fontsize);

            load_table_header_load_ey.ToolTip = tableHeaderTooltip("Eccentricity along y axis\nfor vertical load Fz", "img/ey_guide.jpg", tooltip_fontsize);

            load_table_header_load_shift.ToolTip = tableHeaderTooltip("Position of horizontal load F\nfrom top of the column", "img/Fh_guide.jpg", tooltip_fontsize);

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Notes about the applied load", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            load_table_header_load_description.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Duplicate the filled table data for all other members", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            load_btn_copy_for_all.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Delete row", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            load_table_delete.ToolTip = toolTip;

            // Loads Combos ------------------------------------------------------------------------------------------------------------------------------------

            contentData.load_combos = new initCombosTable(table_combos_content);

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Load combination factor", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            combo_table_header_DL.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Load combination factor", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            combo_table_header_LL.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Load combination factor", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            combo_table_header_WL.ToolTip = toolTip;

            toolTip = new ToolTip();
            toolTipPanel = new StackPanel();
            toolTipPanel.Children.Add(new TextBlock { Text = "Load combination factor", FontSize = tooltip_fontsize });
            toolTip.Content = toolTipPanel;
            combo_table_header_SL.ToolTip = toolTip;



            // Design Tab ------------------------------------------------------------------------------------------------------------------------------------
            contentData.design_table = new initDesignTable(table_design_content);

        }





    }
}
