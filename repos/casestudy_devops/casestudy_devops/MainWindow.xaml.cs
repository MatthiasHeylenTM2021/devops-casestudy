using casestudy_devops.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace casestudy_devops
{
    public partial class MainWindow : Window
    {
        private Monster myMonster;
        private Monster enemyMonster;
        private MonsterDataContext context;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            Random rnd = new Random();
            int myMonsterNumber = rnd.Next(1, 6);
            int enemyMonsterNumber = rnd.Next(1, 6);

            context = new MonsterDataContext();
            myMonster = context.Monsters.Include(m => m.Moves).Include(m => m.Type).SingleOrDefault(m => m.Id == myMonsterNumber);
            enemyMonster = context.Monsters.Include(m => m.Moves).Include(m => m.Type).SingleOrDefault(m => m.Id == enemyMonsterNumber);
            myMonster = new MonsterMaker(myMonster, context).CreateMonster(myMonster.Type.Id);
            enemyMonster = new MonsterMaker(enemyMonster, context).CreateMonster(enemyMonster.Type.Id);
            output.Text = "Your monster: " + myMonster.Name;
            output.Text += "\nHP: " + myMonster.HP + "\tATK: " + myMonster.Attack + "\tDEF: " + myMonster.Defense + "\tType: " + myMonster.Type.Name;
            output.Text += "\nEnemy monster: " + enemyMonster.Name;
            output.Text += "\nHP: " + enemyMonster.HP + "\tATK: " + enemyMonster.Attack + "\tDEF: " + enemyMonster.Defense + "\tType: " + enemyMonster.Type.Name;
            output.Text += "\n-------------";
            listBox.DataContext = new { Moves = myMonster.Moves.ToList() };
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            var multiplier = checkMonster(myMonster);
            if (listBox.Items.Count != 0 && listBox.SelectedItem != null)
            {
                Move move = listBox.SelectedItem as Move;
                Random rand = new Random();
                int index = rand.Next(0, enemyMonster.Moves.Count);
                Move enemyMove = enemyMonster.Moves.ElementAt(index);
                Random rnd = new Random();
                int damageAddNumber = rnd.Next(1, 8);
                var damageToEnemy = (int)((((move.Damage * myMonster.Attack) / (10 * enemyMonster.Defense)) + damageAddNumber) * multiplier);
                multiplier = checkMonster(enemyMonster);
                var damageToMe = (int)((((enemyMove.Damage * enemyMonster.Attack) / (10 * myMonster.Defense)) + damageAddNumber) * multiplier);
                enemyMonster.HP -= damageToEnemy;
                myMonster.HP -= damageToMe;
                string winner = "";
                if (enemyMonster.HP <= 0)
                {
                    winner = myMonster.Name;
                    MessageBox.Show("Congratulations, you won!");
                    output.Text = "";
                    listBox.DataContext = null;
                }
                else if (myMonster.HP <= 0)
                {
                    winner = enemyMonster.Name;
                    MessageBox.Show("Too bad, you lost!");
                    output.Text = "";
                    listBox.DataContext = null;

                }
                else
                {
                    output.Text += "\nYour monster deals: " + damageToEnemy.ToString() + " to the enemy monster";
                    output.Text += "\n" + enemyMonster.Name + " has " + enemyMonster.HP + " HP remaining";
                    output.Text += "\nEnemy monster uses: " + enemyMove.Name + "!!";
                    output.Text += "\nEnemy monster deals: " + damageToMe.ToString() + " to my monster";
                    output.Text += "\n" + myMonster.Name + " has " + myMonster.HP + " HP remaining";
                    output.Text += "\n---";
                }
                if (!string.IsNullOrEmpty(winner))
                {
                    var result = new BattleResult
                    {
                        Winner = winner,
                        Date = DateTime.Now
                    };
                    context.BattleResults.Add(result);
                    context.SaveChanges();
                }
                viewer.ScrollToBottom();
            }
        }

        private double checkMonster(Monster monster)
        {
            if (monster is FireMonster fireMonster)
            {
                double multiplier = fireMonster.effectivenessMultiplier();
                return multiplier;
            }
            else if (monster is WaterMonster waterMonster)
            {
                double multiplier = waterMonster.effectivenessMultiplier();
                return multiplier;
            }
            else if (monster is SteelMonster steelMonster)
            {
                double multiplier = steelMonster.effectivenessMultiplier();
                return multiplier;
            }
            return 0;
        }
    }
}
