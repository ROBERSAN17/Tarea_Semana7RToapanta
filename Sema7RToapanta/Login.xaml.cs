using Sema7RToapanta.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sema7RToapanta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;


        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }


        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("Select * from estudiante where Usuario=? and Contrasenia =?", usuario, contrasena);
        }
        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtContrasenia.Text);
                if (resultado.Count() > 0)
                {
                  Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario Incorrecto", "Cerrar");
                }
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "OKi");
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());

        }
    }
}
