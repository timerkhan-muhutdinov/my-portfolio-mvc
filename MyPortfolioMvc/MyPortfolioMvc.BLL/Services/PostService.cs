using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolioMvc.BLL.DTO.Post;
using MyPortfolioMvc.BLL.Infrastructure;
using MyPortfolioMvc.BLL.Interfaces;
using MyPortfolioMvc.DAL;
using MyPortfolioMvc.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPortfolioMvc.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly PortfolioContext _context;

        public PostService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public (IEnumerable<FilterPostDto>, IEnumerable<string> ) GetFilterPosts(string postCreateDate, string searchString)
        {
            IQueryable<DateTime> dateQuery = from m in _context.Post
                                             orderby m.CreatedDate
                                             select m.CreatedDate;

            var posts = from m in _context.Post
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(postCreateDate))
            {
                posts = posts.Where(x => x.CreatedDate.Date == DateTime.Parse(postCreateDate).Date);
            }

            return (_mapper.Map<List<FilterPostDto>>(posts.ToList()), dateQuery.Select(s => s.Date.ToString("dd/MM/yyyy")).Distinct().ToList());
        }

        public void CreatePost(PostCreateDto postCreateDto)
        {
            var post = _mapper.Map<Post>(postCreateDto);
            _context.Add(post);
            _context.SaveChanges();
        }

        public void UpdatePost(PostUpdateDto postUpdateDto)
        {
            var post = _context.Post.FirstOrDefault(p => p.Id == postUpdateDto.Id);

            _mapper.Map(postUpdateDto, post);

            _context.Update(post);
            _context.SaveChanges();
        }

        public FetchPostDto GetPost(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id поста", "");

            var post = _context.Post.FirstOrDefault(p => p.Id == id);
            if (post == null)
                throw new ValidationException("Пост не найден", "");

            return _mapper.Map<FetchPostDto>(post);
        }

        public void DeletePost(int id)
        {
            var post = _context.Post.FirstOrDefault(p => p.Id == id);
            if (post == null)
                throw new ValidationException("Пост не найден", "");
            _context.Post.Remove(post);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
