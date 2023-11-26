using System;
using System.Windows;
using System.Diagnostics;

namespace DamagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random random = new Random();
        SwordDamage swordDamage = new SwordDamage();

        public MainWindow()
        {
            InitializeComponent();
            swordDamage.SetMagic(false);
            swordDamage.SetFlaming(false);
            RollDice();
        }

        private void RollDice()
        {
            swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            swordDamage.SetFlaming(flaming.IsChecked.Value);
            swordDamage.SetMagic(flaming.IsChecked.Value);
            DisplayDamage();
        }

        private void DisplayDamage()
        {
            damage.Text = "Rolled " + swordDamage.Roll + " for " + swordDamage.Damage + " HP";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }

        private void Flaming_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.SetFlaming(true);
            DisplayDamage();
        }

        private void Flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.SetFlaming(false);
            DisplayDamage();
        }

        private void Magic_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.SetMagic(true);
            DisplayDamage();
        }

        private void Magic_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.SetMagic(false);
            DisplayDamage();
        }
    }
}
