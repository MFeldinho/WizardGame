using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wizard.Common
{

    public static class CloneTools
    {

        /// <summary>
        /// Generische Methode zum Klonen (deep copy) von beliebigen Objekten.
        /// Das Objekt <c>source</c> muss serialisierbar sein, ansonsten wird eine <c>ArgumentException</c> erzeugt.
        /// </summary>
        /// <typeparam name="T">Typ des zu klonenden Objekts</typeparam>
        /// <param name="source">Objekt</param>
        /// <returns>Klon</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Default zurückgeben, wenn das zu klonende Objekt NULL ist
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();

            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

    }

}