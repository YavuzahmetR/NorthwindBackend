using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);

            var accessToken = _tokenHelper.CreateToken(user, claims);

            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessCreateToken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userCheckResult = _userService.GetByEmail(userForLoginDto.Email);
            if (userCheckResult == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }


            if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userCheckResult.PasswordHash , userCheckResult.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordNotFound);
            }

            return new SuccessDataResult<User>(userCheckResult,Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true // bir verifikasyondan sonra aktive edilebilir kuruma göre değişir başlangıç değeri

            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.UserRegistered);

        }

        public IResult UserExists(string email)
        {
            if(_userService.GetByEmail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
