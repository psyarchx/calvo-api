using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Calvo.Domain.Entities.General
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Digest { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        [NotMapped]
        [Required]
        public string Password
        {
            get { return Decrypt_Password(Digest); }
            set { Digest = Encrypt_Password(value); }
        }

        private string Encrypt_Password(string password)
        {
            string pswstr;
            byte[] psw_encode = new byte[password.Length];
            psw_encode = Encoding.UTF8.GetBytes(password);
            pswstr = Convert.ToBase64String(psw_encode);
            return pswstr;
        }

        private string Decrypt_Password(string encryptpassword)
        {
            string pswstr;
            UTF8Encoding encode_psw = new UTF8Encoding();
            Decoder Decode = encode_psw.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpassword);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            pswstr = new String(decoded_char);
            return pswstr;
        }
    }
}
