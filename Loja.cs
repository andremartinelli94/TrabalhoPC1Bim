using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace TrabalhoPC1Bim
{
    class Loja
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public double Preco { get; set; }

        public void AlteraNomeProd(string novoprod)
        {
            Produto = novoprod;
        }

        public void AlterarProduto(double porcentagem)
        {
            Preco += Preco * porcentagem / 100.0;
        }
        public override string ToString()
        {
            return "#" + Id + "| " + Produto + "| " + Preco.ToString("F2", CultureInfo.InvariantCulture);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Loja objAsPart = obj as Loja;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return Id;
        }
        public bool Equals(Loja other)
        {
            if (other == null) return false;
            return (this.Id.Equals(other.Id));
        }

    }
}
