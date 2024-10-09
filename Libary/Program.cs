using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Libary;

namespace Libary
{
    interface IIdentifiable //Для уникального ID для каждого медиа
    {
        int UnId();
    }

    interface ISerializable //Сохранение всех Media и User-ов в txt-файл
    {
        void SaveToFile(string filename);
    }

    interface IReportable //Для реализации отчетов
    {
        List<Media> SearchMedia(Func<Media, bool> criteria);
    }

    interface IPenaltyApplicable //Для реализации штрафов за просрочку
    {
        int Penalty(Media media);
    }

    interface INotifiable //Для напоминания о скорой просрочке
    {
        void Notifiable(Media media);
    }


    //------------------------------------------------------

    sealed class LibrarySystem //Основной класс для взаимодействия с пользователем и работы системы.
    {
        //Для создания единственного экземпляра
        private static LibrarySystem _instance; // Единственный экземпляр
        private static readonly object _lock = new object(); // Для обеспечения потокобезопасности

        // Статический метод для получения единственного экземпляра класса
        public static LibrarySystem GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock) // Потокобезопасная инициализация
                {
                    if (_instance == null)
                    {
                        _instance = new LibrarySystem();
                    }
                }
            }
            return _instance;
        }
        //-----------------------------------------------------------------

        private List<Media> _mediaCollection; //Коллекция всех медиа
        private List<User> _users; //Список пользователей

        public List<Media> MediaCollection { get => _mediaCollection; }
        public List<User> Users { get => _users; }

        private LibrarySystem()
        {
            _mediaCollection = new List<Media>();
            _users = new List<User>();
        }

        private LibrarySystem(List<Media> _mediaCollection, List<User> _users)
        {
            this._mediaCollection = _mediaCollection;
            this._users = _users;
        }

        public void SaveToTextFile(string filePath = "C:\\Users\\user\\Source\\Repos\\Libary\\Libary\\AllMedia.txt")
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in _mediaCollection)
                {
                    writer.WriteLine(item.ToString());
                }
            }
            Console.WriteLine($"Данные сохранены в файл {filePath}");
        }

        public void AddMedia(Media media) //Метод для добавления нового медиа в библиотеку
        {
            _mediaCollection.Add(media);
        }
        public void RegisterUser(User user) //Метод для регистрации нового пользователя
        {
            _users.Add(user);
        }
        public List<Media> SearchMedia(Func<Media, bool> criteria) //Поиск медиа по различным критериям с использованием лямбд
        {
            return _mediaCollection.Where(criteria).ToList();
        }
        public List<Media> SortMedia(Comparison<Media> comparison) //Сортировка медиа по заданному критерию
        {
            var sortedList = _mediaCollection.ToList();
            sortedList.Sort(comparison);
            return sortedList;
        }
        public void GenerateReport() //Генерация отчета по выданным и просроченным медиа
        {
            Console.WriteLine("Все выданные медиа: ");
            foreach (Media media in _mediaCollection)
                media.DisplayInfo();

            Console.WriteLine("Просроченные медиа: ");
            foreach (Media media in _mediaCollection)
                if (media.IsOverdue())
                    media.DisplayInfo();
        }

    }

    //------------------------------------------------------

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Старт");
        }
    }
}
