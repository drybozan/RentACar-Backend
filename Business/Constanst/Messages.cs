using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constanst
{
    public static class Messages
    {
        public static string RentRule = "Günlük kira fiyatı 0'dan büyük olmalıdır.";
        public static string RentRule2 = "Araba adı 2 karekterden kısa olamaz.";
        public static string CarAdd = "Araba eklendi";
        public static string CarDelete = "Araba silindi";
        public static string CarUpdate = "Araba bilgileri güncellendi.";
        public static string CarList = "Arabalar listelendi.";

        public static string RentalAdded = "Araç kiralama başarılı";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string RentalListed = "Kiralama listelendi";
        public static string RentalCarNotAvailable = "Kiralamak istediğiniz arac daha once kiralanmis";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandListed = "Marka listelendi";
        public static string BrandNameInvalid = "Marka adi gecersiz";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorListed = "Renk listelendi";
        public static string ColorNameInvalid = "Renk adi gecersiz";

        public static string UserAdded = "Kullanici eklendi";
        public static string UserDeleted = "Kullanici silindi";
        public static string UserUpdated = "Kullanici güncellendi";
        public static string UsersListed = "Kullanicilar listelendi";
        public static string UserListed = "Kullanici listelendi";
        public static string UserEmailInvalid = "Kullanici e-mail gecersiz";
        public static string UserPasswordInvalid = "Kullanici sifresi gecersiz";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string CustomerListed = "Müşteri listelendi";
        public static string CustomerCompanyNameInvalid = "Müşteri sirket adi gecersiz";

        public static string CarImagesListed = "Arabanın resimleri listelendi";
        public static string CarsImagesListed = "Tüm araba resimleri listelendi";
        public static string CarImageListed = "Araba resmi listelendi";
        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string ImageNotFound = "Resim bulunamadı";
        public static string ErrorUpdatingImage = "Resim güncellenirken hata oluştu";
        public static string ErrorDeletingImage = "Resim silinirken hata oluştu";
        public static string CarImageLimitExceeded = "Bu araca daha fazla resim eklenemez";
    }
}
