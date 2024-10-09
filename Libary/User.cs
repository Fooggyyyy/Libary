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
    sealed class User //Класс User, который будет взаимодействовать с наследниками класса Media (книги, фильмы, журналы
    {
        private string _name; //Имя пользователя
        private List<Media> _borrowedItems; //Список выданных медиа

        public static int _borrow = 0; //Количество взятых медиа
        private const int _borrowLimit = 5; ///Лимит по количеству взятых медиа

        public string Name { get => _name; set => _name = value; }
        public List<Media> BorrowedItems { get => _borrowedItems; }

        public void BorrowItem(Media item) //Метод для взятия медиа
        {
            if (_borrow <= _borrowLimit)
                _borrowedItems.Add(item);
            else
                Console.WriteLine("Превышен лимит на одного пользователя");

        }
        public void ReturnItem(Media item) //Метод для возврата медиа
        {
            _borrowedItems.Remove(item);
        }
        public List<Media> GetOverdueItems() //Метод для получения списка просроченных медиа
        {
            List<Media> overdueItems = new List<Media>();
            foreach (var item in _borrowedItems)
            {
                if (item.IsOverdue())
                {
                    overdueItems.Add(item);
                }
            }
            return overdueItems;
        }
    }

}