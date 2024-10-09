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

    abstract class Media : IIdentifiable //Абстрактный класс с Media, для выделения общих характерестик медиа.
    {
        //Поля

        //Далее для данных полей выдедить файлы с допустимыми значениями
        //Названия, автором, годом выпуска.
        private protected string _title; //Название медиа
        private protected string _author; //Имя автора
        private protected int _year; //Год выпуска
        private protected bool _isAvailable; //Доступность для вылачм
        private protected DateTime _dueDate; //Крайняя дата возврата

        //Свойства

        //Далее для данных полей выдедить файлы с допустимыми значениями
        //Названия, автором, годом выпуска. Подстроить под это set-ер

        public string Title { get => _title; set => _title = value; }
        public string Author { get => _author; set => _author = value; }
        public int Year { get => _year; set => _year = value; }
        public bool IsAvailable { get => _isAvailable; set => _isAvailable = value; }

        //Методы

        public abstract void DisplayInfo();//Абстрактный метод для отображения информации о медиа
        public abstract int UnId();//С интерфейса, для уникального ID

        public virtual void Borrow() //Метод для взятия медиа
        {
            //Пустой, потому что все равно экземпляр не создадим
            //А Virtual, что бы попоробовать работоспособность метода доступа
        }
        public virtual void Return() // Метод для возврата медиа
        {
            //Пустой, потому что все равно экземпляр не создадим
            //А Virtual, что бы попоробовать работоспособность метода доступа
        }

        //Методы для проверки просрочки
        public void SetDueDate(int daysToReturn)
        {
            _dueDate = DateTime.Now.AddDays(daysToReturn);
        }

        public bool IsOverdue()
        {
            return DateTime.Now > _dueDate;
        }

    }

    //Далее наследники класса Media

    //------------------------------------------------------

    sealed class Book : Media //Класс книга
    {

        private int _pages; //Количество страиц

        public int Pages { get => _pages; set => _pages = value; }

        //Конструкторы
        public Book()
        {
            _title = "Не определено";
            _author = "Не определено";
            _year = -1;
            _pages = -1;
            _isAvailable = true;
            SetDueDate(int.MaxValue);
            int Id = UnId();
        }

        public Book(string _title, string _author, int _year, int _pages)
        {
            this._title = _title;
            this._author = _author;
            this._year = _year;
            this._pages = _pages;
            this._isAvailable = true;
            SetDueDate(this._dueDate.Day);
            int Id = UnId();
        }

        //Переопределенные методы
        public override void DisplayInfo()
        {
            Console.WriteLine($"Информация о книге {_title} :");
            Console.WriteLine($"Автор: {_author}");
            Console.WriteLine($"Количество страниц: {_pages}");
            Console.WriteLine($"Год выпуска: {_year}");
        }
        public override void Borrow()
        {
            if (_isAvailable)
            {
                Console.WriteLine($"Книга \"{_title}\"взята из библиотеки");
                _isAvailable = false;
            }
            else
                Console.WriteLine("Книга уже взята");
        }
        public override void Return()
        {
            if (!_isAvailable)
            {
                Console.WriteLine($"Книгу \"{_title}\"вернули в библиотеку");
                _isAvailable = true;
            }
            else
                Console.WriteLine("Книгу еще не взяли, что бы ее возращать.");

        }

        public override int UnId()
        {
            int Id = Year + Title.Length + Author.Length + (int)_dueDate.Day;

            Id *= "Book".Length;
            Id += 10;

            return Id;
        }

    }

    sealed class Movie : Media //Класс фильм
    {
        private int _duration; //Длительность фильма в минутах

        public int Duration { get => _duration; set => _duration = value; }

        //Конструкторы
        public Movie()
        {
            _title = "Не определено";
            _author = "Не определено";
            _year = -1;
            _duration = -1;
            SetDueDate(int.MaxValue);
            int Id = UnId();
        }

        public Movie(string _title, string _author, int _year, int _duration)
        {
            this._title = _title;
            this._author = _author;
            this._year = _year;
            this._duration = _duration;
            SetDueDate(this._dueDate.Day);
            int Id = UnId();
        }

        //Переопределенные методы
        public override void DisplayInfo()
        {
            Console.WriteLine($"Информация о фильме {_title} :");
            Console.WriteLine($"Автор: {_author}");
            Console.WriteLine($"Длительность: {_duration}мин");
            Console.WriteLine($"Год выпуска: {_year}");
        }
        public override void Borrow()
        {
            if (_isAvailable)
            {
                Console.WriteLine($"Фильм \"{_title}\"взят из библиотеки");
                _isAvailable = false;
            }
            else
                Console.WriteLine("Фильм уже взят");
        }
        public override void Return()
        {
            if (!_isAvailable)
            {
                Console.WriteLine($"Фильм \"{_title}\"вернули в библиотеку");
                _isAvailable = true;
            }
            else
                Console.WriteLine("Фильм еще не взяли, что бы ее возращать.");
        }


        public override int UnId()
        {
            int Id = Year + Title.Length + Author.Length + (int)_dueDate.Day;

            Id *= "Movie".Length;
            Id += 20;

            return Id;
        }


    }
    sealed class Magazine : Media //Класс журнал
    {
        private int _issueNumber; //Номер выпуска журнала

        public int IssueNumber { get => _issueNumber; set => _issueNumber = value; }

        //Конструкторы
        public Magazine()
        {
            _title = "Не определено";
            _author = "Не определено";
            _year = -1;
            _issueNumber = -1;
            SetDueDate(int.MaxValue);
            int Id = UnId();
        }

        public Magazine(string _title, string _author, int _year, int _issueNumber)
        {
            this._title = _title;
            this._author = _author;
            this._year = _year;
            this._issueNumber = _issueNumber;
            SetDueDate(this._dueDate.Day);
            int Id = UnId();
        }

        //Переопределенные методы
        public override void DisplayInfo()
        {
            Console.WriteLine($"Информация о журнале {_title} :");
            Console.WriteLine($"Автор: {_author}");
            Console.WriteLine($"Номер выпуска: {_issueNumber}");
            Console.WriteLine($"Год выпуска: {_year}");
        }
        public override void Borrow()
        {
            if (_isAvailable)
            {
                Console.WriteLine($"Журнал \"{_title}\"взят из библиотеки");
                _isAvailable = false;
            }
            else
                Console.WriteLine("Журнал уже взят");
        }
        public override void Return()
        {
            if (!_isAvailable)
            {
                Console.WriteLine($"Журнал \"{_title}\"вернули в библиотеку");
                _isAvailable = true;
            }
            else
                Console.WriteLine("Журнал еще не взяли, что бы ее возращать.");
        }


        public override int UnId()
        {
            int Id = Year + Title.Length + Author.Length + (int)_dueDate.Day;

            Id *= "Magazine".Length;
            Id += 30;

            return Id;
        }

    }
}