using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTypeExp
{
    /// <summary>
    /// Статический класс для операций с цепочками абстракции в записях классов.
    /// </summary>
    public static class EntityPath
    {
        //Основное отличие от класса Path: в Path есть абсолютные пути и относительные.
	    //А тут нет четкого корня подобно C:\, все пути считаются относительными.
        //Второе отличие: класс Path использует дерево файловой системы компьютера, 
        // а текущий класс не может использовать дерево классов - он только разбирает переданную строку.
        
        //Здесь обслуживается только одна цепочка классов. Для выражения с несколькими цепочками классов, 
        // разделенных ;, нужно использовать класс EntityTypeExpression.
        //TODO: проверять, что функциям передается только одна цепочка классов!
        
        /// <summary>
        /// Разделитель ";" между записями классов в строке описания классов
        /// </summary>
        public const char ClassDelimiter = ';';
        /// <summary>
        /// Разделитель "::" Абстракции в записи классов
        /// </summary>
        public const string AbstractionDelimiter = "::";
        /// <summary>
        /// Разделитель "," Агрегации в записи классов
        /// </summary>
        public const char AggregationDelimiter = ',';
        /// <summary>
        /// Символ начала группы агрегации
        /// </summary>
        public const char AggregationGroupBegin = '<';
        /// <summary>
        /// Символ завершения группы агрегации
        /// </summary>
        public const char AggregationGroupEnd = '>';
        //TODO: привести эти переменные к единому виду и области видимости

        /// <summary>
        /// NT-Проверить, что символ допустим для использования в названии класса
        /// </summary>
        /// <returns></returns>
        public static bool isValidClassTitleChar(Char ch)
        {
            if(Char.IsLetterOrDigit(ch) == true)
                return true;
            if(ch == ' ') return true;//space allowed as part of class title
            if(ch == '-') return true;
            if(ch == '+') return true;
            if(ch == '=') return true;
            if(ch == '_') return true;

            return false;
        }

        /// <summary>
        /// NT-Проверить, что символ допустим для использования в выражении классов
        /// </summary>
        /// <returns></returns>
        public static bool isValidExpressionChar(Char ch)
        {
            //символы грамматики классов
            if (ch == EntityPath.AggregationGroupBegin) return true;
            if (ch == EntityPath.AggregationGroupEnd) return true;
            if (ch == EntityPath.ClassDelimiter) return true;
            if (ch == EntityPath.AggregationDelimiter) return true;
            //символы названия класса
            return isValidClassTitleChar(ch);
        }



        /// <summary>
        /// NT-Объединить имена классов в путь классов 
        /// </summary>
        /// <param name="classes">Массив имен классов</param>
        /// <returns>Возвращает путь классов вида: Предмет::Радиодеталь::Транзистор или: Предмет</returns>
        public static string JoinClasses(string[] classes)
        {
            return String.Join(EntityPath.AbstractionDelimiter, classes);
        }
        /// <summary>
        /// NT-Объединить имена классов в путь классов
        /// </summary>
        /// <param name="classes">Массив имен классов</param>
        /// <param name="startIndex">Начальный индекс в массиве</param>
        /// <param name="count">Число используемых элементов массива</param>
        /// <returns>Возвращает путь классов вида: Предмет::Радиодеталь::Транзистор или: Предмет</returns>
        public static string JoinClasses(string[] classes, int startIndex, int count)
        {
            return String.Join(EntityPath.AbstractionDelimiter, classes, startIndex, count);
        }

        /// <summary>
        /// NR-Разделить цепочку классов на отдельные классы
        /// </summary>
        /// <param name="classPath">Цепочка классов вида Предмет::Радиодеталь::ххх</param>
        /// <returns>Возвращает массив строк имен классов в исходном порядке следования.</returns>
        public static string[] SplitSimple(string classPath)
        {
            //  - А::Б::В => А; Б; В;
            //- так как названия классов должны быть уникальными, достаточно разделить строку по AbstractionSeparator и обработать Trim()
            //- возвращает string[]

            String[] splitter = new String[] { EntityPath.AbstractionDelimiter };
            string[] classes = classPath.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            //trim class names
            for (int i = 0; i < classes.Length; i++)
                classes[i] = classes[i].Trim();

            return classes;
        }

        /// <summary>
        /// NR-Разделить цепочку классов на отдельные классы.
        /// </summary>
        /// <param name="classPath">Цепочка классов вида Предмет::Радиодеталь::ххх</param>
        /// <returns>Возвращает массив строк имен классов в исходном порядке следования.</returns>
        public static string[] Split(string classPath)
        {
            //  - А::Б::В<Г::Е, Д> => А; Б; В<Г::Е, Д>;
            //- возвращает string[]

            //варианты выражений:
            //[0] Мои места:: Коллекция музыки<Файл::ФайлМузыки>
            //[1] Файловая система ::Папка < Файловая система::Папка,Файл>
            //[2] ФайлМузыки
            //предполагается, что только конечный класс содержит сведения о агрегации (<> и классы)
            //- это не универсальный случай, вообще-то каждый класс может содержать такие сведения о агрегации.

            //1 надо разделить выражение по EntityPath.AbstractionDelimiter, если он не находится внутри группы агрегации.
            //тут надо бы парсер посимвольный конечный автомат сделать, он бы и выражение проверял на правильность сразу.
            //а эти вот сплиты по разделителям - неправильное решение.

            throw new NotImplementedException();//TODO: Add code here
        }

        /// <summary>
        /// NT-Разделить цепочку классов на отдельные классы
        /// </summary>
        /// <param name="classPath">Цепочка классов вида Предмет::Радиодеталь::ххх</param>
        /// <returns>Возвращает массив строк имен классов в исходном порядке следования, c цепочкой родительских классов для каждого члена массива.</returns>
        public static string[] SplitWithParents(string classPath)
        {
            // разделить цепочку классов на отдельные классы с указанием родительских классов
            //- А::Б::В => А; А::Б; А::Б::В; 
            //- возвращает string[]

            //1 parse class path
            string[] cs = EntityPath.Split(classPath);
            
            //2 create and fill result array
            int size = cs.Length;
            //3 создать выходной массив
            string[] result = new String[size];
            //4 если массив пустой, сразу вернем его
            if (size == 0) return result;
            //5 собрать цепочки классов в цикле 
            for(int i = 0; i < size; i++)
            {
                result[i] = EntityPath.JoinClasses(cs, 0, i + 1);
            }

            return result;
        }

        /// <summary>
        /// NT-Получить цепочку до родительского класса - на уровень выше подняться в иерархии абстракции.
        /// </summary>
        /// <param name="classPath">Запись класса</param>
        /// <returns>Возвращает объект родительского класса или null, если родительский класс не удалось найти.</returns>
        public static string getParent(string classPath)
        {
            //- Получить цепочку до родительского класса - на уровень выше подняться в иерархии абстракции.
            //- применимо, если цепочка длинная или если есть дерево классов.
            //- в этом классе нет дерева классов, поэтому - только по цепочке.
            //Пример А::Б::В<Г::Е, Д>

            //1 parse class path
            string[] cs = EntityPath.Split(classPath);
            int size = cs.Length;
            //если нет родительского класса, вернуть null
            if (size < 2) return null;
            //2 create result
            string result = EntityPath.JoinClasses(cs, 0, size - 1);

            return result;
        }
        /// <summary>
        /// NT-Получить запись последнего класса цепочки классов
        /// </summary>
        /// <param name="classPath">Запись класса</param>
        /// <returns></returns>
        public static string getLastClass(string classPath)
        {
            //вернуть последний класс из цепочки абстракции классов

            //1 parse class path
            string[] cs = EntityPath.Split(classPath);
            int size = cs.Length;
            //если нет классов в записи, вернуть пустую строку
            if (size == 0) return String.Empty;
            //2 create result
            string result = cs[size - 1];

            return result;
        }

        /// <summary>
        /// NT-Получить название последнего класса цепочки классов
        /// </summary>
        /// <param name="classPath">Запись класса</param>
        /// <returns>Возвращает только название последнего класса в цепочке классов, без группы агрегации и </returns>
        public static string getClassTitle(string classPath)
        {
            string last = EntityPath.getLastClass(classPath);
            //ищем позицию AggregationGroupBegin
            int pos = last.IndexOf(EntityPath.AggregationGroupBegin);
            //если не нашли, возвращаем строку класса
            if (pos == -1) return last;
            //если нашли, обрезаем и возвращаем строку названия класса
            string result = last.Remove(pos);

            return result;
        }

        /// <summary>
        /// NT-Получить запись первого класса цепочки классов
        /// </summary>
        /// <param name="classPath">Запись класса</param>
        /// <returns></returns>
        public static string getRootClass(string classPath)
        {
            //вернуть первый класс цепочки абстракции классов
            //1 parse class path
            string[] cs = EntityPath.Split(classPath);
            int size = cs.Length;
            //если нет классов в записи, вернуть пустую строку
            if (size == 0) return String.Empty;
            //2 create result
            string result = cs[0];

            return result;
        }

        /// <summary>
        /// NR-соединить две строки путей классов вместе.
        /// Объединение происходит по правилам для классов Хранилища
        /// </summary>
        /// <param name="baseClassPathString">Запись базового класса</param>
        /// <param name="classPathString">Запись класса</param>
        /// <returns>Возвращает объединенную строку путей классов</returns>
        public static string Combine(string baseClassPathString, string classPathString)
        {
            //сцепить две строки цепочки классов, если есть одинаковые классы
            throw new NotImplementedException();//TODO: Add code here

            //if (String.IsNullOrEmpty(baseClassPathString))
            //    throw new ArgumentException("Class path cannot be empty!", "baseClassPathString");
            //if (String.IsNullOrEmpty(classPathString))
            //    throw new ArgumentException("Class path cannot be empty!", "classPathString");

            //String[] baseclasses = ClassItem.SplitClassPath(baseClassPathString);

            ////String[] classes = ClassItem.SplitClassPath(classPathString);
            //////ищем первый класс в списке базовых классов, чтобы собрать иерархию правильно
            ////String first = classes[0];
            ////String result = null;
            ////for (int i = 0; i < baseclasses.Length; i++)
            ////{
            ////    if (String.Equals(first, baseclasses[i], StringComparison.OrdinalIgnoreCase))
            ////    {
            ////        //нашли, теперь собираем полное имя класса без повтора этого имени.
            ////        result = String.Join(AbstractionDelimiter, baseclasses, 0, i+1);
            ////        if(classes.Length > 1)//для случая классов Собака и Собака
            ////            result = result + AbstractionDelimiter + String.Join(AbstractionDelimiter, classes, 1, classes.Length - 1);
            ////        return result;
            ////    }
            ////}
            //////если ничего не нашли, просто соединяем все вместе
            ////result = baseClassPathString + AbstractionDelimiter + classPathString;

            ////перенес код в одну функцию - так проще ее отлаживать и содержать.
            //string result = Combine(baseclasses, classPathString);

            //return result;
        }

        /// <summary>
        /// NR-соединить две строки путей классов вместе.
        /// Объединение происходит по правилам для классов Хранилища
        /// Оптимизированная версия для массовых операций Хранилища
        /// </summary>
        /// <param name="baseClasses">Массив записей классов базового класса Хранилища</param>
        /// <param name="classPathString">Запись класса</param>
        /// <returns>Возвращает объединенную строку записи классов</returns>
        public static string Combine(string[] baseClasses, string classPathString)
        {
            //сцепить две строки цепочки классов, если есть одинаковые классы
            throw new NotImplementedException();//TODO: Add code here
            
            //if (String.IsNullOrEmpty(classPathString))
            //    throw new ArgumentException("Class path cannot be empty!", "classPathString");
            //if (baseClasses.Length == 0)
            //    throw new ArgumentException("Class array cannot be empty!", "baseClasses");

            //String[] classes = ClassItem.SplitClassPath(classPathString);
            ////ищем первый класс из классов сущности в списке базовых классов, чтобы собрать иерархию правильно
            //String first = classes[0];
            //String result = null;
            //for (int i = 0; i < baseClasses.Length; i++)
            //{
            //    if (String.Equals(first, baseClasses[i], StringComparison.OrdinalIgnoreCase))
            //    {
            //        //нашли, теперь собираем полное имя класса без этого члена.
            //        result = String.Join(AbstractionDelimiter, baseClasses, 0, i);
            //        //result = result + AbstractionDelimiter + String.Join(AbstractionDelimiter, classes, 1, classes.Length - 1); - wrong!
            //        if (String.IsNullOrEmpty(result)) //случай Радиодеталь и Радиодеталь
            //            return classPathString;
            //        else
            //            result = result + AbstractionDelimiter + classPathString;
            //        return result;
            //    }
            //}
            ////если ничего не нашли, просто соединяем все вместе
            //result = String.Join(AbstractionDelimiter, baseClasses) + AbstractionDelimiter + classPathString;
            //return result;
        }

        /// <summary>
        /// NR-Удалить БазовыйКлассХранилища из строки пути класса
        /// </summary>
        /// <param name="baseClassPathString">БазовыйКлассХранилища</param>
        /// <param name="classPathString">Полная запись класса</param>
        /// <returns>Возвращает разностную строку путей классов</returns>
        public static string Subtract(string classPathString, string baseClassPathString)
        {
            //
            throw new NotImplementedException();//TODO: Add code here
            
            //if (String.IsNullOrEmpty(baseClassPathString))
            //    throw new ArgumentException("Class path cannot be empty!", "baseClassPathString");
            //if (String.IsNullOrEmpty(classPathString))
            //    throw new ArgumentException("Class path cannot be empty!", "classPathString");
            ////если обе строки одинаковы, вернуть последний класс базового класса
            ////классы должны быть из одной ветви
            ////если классы разные, выбросить исключение о неправильном пути классов.
            ////примеры:
            ////Предмет::Радиодеталь::Транзистор::ТранзисторБиполярный - Предмет::Радиодеталь = Транзистор::ТранзисторБиполярный
            ////Предмет::Радиодеталь - Предмет::Радиодеталь = Радиодеталь //по правилам для Хранилищ
            ////Предмет::Радиодеталь::Транзистор::ТранзисторБиполярный - Радиодеталь = Транзистор::ТранзисторБиполярный
            ////Предмет::Радиодеталь::Транзистор::ТранзисторБиполярный - Предмет::Собака = исключение.

            ////разложить на массивы имен классов, искать совпадение в именах классов от конца к началу. Если совпадения нет, выдать исключение.
            ////Если совпадение есть, то все последующие классы собрать в выходную строку.

            //String[] baseclasses = ClassItem.SplitClassPath(baseClassPathString);
            //String[] classes = ClassItem.SplitClassPath(classPathString);
            ////ищем верхний базовый класс в пути классов сущности, чтобы разделить иерархию правильно
            //String first = baseclasses[baseclasses.Length - 1];
            //String result = null;
            //for (int i = 0; i < classes.Length; i++)
            //{
            //    if (String.Equals(first, classes[i], StringComparison.OrdinalIgnoreCase))
            //    {
            //        //нашли класс, после которого идут уже только требуемые классы
            //        //нашли, теперь собираем полное имя класса без повтора этого имени.
            //        if (classes.Length == i + 1)//если это последний класс в списке классов сущности, то возвращаем этот последний класс
            //            result = first;
            //        else
            //            result = String.Join(ClassDelimiter, classes, i + 1, classes.Length - i - 1);
            //        return result;
            //    }
            //}
            ////если ничего не нашли, выбрасываем исключение
            //throw new Exception("Classes not compatible");
        }

        //TODO: Надо решить, какая из этих двух функций лучше работает и будет использоваться в коде

        /// <summary>
        /// NR-Удалить БазовыйКлассХранилища из строки пути класса
        /// </summary>
        /// <param name="baseClassPathString">БазовыйКлассХранилища</param>
        /// <param name="classPathString">Полная запись класса</param>
        /// <returns>Возвращает разностную строку путей классов</returns>
        public static string Subtract2(string classPathString, string baseClassPathString)
        {
            //
            throw new NotImplementedException();//TODO: Add code here
            
            //if (String.IsNullOrEmpty(baseClassPathString))
            //    throw new ArgumentException("Class path cannot be empty!", "baseClassPathString");
            //if (String.IsNullOrEmpty(classPathString))
            //    throw new ArgumentException("Class path cannot be empty!", "classPathString");

            //String result = null;
            //int position = classPathString.IndexOf(baseClassPathString, StringComparison.OrdinalIgnoreCase);
            //if (position == -1)
            //    throw new Exception(String.Format("Incompatible entity classes: \"{0}\" and \"{1}\"", classPathString, baseClassPathString));
            ////else
            //position = position + baseClassPathString.Length;
            //if (position < classPathString.Length)
            //    result = classPathString.Substring(position).TrimStart(':'); //вернуть остаток
            //else
            //    result = getLastClass(baseClassPathString);//вернуть последний базовый класс по правилам Хранилища

            //return result.Trim();
        }

        /// <summary>
        /// NR-Извлечь из выражения только цепочку абстракции класса
        /// </summary>
        /// <param name="classPath"></param>
        /// <returns></returns>
        public static string getAbstractionChain(string classPath)
        {
            //- возвращает string[]
            throw new NotImplementedException();//TODO: Add code here

            //string[] classes = ParseClassPathFromClassExpression(exp);
            //string result = ClassItem.JoinClasses(classes);
            //return result;
        }

        /// <summary>
        /// NR-Извлечь из выражения только агрегированные классы
        /// </summary>
        /// <param name="classPath"></param>
        /// <returns>
        /// Возвращает массив агрегированных классов выражения, как они были описаны в выражении.
        /// Если в выражении нет агрегированных классов, функция возвращает пустой массив.
        /// </returns>
        public static string[] getAggregatedClasses(string classPath)
        {
            //- возвращает string[]
            throw new NotImplementedException();//TODO: Add code here

        }

        /// <summary>
        /// NR-Проверить что выражение цепочки классов имеет допустимый формат
        /// </summary>
        /// <param name="classPath">Выражение цепочки классов.</param>
        /// <returns>Функция возвращает True при успехе и False при неудаче.</returns>
        public static bool isValidPath(string classPath)
        {
            //1. проверить наличие недопустимых для цепочки классов символов
            //2. проверить, что в строке только одна цепочка символов 
            //   - (нет ';' или нет символов после нее)
            //3. проверить, что группа агрегации определена только для последнего класса в цепочке.
            //4. проверить, что нет вложенных групп агрегации 
            //   - после '<' должны идти символы и '>', но не '<'
            //   - в строке присутствует только одна '<'  и после нее только одна '>'
 
            throw new NotImplementedException();//TODO: Add code here
        }

        /// <summary>
        /// NR-Проверить, что название класса имеет допустимый формат
        /// </summary>
        /// <param name="title">Название класса</param>
        /// <returns>Функция возвращает True при успехе и False при неудаче.</returns>
        public static bool isValidTitle(string title)
        {
            throw new NotImplementedException();//TODO: Add code here
        }
        /// <summary>
        /// NT-Проверить, что выражение описывает только один класс.
        /// </summary>
        /// <param name="expression">Текст выражения</param>
        /// <returns>Функция возвращает True, если текст выражения описывает только единственный класс или является пустой строкой, False - в противном случае.</returns>
        /// <example>
        /// Пример:
        /// Для выражения " " функция возвращает True.
        /// Для выражения "Класс" функция возвращает True.
        /// Для выражения "Класс::Подкласс" функция возвращает True.
        /// Для выражения "Класс;Класс::Подкласс"  функция возвращает False.
        /// </example>
        public static bool isSingleClassExpression(string expression)
        {
            //bool result = expression.Contains(ClassDelimiter);
            //такое простое решение не прокатит - выражение может содержать один класс и ClassDelimiter после него.
            
            string ex = expression.Trim();
            //если в строке нет символов вообще, возвращаем true, чтобы не запускать IndexOf()
            if (expression.Length == 0) return true;
            int delimiterPos = ex.IndexOf(EntityPath.ClassDelimiter);
            //если разделителя нет в строке, возвращаем true
            if (delimiterPos == -1) return true;
            //если разделитель в строке единственный и идет последним символом строки, возвращаем true.
            if (delimiterPos == ex.Length - 1) return true;
            //иначе возвращаем false
            return false;
        }
    }
}
