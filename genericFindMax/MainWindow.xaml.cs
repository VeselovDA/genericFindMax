﻿using System;
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
        int count = 0;// счетчик сбросов
        //bool Id = false;
        public MainWindow()
        {
            InitializeComponent();
            dgGeneration.ItemsSource = dgList;
            resetBtn_Click(resetBtn, null);

        }

        private void findMax_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Crossing crossing = new Crossing(dgList.Last());
                dgList.Add(crossing.startCrossing());
            }
            
            dgList.Add(dgList.Last().mutation());
           // dgGeneration.RowBackground = Brushes.Red;
            /*var row=dgGeneration.ItemContainerGenerator.ContainerFromIndex(1) as DataGrid;
            row.Background = Brushes.Red;*/




        }
      

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                startRange = Convert.ToInt32(textStartRange.Text);
                endRange= Convert.ToInt32(textEndRange.Text);
                
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

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
             count = 0;
            if(count==0)
             count++; 
            else
            resetBtn_Click(resetBtn, null);

        }
    }
}
