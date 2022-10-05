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
using InputOutputSystem;
using GameLogic;

namespace SnakeWPF
{
    /// <summary>
    /// Логика взаимодействия для SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        MainWindow mw;

        public SettingsControl(MainWindow _mw)
        {
            InitializeComponent();

            snake = new List<Ellipse>();
            field = new List<Rectangle>();
            food = ellipseFood;

            snake.Add(snake1);
            snake.Add(snake2);
            snake.Add(snake3);

            field.Add(rect1);
            field.Add(rect2);
            field.Add(rect3);
            field.Add(rect4);

            fillField = btn_field_color5.Fill;
            fillSnake = btn_snake_color5.Fill;
            fillFood = btn_food_color2.Fill;

            for (int i = 0; i < field.Count; i++)
            {
                field[i].Fill = fillField;
            }
            for (int i = 0; i < snake.Count; i++)
            {
                snake[i].Fill = fillSnake;
            }
            food.Fill = fillFood;

            mw = _mw;
        }

        public Brush fillField { get; private set; }
        public Brush fillSnake { get; private set; }
        public Brush fillFood { get; private set; }

        List<Ellipse> snake;
        List<Rectangle> field;
        Ellipse food;

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            mw.contentControl.Content = mw.mainMenu;
        }

        private void btn_field_colorN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            Brush sb = rect.Fill as Brush;

            for (int i = 0; i < field.Count; i++)
            {
                field[i].Fill = sb;
            }
        }

        private void btn_snake_colorN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            Brush sb = rect.Fill as Brush;

            for(int i = 0; i < snake.Count; i++)
            {
                snake[i].Fill = sb;
            }
        }

        private void btn_food_colorN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            Brush sb = rect.Fill as Brush;

            food.Fill = sb;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] line = new string[5];

            int i = 0;
            line[i] = cbLength.Text;
            i++;

            line[i] = cbField.Text;
            i++;

            if (rbYes_Speed.IsChecked == true)
                line[i] = "True";
            else line[i] = "False";
            i++;

            if (rbYes_CollWall.IsChecked == true)
                line[i] = "True";
            else line[i] = "False";
            i++;

            if (rbYes_CollTail.IsChecked == true)
                line[i] = "True";
            else line[i] = "False";

            fillField = field[0].Fill;
            fillSnake = snake[0].Fill;
            fillFood = food.Fill;

            SaveFile.SaveSettingsToTextFile(line);
        }

        public void ApplyLastSettings()
        {
            Settings.ApplySettings(ReadFile.ReadSettingsFromTextFile());


            cbLength.SelectedIndex = Settings.length - 3;

            string sizeField = Settings.x + "x" + Settings.y;
            switch (sizeField)
            {
                case "20x10": cbField.SelectedIndex = 0; break;
                case "30x15": cbField.SelectedIndex = 1; break;
                case "40x20": cbField.SelectedIndex = 2; break;
            }

            if (Settings.speedMode == true)
            {
                rbYes_Speed.IsChecked = true;
            }
            else rbNo_Speed.IsChecked = true;

            if (Settings.collisionTail == true)
            {
                rbYes_CollTail.IsChecked = true;
            }
            else rbNo_CollTail.IsChecked = true;

            if (Settings.collisionWalls == true)
            {
                rbYes_CollWall.IsChecked = true;
            }
            else rbNo_CollWall.IsChecked = true;
        }
    }
}
