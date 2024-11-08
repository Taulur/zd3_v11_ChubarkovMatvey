using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // объявляем класс
    class Airplane
    {
        // объявляем поля класса
        string name;
        int age;
        double mileage;
        int capacity;
        double consumption;
        double quality = 1;
        // прописываем свойства для полей
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public double Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public double Consumption
        {
            get { return consumption; }
            set { consumption = value; }
        }
        public double Quality
        {
            get { return quality; }
            set { quality = value; }
        }
        // конструктор для занесения значений в поля
        public Airplane(string name, int age, double mileage, int capacity,double consumption)
        {
            this.name = name;
            this.age = age;
            this.mileage = mileage;
            this.capacity = capacity;
            this.consumption = consumption;
        }
        // функция для расчета поля 'качество'
        public virtual void SetQuality()
        {
            this.quality = ((mileage*Convert.ToDouble(capacity))/consumption);
        }

       
    }
}
