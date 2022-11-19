using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();  
        }
        public void Add(FriendAddData friendAddData)
        {
            var findUserEntity = userRepository.FindByEmail(friendAddData.FriendEmail);
            if (findUserEntity == null) throw new UserNotFoundException();

            if (friendRepository.FindAllByUserId(friendAddData.UserId).Any(p => p.friend_id == findUserEntity.id))
                throw new UserAlreadyFriendException();

            if (findUserEntity.id == friendAddData.UserId)
                throw new IncorrectUserException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddData.UserId,
                friend_id = findUserEntity.id,

            };

            if (friendRepository.Create(friendEntity) == 0)
            throw new Exception();
        }

        public void Delete(FriendDeleteData friendDeleteData)
        {
           var userToDeleteEntity=userRepository.FindByEmail(friendDeleteData.FriendEmail);
            if (userToDeleteEntity == null) throw new UserNotFoundException();

            friendDeleteData.FrienId=userToDeleteEntity.id;

            
            if (!friendRepository.FindAllByUserId(friendDeleteData.UserID).Any(p => p.friend_id == friendDeleteData.FrienId))
                throw new UserNotInFriendsException();
            

            var toDelete = friendRepository.FindAllByUserId(friendDeleteData.UserID).Where(p => p.friend_id == friendDeleteData.FrienId).FirstOrDefault();

            if (friendRepository.Delete(toDelete.id)==null) throw new Exception();
        }
    }
}
