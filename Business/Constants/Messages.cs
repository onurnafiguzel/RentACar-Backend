using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Maintenance = "Servis bakımda";

        public static string ProductAdded = "Ürün eklendi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductDeleted = "Ürün silindi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandListed = "Markalar listelendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";

        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalUpdated = "Kiralama güncellendi";

        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string CarImageDeleted = "Araba resmi silindi";

        public static string ImageCarExceded = "5 adet resim mevcut daha eklenemez.";
        public static string CarImageListed = "Araba resimleri listelendi.";
        public static string AuthorizationDenied = "Erişim reddedildi.";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfullLogin = "Başarılı giriş";
        public static string AccessTokenCreated = "AccessToken oluşturuldu";
        public static string RentalAddedError = "Rental Added Error";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string FindeksScoreError = "FindeksScore yetersiz";
    }
}
