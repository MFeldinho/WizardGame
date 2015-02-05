namespace Wizard.IO
{
    
    /// <summary>
    /// Statische Factory, um einen geeigneten IOManager zu erhalten.
    /// </summary>
    public static class IOManagerFactory
    {

        private static IIOManager _ioManager = null;

        /// <summary>
        /// Liefert einen IOManager vom Default-Typ (Console) zurück.
        /// </summary>
        /// <returns>IOManager</returns>
        public static IIOManager GetIOManager()
        {
            return GetIOManager(IOType.Unknown);
        }

        /// <summary>
        /// Liefert einen IOManager vom angegebenen Typ.
        /// Nur beim ersten Aufruf kann der Typ gewählt werden, danach wird immer der initiale IOManager
        /// zurückgegeben.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>IOManager</returns>
        public static IIOManager GetIOManager(IOType type)
        {
            if (_ioManager == null)
            {
                switch (type)
                {
                    case IOType.Console:
                        return new ConsoleIOManager();
                    case IOType.Form:
                        return new FormIOManager();
                    default:
                        return new ConsoleIOManager();
                }
            }

            return _ioManager;
        }

    }

}