using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeraySis.Common.Helpers;
using SeraySis.BLL.Abstract;
using SeraySis.BLL.Results;
using SeraySis.DAL.EntityFramework;
using SeraySis.Entities;
using SeraySis.Entities.Messages;
using SeraySis.Entities.ValueObjects;

namespace SeraySis.BLL
{
    public class UserManager : ManagerBase<Users>
    {
        public BusinessLayerResult<Users> RegisterUser(RegisterVM data)
        {
            Users control = Find(x => x.Username == data.Username || x.Email == data.Email);

            BusinessLayerResult<Users> layerResult = new BusinessLayerResult<Users>();

            if (control != null)
            {
                if (control.Username == data.Username)
                {
                    layerResult.AddError(Entities.Messages.ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı Adı Kayıtlı!");
                }
                if (control.Email == data.Email)
                {
                    layerResult.AddError(ErrorMessageCode.EmailAlreadyExists, "E-Posta Adresi Kayıtlı!");
                }
            }
            else
            {
                int dbResult = insert(new Users()
                {
                    Username = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = false,
                    IsAdmin = false

                });

                if (dbResult > 0)
                {
                    layerResult.Result = Find(x => x.Email == data.Email && x.Username == data.Username);

                    string siteUrl = ConfigHelper.Get<string>("SiteRouteUrl");
                    string activateUrl = $"{siteUrl}/Account/UserActivate/{layerResult.Result.ActivateGuid}";
                    string body = $"<a href='{activateUrl}' target='_blank'> Merhaba {layerResult.Result.Username}, Hesabini aktiflestirmek icin buraya tiklamalisin</a>";

                    MailHelper.SendMail(body, layerResult.Result.Email, subject: "Doktirini Hesap Aktiflestirme", isHtml: true);

                }
            }

            return layerResult;
        }

        public BusinessLayerResult<Users> LoginUser(LoginVM data)
        {

            BusinessLayerResult<Users> control = new BusinessLayerResult<Users>();
            control.Result = Find(x => x.Username == data.Username && x.Password == data.Password);


            if (control.Result != null)
            {
                if (!control.Result.IsActive)
                {
                    control.AddError(ErrorMessageCode.UserIsNoActive, "Aktif edilmemiş kullanıcı...");
                    control.AddError(ErrorMessageCode.CheckYourEmail, "Lutfen E-Posta Adresinizi Kontrol Ediniz.");
                }

            }
            else
            {
                control.AddError(ErrorMessageCode.UserNameOrPassWrong, "Kullanıcı Adı ya da Şifre Uyuşmuyor");
            }

            return control;
        }

        public BusinessLayerResult<Users> ActivateUser(Guid activateId)
        {
            BusinessLayerResult<Users> res = new BusinessLayerResult<Users>();
            res.Result = Find(x => x.ActivateGuid == activateId);

            if (res.Result != null)
            {
                if (res.Result.IsActive)
                {
                    res.AddError(ErrorMessageCode.UserAlreadyActive, "Kullanici zaten aktif edilmistir.");
                    return res;
                }

                res.Result.IsActive = true;
                Update(res.Result);
            }
            else
            {
                res.AddError(ErrorMessageCode.ActivateIdDoesNotExists, "Gecersiz aktiflestirme kodu");
            }

            return res;
        }

        public BusinessLayerResult<Users> GetUserById(int id)
        {
            BusinessLayerResult<Users> res = new BusinessLayerResult<Users>();
            res.Result = Find(x => x.Id == id);

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "Kullanici Bulunamadi");
            }

            return res;
        }

        public BusinessLayerResult<Users> GetUserByUserName(string username)
        {
            BusinessLayerResult<Users> res = new BusinessLayerResult<Users>();
            res.Result = Find(x => x.Username == username);

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "Kullanici Bulunamadi");
            }

            return res;
        }

        public BusinessLayerResult<Users> UpdateProfile(Users data)
        {
            //Kayitli bir kullanicinin bilgisini alamasin diye

            Users db_user = Find(x => x.Id != data.Id && (x.Username == data.Username || x.Email == data.Email));

            BusinessLayerResult<Users> res = new BusinessLayerResult<Users>();

            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
                }

                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "E-posta adresi kayıtlı.");
                }

                return res;
            }

            res.Result = Find(x => x.Id == data.Id);
            res.Result.Name = data.Name;
            res.Result.Surname = data.Surname;


            if (string.IsNullOrEmpty(data.ProfileImage) == false)
            {
                res.Result.ProfileImage = data.ProfileImage;
            }

            if (Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Profil güncellenemedi.");
            }

            return res;
        }

        public BusinessLayerResult<Users> RemoveUserById(int id)
        {
            BusinessLayerResult<Users> res = new BusinessLayerResult<Users>();
            Users control = Find(x => x.Id == id);

            if (control != null)
            {
                if (Delete(control) == 0)
                {
                    //res.AddError();
                    return res;
                }
            }
            else
            {
                // hata
            }
            return res;
        }
    }
}
