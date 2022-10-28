using Microsoft.AspNetCore.Mvc;
using Mobflix_backend.Dtos.Video;
using Mobflix_backend.Models;
using Mobflix_backend.Repositories.Interfaces;

namespace Mobflix_backend.Controllers;

[Route("[controller]")]
[ApiController]
public class VideoController : ControllerBase
{
    private readonly IVideoRepository _videoRepository;

    public VideoController(IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var videos = await _videoRepository.GetAll();
        return Ok(videos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var video = await _videoRepository.GetById(id);
        return video is null ? NotFound() : Ok(video);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] VideoUpdateDto dto)
    {
        var video = await _videoRepository.GetById(dto.Id);
        if (video is null) return NotFound();

        video.Titulo = dto.Titulo;
        video.Descricao = dto.Descricao;
        video.Url = dto.Url;

        await _videoRepository.Update(video);
        return Ok(dto);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _videoRepository.Delete(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VideoInsertDto dto)
    {
        var video = new Video(dto.Titulo, dto.Descricao, dto.Url);
        await _videoRepository.Save(video);
        return Created("", video.Id);
    }
}
