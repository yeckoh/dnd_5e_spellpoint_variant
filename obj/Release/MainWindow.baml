   M S B A M L   `   `   `  ���� L  Hspellpoint_var_v3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:spellpoint_var_v3spellpoint_var_v3  "    spellpoint_var_v3.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  +localclr-namespace:spellpoint_var_v3    � Title$  Spellpoint var v3.0��$��465.167��$��314.666��(  "MahApps.Metro.Controls.MetroWindow   Flyouts +  %MahApps.Metro.Controls.FlyoutsControl  .@�#  MahApps.Metro.Controls.Flyout  -   $��classflyout��$��Classes��   Position$ Right=�$	��200��$y�	Collapsed=�   IsOpen .     Theme$
 Dark=�.��� .+��� -   $��lv_class��$
��Left=�$	��185��$��	10,10,0,0q�$	��Top=�$	��170�� �� View �� .P��� $��Class Selection�� �� Width$
 Auto��  -   $��	lvlflyout��$
��Lvls��$ Right=�$	��150��$y�	Collapsed=� .  $
 Dark=�.��� .+��� -   $��lv_lvl��$
��Left=�$	��350��$��	10,10,0,0q�$	��Top=�$��50�� �� .P��� $	��Lvl��$
 Auto��.��� ���	#FF151A1B.+��� -   $��btn_topmost��$��topmost off��$
��Left=�$��
10,345,0,0q�$	��Top=�$��98���� -   $��btn_fly��$��Class��   SquareButtonStyle#��[  $
��Left=�$��	10,10,0,0q�$	��Top=�$��75���� -   $	��Lvl��$
��Left=�$��	10,42,0,0q�$	��Top=�$��75���� -   $��	btn_reset��$��renew��$
��Left=�$��
233,46,0,0q�$	��Top=�$��60��� -	   $��pgbar��$
��Left=�$��10��$��	10,84,0,0q�$	��Top=�$	��250���� -
   $��	lbl_class��$��1��$
��Left=�$��	90,14,0,0q�$	��Top=��� -   $��lbl_lvl��$��1��$
��Left=�$��	90,46,0,0q�$	��Top=��� -   $��lbl_pts��$��numeric��$
��Left=�$��	10,99,0,0q�$	��Top=��� $��Caster Lvl: ��$
��Left=�$��
127,46,0,0q�$	��Top=��� -   $��lbl_castlvl��$��Label��$
��Left=�$��
192,46,0,0q�$	��Top=��� -   $��	lv_spells��$
��Left=�$	��174��$��
10,164,0,0q�$	��Top=�$	��130�� �� .P��� $��Level��$ 55�� �� DisplayMemberBinding �� *
spelllvl+�� $��Casts��$ 55�� �� *	castsleft+�� -   $��btn_cast��$
��Cast��  AccentedSquareButtonStyle#��[ $
��Left=�$��
10,132,0,0q�$	��Top=�$��75���� -   $��lb_cost��$��0��$
��Left=�$��	64,99,0,0q�$	��Top=��� -   $��btn_recovery��$��recoveREEEEEE��#��[  $
��Left=�$��160,121,0,0q�$	��Top=�$	��116���� -   $��lbl_recover��$��recoverynumber��$
��Left=�$��166,148,0,0q�$	��Top=��� -   $��lbl_plus��$��+��$
��Left=�$��154,148,0,0q�$	��Top=�� -   $��sorcgrid��$
��Left=�$	��261��$��149,111,0,0q�$	��Top=�$	��110��.+��� -   $��cb_care��$��Careful��$
��Left=�$��	27,55,0,0q�$	��Top=��� -   $��cb_dist��$��Distant��$
��Left=�$��	27,78,0,0q�$	��Top=��� -   $��cb_ext��$��Extendo��$
��Left=�$��
27,101,0,0q�$	��Top=��� -   $��cb_hgt��$��Heighten��$
��Left=�$��
27,124,0,0q�$	��Top=��� -   $��cb_qck��$��Quicken��$
��Left=�$��
27,147,0,0q�$	��Top=��� -   $��cb_sbt��$��Subtle��$
��Left=�$��
27,170,0,0q�$	��Top=��� -   $��cb_twn��$
��Twin��$
��Left=�$��
27,193,0,0q�$	��Top=��� -   $��cb_pwr��$��Empower��$
��Left=�$��
27,216,0,0q�$	��Top=��� -   $��btn_mmclear��$��Uncheck all��#��[  $
��Left=�$��	10,10,0,0q�$	��Top=�$��90���� $��+1��$
��Left=�$��3,53,0,0q�$	��Top=��� $��+1��$
��Left=�$��3,76,0,0q�$	��Top=��� $��+1��$
��Left=�$��3,99,0,0q�$	��Top=��� $��+3��$
��Left=�$��	3,122,0,0q�$	��Top=��� $��+2��$
��Left=�$��	3,145,0,0q�$	��Top=��� $��+1��$
��Left=�$��	3,168,0,0q�$	��Top=��� -   $��lbl_twin��$��+1��$
��Left=�$��	3,191,0,0q�$	��Top=��� $��+1��$
��Left=�$��	3,214,0,0q�$	��Top=��� -   $��	tb_manual��$
��Left=�$��23��$��
10,377,0,0q� �� TextWrapping$
 Wrap=�$�� ��*  $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$"	 Manually add/subtract points��$	��Top=�$	��173���� -    $��
btn_manual��$��Ok��#��[  $
��Left=�$��188,377,0,0q�$	��Top=�$��75��