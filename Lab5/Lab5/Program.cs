using System;
using System.Collections.Generic;
using System.Linq;

namespace laba_5
{
    class Lab5
    {
        enum Pos
        {
        	П,
        	С,
        	А
        }
        
        struct Worker
        {
            public string surname;
            public Pos position;
            public int year;
            public decimal salary;

            public void showTable()
            {
                Console.WriteLine("{0, -20} {1, -5} {2, -10} {3, -10}", surname, position, year, salary);
                Console.WriteLine();
            }
        }
        
        struct Log 
		{
			public DateTime time;
			public string operation;
			public string name;

			public void logOutput() 
			{
				Console.WriteLine("{0, -20} : {1, -15} {2, -15}", time, operation, name);
			}
		}
        
        public static void Main(string[] args)
		{
			var logOfSession = new List<Log>(50);			
			DateTime firstTime = DateTime.Now;
			DateTime secondTime = DateTime.Now;
			TimeSpan downtime = secondTime - firstTime;
        	
        	Worker Иванов;
        	Иванов.surname = "Иванов И.И.";
        	Иванов.position = Pos.П;
        	Иванов.year = 1975;
        	Иванов.salary = 4170.50M;
        	
        	Worker Петренко;
        	Петренко.surname = "Петренко П.П.";
        	Петренко.position = Pos.С;
        	Петренко.year = 1996;
        	Петренко.salary = 790.10M;
        	
        	Worker Сидоревич;
        	Сидоревич.surname = "Сидоревич М.С.";
        	Сидоревич.position = Pos.А;
        	Сидоревич.year = 1990;
        	Сидоревич.salary = 2200.00M;
        	
        	var table = new List<Worker>();
			table.Add(Иванов);
			table.Add(Петренко);
			table.Add(Сидоревич);
			
			bool working = true;
			bool error = true;
			do
			{
				Console.WriteLine("Select an action:");
				Console.WriteLine("1 - View the table");
				Console.WriteLine("2 - Add a record");
				Console.WriteLine("3 - Delete a record");
				Console.WriteLine("4 - Update a record");
				Console.WriteLine("5 - Search a record");
				Console.WriteLine("6 - Show log");
				Console.WriteLine("7 - Exit");
				int selector = int.Parse(Console.ReadLine());
				if (selector == 1)
				{
					for (int i = 0; i < table.Count; i++)
					{
						table[i].showTable();
					}
					Console.WriteLine();
				}
				if (selector == 2)
				{
					Console.Write("Enter the surname: ");
					string surname = Console.ReadLine();
					var position = Pos.А;
					int year = 0;
					decimal salary = 0;
					do
					{
						Console.Write("Enter the position in Russian: ");
						string pos = Console.ReadLine();
							if (pos == "П")
							{
								position = Pos.П;
								error = false;
							}
							else if (pos == "С")
							{
								position = Pos.С;
								error = false;
							}
							else if (pos == "А")
							{
								position = Pos.А;
								error = false;
							}
							else
							{
								Console.WriteLine("Enter the correct position!");
								Console.WriteLine();
							}
					}
					while (error);
					error = true;
					do
					{
						Console.Write("Enter the year of birth: ");
						try
						{
							year = int.Parse(Console.ReadLine());
							error = false;
						}
						catch (FormatException)
						{
							year = 0;
							Console.WriteLine("Enter the correct year!");
						}
					}
					while (error);
					error = true;
					do
					{
						Console.Write("Enter the salary: ");
						try
						{
							salary = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
							error = false;
						}
						catch (FormatException)
						{
							salary = 0;
							Console.WriteLine("Enter the correct salary!");
						}
					}
					while (error);
					error = true;
					
					Worker newWorker;
					newWorker.surname = surname;
					newWorker.position = position;
					newWorker.year = year;
					newWorker.salary = salary;
					table.Add(newWorker);
					
					Log newLog;
					newLog.time = DateTime.Now;
					newLog.operation = "Record added";
					newLog.name = surname;
					logOfSession.Add(newLog);
					
					firstTime = newLog.time;
					TimeSpan secondDowntime = firstTime - secondTime;
					if(downtime < secondDowntime)
					{
						downtime = secondDowntime;
					}
					secondTime = newLog.time;
					Console.WriteLine();
				}
				if (selector == 3)
				{
					int number = 0;
					do
					{
						Console.WriteLine("Choose the number of row to delete: ");
						number = int.Parse(Console.ReadLine());
						if (number > 0 && number < table.Count)
						{
							table.RemoveAt(number - 1);
							error = false;
						}
						else
						{
							Console.WriteLine("Enter the correct number!");
						}
					}
					while (error);
					error = true;
					
					Log newLog;
					newLog.time = DateTime.Now;
					newLog.operation = "Record deleted";
					newLog.name = table[number - 1].surname;
					logOfSession.Add(newLog);
					
					firstTime = newLog.time;
					TimeSpan secondDowntime = firstTime - secondTime;
					if(downtime < secondDowntime)
					{
						downtime = secondDowntime;
					}
					secondTime = newLog.time;
					Console.WriteLine();
				}
				if (selector == 4)
				{
					string oldSurname = string.Empty;
					string surname = string.Empty;
					var position = Pos.А;
					int year = 0;
					decimal salary = 0;
					int number = 0;
					do
					{
						Console.WriteLine("Choose the number of row to update: ");
						number = int.Parse(Console.ReadLine());
						if (number > 0 && number < table.Count)
						{
							oldSurname = table[number - 1].surname;
							Console.Write("Enter the surname: ");
							surname = Console.ReadLine();
							do
							{
								Console.Write("Enter the position in Russian: ");
								string pos = Console.ReadLine();
								if (pos == "П")
								{
									position = Pos.П;
									error = false;
								}
								else if (pos == "С")
								{
									position = Pos.С;
									error = false;
								}
								else if (pos == "А")
								{
									position = Pos.А;
									error = false;
								}
								else
								{
									Console.WriteLine("Enter the correct position!");
									Console.WriteLine();
								}
							}
							while (error);
							error = true;
							do
							{
								Console.Write("Enter the year of birth: ");
								try
								{
									year = int.Parse(Console.ReadLine());
									error = false;
								}
								catch (FormatException)
								{
									year = 0;
									Console.WriteLine("Enter the correct year!");
								}
							}
							while (error);
							error = true;
							do
							{
								Console.Write("Enter the salary: ");
								try
								{
									salary = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
									error = false;
								}
								catch (FormatException)
								{
									salary = 0;
									Console.WriteLine("Enter the correct salary!");
								}
							}
							while (error);
						}
						else
						{
							Console.WriteLine("Enter the correct number!");
						}
					}
					while (error);
					error = true;
					
					Worker editWorker;
					editWorker.surname = surname;
					editWorker.position = position;
					editWorker.year = year;
					editWorker.salary = salary;
					table.Insert(number - 1, editWorker);
					
					Log newLog;
					newLog.time = DateTime.Now;
					newLog.operation = "Record updated";
					newLog.name = oldSurname;
					logOfSession.Add(newLog);
					
					firstTime = newLog.time;
					TimeSpan secondDowntime = firstTime - secondTime;
					if(downtime < secondDowntime)
					{
						downtime = secondDowntime;
					}
					secondTime = newLog.time;
					Console.WriteLine();
				}
				if (selector == 5)
				{
					var pos = Pos.П;
					do
					{
						Console.WriteLine("П - teachers");
						Console.WriteLine("С - students");
						Console.WriteLine("А - graduate students");
						Console.WriteLine("Enter who you want to find (russian letter): ");
						string select = Console.ReadLine();
						Console.WriteLine();
						if (select == "П" || select == "С" || select == "А")
						{
							if (select == "П")
								pos = Pos.П;
							if (select == "С")
								pos = Pos.С;
							if (select == "А")
								pos = Pos.А;
							for (int i = 0; i < table.Count; i++)
							{
								Console.WriteLine(table[i].position);
								if (table[i].position == pos)
								{
									Console.WriteLine(table[i]);
								}
							}
						}
						else
						{
							Console.WriteLine("Enter in the correct form!");
						}
					}
					while (error);
					error = true;
					Console.WriteLine();
				}
				if (selector == 6)
				{
					for (int i = 0; i < logOfSession.Count; i++)
					{
						logOfSession[i].logOutput();
					}
					Console.WriteLine();
					Console.WriteLine(downtime + " - the largest downtime");
					Console.WriteLine();
				}
				if (selector == 7)
				{
					working = false;
				}
				if (selector < 1 || selector > 7)
				{
					Console.WriteLine("Choose the correct action!");
					Console.WriteLine();
				}
			}
			while (working);
			Console.WriteLine();
        }
    }
}
