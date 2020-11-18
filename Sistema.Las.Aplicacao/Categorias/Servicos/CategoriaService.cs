using AutoMapper;
using Sistema.Las.Aplicacao.Contratos;
using Sistema.Las.Aplicacao.Interfaces;
using Sistema.Las.Domain.Categorias.Comandos;
using Sistema.Las.Domain.Categorias.Entidades;
using Sistema.Las.Domain.Categorias.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.Las.Aplicacao.Servicos
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaService(
            ICategoriaRepositorio categoriaRepositorio,
            IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }

        public async Task<CriaCategoriaCommand> Adicionar(CriaCategoriaCommand CategoriaCommand)
        {
            var categoria = _mapper.Map<Categoria>(CategoriaCommand);
            var response = await _categoriaRepositorio.AddAsync(categoria);
            return _mapper.Map<CriaCategoriaCommand>(response);
        }

        public async Task<IEnumerable<CategoriaResponse>> BuscarTodos()
        {
            var listaCategorias = await _categoriaRepositorio.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoriaResponse>>(listaCategorias);
        }
    }
}
