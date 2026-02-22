using System.Threading.Tasks;
using AutoMapper;
using HotelCore.Application.Interfaces;
using HotelCore.Domain.Interfaces;

namespace HotelCore.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var usuario = await _usuarioRepository.GetByUsernameAsync(username);
            if (usuario == null || !usuario.ValidarPassword(password))
                throw new Exception("Credenciales invalidas");

            return "TOKEN_TEMPORAL";
        }
    }
}