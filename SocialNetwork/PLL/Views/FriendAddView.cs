using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
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
    public class FriendAddView
    {
        public FriendAddView(UserService userService, FriendService friendService)
        {
            this.userService = userService;
            this.friendService = friendService;
        }

        public UserService userService { get; set; }  
        public FriendService friendService { get; set; }

        public void Show(User user)
        {
            var friendAddData = new FriendAddData();

            Console.WriteLine("Введите Email друга");
            friendAddData.FriendEmail = Console.ReadLine();
            friendAddData.UserId=user.Id;

            try
            {
                friendService.Add(friendAddData);
                var friend = userService.FindByEmail(friendAddData.FriendEmail);
                var message = friend.FirstName +" "+ friend.LastName + " Успешно добавлен в друзья";
                SuccessMessage.Show(message);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }
            catch (UserAlreadyFriendException)
            {
                AlertMessage.Show("Этот пользователь уже в списке друзей");
            }
            catch (IncorrectUserException)
            {
                AlertMessage.Show("Нельзя добавить в друзья самого себя");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
            }

        }


    }
}
