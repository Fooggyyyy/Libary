using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Libary
{
    abstract class Media //Абстрактный класс с Media, для выделения общих характерестик медиа.
    {
        //Поля

        //Далее для данных полей выдедить файлы с допустимыми значениями
        //Названия, автором, годом выпуска.
        private string _title; //Название медиа
        private string _author; //Имя автора
        private int _year; //Год выпуска

        private protected bool _isAvailable; //Доступность для вылачм

        //Свойства

        //Далее для данных полей выдедить файлы с допустимыми значениями
        //Названия, автором, годом выпуска. Подстроить под это set-ер

        public string Title { get => _title; set => _title = value; }
        public string Author { get => _author; set => _author = value; }
        public int Year { get => _year; set => _year = value; }
        public bool IsAvailable { get => _isAvailable; set => _isAvailable = value; }

        //Методы

        public abstract void DisplayInfo();//Абстрактный метод для отображения информации о медиа
        public virtual void Borrow() //Метод для взятия медиа
        { 

        } 
        public virtual void Return() // Метод для возврата медиа
        { 

        } 

    }

    //Далее наследники класса Media

    //------------------------------------------------------

    sealed class Book : Media //Класс книга
    {
        private int _pages; //Количество страиц

        public int Pages { get => _pages; set => _pages = value; }

        //Переопределенные методы
        public override void DisplayInfo()
        {

        }
        public override void Borrow() 
        {

        }
        public override void Return() 
        {

        }
    }

    sealed class Movie : Media //Класс фильм
    {
        private int _duration; //Длительность фильма в минутах

        public int Duration { get => _duration; set => _duration = value; }

        //Переопределенные методы
        public override void DisplayInfo()
        {

        }
        public override void Borrow()
        {

        }
        public override void Return()
        {

        }
    }
    sealed class Magazine : Media //Класс журнал
    {
        private int _issueNumber; //Номер выпуска журнала

        public int IssueNumber { get => _issueNumber; set => _issueNumber = value; }

        //Переопределенные методы
        public override void DisplayInfo()
        {

        }
        public override void Borrow()
        {

        }
        public override void Return()
        {

        }
    }

    //------------------------------------------------------

    sealed class User //Класс User, который будет взаимодействовать с наследниками класса Media (книги, фильмы, журналы
    {
        private string _name; //Имя пользователя
        private List<Media> _borrowedItems; //Список выданных медиа
        private const int _borrowLimit = 5; ///Лимит по количеству взятых медиа

        public string Name { get => _name; set => _name = value; }
        public List<Media> BorrowedItems { get => _borrowedItems; }

        public void BorrowItem(Media item) //Метод для взятия медиа
        {

        } 
        public void ReturnItem(Media item) //Метод для возврата медиа
        {

        }
        public List<Media> GetOverdueItems() //Метод для получения списка просроченных медиа
        {
            return _borrowedItems;
        }
    }

    sealed class LibrarySystem //основной класс для взаимодействия с пользователем и работы системы.
    {
        private static LibrarySystem _instance; //Экземпляр класса
        private List<Media> _mediaCollection; //Коллекция всех медиа
        private List<User> _users; //Список пользователей


        public static LibrarySystem Instance { get { if (_instance == null) _instance = new LibrarySystem(); return _instance; } }
        public List<Media> MediaCollection { get => _mediaCollection; }
        public List<User> Users { get => _users; }

  
        public void AddMedia(Media media) //Метод для добавления нового медиа в библиотеку
        {

        }
        public void RegisterUser(User user) //Метод для регистрации нового пользователя
        {

        }
        public List<Media> SearchMedia(Func<Media, bool> criteria) //Поиск медиа по различным критериям с использованием лямбд
        {
            return _mediaCollection;
        }
        public List<Media> SortMedia(Comparison<Media> comparison) //Сортировка медиа по заданному критерию
        {
            return _mediaCollection;
        }
        public void GenerateReport() //Генерация отчета по выданным и просроченным медиа
        {
           
        }
    }

    //------------------------------------------------------

    class Report //Класс для отчетности по всей библиотеке
    {
        public List<Media> GenerateBorrowedItemsReport() // Список всех выданных медиа
        {
            return new List<Media>();
        }
        public List<Media> GenerateOverdueItemsReport() // Список всех просроченных медиа
        {
            return new List<Media>();
        }
        public List<Media> GeneratePopularItemsReport() // Список популярных медиа на основе выданных
        {
            return new List<Media>();
        }
        public void SaveToFile(string filePath) // Сохранение данных в файл(JSON/XML)
        {

        }
        public void LoadFromFile(string filePath) // Загрузка данных из файла
        {

        }
    }

    //------------------------------------------------------

    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
