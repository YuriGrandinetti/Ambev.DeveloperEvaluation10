using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity, ISale
    {
     //   public Guid Id { get; set; }
        public string NumeroVenda { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; }= DateTime.MinValue;
        public int CustomerId { get; set; } = 0;
        public int BranchId { get; set; }= 0;
        public decimal ValorTotalVenda { get; set; } = decimal.Zero;

        // Propriedades de navegação
        public Customer Customer { get; set; } = new Customer();
        public Branch Branch { get; set; } = new Branch();
        // Campo privado para armazenar os itens (mutável)
     //  private readonly List<SaleItem> _itens = new List<SaleItem>();

        // Exposição dos itens como somente leitura
       // public IReadOnlyCollection<SaleItem> Itens => _itens.AsReadOnly();
        public List<SaleItem> Itens { get; set; }  = new List<SaleItem>();

        /// <summary>
        /// Adiciona um item à venda e atualiza o valor total da venda.
        /// </summary>
        /// <param name="item">O item da venda a ser adicionado.</param>
        public void AdicionarItem(SaleItem item)
        {
          //  List<SaleItem> _itenspe  = new List<SaleItem>();
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Itens.Add(item);
         //   _itens.Add(item);
            ValorTotalVenda += item.CalcularTotal();
        }


        string ISale.Id => Id.ToString();
        string ISale.NumeroVenda  => NumeroVenda.ToString();

        /// Construtor que permite a criação de uma venda com um Id e a data da venda.
        /// Utilizado para facilitar a geração de dados via Faker.
        /// </summary>
        /// <param name="id">Identificador único da venda.</param>
        /// <param name="dataVenda">Data em que a venda ocorreu.</param>
        public Sale(Guid id, DateTime dataVenda)
        {
            Id = id;
            DataVenda = DateTime.Now;
        }

        public Sale()
        {
            DataVenda = DateTime.Now;
        }

        /// <summary>
        /// Performs validation of the user entity using the UserValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Username format and length</list>
        /// <list type="bullet">Email format</list>
        /// <list type="bullet">Phone number format</list>
        /// <list type="bullet">Password complexity requirements</list>
        /// <list type="bullet">Role validity</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
