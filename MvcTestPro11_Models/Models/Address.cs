using System.ComponentModel;

namespace MvcTestPro11_Models.Models
{
    public class Address
    {
        [DisplayName("����� 1")]
        public string Line1 { get; set; }

        [DisplayName("����� 2")]
        public string Line2 { get; set; }

        [DisplayName("�����")]
        public string City { get; set; }

        [DisplayName("�������� ������")]
        public string PostalCode { get; set; }

        [DisplayName("������")]
        public string Country { get; set; }
    }
}