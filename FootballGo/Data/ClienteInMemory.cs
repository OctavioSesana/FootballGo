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
                new Cliente(1, "Octavio", "Sesana", "octasesana@gmail.com", DateTime.Now.AddMonths(-5)),
            };
        }

    }
}
