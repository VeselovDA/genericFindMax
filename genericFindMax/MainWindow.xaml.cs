using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace genericFindMax
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Generation> dgList = new ObservableCollection<Generation>();//коллекция для таблицы
        int startRange;// начало диапозона
        int endRange;// конец диапозона
        int N;// переменная N(+ вариант)
        public MainWindow()
        {
            InitializeComponent();
            dgGeneration.ItemsSource = dgList;
            resetBtn_Click(resetBtn, null);

        }

        private void findMax_Click(object sender, RoutedEventArgs e)
        {

        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                startRange = Convert.ToInt32(textStartRange.Text);
                endRange= Convert.ToInt32(textEndRange.Text);
                N= Convert.ToInt32(textN.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Некореектный ввод");
            }
            if (startRange > endRange)
            {
                startRange ^= endRange; endRange ^= startRange; startRange ^= endRange;// поменять местами переменные
                MessageBox.Show("Переменные поменялись местами");
            }
            dgList.Clear();
            //dgGeneration.ItemsSource.Cle;
            Generation generation = new Generation(startRange, endRange);
            dgList.Add(generation);

        }
    }
}
