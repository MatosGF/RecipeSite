using Microsoft.Extensions.Logging;
using Models;
using Models.Entities;
using Models.Mappers;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly ILogger<CommentService> _logger;

        public CommentService(ICommentRepository commentRepository, ILogger<CommentService> logger)
        {
            _repository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CommentDto> AddAsync(CommentDto entityDto)
        {
            try
            {
                var entity = CommentMapper.ToEntityAdd(entityDto);
                var entitySaved = await _repository.AddAsync(entity);
                await _repository.SaveAsync();

                return CommentMapper.ToDto(entitySaved);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao registrar novo comentário");
                throw;
            }
        }

        public async Task<CommentDto> Update(CommentDto entityDto)
        {
            try
            {
                // Buscar o Comment pelo ID
                Comment entity = await _repository.GetByIdAsync(entityDto.Id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Comentário não encontrado.");
                }
                // Atualizar as informações
                entity = CommentMapper.ToEntityUpdate(entityDto, entity);

                // Salvar as alterações no repositório
                var entityUpdated = await _repository.Update(entity);
                await _repository.SaveAsync();
                return CommentMapper.ToDto(entityUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar dados.");
                throw;
            }
        }

        public async Task<CommentDto> GetById(int entityId)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(entityId);
                return CommentMapper.ToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Comentário não encontrado.");
                throw;
            }
        }

        public async Task<IEnumerable<CommentDto>> GetAll()
        {
            try
            {
                var entity = await _repository.GetAllAsync();
                return CommentMapper.ToDtos(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lista de comentários não encontrada.");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _repository.Delete(entity);
                await _repository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao tentar deletar comentário com ID {{ID}}", id);
                throw;
            }
        }

    }
}
