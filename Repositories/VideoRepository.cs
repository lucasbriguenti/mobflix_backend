using Microsoft.EntityFrameworkCore;
using Mobflix_backend.Models;
using Mobflix_backend.Models.Context;
using Mobflix_backend.Repositories.Interfaces;

namespace Mobflix_backend.Repositories;

public class VideoRepository : IVideoRepository
{
    private readonly MobflixContext _context;

    public VideoRepository(MobflixContext context)
    {
        _context = context;
    }
    
    public async Task<Video> Save(Video video)
    {
        await _context.Videos.AddAsync(video);
        await _context.SaveChangesAsync();
        return video;
    }

    public async Task<IEnumerable<Video>> GetAll()
    {
        return await _context.Videos.ToListAsync();
    }

    public async Task<Video?> GetById(int id)
    {
        return await _context.Videos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Delete(int id)
    {
        var video = await GetById(id);
        if (video is null) return;
        
        _context.Videos.Remove(video);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Video video)
    {
        _context.Videos.Update(video);
        await _context.SaveChangesAsync();
    }
}
