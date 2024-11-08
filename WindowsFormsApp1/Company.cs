using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    // объявляем класса
    class Company
    {
        // объявляем поля класса, лист и словарь
        List<Airplane> listAirplane;
        Dictionary<string, SpecialAirplane> dictionaryAirplane;
        // консруктор класса где инициализируются поля класса
        public Company()
        {
            listAirplane = new List<Airplane>();
            dictionaryAirplane = new Dictionary<string, SpecialAirplane>();
        }
        // функция для добавления объекта класса в лист
        public void AddAirplane(Airplane airplane)
        {
            listAirplane.Add(airplane);
        }
        // первая перегрузка функции для добавления объекта класса в лист путем прописывания во входные данные все поля
        public void AddAirplane(string name, int age, double mileage, int capacity, double consumption)
        {
            listAirplane.Add(new Airplane(name, age, mileage, capacity, consumption));
        }
        // вторая перегрузка функции для добавления объекта класса в словарь с помощью ключа
        public void AddAirplane(string code, SpecialAirplane specAirplane)
        {
            if (!dictionaryAirplane.ContainsKey(code))
            {
                dictionaryAirplane.Add(code, specAirplane);
            }
            else
            {
                MessageBox.Show("Самолет с таким названием уже сущетсвует!");
            }
        }
        // функция для удаления объекта класса из списка
        public void RemoveAirplane(Airplane airplane)
        {
            listAirplane.Remove(airplane);
        }
        // первая перегрузка функции для удаления объекта класса из списка по индексу
        public void RemoveAirplane(int index)
        {
            listAirplane.RemoveAt(index);
        }
        // вторая перегрузка функции для удаления объекта класса из словаря по ключу
        public void RemoveAirplane(string code)
        {
            dictionaryAirplane.Remove(code);
        }
        // функция заполнения datagridview с помощью листа для отображения информации
        public void LoadData(List<Airplane> list,DataGridView datagridview)
        {
            datagridview.Rows.Clear();

            foreach (Airplane airplane in list)
            {
                datagridview.Rows.Add(airplane.Name, airplane.Age, airplane.Mileage, airplane.Capacity, airplane.Consumption, airplane.Quality);
            }
        }
        // перегрузка функции для заполнения datagridview с помощью словаря
        public void LoadData(Dictionary<string,SpecialAirplane> list, DataGridView datagridview)
        {
            datagridview.Rows.Clear();

            foreach (SpecialAirplane specAirplane in list.Values)
            {
                datagridview.Rows.Add(specAirplane.Name, specAirplane.Age, specAirplane.Mileage, specAirplane.Capacity, specAirplane.Consumption, specAirplane.Quality, specAirplane.Term);
            }
        }
        // функция для получения листа
        public List<Airplane> GetAirplaneList()
        {
            return listAirplane;
        }
        // функция для получения словаря
        public Dictionary<string,SpecialAirplane> GetAirplaneDictionary()
        {
            return dictionaryAirplane;
        }
    }
}
