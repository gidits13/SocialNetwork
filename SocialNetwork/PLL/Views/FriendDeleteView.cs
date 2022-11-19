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
    public class FriendDeleteView
    {
        UserService userService;
        FriendService friendService;

        public FriendDeleteView(UserService userService,FriendService friendService)
        {
            this.userService = userService;
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var friendDeleteData = new FriendDeleteData();

            Console.WriteLine("Ввведите Email пользователя для удаления из списка друзей");
            friendDeleteData.FriendEmail = Console.ReadLine();
            friendDeleteData.UserID = user.Id;

            try
            {
                friendService.Delete(friendDeleteData);
                var message = "Пользователь успешно удален из списка друзей";
                SuccessMessage.Show(message);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден");
            }
            catch(UserNotInFriendsException)
            { 
                AlertMessage.Show("Данный пользователь отсутствует в списке друзей");
            }
            catch(Exception)
            {
                AlertMessage.Show("Произошла ошибка");
            }
        }
    }
}
