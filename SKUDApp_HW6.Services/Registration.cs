using SKUDApp_HW6.DataAccess;
using SKUDApp_HW6.Models;
using System;
using System.Collections.Generic;

namespace SKUDApp_HW6.Services
{
    public class Registration
    {
        public static void Input()
        {
            Console.WriteLine("приложите карту к регистратору...(наж. любую кнопку)");
            Console.ReadKey();

            Random random = new Random();
            int count = 0;
            string cardNumber = "";

            List<string> purposeVisit = new List<string>() { "Прибыл", "Убыл", "Разовый вход" };

            using (DataContext context = new DataContext())
            {
                var identificationCards = context.IdentificationCards;
                foreach (var item in identificationCards) count++;
                int card = random.Next(0, count);

                foreach (var item in identificationCards)
                {
                    if (card == item.Id)
                    {
                        cardNumber = item.CardNumber;
                    }
                }
            }

            bool isInput = false;

            using (DataContext context = new DataContext())
            {
                var logs = context.Logs;
                foreach (var log in logs)
                {
                    if (cardNumber == log.CardNumber && log.OutputTime == "")
                    {
                        isInput = true;
                        break;
                    }
                }
            }

            if (isInput == true)
            {
                Output(cardNumber, purposeVisit);
            }
            else
            {
                string fullName = "";
                string passportNumber = "";
                string visit = "";

                using (DataContext context = new DataContext())
                {
                    var controllers = context.Controller;

                    foreach (var controller in controllers)
                    {
                        if (cardNumber==controller.CardNumber && cardNumber!="0")
                        {
                            fullName = controller.FullName;
                            passportNumber = controller.PassportNumber;
                            visit = purposeVisit[0];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введите Имя и Фамилию");
                            fullName = Console.ReadLine();

                            Console.WriteLine("Введите номер удостоверения личности");
                            passportNumber = Console.ReadLine();

                            visit = purposeVisit[2];
                            break;
                        }
                    }
                }

                using(DataContext context=new DataContext())
                {
                    var logs = context.Logs;
                    Log log = new Log
                    {
                        FullName = fullName,
                        PassportNumber = passportNumber,
                        EntryTime = DateTime.Now.ToString(),
                        OutputTime = "",
                        PurposeVisit = visit,
                        CardNumber=cardNumber
                    };
                    logs.Add(log);
                    context.SaveChanges();
                }
                    Console.Clear();
                int left = 0, top = 0;
                using (DataContext context = new DataContext())
                {
                    var logs = context.Logs;
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(left = 10, top);
                    Console.WriteLine("Полное имя");
                    Console.SetCursorPosition(left += 20, top);
                    Console.WriteLine("Паспортные данные");
                    Console.SetCursorPosition(left += 27, top);
                    Console.WriteLine("Время входа");
                    Console.SetCursorPosition(left += 22, top);
                    Console.WriteLine("Время выхода");
                    Console.SetCursorPosition(left += 22, top);
                    Console.WriteLine("Событие");
                    left = 0;
                    foreach (var l in logs)
                    {
                        Console.SetCursorPosition(left+2, ++top);
                        Console.WriteLine($"{l.Id}");
                        Console.SetCursorPosition(left = 8, top);
                        Console.WriteLine($"{l.FullName}");
                        Console.SetCursorPosition(left += 25, top);
                        Console.WriteLine($"{l.PassportNumber}");
                        Console.SetCursorPosition(left += 21, top);
                        Console.WriteLine($"{l.EntryTime}");
                        Console.SetCursorPosition(left += 22, top);
                        Console.WriteLine($"{l.OutputTime}");
                        Console.SetCursorPosition(left += 26, top);
                        Console.WriteLine($"{l.PurposeVisit}");
                    }
                }
            }
        }

        public static void Output(string cardNumber, List<string> purposeVisit)
        {
            using (DataContext context = new DataContext())
            {
                var logs = context.Logs;
                foreach (var log in logs)
                {
                    if (cardNumber == log.CardNumber && log.OutputTime=="")
                    {
                        log.FullName = log.FullName;
                        log.PassportNumber = log.PassportNumber;
                        log.EntryTime = log.EntryTime;
                        log.OutputTime = DateTime.Now.ToString();
                        log.PurposeVisit = purposeVisit[1];
                        break;
                    }
                }
                context.SaveChanges();

                Console.Clear();
                int left = 0, top = 0;

                Console.SetCursorPosition(left, top);
                Console.WriteLine("ID");
                Console.SetCursorPosition(left = 10, top);
                Console.WriteLine("Полное имя");
                Console.SetCursorPosition(left += 20, top);
                Console.WriteLine("Паспортные данные");
                Console.SetCursorPosition(left += 27, top);
                Console.WriteLine("Время входа");
                Console.SetCursorPosition(left += 22, top);
                Console.WriteLine("Время выхода");
                Console.SetCursorPosition(left += 22, top);
                Console.WriteLine("Событие");
                left = 0;
                foreach (var l in logs)
                {
                    Console.SetCursorPosition(left, ++top);
                    Console.WriteLine($"{l.Id}");
                    Console.SetCursorPosition(left = 8, top);
                    Console.WriteLine($"{l.FullName}");
                    Console.SetCursorPosition(left += 25, top);
                    Console.WriteLine($"{l.PassportNumber}");
                    Console.SetCursorPosition(left += 21, top);
                    Console.WriteLine($"{l.EntryTime}");
                    Console.SetCursorPosition(left += 22, top);
                    Console.WriteLine($"{l.OutputTime}");
                    Console.SetCursorPosition(left += 26, top);
                    Console.WriteLine($"{l.PurposeVisit}");

                }
                Console.WriteLine("До свидания!");

            }
        }
    }
}

