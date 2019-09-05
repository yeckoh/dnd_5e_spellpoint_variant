using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace spellpoint_var_v3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public struct dailies
    {
        public bool s6;
        public bool s7;
        public bool e8;
        public bool n9;
    }

    public class spelllist
    {
        public int spelllvl { get; set; }
        public int castsleft { get; set; }
        public int cost { get; set; }
        //private int i;
        //private int v;

        public spelllist(int i, int v)
        {
            this.spelllvl = i;
            this.castsleft = v;
        }
    }

    public partial class MainWindow
    {

        public List<string> classList = new List<string>();
        public List<int> lvlList = new List<int>();
        //public List<int> spelllvl = new List<int>();
        public List<spelllist> spells = new List<spelllist>();
        int[] lvlToPoints = new int[21] {0,4,6,14,17,27,32,38,44,57,64,73,73,83,83,94,94,107,114,123,133};
        int maxspell = 0;
        dailies daylys;
        int totalcost = 0;

        public MainWindow()
        {
            InitializeComponent();

            startup();


        }



        public void startup()
        {
            lv_class.ItemsSource = classList;
            classList.Add("Bard, Cleric, Druid");
            classList.Add("Sorcerer");
            classList.Add("Wizurd");
            classList.Add("Paladin, Ranger");
            classList.Add("Eldritch knight, Arcane trikztr");


            lv_lvl.ItemsSource = lvlList;
            for(int i = 1; i <= 20; i++)
            {
                lvlList.Add(i);
            }

            lv_class.SelectedIndex = 0;
            lv_lvl.SelectedIndex = 0;

            lv_class.Items.Refresh();
            lv_lvl.Items.Refresh();

            lbl_class.Content = lv_class.SelectedItem.ToString();
            lbl_lvl.Content = lv_lvl.SelectedItem.ToString();

            cb_care.ToolTip = "Spells requiring a saving throw, you can force creatures to succeed.\nMax creature count = your CHA mod.";
            cb_dist.ToolTip = "Spells with range of +5ft, double spell range.\nTouch spells gain a range of 30ft.";
            cb_ext.ToolTip = "Spells with duration of 1+ min, double its duration.\nMax duration of an extended spell is 24hrs.";
            cb_hgt.ToolTip = "Spells requiring a saving throw, give one target disadvantage on its first save.";
            cb_qck.ToolTip = "Spells with casting time of 1 action, change it to a bonus action.";
            cb_sbt.ToolTip = "Spells cast without somatic or verbal components.";
            cb_twn.ToolTip = "Spells that targets a single creature and doesn't have a range of self, target a 2nd creature within range\nCost = spell lvl(or 1 for cantrips).";
            cb_pwr.ToolTip = "REEroll damage dice up to your CHA mod.\nYou must use the new rolls.";
            btn_recovery.ToolTip = "Wizurds can REEEEE during a short rest.\nLeftover points are saved.";
            btn_reset.ToolTip = "Long rest / Reset";
            btn_topmost.ToolTip = "Keep this app ontop when out of focus";

        }

        // set spellpoints, casterlvl, spellslots
        public void doStuff()
        {
            daylys.s6 = daylys.s7 = daylys.e8 = daylys.n9 = false;
            btn_recovery.Visibility = lbl_recover.Visibility = lbl_plus.Visibility = Visibility.Hidden;
            sorcgrid.Visibility = Visibility.Hidden;
            int lvl = Convert.ToInt16(lbl_lvl.Content);
            string classs = lbl_class.Content.ToString();
            //lvl++;
            if (classs == "Paladin, Ranger")
                lvl = (lvl + 1) / 2;
            else if (classs == "Eldritch knight, Arcane trikztr")
                lvl = (lvl + 2) / 3;
                lbl_castlvl.Content = lvl;

            maxspell = (lvl + 1) / 2;
            if (maxspell >= 10)
                maxspell = 9;

            pgbar.Maximum = lvlToPoints[lvl];
            pgbar.Value = lvlToPoints[lvl];

            if (classs == "Wizurd")
            {
                btn_recovery.IsEnabled = true;
                lbl_recover.Content = lvlToPoints[maxspell];
                btn_recovery.Visibility = lbl_recover.Visibility = lbl_plus.Visibility = Visibility.Visible;
            }

            //lvl--;
            if (classs == "Sorcerer")
            {
                pgbar.Maximum += lvl;
                pgbar.Value += lvl;
                // stuff becomes visible
                sorcgrid.Visibility = Visibility.Visible;
            }

            //lbl_pts.Content = pgbar.Maximum + "/" + pgbar.Value;
            lbl_pts.Content = pgbar.Value + "/" + pgbar.Maximum;

            //spelllvl.Clear();
            spells.Clear();
            for(int i = 0; i <= maxspell; i++)
            {
                //spelllvl.Add(i);
                spells.Add(new spelllist(i, 0));
            }

            for(int i = 0;i < spells.Count; i++)
            {
                int cccost = 0;
                switch (i)
                {
                    case 0:
                        cccost = 0;
                        break;
                    case 1:
                        cccost = 2;
                        break;
                    case 2:
                        cccost = 3;
                        break;
                    case 3:
                        cccost = 5;
                        break;
                    case 4:
                        cccost = 6;
                        break;
                    case 5:
                        cccost = 7;
                        break;
                    case 6:
                        cccost = 9;
                        break;
                    case 7:
                        cccost = 10;
                        break;
                    case 8:
                        cccost = 11;
                        break;
                    case 9:
                        cccost = 13;
                        break;
                }
                spells[i].cost = cccost;
            }

            switch (maxspell)
            {
                case 6: daylys.s6 = true;
                    break;
                case 7: daylys.s7 = true;
                    daylys.s6 = true;
                    break;
                case 8: daylys.e8 = true;
                    daylys.s7 = true;
                    daylys.s6 = true;
                    break;
                case 9: daylys.n9 = true;
                    daylys.e8 = true;
                    daylys.s7 = true;
                    daylys.s6 = true;
                    break;
                default: break;
            }
            //lv_spells.ItemsSource = spelllvl;
            updatecasts();
            lv_spells.ItemsSource = spells;
            lv_spells.Items.Refresh();
            //MessageBox.Show("spell item count is " + spells.Count);
            //MessageBox.Show("lv_spell item count is " + lv_spells.Items.Count);
        }

        public void updatecasts()
        {
            // update castsleft
            spelllist current;
            for (int i = 0; i < spells.Count; i++)
            {
                if (spells[i] != null)
                    switch (i)
                    {
                        case 0: break;
                        case 1:
                            current = spells[i];
                            current.castsleft = (int)pgbar.Value / 2;
                            break;
                        case 2:
                            current = spells[i];
                            current.castsleft = (int)pgbar.Value / 3;
                            break;
                        case 3:
                            current = spells[i];
                            current.castsleft = (int)pgbar.Value / 5;
                            break;
                        case 4:
                            current = spells[i];
                            current.castsleft = (int)pgbar.Value / 6;
                            break;
                        case 5:
                            current = spells[i];
                            current.castsleft = (int)pgbar.Value / 7;
                            break;
                        case 6:
                            current = spells[i];
                            current.castsleft = 1;
                            break;
                        case 7:
                            current = spells[i];
                            current.castsleft = 1;
                            break;
                        case 8:
                            current = spells[i];
                            current.castsleft = 1;
                            break;
                        case 9:
                            current = spells[i];
                            current.castsleft = 1;
                            break;

                    }
            }
        }

        public void updatecost()
        {
            int costval = 0;
            switch (lv_spells.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    costval = 2;
                    break;
                case 2:
                    costval = 3;
                    break;
                case 3:
                    costval = 5;
                    break;
                case 4:
                    costval = 6;
                    break;
                case 5:
                    costval = 7;
                    break;
                case 6:
                    costval = 9;
                    break;
                case 7:
                    costval = 10;
                    break;
                case 8:
                    costval = 11;
                    break;
                case 9:
                    costval = 13;
                    break;
            }
            // update twincost
            lbl_twin.Content = "+" + lv_spells.SelectedIndex;
            if (lv_spells.SelectedIndex == 0)
                lbl_twin.Content = "+1";

                // metamagic goes here
                int mmcost = 0;
            if (cb_care.IsChecked == true)
                mmcost++;
            if (cb_dist.IsChecked == true)
                mmcost++;
            if (cb_ext.IsChecked == true)
                mmcost++;
            if (cb_sbt.IsChecked == true)
                mmcost++;
            if (cb_pwr.IsChecked == true)
                mmcost++;
            if (cb_hgt.IsChecked == true)
                mmcost += 3;
            if (cb_qck.IsChecked == true)
                mmcost += 2;
            if (cb_twn.IsChecked == true)
            {
                mmcost += lv_spells.SelectedIndex;
                if (lv_spells.SelectedIndex == 0)
                    mmcost++;
            }
            totalcost = costval + mmcost;
            lb_cost.Content = "-" + totalcost;
        }



        private void btn_fly_Click(object sender, RoutedEventArgs e)
        {
            classflyout.IsOpen = true;
        }

        private void lv_class_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // class has just been selected here
            lbl_class.Content = lv_class.SelectedItem.ToString();
            doStuff();
        }

        private void btn_lvl_Click(object sender, RoutedEventArgs e)
        {
            lvlflyout.IsOpen = true;
        }

        private void lv_lvl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // lvl selection has just happened here
            lbl_lvl.Content = lv_lvl.SelectedItem.ToString();
            doStuff();
        }

        private void lv_spells_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // spell level has just been selected, update cost deduction
            updatecost();
        }

        private void btn_topmost_Click(object sender, RoutedEventArgs e)
        {
            Topmost = !Topmost;
            if (Topmost)
                btn_topmost.Content = "topmost on";
            else btn_topmost.Content = "topmost off";
        }

        private void btn_cast_Click(object sender, RoutedEventArgs e)
        {
            //int macks = (int)pgbar.Maximum;
            //int left = (int)pgbar.Value;
            /*switch (lv_spells.SelectedIndex)
            {
                case 0:
                    //pgbar.Value -= 2;
                    break;
                case 1:
                    pgbar.Value -= 2;
                    break;
                case 2:
                    pgbar.Value -= 3;
                    break;
                case 3:
                    pgbar.Value -= 5;
                    break;
                case 4:
                    pgbar.Value -= 6;
                    break;
                case 5:
                    pgbar.Value -= 7;
                    break;
                case 6:
                    pgbar.Value -= 9;
                    break;
                case 7:
                    pgbar.Value -= 10;
                    break;
                case 8:
                    pgbar.Value -= 11;
                    break;
                case 9:
                    pgbar.Value -= 13;
                    break;
            }*/
            pgbar.Value += Convert.ToInt16(lb_cost.Content);

            // update pointsleft
            lbl_pts.Content = pgbar.Value + "/" + pgbar.Maximum;
            
            // remove uncastable
            if (pgbar.Value < 13 && spells.Count == 10)
                spells.RemoveAt(9); //spelllvl.Remove(9);
            if (pgbar.Value < 11 && spells.Count == 9)
                spells.RemoveAt(8); //spelllvl.Remove(8);
            if (pgbar.Value < 10 && spells.Count == 8)
                spells.RemoveAt(7); //spelllvl.Remove(7);
            if (pgbar.Value < 9 && spells.Count == 7)
                spells.RemoveAt(6); //spelllvl.Remove(6);
            if (pgbar.Value < 7 && spells.Count == 6)
                spells.RemoveAt(5); //spelllvl.Remove(5);
            if (pgbar.Value < 6 && spells.Count == 5)
                spells.RemoveAt(4); //spelllvl.Remove(4);
            if (pgbar.Value < 5 && spells.Count == 4)
                spells.RemoveAt(3); //spelllvl.Remove(3);
            if (pgbar.Value < 3 && spells.Count == 3)
                spells.RemoveAt(2); //spelllvl.Remove(2);
            if (pgbar.Value < 2 && spells.Count == 2)
                spells.RemoveAt(1); //spelllvl.Remove(1);

            switch (lv_spells.SelectedIndex)
            {
                case 9: daylys.n9 = false;
                    spells.RemoveAt(lv_spells.SelectedIndex);
                    break;
                case 8: daylys.e8 = false;
                    spells.RemoveAt(lv_spells.SelectedIndex);
                    break;
                case 7: daylys.s7 = false;
                    spells.RemoveAt(lv_spells.SelectedIndex);
                    break;
                case 6:
                    daylys.s6 = false;
                    spells.RemoveAt(lv_spells.SelectedIndex);
                    break;
                default: break;
            }
            // update castsleft
            updatecasts();

            lv_spells.Items.Refresh();
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            lv_lvl_SelectionChanged(sender, null);
        }

        private void btn_recovery_Click(object sender, RoutedEventArgs e)
        {
            double missing = pgbar.Maximum - pgbar.Value;
            double left = missing - (int)lbl_recover.Content;
            if (left >= 0)
            {
                pgbar.Value += (int)lbl_recover.Content;
                lbl_recover.Content = 0;
            }
            else
            {
                pgbar.Value += (int)missing;
                lbl_recover.Content = (int)Math.Abs(left);
            }
            lbl_pts.Content = pgbar.Value + "/" + pgbar.Maximum;
            //int placeholder = lv_spells.SelectedIndex;
            spells.Clear();
            for (int i = 0; i <= maxspell;i++)
            {
                if (i == 1 && pgbar.Value < 2) continue;
                if (i == 2 && pgbar.Value < 3) continue;
                if (i == 3 && pgbar.Value < 5) continue;
                if (i == 4 && pgbar.Value < 6) continue;
                if (i == 5 && pgbar.Value < 7) continue;
                if (i == 6 && !daylys.s6) continue;
                if (i == 7 && !daylys.s7) continue;
                if (i == 8 && !daylys.e8) continue;
                if (i == 9 && !daylys.n9) continue;
                spells.Add(new spelllist(i, 0));
            }

            updatecasts();
            if(lbl_recover.Content.ToString() == "0")
                btn_recovery.IsEnabled = false;
            lv_spells.SelectedIndex = 0;
            lv_spells.Items.Refresh();
        }

        private void cb_care_Click(object sender, RoutedEventArgs e)
        {
            updatecost();
        }

        private void cb_dist_Click(object sender, RoutedEventArgs e)
        {
            updatecost();
        }

        private void cb_ext_Click(object sender, RoutedEventArgs e)
        {
            updatecost();
        }

        private void cb_hgt_Click(object sender, RoutedEventArgs e)
        {
            updatecost();
        }

        private void cb_qck_Click(object sender, RoutedEventArgs e)
        {
            updatecost();
        }

        private void cb_sbt_Click(object sender, RoutedEventArgs e)
        {
            updatecost();
        }

        private void cb_twn_Click(object sender, RoutedEventArgs e)
        {
            updatecost();
        }

        private void cb_pwr_Click(object sender, RoutedEventArgs e)
        {
            updatecost();
        }

        private void btn_mmclear_Click(object sender, RoutedEventArgs e)
        {
            cb_care.IsChecked = cb_dist.IsChecked = cb_ext.IsChecked = cb_hgt.IsChecked = cb_qck.IsChecked = cb_sbt.IsChecked = cb_twn.IsChecked = cb_pwr.IsChecked = false;
            updatecost();
        }

        private void btn_manual_Click(object sender, RoutedEventArgs e)
        {
            if (tb_manual.Text == "")
                return;
            int doitmyself = 0;
            try
            {
                doitmyself = Convert.ToInt16(tb_manual.Text);
                pgbar.Value += doitmyself;
                lbl_pts.Content = pgbar.Value + "/" + pgbar.Maximum;
                spells.Clear();
                for (int i = 0; i <= maxspell; i++)
                {
                    if (i == 1 && pgbar.Value < 2) continue;
                    if (i == 2 && pgbar.Value < 3) continue;
                    if (i == 3 && pgbar.Value < 5) continue;
                    if (i == 4 && pgbar.Value < 6) continue;
                    if (i == 5 && pgbar.Value < 7) continue;
                    if (i == 6 && !daylys.s6) continue;
                    if (i == 7 && !daylys.s7) continue;
                    if (i == 8 && !daylys.e8) continue;
                    if (i == 9 && !daylys.n9) continue;
                    spells.Add(new spelllist(i, 0));
                }
                updatecasts();
                lv_spells.SelectedIndex = 0;
                lv_spells.Items.Refresh();
            }
            catch (Exception)
            {
                return;
            }

        }
    } // end.main stuff
} // end.namespace


