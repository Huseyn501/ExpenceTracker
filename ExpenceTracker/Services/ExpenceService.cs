using ExpenceTracker.Data;
using ExpenceTracker.DTOs.ExpenceDTOs;
using ExpenceTracker.Entities;
using ExpenceTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenceTracker.Services
{
    public class ExpenceService : IExpenceService
    {
        private readonly AppDbContext _context;

        public ExpenceService(AppDbContext Context)
        {
            _context = Context;
        }

        public async Task<ExpenceResponseDTO> CreateExpenceAsync(CreateExpenceDTO createExpenceDTO, string userId)
        {
            Expence expence = new Expence()
            {
                Title = createExpenceDTO.Title,
               
                Price = createExpenceDTO.Price,
                dateTime = createExpenceDTO.dateTime,
                CategoryId = createExpenceDTO.CategoryId,
                UserId = userId
            };

            await _context.Expences.AddAsync(expence);
            await _context.SaveChangesAsync();

            return new ExpenceResponseDTO()
            {
                Id = expence.Id,
                Title = expence.Title,
                Price = expence.Price,
                dateTime = expence.dateTime,
                UserId = expence.UserId,
                CategoryId = expence.CategoryId
            };
        }

        public async Task<List<ExpenceResponseDTO>> GetAllExpencesAsync(string userId)
        {
            var expences = await _context.Expences
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return expences.Select(x => new ExpenceResponseDTO
            {
                Id = x.Id,
                Title = x.Title,
                Price = x.Price,
                dateTime = x.dateTime,
                UserId = x.UserId,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public async Task<ExpenceResponseDTO> GetExpenceByIdAsync(int ExpenceId, string userId)
        {
            var expence = await _context.Expences
                .FirstOrDefaultAsync(x => x.Id == ExpenceId && x.UserId == userId);

            if (expence == null)
            {
                throw new KeyNotFoundException("Expense not found or you do not have permission to access it.");
            }

            return new ExpenceResponseDTO
            {
                Id = expence.Id,
                Title = expence.Title,
                Price = expence.Price,
                dateTime = expence.dateTime,
                UserId = expence.UserId,
                CategoryId = expence.CategoryId
            };
        }

        public async Task<bool> UpdateExpenceAsync(UpdateExpenceDTO updateExpenceDTO, string userId, int expenceId)
        {
            var expence = await _context.Expences
                .FirstOrDefaultAsync(x => x.Id == expenceId && x.UserId == userId);

            if (expence == null)
            {
                throw new KeyNotFoundException("Expense not found or you do not have permission to access it.");
            }

            expence.Title = updateExpenceDTO.Title;
            expence.Price = updateExpenceDTO.Price;
            expence.CategoryId = updateExpenceDTO.CategoryId;
            expence.dateTime = updateExpenceDTO.dateTime;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteExpenceAsync(int expenceId, string userId)
        {
            var expence = await _context.Expences
                .FirstOrDefaultAsync(x => x.Id == expenceId && x.UserId == userId);

            if (expence == null)
            {
                throw new KeyNotFoundException("Expense not found or you do not have permission to access it.");
            }

            _context.Expences.Remove(expence);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}