using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTypeExp
{
    /// <summary>
    /// Представляет дерево классов
    /// </summary>
    public class EntityTypesTree
    {
        //Это должен быть основной класс данной темы с выражениями типов классов.
        //В нем нужно реализовать все практически применимые функции работы с классами для приложений.
        //Но я обычно делал в своих проектах более простые алгоритмы для более простых и ограниченных случаев.
        //А тут весь код надо писать практически заново, для поддержки всего, что когда-нибудь, возможно, потребуется.
 
        //TODO: Добавить функции дерева 
        
        //1. GetFullPath  Returns the absolute path for the specified path string.
        //- вернуть полный путь в цепочке классов 
        //- требует дерева классов
        //4. Получить полную форму класса (с родительскими классами и агрегированными классами) по его названию.
        //- На входе: Транзистор На выходе: Предмет::Радиодеталь::Транзистор
        /// <summary>
        /// NR-вернуть полный путь в цепочке классов 
        /// </summary>
        /// <param name="partialPath">частичный путь или имя конечного класса.</param>
        /// <returns></returns>
        public string GetFullPath(string partialPath)
        {
            
            
            throw new NotImplementedException();//TODO: add code here
        }
        

        //2. GetRandomName  Returns a random class name.
        //- Вернуть случайное название класса для использования в пакетном добавлении классов.
        //- понятия не имею, зачем это может пригодиться, если вся суть класса здесь заключается в его названии и еще - в его связях.
        //- только в дереве классов можно определить, что название уникальное и не существует в дереве.

        /// <summary>
        /// NR-Returns a random class name
        /// </summary>
        /// <returns>Вернуть случайное название класса для использования в пакетном добавлении классов.</returns>
        public string GetRandomName()
        {
            throw new NotImplementedException();//TODO: add code here
        }


        //3. Добавить выражение классов Сущности для пополнения Дерева классов.
        //- А) каждое вхождение класса представлено собственным объектом
        //- Проблема: это будет не дерево, а список ветвей.
        //- Б) все вхождения класса представлены единственным объектом.
        //- Проблема: тогда это уже не дерево получится, а граф.
        //- В) реализовать дерево, как оно сделано в браузере Хранилищ.
        //- код есть в материалах проекта?
        //- ТОДО: сформулировать способ построения такого дерева здесь
		//TODO: проверять, что выражение не противоречит уже существующему дереву. 
		//  Если есть конфликт структуры и наследования, то выдавать ошибку или выбрасывать исключение. 
		//  Для этого надо разработать теорию для выявления ошибок структуры классов.
        /// <summary>
        /// NR-Добавить выражение классов Сущности для пополнения Дерева классов.
        /// </summary>
        /// <param name="expression">Выражение классов</param>
        public void AddExpression(string expression)
        {
            throw new NotImplementedException();//TODO: add code here
        }
        

        //5. Получить список корневых классов дерева 
        //- TODO: как массив названий или как массив объектов EntityType?
        /// <summary>
        /// NR-Получить массив объектов корневых классов дерева
        /// </summary>
        /// <returns></returns>
        public EntityType[] GetRoots()
        {
            throw new NotImplementedException();//TODO: add code here
        }
        /// <summary>
        /// NR-Получить массив названий корневых классов дерева
        /// </summary>
        /// <returns></returns>
        public String[] GetRootTitles()
        {
            throw new NotImplementedException();//TODO: add code here
        }

        //7. Получить ноду дерева - объект класса по его названию.
        //Получить объект класса EntityType по названию класса.
        //TODO: а если класс участвует внутри группы абстракции какого-то класса,
        //то в дереве может быть много его объектов. Какой объект вернуть?
        //- очевидно, тот, что участвует в цепочке абстракции - имеет надклассы.
        //Тут пробел в теории:
        //  Так как классы в группе агрегации не образуют цепочек абстракции, они только упоминаются, подобно ссылкам.
        //   то и представлять их объектами EntityType - избыточно. 
        //Очевидно, подклассы класса-контейнера должны наследовать его классы из группы абстракции, хоть они и не упоминаются в записи класса.
        //Но вот эта часть концепции пока не продумана мною, я занялся цепочкой абстракции как практической частью,
        //востребованной в проектах, а цепочку агрегации отложил на момент, когда в ней возникнет понятная необходимость.
        //Возможно, следует коллекцию подклассов агрегации в объектах EntityType заменить на коллекцию строк-названий подклассов?
        //Тогда в дереве будет (вроде бы ?) один объект класса, и этой функции возвращать придется только его.
        /// <summary>
        /// NR-Получить ноду дерева - объект класса по его названию.
        /// </summary>
        /// <param name="title">Название класса</param>
        /// <returns>Функция возвращает объект класса.</returns>
        public EntityType GetEntity(String title)
        {
            throw new NotImplementedException();//TODO: add code here
        }

        //8. Проверить, имеет ли класс с указанным названием подклассы в цепочке абстракции.
        //- это можно сделать только в дереве, так как объект класса EntityType не хранит ссылки на подклассы в цепочке абстракции.
        /// <summary>
        /// NR-Проверить, имеет ли класс с указанным названием подклассы в цепочке абстракции.
        /// </summary>
        /// <param name="classPath">Путь класса</param>
        /// <returns></returns>
        public bool hasSubClasses(string classPath)
        {
            throw new NotImplementedException();//TODO: add code here
        }

        //9. Проверить, имеет ли класс с указанным названием подклассы агрегации - является ли контейнером.
        //- Это функция для класса EntityType, а в дереве можно реализовать обертку, 
        //  чтобы пользовательскому коду работать с деревом,
        //  и скрыть реализацию этого механизма для пользователя.
        /// <summary>
        /// NR-Проверить, имеет ли класс с указанным названием подклассы агрегации - является ли контейнером.
        /// </summary>
        /// <param name="classPath">Путь класса</param>
        /// <returns></returns>
        public bool hasAggregation(string classPath)
        {
            throw new NotImplementedException();//TODO: add code here
        }


        //10. Проверить, является ли класс с указанным названием корнем дерева.
        //- проверить, содержит ли данный класс ссылку на какой-либо надкласс.
        //  Если нет, значит данный класс является корнем в дереве классов.
        //- Это функция для класса EntityType, а в дереве можно реализовать обертку, 
        //  чтобы пользовательскому коду работать с деревом,
        //  и скрыть реализацию этого механизма для пользователя.
        /// <summary>
        /// NR-Проверить, является ли класс с указанным названием корнем дерева.
        /// </summary>
        /// <param name="classPath">Путь класса</param>
        /// <returns></returns>
        public bool isRoot(string classPath)
        {
            throw new NotImplementedException();//TODO: add code here
        }


        //11. Проверить, является ли класс с указанным названием листом дерева.
        //- Проверить, содержат ли другие классы в дереве ссылку на данный надкласс. Если нет ссылок, то данный класс является конечным узлом - листом дерева.
        /// <summary>
        /// NR-Проверить, является ли класс с указанным названием листом дерева.
        /// </summary>
        /// <param name="classPath">Путь класса</param>
        /// <returns></returns>
        public bool isLeaf(string classPath)
        {
            throw new NotImplementedException();//TODO: add code here
        }

        //12.- Проверить, что класс является подклассом указанного класса-аргумента - по иерархии абстракции
        //- получить уровень глубины абстракции - целое число классов между двумя классами в цепочке иерархии.
        //  = 0: А = Б оба названия обозначают один и тот же класс
        //  = 1: А надкласс Б как А::Б
        //  = 2: А надкласс Б как А::Х::Б
        //  = -1: А подкласс Б как Б::А
        //  = -2:  А подкласс Б как Б::Х::А
        //  ... и так далее
        //TODO: а если между классами нет связи в цепочке абстракции, как это обозначать в возвращаемом результате функции?
        //- возвращать Double.Infinity ?
        /// <summary>
        /// NR- получить уровень глубины абстракции - целое число классов между двумя классами в цепочке иерархии.
        /// </summary>
        /// <param name="classPathA">Путь класса A</param>
        /// <param name="classPathB">Путь класса B</param>
        /// <returns></returns>
        public Double GetAbstractionLevel(string classPathA, string classPathB)
        {
            throw new NotImplementedException();//TODO: add code here
        }


        //14. - проверить, что указанное выражение записи цепочки классов уже есть в дереве классов.
        //- запись может содержать несколько классов, любой из которых, может оказаться, не присутствует в дереве.
        //  Поэтому результат Да-Нет тут не может быть использован.
        //Тут надо разделить цепочку на раздельные записи классов (по ;) и каждую проверять.
        /// <summary>
        /// NR-проверить, что указанное выражение записи цепочки классов уже есть в дереве классов.
        /// </summary>
        /// <param name="expression">Выражение классов</param>
        /// <returns></returns>
        public bool isExpressionExists(string expression)
        {
            throw new NotImplementedException();//TODO: add code here
        }

        //15. Вывести дерево классов в текстовый файл, в XML-файл.
        /// <summary>
        /// NR-Вывести дерево классов в текстовый файл
        /// </summary>
        /// <param name="filepath">Путь к файлу</param>
        /// <param name="enc">Кодировка файла</param>
        public void StoreToTxt(String filepath, Encoding enc)
        {
            //TODO: найти где-то у меня был код для вывода дерева классов через ---
            // - В проекте переработки классификации слов?
            throw new NotImplementedException();//TODO: add code here
        }
        /// <summary>
        /// NR-Вывести дерево классов в XML-файл.
        /// </summary>
        /// <param name="filepath">Путь к файлу</param>
        public void StoreToXml(String filepath)
        {
            throw new NotImplementedException();//TODO: add code here
        }
        
        //16. Загрузить дерево классов из текстовый файла, из XML-файла.
        /// <summary>
        /// NR-Загрузить дерево классов из текстовый файла.
        /// </summary>
        /// <param name="filepath">Путь к файлу</param>
        /// <param name="enc">Кодировка файла</param>
        public void LoadFromTxt(String filepath, Encoding enc)
        {
            throw new NotImplementedException();//TODO: add code here
        }
        /// <summary>
        /// NR-Загрузить дерево классов из XML-файла.
        /// </summary>
        /// <param name="filepath">Путь к файлу</param>
        public void LoadFromXml(String filepath)
        {
            throw new NotImplementedException();//TODO: add code here
        }


        //17. Выполнить сложение (слияние) двух деревьев.
        //- Результатом должно стать новое дерево
        //  TODO: надо определить правила сложения двух деревьев.
        //- вероятно, по тому же принципу, что и добавление записей классов в джерево.
        /// <summary>
        /// NR-Выполнить сложение (слияние) двух деревьев.
        /// </summary>
        /// <param name="treeA">Дерево A</param>
        /// <param name="treeB">Дерево B</param>
        /// <returns>Функция возвращает новое дерево как результат сложения.</returns>
        public static EntityTypesTree Summation(EntityTypesTree treeA, EntityTypesTree treeB)
        {
            throw new NotImplementedException();//TODO: add code here
        }


        //18. Выполнить вычитание двух деревьев.
        //- Результатом должно стать новое дерево
        // TODO: надо определить правила вычитания двух деревьев.
        /// <summary>
        /// NR-Выполнить вычитание двух деревьев.
        /// </summary>
        /// <param name="treeA">Дерево A</param>
        /// <param name="treeB">Дерево B</param>
        /// <returns>Функция возвращает новое дерево как результат вычитания.</returns>
        public static EntityTypesTree Subtraction(EntityTypesTree treeA, EntityTypesTree treeB)
        {
            throw new NotImplementedException();//TODO: add code here
        }

        //19. Для данных нескольких классов вернуть общий надкласс и пути от него до каждого из указанных классов.
        //- Это возможно, если все указанные классы имеют общий надкласс.
        //  TODO: А если это не так, то что делать?

        /// <summary>
        /// NR-Для данных нескольких классов вернуть общий надкласс
        /// </summary>
        /// <param name="classes">Массив классов</param>
        /// <returns></returns>
        public string GetSingleAbstraction(string[] classes)
        {
            throw new NotImplementedException();//TODO: add code here
        }
        /// <summary>
        /// NR-Для данных нескольких классов вернуть общий надкласс
        /// </summary>
        /// <param name="classes">Массив классов</param>
        /// <returns></returns>
        public EntityType GetSingleAbstractionEntity(EntityType[] classes)
        {
            throw new NotImplementedException();//TODO: add code here
        }

       

    }
}
