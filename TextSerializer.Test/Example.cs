using System;
using TextSerializer.Attributes;

namespace TextSerializer.Test
{
    [RegistrySize(200)] // Optional
    public class Example
    {
        [Index(1), Type(DataType.N), Length(1)]
        public int DocumentType { get; set; }

        [Index(2), Type(DataType.N), Length(1)]
        public int Operation { get; set; }

        [Index(3), Type(DataType.C), Length(7)]
        public string OperationName { get; set; }

        [Index(4), Type(DataType.N), Length(2)]
        public int ServiceCode { get; set; }

        [Index(5), Type(DataType.C), Length(15)]
        public string ServiceName { get; set; }

        [Index(6), Type(DataType.N), Length(4)]
        public string ActionCode { get; set; }

        [Index(7), Type(DataType.N), Length(2)]
        public int Filler0_Zeros { get; set; }

        [Index(8), Type(DataType.N), Length(5)]
        public string FunctionCode { get; set; }

        [Index(9), Type(DataType.N), Length(1)]
        public string CheckDigit { get; set; }


        [Index(10), Type(DataType.C), Length(8)]
        public int Filler1_Spaces { get; set; }

        [Index(11), Type(DataType.C), Length(30)]
        public string CompanyName { get; set; }

        [Index(12), Type(DataType.C), Length(3)]
        public string IssuerCode { get; set; }

        [Index(13), Type(DataType.C), Length(15)]
        public string IssuerName { get; set; }

        [Index(14), Type(DataType.C), Length(6)]
        public DateTime CreationDate { get; set; }

        [Index(15), Type(DataType.C), Length(94)]
        public int Filler2_Spaces { get; set; }

        [Index(16), Type(DataType.N), Length(6)]
        public int SequencialCode { get; set; }
    }
}
