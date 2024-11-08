using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    // объявляем дочерний класс от класса Airplane
    class SpecialAirplane : Airplane
    {
        // объявляем поле классу
        int term;
        // прописываем свойство для поля
        public int Term
        {
            get { return term; }
            set { term = value; }
        }
        // прописываем конструктор дочернего класса
        public SpecialAirplane(string name, int age, double mileage, int capacity, double consumption, int term) : base(name, age, mileage, capacity, consumption)
        {
            this.term = term;
        }
        // переписываем функцию родительского класса
        public override void SetQuality()
        {
            if (term < 10)
            {
                Quality = Quality / 1.05 * term;
            }
            else if (term > 10 && term < 25)
            {
                Quality = Quality / 1.15 * term;
            }
            else
            {
                Quality = Quality / 1.3 * term;
            }
        }
    }
}
