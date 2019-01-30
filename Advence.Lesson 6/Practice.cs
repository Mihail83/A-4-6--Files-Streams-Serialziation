using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Advence.Lesson_6
{
    public partial class Practice
    {
        /// <summary>
        /// AL6-P1/7-DirInfo. Вывести на консоль следующую информацию о каталоге “c://Program Files”:
        /// Имя
        /// Дата создания
        /// </summary>
        public static void AL6_P1_7_DirInfo()
        {
            var dirinfo = new DirectoryInfo("C:/Program Files");
            Console.WriteLine(dirinfo.FullName);
            Console.WriteLine(dirinfo.CreationTime);
        }

        /// <summary>
        /// AL6-P2/7-FileInfo. Получить список файлов каталога и для каждого вывести значение:
        /// Имя
        /// Дата создания
        /// Размер 
        /// </summary>
        public static void AL6_P2_7_FileInfo()
        {
            var dirinfo = new DirectoryInfo(@"D:\миша_документы\курсы 2018\С# basic\Wav");           
            var InfoOfFiles = dirinfo.GetFiles("*.WAV");
            foreach (var item in InfoOfFiles)
            {                
                Console.WriteLine("{0, 15} - {1} -  {2}Kb", item.Name, item.CreationTime, item.Length / 1024);
            }
        }

        /// <summary>
        /// AL6-P3/7-CreateDir. Создать пустую директорию “c://Program Files Copy”.
        /// </summary>
        public static void AL6_P3_7_CreateDir()
        {
            Directory.CreateDirectory("D:\\Program Files Copy");
        }

        /// <summary>
        /// AL6-P4/7-CopyFile. Скопировать первый файл из Program Files в новую папку.
        /// </summary>
        public static void AL6_P4_7_CopyFile()
        {
            var dirinfo = new DirectoryInfo(@"D:\миша_документы\курсы 2018\С# basic\Wav");
            var InfoOfFiles = dirinfo.GetFiles("*.WAV");
            foreach (var item in InfoOfFiles)
            {
                Console.WriteLine("{0, 15} - {1} -  {2}Kb", item.Name, item.CreationTime, item.Length / 1024);
            }
            InfoOfFiles[0].CopyTo("D:\\Program Files Copy\\" + InfoOfFiles[0].Name);

        }

        /// <summary>
        /// AL6-P5/7-FileChat. Написать программу имитирующую чат. 
        /// Пускай в ней будут по очереди запрашивается реплики для User 1 и User 2 (используйте цикл из 5-10 итераций).  Сохраняйте данные реплики с ником пользователя и датой в файл на диске.
        /// </summary>
        public static void AL6_P5_7_FileChat()
        {
           
            var user1 = "user1: ";
            var user2 = "user2: ";
            var strToWrite = "";

            using (StreamWriter sw = new StreamWriter(@"D:\миша_документы\курсы 2018\С# basic\Wav\File.txt", true))
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(user1);
                        strToWrite = DateTime.Now + "  " + user1 + Console.ReadLine();
                    }
                    else
                    {
                        Console.Write(user2);
                        strToWrite = DateTime.Now + "  " + user2 + Console.ReadLine();
                    }
                    sw.WriteLine(strToWrite);
                }
            }            
        }

        /// <summary>
        /// AL6-P6/7-ConsoleSrlz. (Демонстрация). 
        /// Сериализовать обьект класса Song в XML.Вывести на консоль.
        /// Десериализовать XML из строковой переменной в объект.
        /// </summary>
        public static void AL6_P6_7_ConsoleSrlzn()
        {
            Song song = new Song()
            {
                Title = "Title 1",
                Duration = 24,
                Lyrics = "Lyrics 1"
            };   
            
            var xmlSerializer = new XmlSerializer(typeof(Song));
               //Сериализация
            StringWriter xmlToString = new StringWriter();
            xmlSerializer.Serialize(xmlToString, song);
            Console.WriteLine(xmlToString.ToString() + "//Сериализация");
            //Десериализация
            StringReader strinToXml = new StringReader(xmlToString.ToString());
            var song2 = (Song)xmlSerializer.Deserialize(strinToXml);
            Console.WriteLine(song2 + "//Десериализация");
        }

        /// <summary>
        /// AL6-P7/7-FileSrlz.
        /// Отредактировать предыдущий пример для поддержки сериализации и десериализации в файл.
        /// </summary>
        public static void AL6_P7_7_FileSrlz()
        {
            Song song = new Song()
            {
                Title = "Title 1",
                Duration = 247,
                Lyrics = "Lyrics 1"
            };
            var xmlSerializer = new XmlSerializer(typeof(Song));

            //using (StreamWriter songToXml = new StreamWriter(@"D:\миша_документы\курсы 2018\С# basic\A4 lesson\XMLsong.xml"))
            //{
            //    xmlSerializer.Serialize(songToXml, song);                
            //}

            using (StreamReader xmlToSong = new StreamReader(@"D:\миша_документы\курсы 2018\С# basic\A4 lesson\XMLsong.xml"))
            {
                var song2= (Song)xmlSerializer.Deserialize(xmlToSong);
                Console.WriteLine(song2);
            }            
        }
    }
}
