using ApplicationsControllerConsole.DTO;
using System.Net.Http.Json;

namespace ApplicationsControllerConsole
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string baseUrl = "http://localhost:5022/api/";
        static void Main()
        {
            client.BaseAddress = new Uri(baseUrl);
            //ApplicationsController
            Console.WriteLine("0.Получение заявки уникальному коду");
            Console.WriteLine("1.Получение списка персональных заявок по почте заявителя");
            Console.WriteLine("2.Получение списка групповых заявок по почте заявителя");
            //ReferenceController
            Console.WriteLine("3.Получение списка Список подразделений ");
            Console.WriteLine("4.Получение списка Список сотрудников указанного подразделения ");
            //ApprovalController
            Console.WriteLine("5.Получение списка заявок по отделению");
            Console.WriteLine("6.Подтверждение заявки ");
            Console.WriteLine("7.запрет заявки");
            Console.WriteLine("");
            Console.WriteLine("Введите номер требуемой операции");
            int.TryParse(Console.ReadLine(), out var result);

            switch (result)
            {
                default: Console.WriteLine("неверная операция, введите номер без лишних символов"); break;
                case 0: NewZero(); Console.ReadLine(); break;
                case 1: First(); Console.ReadLine(); break;
                case 2: Second(); Console.ReadLine(); break;
                case 3: Third(); Console.ReadLine(); break;
                case 4: Fourth(); Console.ReadLine(); break;
                case 5: Fifth(); Console.ReadLine(); break;
                case 6: Sixth(); Console.ReadLine(); break;
                case 7: Seventh(); Console.ReadLine(); break;
            }
        }

        public static async void First()
        {
            Console.Write("Введите email заявителя: ");
            var id = Console.ReadLine();
            var data = await client.GetFromJsonAsync<IEnumerable<ApplicationDTO>>($"Applications/PersApplicationByEmail?ApplicantEmail={id}");
            foreach (var data1 in data)
            {
                string res = $"{data1.Id} | {data1.RejectionReason} | {data1.StartDate} | {data1.EndDate} | {data1.Purpose}" +
                    $"  {data1.ApplicantEmail} | {data1.CreatedAt} | {data1.ApplicationType} | {data1.Status}";
                var co = new string('-', res.Count());
                Console.WriteLine(co);
                Console.WriteLine(res);
                Console.WriteLine(co);
            }
        }
        public static async void Second()
        {
            Console.Write("Введите email заявителя: ");
            var id = Console.ReadLine();
            var data = await client.GetFromJsonAsync<IEnumerable<ApplicationDTO>>($"Applications/GroupApplicationByEmail?ApplicantEmail={id}");
            foreach (var data1 in data)
            {
                string res = $"{data1.Id} | {data1.RejectionReason} | {data1.StartDate} | {data1.EndDate} | {data1.Purpose}" +
                    $"  {data1.ApplicantEmail} | {data1.CreatedAt} | {data1.ApplicationType} | {data1.Status}";
                var co = new string('-', res.Count());
                Console.WriteLine(co);
                Console.WriteLine(res);
                Console.WriteLine(co);
            }
        }
        public static async void Third()
        {
            var data = await client.GetFromJsonAsync<IEnumerable<DepartmentDTO>>($"Reference/Third");
            foreach (var data1 in data)
            {
                string res = $"{data1.Id} | {data1.Name} | {data1.Code}";
                var co = new string('-', res.Count());
                Console.WriteLine(co);
                Console.WriteLine(res);
                Console.WriteLine(co);
            }
        }
        public static async void Fourth()
        {
            Console.Write("Введите id департамента: ");
            var id = Console.ReadLine();
            var data = await client.GetFromJsonAsync<IEnumerable<EmployeeDTO>>($"Reference/Fourth?idDep={id}");
            foreach (var data1 in data)
            {
                string res = $"{data1.Id} | {data1.FullName} | {data1.DepartamentId}";
                var co = new string('-', res.Count());
                Console.WriteLine(co);
                Console.WriteLine(res);
                Console.WriteLine(co);
            }
        }
        public static async void Fifth()
        {
            Console.Write("Введите id департамента: ");
            var id = Console.ReadLine();
            var data = await client.GetFromJsonAsync<IEnumerable<ApplicationDTO>>($"Approval/Fifth?idDep={id}");
            foreach (var data1 in data)
            {
                string res = $"{data1.Id} | {data1.ApplicationType} | {data1.Status}| {data1.RejectionReason}| {data1.StartDate}| {data1.EndDate}| {data1.Purpose}| {data1.DepartmentId}| {data1.EmployeeId}| {data1.ApplicantEmail}| {data1.CreatedAt}| {data1.UpdatedAt}";
                var co = new string('-', res.Count());
                Console.WriteLine(co);
                Console.WriteLine(res);
                Console.WriteLine(co);
            }
        }
        public static async void Sixth()
        {

        }
        public static async void Seventh()
        {

        }

        public static async void NewZero()
        {
            Console.Write("Введите уникальный код заявки: ");
            var id = Console.ReadLine();
            var data = await client.GetFromJsonAsync<IEnumerable<ApplicationDTO>>($"Applications/ApplicationById?applicantId={id}");
            foreach (var data1 in data)
            {
                string res = $"{data1.Id} | {data1.RejectionReason} | {data1.StartDate} | {data1.EndDate} | {data1.Purpose}" +
                    $"  {data1.ApplicantEmail} | {data1.CreatedAt} | {data1.ApplicationType} | {data1.Status}";
                var co = new string('-', res.Count());
                Console.WriteLine(co);
                Console.WriteLine(res);
                Console.WriteLine(co);
            }
        }
    }
}