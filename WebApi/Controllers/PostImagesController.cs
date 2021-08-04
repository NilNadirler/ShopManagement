using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Abstract;
using Core.Aspects.Autofac.FluentValidation;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostImagesController : ControllerBase
    {
        private IPostImageService _postImageService;
        public PostImagesController(IPostImageService postImageService)
        {
            _postImageService = postImageService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _postImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAllDeleted")]
        public IActionResult GetAllDeleted()
        {
            var result = _postImageService.GetAllDeleted();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [ValidationAspect(typeof(PostImageValidator))]
        [HttpPost("add")]
        public IActionResult Add([FromQuery] PostImageDto dto)
        {
            var result = _postImageService.Add(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromQuery] PostImageDto dto)
        {
            var result = _postImageService.Update(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var result = _postImageService.Delete(new PostImage() { Id=id });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("recoverById")]
        public IActionResult RecoverByID(int id)
        {
            var result = _postImageService.RecoverByID(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
