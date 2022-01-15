using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EntityTypeExp
{
    /// <summary>
    /// Коллекция-словарь типов сущностей
    /// </summary>
    public class EntityTypesCollection: ICollection<EntityType>
    {
        //TODO: интерфейс ICollection добавлен, но неудобен для использования.
        
        #region *** Fields ***
        /// <summary>
        /// Словарь типов сущностей первого уровня
        /// </summary>
        private Dictionary<String, EntityType> m_EntityTypes;
        #endregion


        /// <summary>
        /// RT-Default constructor
        /// </summary>
        public EntityTypesCollection()
        {
            this.m_EntityTypes = new Dictionary<string, EntityType>();
        }
        
        #region *** Properties ***

        /// <summary>
        /// RT-Словарь типов сущностей первого уровня
        /// </summary>
        internal Dictionary<String, EntityType> EntityTypes
        {
            get { return m_EntityTypes; }
            set { m_EntityTypes = value; }
        }


        /// <summary>
        /// RT-Возвращает число элементов коллекции
        /// </summary>
        public int Count
        {
            get { return this.m_EntityTypes.Count; }
        }

        /// <summary>
        /// NR- Flag for Collection is read-only
        /// </summary>
        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); } //TODO: Add code here
        }

        #endregion



        /// <summary>
        /// NR-Распарсить строку описания классов сущности в дерево классов
        /// </summary>
        /// <param name="expression">Выражение описания классов сущности </param>
        public void ParseExpression(String expression)
        {
            throw new NotImplementedException();//TODO: Add code here
            
            ////Это образец формата для разработки парсинга.
            ////выражение представляет собой список выражений типов через ;
            ////Мои места:: Коллекция музыки<Файл::ФайлМузыки>;ЭлементФайловойСистемы::Папка<ЭлементФайловойСистемы>;ЭлементФайловойСистемы::Файл;

            ////тут надо бы исключение перехватывать и выводить boolean результат парсинга.

            ////парсим
            ////1) удаляем пробелы с начала и конца выражения
            //String exp = expression.Trim();
            ////2) разделяем на элементы по ;
            //String[] sar = exp.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            ////тут мы получим несколько элементов:
            ////[0] Мои места:: Коллекция музыки<Файл::ФайлМузыки>
            ////[1] ЭлементФайловойСистемы::Папка<ЭлементФайловойСистемы>
			////[2] ЭлементФайловойСистемы::Файл
            ////[3] элемент после последней ; должен уже быть удален как пустой элемент
            ////3) передаем каждое выражение для парсинга в объект типа 
            //foreach (String s in sar)
            //{
            //    EntityType t = new EntityType(); //создаем новый объект
            //    t.ParseExpression(s); //отправляем строку на парсинг
            //    this.m_EntityTypes.Add(t.Title, t); //добавляем объект в коллекцию.
            //}

            //return;
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }







        /// <summary>
        /// NR-
        /// </summary>
        /// <param name="item"></param>
        public void Add(EntityType item)
        {
            throw new NotImplementedException();//TODO: Add code here
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <param name="ets"></param>
        public void Add(EntityType[] ets)
        {
            throw new NotImplementedException();//TODO: Add code here
        }

        /// <summary>
        /// NR-
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();//TODO: Add code here
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(EntityType item)
        {
            throw new NotImplementedException();//TODO: Add code here
        }

        /// <summary>
        /// NR-Ищет запись типа по его названию. Если тип не упомянут, возвращается null
        /// </summary>
        /// <param name="nameOfType">Название типа</param>
        /// <returns>Возвращает первый найденный объект записи типа или null если объект не найден</returns>
        public EntityType ContainsType(String nameOfType)
        {
            throw new NotImplementedException();//TODO: Add code here
            ////ищем в словаре объект по названию класса. 
            ////Предполагается, что название класса уникальное?
            //if (m_EntityTypes.ContainsKey(nameOfType))
            //    return m_EntityTypes[nameOfType];
            //else
            //{
            //    //а если не нашли, то перебором всех элементов словаря ищем в них класс по имени класса. 
            //    foreach (KeyValuePair<String, EntityType> kvp in m_EntityTypes)
            //    {
            //        EntityType res = kvp.Value.ContainsType(nameOfType);
            //        if (res != null) return res;
            //    }
            //    return null;
            //}
        }


        /// <summary>
        /// NR-
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(EntityType[] array, int arrayIndex)
        {
            throw new NotImplementedException();//TODO: Add code here
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns></returns>
        public EntityType[] toArray()
        {
            throw new NotImplementedException();//TODO: Add code here
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(EntityType item)
        {
            throw new NotImplementedException();//TODO: Add code here
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <param name="EntityTypeName"></param>
        public void Remove(String EntityTypeName)
        {
            throw new NotImplementedException();//TODO: Add code here
        }

        IEnumerator<EntityType> IEnumerable<EntityType>.GetEnumerator()
        {
            throw new NotImplementedException();//TODO: Add code here
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();//TODO: Add code here
        }
    }//end class
}
