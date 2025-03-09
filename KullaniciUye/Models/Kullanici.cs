using System;
using System.ComponentModel.DataAnnotations;

namespace KullaniciUye.Models
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez." )]
        [MinLength(3, ErrorMessage = "Ad alanı en az 3 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Ad alanı en fazla 30 karakter olmalıdır.")]
        [StringLength(30)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez.")]
        [MinLength(3, ErrorMessage = "Soyad alanı en az 3 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Soyad alanı en fazla 30 karakter olmalıdır.")]
        [StringLength(30)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
       
        [DataType(DataType.Password)]
        [StringLength(15)]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Şifre onay alanı boş geçilemez.")]
        
        [DataType(DataType.Password)]
        [StringLength(15)]
       [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string SifreOnayla { get; set; } 

        public DateTime? KayitTarihi { get; set; } = DateTime.Now;
    }
}