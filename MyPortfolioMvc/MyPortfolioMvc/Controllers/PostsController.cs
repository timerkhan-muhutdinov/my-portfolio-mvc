using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolioMvc.BLL.DTO.Post;
using MyPortfolioMvc.BLL.Interfaces;
using MyPortfolioMvc.Models;
using MyPortfolioMvc.Models.Post;

namespace MyPortfolioMvc.Controllers
{
    public class PostsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        // GET: Posts
        public async Task<IActionResult> Index(string postCreateDate, string searchString)
        {
            var (posts, createDates) = _postService.GetFilterPosts(postCreateDate, searchString);

            var movieGenreVM = new PostCreateDateViewModel
            {
                CreateDates = new SelectList(createDates),
                Posts = _mapper.Map<List<PostFilterViewModel>>(posts)
            };

            return View(movieGenreVM);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var post = _mapper.Map<PostInfoViewModel>(_postService.GetPost(id));

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ShortDescription,Description,Meta,UrlSlug,IsPublish,CreatedDate,PostedDate,ModifiedDate,DeletedDate,Price,Rating")] PostCreateViewModel post)
        {
            if (ModelState.IsValid)
            {
                _postService.CreatePost(_mapper.Map<PostCreateDto>(post));

                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _mapper.Map<PostInfoViewModel>(_postService.GetPost(id));
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ShortDescription,Description,Meta,UrlSlug,IsPublish,CreatedDate,PostedDate,ModifiedDate,DeletedDate,Price")] PostUpdateViewModel post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _postService.UpdatePost(_mapper.Map<PostUpdateDto>(post));
                }
                catch (DbUpdateConcurrencyException)
                {
                  return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _mapper.Map<PostInfoViewModel>(_postService.GetPost(id));

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _postService.DeletePost(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
