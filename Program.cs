using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DeliveryAppGrupo0008.Services;
using System.IO;

namespace DeliveryAppGrupo0008
{
    internal static class Program
    {
        public static DeliveryContext DbContext;

        [STAThread]
        static void Main()
        {
            // Cargar configuraci�n desde appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configurar el contexto con la cadena de conexi�n desde JSON
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
