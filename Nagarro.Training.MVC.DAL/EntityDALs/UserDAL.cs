using System.Linq;
using AutoMapper;
using Nagarro.Training.MVC.Shared;
using Nagarro.Training.MVC.DAL.EntityDALs;
using System;


namespace Nagarro.Training.MVC.DAL
{
    public class UserDAL : IUserDAL
    {
        private IMapper mapUserDTO2Entity;
        private IMapper mapUserEntity2DTO;

        public UserDAL()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, UserEntity>();
            }
            );
            mapUserDTO2Entity = mapperConfiguration.CreateMapper();

            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserDTO>();
            }
            );
            mapUserEntity2DTO = mapperConfiguration1.CreateMapper();

        }

        /// <summary>
        /// Create new User 
        /// </summary>
        /// <param name="userDTO"></param>
        public UserDTO CreateUser(UserDTO userDTO)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    UserEntity userEntity = mapUserDTO2Entity.Map<UserEntity>(userDTO);
                    db.UserEntity.Add(userEntity);
                    db.SaveChanges();
                    UserEntity user = (from u in db.UserEntity
                                       where (u.EmailID == userEntity.EmailID && u.Password == userEntity.Password)
                                       select u).FirstOrDefault();

                    return mapUserEntity2DTO.Map<UserDTO>(user);
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }

        /// <summary>
        /// Check Logging in user.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public UserDTO LoginUser(UserDTO userDTO)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    UserEntity userEntity = mapUserDTO2Entity.Map<UserEntity>(userDTO);

                    UserEntity user = (from u in db.UserEntity
                                       where (u.EmailID == userEntity.EmailID && u.Password == userEntity.Password)
                                       select u).FirstOrDefault();

                    return mapUserEntity2DTO.Map<UserDTO>(user);
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }

        /// <summary>
        /// Get Details of User 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public UserDTO GetUserEntity(UserDTO userDTO)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    UserEntity userEntity = mapUserDTO2Entity.Map<UserEntity>(userDTO);

                    var user = (from u in db.UserEntity
                                where (u.EmailID == userEntity.EmailID)
                                select u).FirstOrDefault();

                    return mapUserEntity2DTO.Map<UserDTO>(user);
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }

        /// <summary>
        /// Get User having a particular userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserDTO GetUser(int userID)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    return mapUserEntity2DTO.Map<UserDTO>(db.UserEntity.Find(userID));
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }

        /// <summary>
        /// Edit Details of user.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public UserDTO EditUser(UserDTO userDTO)
        {
            try
            {
                using (BookReadingEventContext db = new BookReadingEventContext())
                {
                    UserEntity newUserEntity = mapUserDTO2Entity.Map<UserEntity>(userDTO);
                    UserEntity oldUserEntity = db.UserEntity.Find(newUserEntity.UserID);
                    db.Entry(oldUserEntity).CurrentValues.SetValues(newUserEntity);
                    db.SaveChanges();
                    return userDTO;
                }
            }
            catch (Exception)
            {
                throw new DALException(Resource.DALErrorMessage);
            }
        }
    }
}
