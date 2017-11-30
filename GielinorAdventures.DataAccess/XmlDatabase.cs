using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GielinorAdventures.DataAccess
{
    /// <summary>
    /// XML database.
    /// </summary>
    class XmlDatabase<T>
    {
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlDatabase"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public XmlDatabase(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Loads the entities.
        /// </summary>
        /// <returns>The entities.</returns>
        public IEnumerable<T> LoadEntities()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<T>));
            IEnumerable<T> entities = null;

            try
            {
                using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    entities = (IEnumerable<T>)xs.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                string logMessage = "The repository cannot be accessed";
                // TODO: Log error

                Console.WriteLine(logMessage + Environment.NewLine + ex);
            }

            return entities;
        }

        /// <summary>
        /// Saves the entities.
        /// </summary>
        /// <param name="entities">Entities.</param>
        public void SaveEntities(IEnumerable<T> entities)
        {
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                    xs.Serialize(sw, entities);
                }
            }
            catch (Exception ex)
            {
                string logMessage = "The repository cannot be accessed";
                // TODO: Log error

                Console.WriteLine(logMessage + Environment.NewLine + ex);
            }
        }
    }
}
