using System.Linq;
using System.Threading.Tasks;
using vehicles.API.Common.Enums;
using vehicles.API.Data.Entities;
using vehicles.API.Helpers;

namespace vehicles.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            //crear la base de datos y aplica las migraciones
            await _context.Database.EnsureCreatedAsync();
            await checkVehiclesTypeAsync();
            await checkBrandsAsync();
            await checkDocumentTypesAsync();
            await checkProceduresAsync();
            await checkRolesAsync();
            await checkUserAsync("1010", "Santiago", "Murillo", "santiago@yopmail.com", "3217543188", "Calle 11", UserType.User);
            await checkUserAsync("1010", "Luis", "Salazar", "luis@yopmail.com", "311 322 4620", "Calle Luna Calle Sol", UserType.Admin);
            await checkUserAsync("2020", "Juan", "Zuluaga", "zulu@yopmail.com", "311 322 4620", "Calle Luna Calle Sol", UserType.User);
            await checkUserAsync("3030", "Ledys", "Bedoya", "ledys@yopmail.com", "311 322 4620", "Calle Luna Calle Sol", UserType.User);
            await checkUserAsync("4040", "Sandra", "Lopera", "sandra@yopmail.com", "311 322 4620", "Calle Luna Calle Sol", UserType.Admin);
        }

        private async Task checkUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Document = document,
                    DocumentType = _context.documentTypes.FirstOrDefault(x => x.Description == "Cédula"),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

            }
        }

        private async Task checkRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task checkProceduresAsync()
        {
            if (!_context.procedures.Any())
            {
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Alineación" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Lubricación de suspención delantera" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Lubricación de suspención trasera" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Frenos delanteros" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Frenos traseros" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Líquido frenos delanteros" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Líquido frenos traseros" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Calibración de válvulas" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Alineación carburador" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Aceite motor" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Aceite caja" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Filtro de aire" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Sistema eléctrico" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Guayas" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta delantera" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta trasera" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Reparación de motor" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Kit arrastre" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Banda transmisión" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Cambio batería" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Lavado sistema de inyección" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Lavada de tanque" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Cambio de bujia" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento delantero" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento trasero" });
                _context.procedures.Add(new Procedure { Price = 10000, Description = "Accesorios" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task checkDocumentTypesAsync()
        {
            if (!_context.documentTypes.Any())
            {
                _context.documentTypes.Add(new DocumentType { Description = "Cédula" });
                _context.documentTypes.Add(new DocumentType { Description = "Tarjeta de identidad" });
                _context.documentTypes.Add(new DocumentType { Description = "NIT" });
                _context.documentTypes.Add(new DocumentType { Description = "Pasaporte" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task checkBrandsAsync()
        {
            if (!_context.brands.Any())
            {
                _context.brands.Add(new Brand { Description = "Ducati" });
                _context.brands.Add(new Brand { Description = "Harley Davidson" });
                _context.brands.Add(new Brand { Description = "KTM" });
                _context.brands.Add(new Brand { Description = "BMW" });
                _context.brands.Add(new Brand { Description = "Triumph" });
                _context.brands.Add(new Brand { Description = "Victoria" });
                _context.brands.Add(new Brand { Description = "Honda" });
                _context.brands.Add(new Brand { Description = "Suzuki" });
                _context.brands.Add(new Brand { Description = "Kawasaky" });
                _context.brands.Add(new Brand { Description = "TVS" });
                _context.brands.Add(new Brand { Description = "Bajaj" });
                _context.brands.Add(new Brand { Description = "AKT" });
                _context.brands.Add(new Brand { Description = "Yamaha" });
                _context.brands.Add(new Brand { Description = "Chevrolet" });
                _context.brands.Add(new Brand { Description = "Mazda" });
                _context.brands.Add(new Brand { Description = "Renault" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task checkVehiclesTypeAsync()
        {
            if (!_context.vehicleTypes.Any())
            {
                _context.vehicleTypes.Add(new VehicleType { Description = "Carro" });
                _context.vehicleTypes.Add(new VehicleType { Description = "Moto" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
