using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Services.Models;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;

        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }
        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.WriteLine("Для создания нового профиля введите ваше имя:");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.WriteLine("Ваша фамилия:");
            userRegistrationData.LastName = Console.ReadLine();

            Console.WriteLine("Ваш Email:");
            userRegistrationData.Email = Console.ReadLine();

            Console.WriteLine("Ваша пароль:");
            userRegistrationData.Password = Console.ReadLine();

            try
            {
                userService.Register(userRegistrationData);

                SuccessMessage.Show("Вы успешно зарегистрировались");
            }
            catch (ArgumentNullException)
            {

                AlertMessage.Show("Введите корректное значение");
            }
            catch(Exception)
            {
                AlertMessage.Show("Произошла ошибка");
            }

        }
    }
}
