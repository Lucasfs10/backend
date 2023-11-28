using Data.Models;
using Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FtsWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonServices _personServices;

        public PersonController(PersonServices personServices)
        {
            _personServices = personServices;
        }

        [HttpGet]
        public async Task<List<Person>> List()
        {
            return await _personServices.GetAsync();
        }

        [HttpPost]
        public async Task<Person> Post(Person produto)
        {
            await _personServices.CreateAsync(produto);

            return produto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(string id)
        {
            Person produto = await _personServices.GetByIdAsync(id);

            if (produto == null)
            {
                return NotFound(); // Retorna 404 Not Found se o produto não for encontrado
            }

            return produto;
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Update(string id, Person produto)
        {
            var existingProduto = await _personServices.GetByIdAsync(id);

            if (existingProduto == null)
            {
                return NotFound(); // Retorna 404 Not Found se o produto não for encontrado
            }

            // Atualiza as propriedades do produto existente com as do produto recebido
            existingProduto.Name = produto.Name;
            existingProduto.Phone = produto.Phone;
            existingProduto.Document = produto.Document;

            await _personServices.UpdateAsync(id, existingProduto);

            return existingProduto;
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            var existingProduto = await _personServices.GetByIdAsync(id);

            if (existingProduto == null)
            {
                return NotFound(); // Retorna 404 Not Found se o produto não for encontrado
            }

            await _personServices.DeleteAsync(id);

            return NoContent(); // Retorna 204 No Content indicando sucesso sem conteúdo
        }
    }
}
