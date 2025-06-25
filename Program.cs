using DeliveryAppGrupo0008.Models;
using DeliveryAppGrupo0008.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DeliveryAppGrupo0008
{
    internal static class Program
    {
        public static DeliveryContext DbContext;
        public static Usuario UsuarioLogueado { get; set; } 

        [STAThread]
        static void Main()
        {
            // Cargar configuración desde appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configurar el contexto con la cadena de conexión desde JSON
            var options = new DbContextOptionsBuilder<DeliveryContext>()
                .UseSqlServer(connectionString)
                .Options;

            DbContext = new DeliveryContext(options);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var authService = new AuthService(DbContext);
            Application.Run(new Forms.LoginForm(authService));
        }
    }
}
