using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTypeExp
{
    class Program
    {
        static string[] testExpressionsSingle = {
"Мои места:: Коллекция музыки<Файл::ФайлМузыки>",
"ЭлементФайловойСистемы::Папка<ЭлементФайловойСистемы>;",
"ЭлементФайловойСистемы::Файл;",
"ФайлМузыки;",
"Предмет::Радиодеталь::Транзистор",
"Предмет::Радиодеталь::Транзистор::ТранзисторБиполярный",
"Транзистор::ТранзисторБиполярный",
"Транзистор::ТранзисторПолевой",
"ТранзисторБиполярный::ТранзисторPNP",
"ТранзисторPNP",
"Транзистор::IGBT",

"Предмет::Ведро  ",
"Предмет::Ведро  ; ", 
"Коробка<Карандаш, Ластик, Ручка>",
"Коробка<Карандаш, Ластик, Ручка>;",
"Контейнер<Предмет>",
"Контейнер<Предмет>  ;   ",
                                              };

        static string[] testExpressionsSingleWrong = {
"Мои места:: Коллекция музыки<Файл:ФайлМузыки>",//пропущена : в ::
"ЭлементФайловойСистемы;:Папка<ЭлементФайловойСистемы>;ЭлементФайловойСистемы::Файл;", //; вместо :
"ФайлМузыки:", //: вместо ;
"Предмет::Радиодеталь,Транзистор", //, вместо ::
"Предмет::Радиодеталь::Транзистор::ТранзисторБиполярный , ", //, вместо ;
"Контейнер<Предмет ,>  ;   ",//, без следующего за ним класса - не игонорировать, надо сообщить пользователю, что запись неправильная.
                                              };

        static string[] testExpressionsMultiple = {
"Мои места:: Коллекция музыки<Файл::ФайлМузыки>;ЭлементФайловойСистемы::Папка<ЭлементФайловойСистемы>;ЭлементФайловойСистемы::Файл;",
"Предмет:: Стул;Помещение ::Комната < Предмет::Ведро,Стол , Предмет :: Стул >",
"Предмет:: Стул;Помещение ::Комната < Предмет::Ведро, Стол , Предмет ::Стул >;",
"Папка; Каталог<Каталог, Файл>;Директория   ",
"Папка; Каталог<Каталог, Файл>;Директория ;",
                                                };
        static string[] testExpressionsMultipleWrong = {
"Мои места:: Коллекция музыки<Файл:ФайлМузыки>;ЭлементФайловойСистемы::Папка<ЭлементФайловойСистемы>;ЭлементФайловойСистемы::Файл;",//пропущена : в ::
"Предмет:: Стул;Помещение ::Комната < Предмет::Ведро,Стол , Предмет :; Стул >", //; вместо :
"Предмет:: Стул:Помещение ::Комната < Предмет::Ведро, Стол , Предмет ::Стул >;",//: вместо ;
"Папка; Каталог<Каталог, Файл>,Директория   ", //, вместо ;
"Папка; Каталог<Каталог, Файл>Директория ;",//пропущена ;
                                                };

        static void Main(string[] args)
        {
            Console.WriteLine("General test started");

                EntityPathTest();
                EntityTypeCollectionTest();
                EntityTypeTest();
                EntityTypesTreeTest();
                EntityTypeExpressionTest();

                Console.WriteLine();
                Console.WriteLine("General test finished");
                return;
        }


        private static void EntityPathTest()
        {
            try
            {
                PrintChapterHeader("Test EntityPath started");

                #region Test isSingleClassExpression()
                Console.WriteLine("Test isSingleClassExpression() started");
                foreach (String s in testExpressionsSingle)
                {
                    bool result = EntityPath.isSingleClassExpression(s);
                    if (result == false)
                        Console.WriteLine("Error singleClassExpression(" + s + ")");
                }

                foreach (String s in testExpressionsMultiple)
                {
                    bool result = EntityPath.isSingleClassExpression(s);
                    if (result == true)
                        Console.WriteLine("Error singleClassExpression(" + s + ")");
                }
                Console.WriteLine("Test isSingleClassExpression() finished");
                #endregion

                #region T

                #endregion

                Console.WriteLine("Test EntityPath) completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception {0} : {1}", ex.GetType().ToString(), ex.ToString());
            }
            return;
        }



        private static void EntityTypeCollectionTest()
        {
            try 
            {
                PrintChapterHeader("Test EntityTypeCollection NotImplemented");

            #region T

            #endregion


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception {0} : {1}", ex.GetType().ToString(), ex.ToString());
            }
            return;
        }

        private static void EntityTypeTest()
        {
            try 
            {
                PrintChapterHeader("Test EntityType NotImplemented");

            #region T

            #endregion



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception {0} : {1}", ex.GetType().ToString(), ex.ToString());
            }
            return;
        }

        private static void EntityTypesTreeTest()
        {
            try 
            {
                PrintChapterHeader("Test EntityTypesTree NotImplemented");

            #region T

            #endregion


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception {0} : {1}", ex.GetType().ToString(), ex.ToString());
            }
            return;
        }

        private static void EntityTypeExpressionTest()
        {
            try 
            {
                PrintChapterHeader("Test EntityTypeExpression NotImplemented");

            #region T

            #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception {0} : {1}", ex.GetType().ToString(), ex.ToString());
            }
            return;
        }

        /// <summary>
        /// Напечатать заголовок раздела теста
        /// </summary>
        /// <param name="title"></param>
        private static void PrintChapterHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine("==========");
            Console.WriteLine(title);
            return;
        }

    }
}
