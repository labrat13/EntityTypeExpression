﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryModuleManager2.ClassificationEntity
{
    //THEME: QNAME - переработать все места по этой теме
    
    /// <summary>
    /// Управляет квалифицированными именами.
    /// </summary>
    /// <remarks>
    /// 
    /// Пример квалифицированного пути файла:
    /// Предмет.Радиодеталь.Транзистор/docs1/КТ315Б.pdf
    /// Предмет/pics1/picture.gif
    /// 
    /// Здесь:
    /// Предмет.Радиодеталь.Транзистор - квалифицированное имя хранилища, 
    /// составленное из иерархии классов сущностей, 
    /// размещенных в Хранилище, от корня иерархии до класса сущности, представленной в Хранилище.
    /// То есть, в данном случае, в хранилище находятся сущности, относящиеся к классу Транзистор и его подклассам.
    /// И их строка типа должна начинаться с слова Транзистор.
    /// Классы разделены точкой. 
    /// 
    /// После квалифицированного имени хранилища идет имя каталога. 
    /// Может быть только один каталог между именем файла и квалифицированным именем хранилища.
    /// Это имя определяет раздел хранилища: документ или изображение.
    /// Это же имя является именем файла архива, в котором находится файл. 
    /// Чтобы получить имя файла архива, надо добавить стандартное расширение архива.
    /// Это же имя используется для папки, которая находится в корне архива и в которой хранятся все помещаемые в архив файлы.
    /// Таким образом, при распаковке всех архивов вручную, относительный порядок в хранилище все еще сохраняется.
    /// Такая распаковка возможна, когда пользователю нужен доступ к файлам, а менеджер хранилища он не может использовать.
    /// В этом случае файлы архивов распаковываются в один каталог и оказываются в относительно упорядоченном виде.
    ///  
    /// После имени каталога идет собственно имя файла в этом каталоге и его расширение.
    /// Все файлы внутри раздела документов либо внутри раздела изображений имеют уникальные имена.
    /// 
    /// </remarks>
    public class QualifiedNameManager
    {
        /// <summary>
        /// Разделитель файлов и каталогов в пути
        /// </summary>
        internal const string PathDelimiterString = "/";
        /// <summary>
        /// Разделитель классов в записи классов
        /// </summary>
        internal const string ClassDelimiter = "::";
        
        /// <summary>
        /// NT-Извлечь квалифицированное имя хранилища
        /// </summary>
        /// <param name="qualifiedName">Квалифицированный путь</param>
        /// <returns></returns>
        public static string getStorageQName(string qualifiedName)
        {
            //отделить по первому символу '/'
            String[] sar = qualifiedName.Split('/');
            //может быть только два или три элемента пути. 
            if ((sar.Length < 2) || (sar.Length > 3)) 
                throw new Exception(String.Format("Invalid qualified path: {0}", qualifiedName));
            //вернуть квалифицированное имя
            return sar[0];
        }

        /// <summary>
        /// NR-Извлечь путь к файлу в Хранилище
        /// </summary>
        /// <param name="qualifiedName"></param>
        /// <returns></returns>
        public static string getFileQName(string qualifiedName)
        {
            //отделить по первому символу '/'
            String[] sar = qualifiedName.Split('/');
            //может быть только два или три элемента пути. 
            if ((sar.Length < 2) || (sar.Length > 3))
                throw new Exception(String.Format("Invalid qualified path: {0}", qualifiedName));
            //вернуть квалифицированное имя
            String result = sar[1];
            //если есть третий элемент, то это путь к файлу
            if (sar.Length == 3)
                result = result + PathDelimiterString + sar[2];

            return result;
        }
        /// <summary>
        /// NT-Собрать квалифицированное имя файла
        /// </summary>
        /// <param name="storageQName">Квалифицированное имя хранилища</param>
        /// <param name="archpath">Путь файла внутри хранилища</param>
        /// <returns>Возвращает квалифицированное имя файла для использования вне хранилища</returns>
        internal static string CombineForFile(string storageQName, string archpath)
        {
            return storageQName + PathDelimiterString + archpath;
        }


    }
}
