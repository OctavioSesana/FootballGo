using Domain.Model;

namespace Data
{
    public class ClienteInMemory
    {
        //No es ThreadSafe pero sirve para el proposito del ejemplo        
        public static List<Cliente> Clientes;

        static ClienteInMemory()
        {
            Clientes = new List<Cliente>
            {
                new Cliente(1, "Octavio", "Sesana", "octasesana@gmail.com", 43644808, 33333, DateTime.Now.AddMonths(-5)),
                new Cliente(2, "Emilio", "Zallocco", "emizallocco@gmail.com", 44789093, 222, DateTime.Now.AddMonths(-5)),
            };
        }

    }
}
