using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using GameLogic;

namespace SnakeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Thread keyboardThread = new Thread(new ThreadStart(getDirection));
        Ellipse food;
        List<Ellipse> body;
        static Direction direction = new Direction();

        public MainMenu mainMenu;
        public SettingsControl sControl;

        public MainWindow()
        {
            InitializeComponent();
            mainMenu = new MainMenu(this);
            sControl = new SettingsControl(this);

            keyboardThread.SetApartmentState(ApartmentState.STA);
            keyboardThread.IsBackground = true;
            keyboardThread.Start();

            contentControl.Content = mainMenu;

            video.Play();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            keyboardThread.Interrupt();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            keyboardThread.Interrupt();
        }

        Game game;
        public async void Process()
        {
            NewGame();

            while (true)
            {
                PrintSnake();  // Рисуется новый
                PrintFood();
                field.Children.Add(food);
                lCounter.Content = "Счет: " + game.counter;

                game.NextDirection = direction;
                await Task.Run(() => game.Process()); // В игре делается ход

                if ((game.isGameOver) || (isEscape))
                {
                    break;
                }

                DeletePrint(); // Удаляется предыдущий ход
            }

            lGameOver.Visibility = Visibility.Visible;
        }

        void NewGame()
        {
            game = new Game();
            direction = Direction.Right;
            body = new List<Ellipse>();
            food = new Ellipse();
            isEscape = false;
            lGameOver.Visibility = Visibility.Hidden;

            field.Children.Clear();
            CreateField();
        }

        void DeletePrint()
        {
            foreach (var b in body)
            {
                field.Children.Remove(b);
            }
            body = new List<Ellipse>();

            field.Children.Remove(food);
        }

        void PrintFood()
        {
            food = new Ellipse();
            food.HorizontalAlignment = HorizontalAlignment.Stretch;
            food.VerticalAlignment = VerticalAlignment.Stretch;

            food.Fill = sControl.fillFood;

            food.Margin = new Thickness(7, 7, 7, 7);

            Grid.SetRow(food, game.field.food.Y);
            Grid.SetColumn(food, game.field.food.X);
        }


        public void PrintSnake()
        {
            for (int i = 0; i < game.field.snake.Body.Count; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.HorizontalAlignment = HorizontalAlignment.Stretch;
                ellipse.VerticalAlignment = VerticalAlignment.Stretch;

                ellipse.Fill = sControl.fillSnake;

                Grid.SetRow(ellipse, game.field.snake.Body[i].Y);
                Grid.SetColumn(ellipse, game.field.snake.Body[i].X);

                ellipse.Margin = new Thickness(3, 3, 3, 3);

                body.Add(ellipse);

                field.Children.Add(ellipse);

            }
            body[body.Count-1].Stroke = Brushes.Black;
            body[body.Count - 1].StrokeThickness = 3;
        }

        static void getDirection()
        {
            while (true)
            {
                if ((Keyboard.IsKeyDown(Key.Down)) && (direction != Direction.Bottom))
                    direction = Direction.Bottom;
                if ((Keyboard.IsKeyDown(Key.Up)) && (direction != Direction.Top))
                    direction = Direction.Top;
                if ((Keyboard.IsKeyDown(Key.Left)) && (direction != Direction.Left))
                    direction = Direction.Left;
                if ((Keyboard.IsKeyDown(Key.Right)) && (direction != Direction.Right)) 
                    direction = Direction.Right;
            }
        }

        void CreateField()
        {
            RowDefinitionCollection rd = field.RowDefinitions;
            ColumnDefinitionCollection cd = field.ColumnDefinitions;
            rd.Clear();
            cd.Clear();

            for (int i = 0; i < game.field.x + 2; i++)
            {
                cd.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int j = 0; j < game.field.y + 2; j++)
            {
                rd.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }

            AddUnits();
            AddHorizontalWalls();
            AddVerticalWalls(); 
        }

        void AddUnits()
        {
            for (int i = 0; i < game.field.y + 2; i++)
            {
                for (int j = 0; j < game.field.x + 2; j++)
                {
                    Rectangle rect = CreateFieldUnit(sControl.fillField);

                    field.Children.Add(rect);

                    Grid.SetRow(rect, i);
                    Grid.SetColumn(rect, j);
                }
            }
        }

        void AddVerticalWalls()
        {
            for (int i = 0; i < game.field.x + 2; i++)
            {
                Rectangle rect = CreateFieldUnit(Brushes.Black);
                Rectangle rect1 = CreateFieldUnit(Brushes.Black);

                Grid.SetRow(rect, game.field.y + 2);
                Grid.SetColumn(rect, i);
                field.Children.Add(rect);


                Grid.SetRow(rect1, 0);
                Grid.SetColumn(rect1, i);
                field.Children.Add(rect1);
            }
        }

        void AddHorizontalWalls()
        {
            for (int i = 1; i < game.field.y + 1; i++)
            {
                Rectangle rect = CreateFieldUnit(Brushes.Black);
                Rectangle rect1 = CreateFieldUnit(Brushes.Black);

                Grid.SetRow(rect, i);
                Grid.SetColumn(rect, game.field.x + 2);
                field.Children.Add(rect);

                Grid.SetRow(rect1, i);
                Grid.SetColumn(rect1, 0);
                field.Children.Add(rect1);
            }
        }

        Rectangle CreateFieldUnit(Brush br)
        {
            Rectangle rect = new Rectangle();
            rect.Stroke = br;
            rect.Fill = br;

            if (br == Brushes.Black)
            rect.Opacity = 0.30;

            rect.Stroke = Brushes.Black;

            rect.HorizontalAlignment = HorizontalAlignment.Stretch;
            rect.VerticalAlignment = VerticalAlignment.Stretch;
            rect.StrokeThickness = 1;

            return rect;
        }

        void EscapeToMainMenu()
        {
            isEscape = true;
            contentControl.Content = mainMenu;
            gameGrid.Visibility = Visibility.Hidden;
            contentControl.Visibility = Visibility.Visible;
        }

        bool isEscape = false;
        private void buttonEsc_Click(object sender, RoutedEventArgs e)
        {
            video.Play();
            video.Visibility = Visibility.Visible;

            EscapeToMainMenu();
        }

        private void buttonAgain_Click(object sender, RoutedEventArgs e)
        {
            isEscape = true;
            mainMenu.StartGame();
        }
    }
}
