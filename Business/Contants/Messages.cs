using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla Eklendi";

        public static string ProductDeleted = "Ürün başarıyla Silindi";

        public static string ProductUpdated = "Ürün başarıyla Güncellendi";

        public static string UserNotFound = "Kullanıcı Bulunamadı";

        public static string PasswordNotFound = "Şifre Bulunamadı";

        public static string SuccessfulLogin = "Giriş Başarılı";

        public static string UserAlreadyExists = "Böyle Bir Kullanıcı Zaten Mevcut";

        public static string UserRegistered = "Kullanıcı Başarıyla Kaydedildi";

        public static string AccessCreateToken = "Access Token Başarıyla Oluşturuldu.";
    }
}
