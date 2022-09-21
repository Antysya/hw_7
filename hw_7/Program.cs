using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw_7
{
    internal class Program
    {
        public class My_Exep : ApplicationException
        {
            public My_Exep() : base("Стоимость автомобиля завышена!!!") { }
            
        }
        public static AutoPas f(int _size)
        {
           return new AutoPas(_size);
        }
        public static AutoPas f2(AutoPas _autoPas)
        {
            _autoPas[0] = new Passenger { Stamp = "Volvo", Model = "XC90", Cost = 4100000, Type = "Кроссовер", PassengerNumbers = 5 };
            _autoPas[1] = new Passenger { Stamp = "KIA", Model = "Optima", Cost = 3500000, Type = "Седан", PassengerNumbers = 5 };
            _autoPas[2] = new Passenger { Stamp = "Audi", Model = "TT", Cost = 5300000, Type = "Спорткар", PassengerNumbers = 2 };
            return _autoPas;
        }
        public static void f3(AutoPas _autoPas)
        {
         
            for (int i = 0; i < _autoPas.Length; i++)
            {
                WriteLine(_autoPas[i]);
            }
        }
        public static void f4(AutoPas _autoPas)
        {
            try
            {
                WriteLine("***Мои исключения из функции***");
                for (int i = 0; i < _autoPas.Length; i++)
                {
                    if (_autoPas[i].Cost > 5000000)
                    {
                        WriteLine(_autoPas[i]);
                        throw new My_Exep();
                    }
                    else
                        WriteLine(_autoPas[i]);
                }
            }
            catch (My_Exep e)
            {
                WriteLine($"{e.Message}");
            }
            finally
            {
                WriteLine("Выход из функции");
            }
        }

        static void Main(string[] args)
        {
            AutoPas autoPas = new AutoPas(3);
            autoPas[0] = new Passenger { Stamp = "Volvo", Model = "XC90", Cost = 4100000, Type = "Кроссовер", PassengerNumbers = 5 };
            autoPas[1] = new Passenger { Stamp = "KIA", Model = "Optima", Cost = 3500000, Type = "Седан", PassengerNumbers = 5 };
            autoPas[2] = new Passenger { Stamp = "Audi", Model = "TT", Cost = 5300000, Type = "Спорткар", PassengerNumbers = 2 };

            AutoPas autoPas2 = new AutoPas(4);
            autoPas2[0] = new Passenger { Stamp = "Volvo", Model = "XC90", Cost = 4100000, Type = "Кроссовер", PassengerNumbers = 5 };
            autoPas2[1] = new Passenger { Stamp = "KIA", Model = "Optima", Cost = 3500000, Type = "Седан", PassengerNumbers = 5 };
            autoPas2[2] = new Passenger { Stamp = "Audi", Model = "TT", Cost = 5300000, Type = "Спорткар", PassengerNumbers = 2 };

            AutoC autoC = new AutoC(3);
            autoC[0] = new Cargo { Stamp = "Hyundai", Model = "HD78", Cost = 990000000, Type = "Рефрижиратор", Capacity = 5 };
            autoC[1] = new Cargo { Stamp = "MAZ", Model = "TF45", Cost = 875000000, Type = "Самосвал", Capacity = 10 };
            autoC[2] = new Cargo { Stamp = "Hyundai", Model = "HD79", Cost = 923000000, Type = "Фургон", Capacity = 6 };


            try
            {
                WriteLine("***ПРОВЕРКА СТОИМОСТИ***");
                for (int i = 0; i < autoPas.Length; i++)
                {
                    if (autoPas[i].Cost > 5000000)
                    {
                        WriteLine(autoPas[i]);
                        throw new My_Exep();
                    }
                    else
                        WriteLine(autoPas[i]);
                }
            }
            catch (My_Exep e)
            {
                WriteLine($"{e.Message}");
            }
            finally
            {
                WriteLine("**********************");
            }
            WriteLine();
            try
            {
                WriteLine("***ПРОВЕРКА СТОИМОСТИ***");
                f4(autoPas);
            }
            catch (My_Exep e)
            {
                WriteLine($"{e.Message}");
            }
            finally
            {
                WriteLine("**********************");
            }
            WriteLine();
            try
            {
                WriteLine("***Проверка пределов массива***");
                double sum = 0;
                for (int i = 0; i < autoPas2.Length; i++)
                {
                    sum += autoPas2[i].Cost;
                }
                WriteLine($"Стоимость пассажирского транспорта = {sum}\n");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            finally
            {
                WriteLine("**********************");
            }
            WriteLine();
            try
            {
                WriteLine("***Stack trace и Target Site***");
                WriteLine("***Вызов без ошибок:***");
                f3(f2(f(3)));
                WriteLine("***Вызов с ошибкой:***");
                f3(f2(f(2)));
            }
            catch (Exception e)
            {
                WriteLine($"Stack trace: \n {e.StackTrace}");
                WriteLine($"Target Site: \n {e.TargetSite}");
            }
            finally
            {
                WriteLine("**********************");
            }
            WriteLine();
            try
            {
                WriteLine("***Checked при выполнении арифметической операции (double -> int)***");
               double sum = 0;
                for (int i = 0; i < autoC.Length; i++)
                {
                    sum += autoC[i].Cost;
                }
                WriteLine($"Стоимость грузового транспорта = {checked((int)sum)}\n");
            }
            catch (OverflowException e)
            {
                WriteLine(e.Message);
            }
            finally
            {
                WriteLine("**********************");
            }
        }
    }
}
